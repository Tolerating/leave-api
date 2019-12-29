using BLL;
using leaveAPI.Filters;
using leaveAPI.Models;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace leaveAPI.Controllers
{
    [ControllerGroup("学生请假")]
    //[EnableCors(origins: "http://118.25.137.129:8282", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class StudentLeaveController : ApiController
    {
        #region 学生请假/个人信息

        /// <summary>
        /// 获取学生信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string GetStudentInfo()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            Students stu = StudentsBLL.getStuInfo(StudentID);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(stu); 

        }


        /// <summary>
        /// 获取班级信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string getClassInfo(string classNum)
        {
            Class cla = ClassBLL.getClassInfo(classNum);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Serialize(cla);
        }

        /// <summary>
        /// 获取班主任电话
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string headTeacherTel(string teacherId)
        {
            Teachers tea = TeachersBLL.SelectByTeacherNum(teacherId);
            if (tea.TeacherTel != "")
            {
                return tea.TeacherTel;
            }
            else
            {
                return "暂无教师电话";
            }
        }

        /// <summary>
        /// 更新学生的电话号码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public int updateStuTel(string StuTel, string StuNum)
        {
            if (StudentsBLL.updateStuTel(StuTel, StuNum) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// 更新学生密码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public int updateStuPwd(string StuNum, string StuPwd)
        {            
            string pwd = MD5ToString(StuPwd);

            if (AdminInfoBLL.updatePwd(Convert.ToInt32(StuNum), pwd) > 0)
            {
                if (StudentsBLL.updateStuPwd(pwd, Convert.ToInt32(StuNum)) > 0)
                {
                    return 1;
                }
            }
            return -1;
        }

        #endregion

        #region 请假记录相关

        /// <summary>
        /// 待审核请假
        /// </summary>
        /// <param name="StudentID">学生ID</param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string selectAudit()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<LeaveRecord> lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordApprovalResult='未审核';");
            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    if (leave.LeaveRecordCategory == "1")
                    {
                        result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"title\":\"上课请假\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\"},";
                    }
                    else if (leave.LeaveRecordCategory == "2")
                    {
                        result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"title\":\"不留宿请假\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\"},";
                    }
                    else if (leave.LeaveRecordCategory == "3")
                    {
                        result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"title\":\"早自习请假\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\"},";
                    }
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }

        /// <summary>
        /// 获取待审核请假条数
        /// </summary>
        /// <param name="StudentID"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public int getAuitNum()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            int num = LeaveRecordBLL.SelectCountByCondition("LeaveRecordStudentID='" + StudentID + "' and  LeaveRecordApprovalResult='未审核'");
            return num;
        }

        /// <summary>
        /// 获取各请假数目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string selectLeaveCount()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            int lessonNum = LeaveRecordBLL.SelectCountByCondition("LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='1'");
            int notSleep = LeaveRecordBLL.SelectCountByCondition("LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='2'");
            int zaozixi = LeaveRecordBLL.SelectCountByCondition("LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='3'");
            int weekdays = WeekDaysBLL.SelectCountByCondition("WeekDaysStudentID='" + StudentID + "'");
            int ad = AdvanceDelayBLL.SelectCountByCondition("StudentNum='" + StudentID + "'");
            return "{\"lessonNum\":\"" + lessonNum + "\",\"notSleepLeave\":\"" + notSleep + "\",\"zaozixi\":\"" + zaozixi + "\",\"weekdays\":\"" + weekdays + "\",\"ad\":\"" + ad + "\"}";
        }

        /// <summary>
        /// 上课请假记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string lessonLeaveRecord()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<LeaveRecord> lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='1';");
            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"lessonNum\":\"" + leave.LeaveRecordSumLesson + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
            }
            return result;
        }

        /// <summary>
        /// 通过时间检索上课请假记录
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string retrievalLesson(string StudentID, string stime, string etime, string leaveResult)
        {
            string result = "[";
            IList<LeaveRecord> lea;
            if (stime == null && etime == null)
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='1';");
            }
            else
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "'and LeaveRecordApprovalResult = '" + leaveResult + "' and LeaveRecordCategory='1' and (LeaveRecordStartTime between '" + stime + "' and '" + etime + "') and (LeaveRecordEndtTime between '" + stime + "' and '" + etime + "');");
            }

            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"lessonNum\":\"" + leave.LeaveRecordSumLesson + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }

        /// <summary>
        /// 不留宿请假记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string notSleepRecord()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<LeaveRecord> lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='2';");
            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
            }
            return result;
        }

        /// <summary>
        /// 通过时间检索不留宿请假记录
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string retrievalNotSleep(string StudentID, string stime, string etime, string leaveResult)
        {
            string result = "[";
            IList<LeaveRecord> lea;
            if (stime == null && etime == null)
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='2';");
            }
            else
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordApprovalResult='" + leaveResult + "' and LeaveRecordCategory='2' and (LeaveRecordStartTime between '" + stime + "' and '" + etime + "') and (LeaveRecordEndtTime between '" + stime + "' and '" + etime + "');");
            }

            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }

        /// <summary>
        /// 早自习请假记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string zaozixiRecord()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<LeaveRecord> lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='3';");
            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
            }
            return result;
        }

        /// <summary>
        /// 通过时间检索早自习请假记录
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string retrievalZZX(string StudentID, string stime, string etime, string leaveResult)
        {
            string result = "[";
            IList<LeaveRecord> lea;
            if (stime == null && etime == null)
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordCategory='3';");
            }
            else
            {
                lea = LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStudentID='" + StudentID + "' and LeaveRecordApprovalResult='" + leaveResult + "' and LeaveRecordCategory='3' and (LeaveRecordStartTime between '" + stime + "' and '" + etime + "') and (LeaveRecordEndtTime between '" + stime + "' and '" + etime + "');");
            }

            if (lea != null)
            {
                foreach (LeaveRecord leave in lea)
                {
                    result += "{\"id\":\"" + leave.LeaveRecordID + "\",\"sTime\":\"" + leave.LeaveRecordStartTime + "\",\"eTime\":\"" + leave.LeaveRecordEndtTime + "\",\"time\":\"" + leave.LeaveRecordApprovalTime + "\",\"reason\":\"" + leave.LeaveRecordReason + "\",\"status\":\"" + leave.LeaveRecordApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }


        /// <summary>
        /// 周末请假记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string weekdaysRecord()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<WeekDays> week = WeekDaysBLL.SelectAllByCondition("WHERE WeekDaysStudentID='" + StudentID + "'");
            if (week != null)
            {
                foreach (WeekDays wk in week)
                {
                    result += "{\"id\":\"" + wk.WeekDaysID + "\",\"sTime\":\"" + wk.WeekDaysStartTime + "\",\"eTime\":\"" + wk.WeekDaysEndtTime + "\",\"time\":\"" + wk.WeekDaysApprovalTime + "\",\"reason\":\"" + wk.WeekDaysReason + "\",\"status\":\"" + wk.WeekDaysApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
            }
            return result;
        }

        /// <summary>
        /// 通过时间检索周末请假记录
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string retrievalWeek(string StudentID, string stime, string etime, string leaveResult)
        {
            string result = "[";
            IList<WeekDays> week;
            if (stime == null && etime == null)
            {
                week = WeekDaysBLL.SelectAllByCondition("WHERE WeekDaysStudentID='" + StudentID + "';");
            }
            else
            {
                week = WeekDaysBLL.SelectAllByCondition("WHERE WeekDaysStudentID='" + StudentID + "' and WeekDaysApprovalResult='" + leaveResult + "' and (WeekDaysStartTime between '" + stime + "' and '" + etime + "') and (WeekDaysEndtTime between '" + stime + "' and '" + etime + "');");
            }

            if (week != null)
            {
                foreach (WeekDays wk in week)
                {
                    result += "{\"id\":\"" + wk.WeekDaysID + "\",\"sTime\":\"" + wk.WeekDaysStartTime + "\",\"eTime\":\"" + wk.WeekDaysEndtTime + "\",\"time\":\"" + wk.WeekDaysApprovalTime + "\",\"reason\":\"" + wk.WeekDaysReason + "\",\"status\":\"" + wk.WeekDaysApprovalResult + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }

        /// <summary>
        /// 早出晚归请假记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string advanceDelyRecord()
        {
            string StudentID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "[";
            IList<AdvanceDelay> advance = AdvanceDelayBLL.SelectAllByCondition("WHERE StudentNum='" + StudentID + "'");
            if (advance != null)
            {
                foreach (AdvanceDelay ad in advance)
                {
                    result += "{\"id\":\"" + ad.ZCWGID + "\",\"advanceTime\":\"" + ad.AdvanceStudentT + "\",\"advanceReason\":\"" + ad.AdvanceReson + "\",\"adLeaveTime\":\"" + ad.AdvanceStudentT + "\", "
                        + " \"delayTime\":\"" + ad.DelayTime + "\",\"delayReason\":\"" + ad.DeatReson + "\",\"deLeaveTime\":\"" + ad.DelayStudentT + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
            }
            return result;
        }

        /// <summary>
        /// 通过时间检索早出晚归请假记录
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="stime"></param>
        /// <param name="etime"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string retrievalAdDely(string StudentID, string stime, string etime)
        {
            string result = "[";
            IList<AdvanceDelay> advance;
            if (stime == null && etime == null)
            {
                advance = AdvanceDelayBLL.SelectAllByCondition("WHERE StudentNum='" + StudentID + "'");
            }
            else
            {
                advance = AdvanceDelayBLL.SelectAllByCondition("WHERE StudentNum='" + StudentID + "' and (AdvanceStudentT between '" + stime + "' and '" + etime + "') and (DelayStudentT between '" + stime + "' and '" + etime + "');");
            }

            if (advance != null)
            {
                foreach (AdvanceDelay ad in advance)
                {
                    result += "{\"id\":\"" + ad.ZCWGID + "\",\"advanceTime\":\"" + ad.AdvanceStudentT + "\",\"advanceReason\":\"" + ad.AdvanceReson + "\",\"adLeaveTime\":\"" + ad.AdvanceStudentT + "\", "
                        + " \"delayTime\":\"" + ad.DelayTime + "\",\"delayReason\":\"" + ad.DeatReson + "\",\"deLeaveTime\":\"" + ad.DelayStudentT + "\"},";
                }
            }
            if (result == "[")
            {
                return "[]";
            }
            else
            {
                result = result.Substring(0, result.Length - 1);
                result += "]";
                return result;
            }
        }

        #endregion

        #region 请假操作相关

        /// <summary>
        /// 添加请假记录
        /// </summary>
        /// <returns>1表示添加成功,-1表示失败</returns>
        [HttpPost]
        [TokenCheck]
        public int insertLeaveRecord([FromBody] JObject obj)
        {

            LeaveRecord lea = new LeaveRecord()
            {
                LeaveRecordStudentID = Convert.ToInt32(obj["LeaveRecordStudentID"]),
                LeaveRecordReason = obj["LeaveRecordReason"].ToString(),
                LeaveRecordStartTime = obj["LeaveRecordStartTime"].ToString(),
                LeaveRecordEndtTime = obj["LeaveRecordEndtTime"].ToString(),
                LeaveRecordStartLesson = 0,
                LeaveRecordEndLesson = 0,
                LeaveRecordCategory = obj["LeaveRecordCategory"].ToString(),
                LeaveRecordNumDays = Convert.ToInt32(obj["LeaveRecordNumDays"]),
                LeaveRecordSumLesson = Convert.ToInt32(obj["LeaveRecordNumDays"]),
                LeaveRecordClassNum = obj["LeaveRecordClassNum"].ToString(),
                LeaveRecordApprovalTime = DateTime.Now.ToString(),
                LeaveRecordApprovalResult = "未审核",
                LeaveRecordStage = 1
            };
            if (LeaveRecordBLL.Insert(lea) == 1)
            {
                string category = obj["LeaveRecordCategory"].ToString();
                Teachers teas = TeachersBLL.SelectTeaPhone(obj["TeacherID"].ToString());
                if (category == "1" && teas.TeacherID != 0)
                {
                    return compStuContent(obj["LeaveRecordCategory"].ToString(), teas.TeacherTel, teas.TeacherName, obj["StudentName"].ToString(), Convert.ToInt32(obj["LeaveRecordStudentID"].ToString()), obj["LeaveRecordReason"].ToString(), 0, obj["LeaveRecordStartTime"].ToString(), Convert.ToInt32(obj["LeaveRecordSumLesson"].ToString()), obj["LeaveRecordEndtTime"].ToString(), 0, Convert.ToInt32(obj["LeaveRecordNumDays"].ToString()));
                }
                else if (obj["LeaveRecordCategory"].ToString() == "2" && teas.TeacherID != 0)
                {
                    return compStuContent(obj["LeaveRecordCategory"].ToString(), teas.TeacherTel, teas.TeacherName, obj["StudentName"].ToString(), Convert.ToInt32(obj["LeaveRecordStudentID"].ToString()), obj["LeaveRecordReason"].ToString(), 0, obj["LeaveRecordStartTime"].ToString(), 0, obj["LeaveRecordEndtTime"].ToString(), 0, Convert.ToInt32(obj["LeaveRecordNumDays"].ToString()));
                }
                else if (obj["LeaveRecordCategory"].ToString() == "3" && teas.TeacherID != 0)
                {
                    return compStuContent(obj["LeaveRecordCategory"].ToString(), teas.TeacherTel, teas.TeacherName, obj["StudentName"].ToString(), Convert.ToInt32(obj["LeaveRecordStudentID"].ToString()), obj["LeaveRecordReason"].ToString(), 0, obj["LeaveRecordStartTime"].ToString(), 0, obj["LeaveRecordEndtTime"].ToString(), 0, Convert.ToInt32(obj["LeaveRecordNumDays"].ToString()));
                }
                //else if (obj["LeaveRecordCategory"].ToString() == "4" && teas.TeacherID != 0)
                //{
                //    return compStuContent(LeaveRecordCategory, teas.TeacherTel, teas.TeacherName, StudentName, LeaveRecordStudentID, LeaveRecordReason, 0, LeaveRecordStartTime, 0, LeaveRecordEndtTime, 0, LeaveRecordNumDays);
                //}
                return -1;
            }
            else
            {
                return -7;
            }

        }

        /// <summary>
        /// 插入+更新，早出晚归
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [TokenCheck]
        public string insertIntoAdvanceDelay([FromBody] JObject obj)
        {
            AdvanceDelay ad = new AdvanceDelay();
            DateTime time = DateTime.Now;
            int numof = 0;
            IList<AdvanceDelay> AdvanceDelay = AdvanceDelayBLL.SelectAllByStudentNum(obj["StudentID"].ToString());
            foreach (AdvanceDelay AdvanceDelayone in AdvanceDelay)
            {
                if (AdvanceDelayone.AdvanceTime.ToString("yyyy-MM-dd") == time.ToString("yyyy-MM-dd") || AdvanceDelayone.DelayTime.ToString("yyyy-MM-dd") == time.ToString("yyyy-MM-dd"))
                {
                    numof = AdvanceDelayone.ZCWGID;
                    ad.ZCWGID = numof;
                    ad.AdvanceTime = AdvanceDelayone.AdvanceTime;
                    ad.AdvanceReson = AdvanceDelayone.AdvanceReson;
                    ad.DeatReson = AdvanceDelayone.DeatReson;
                    ad.DelayTime = AdvanceDelayone.DelayTime;
                    ad.DelayStudentT = AdvanceDelayone.DelayStudentT;
                    ad.AdvanceStudentT = AdvanceDelayone.AdvanceStudentT;
                }
            }
            ad.StudentNum = obj["StudentID"].ToString();
            ad.ClassNum = obj["classID"].ToString();
            if (obj["arriveCategory"].ToString() == "晚归")
            {
                ad.DelayTime = DateTime.Now;
                ad.DeatReson = obj["DReson"].ToString();
                ad.DelayStudentT = Convert.ToDateTime(obj["WTIME"].ToString());
            }
            else if (obj["arriveCategory"].ToString() == "早出")
            {
                ad.AdvanceReson = obj["AReson"].ToString();
                ad.AdvanceTime = DateTime.Now;
                ad.AdvanceStudentT = Convert.ToDateTime(obj["ZTIME"].ToString());
            }
            //else
            //{
            //    ad.DelayTime = DateTime.Now;
            //    ad.DeatReson = obj["DReson"].ToString(); ;
            //    ad.AdvanceReson = obj["AReson"].ToString(); ;
            //    ad.AdvanceTime = DateTime.Now;
            //    ad.DelayStudentT = Convert.ToDateTime(obj["WTIME"].ToString());
            //    ad.AdvanceStudentT = Convert.ToDateTime(obj["ZTIME"].ToString());
            //}
            int numInto = 0;
            if (numof == 0)
            {
                numInto = AdvanceDelayBLL.Insert(ad);
            }
            else
            {
                numInto = AdvanceDelayBLL.Update(ad);
            }
            if (numInto > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

        /// <summary>
        /// 插入周六日请假
        /// </summary>
        /// <returns>json</returns>
        [HttpPost]
        [TokenCheck]
        public int InsertWeekDays([FromBody] JObject obj)
        {
            WeekDays week = new WeekDays()
            {
                WeekDaysStudentID = Convert.ToInt32(obj["WeekDaysStudentID"]),
                WeekDaysStartTime = obj["WeekDaysStartTime"].ToString(),
                WeekDaysEndtTime = obj["WeekDaysEndtTime"].ToString(),
                WeekDaysNumDays = obj["WeekDaysNumDays"].ToString(),
                WeekDaysReason = obj["WeekDaysReason"].ToString(),
                WeekDaysStage = "1",
                LeaveRecordClassNum = obj["LeaveRecordClassNum"].ToString(),
                WeekDaysApprovalResult = "未审核"
            };
            int result = SelectCountByCondition(obj["WeekDaysStudentID"].ToString(), obj["WeekDaysStartTime"].ToString(), obj["WeekDaysEndtTime"].ToString());
            if (result == 0)
            {
                return WeekDaysBLL.Insert(week);
            }
            else
            {
                return -1;
            }

        }

        /// <summary>
        /// 查询本周该学生是否未周六日请假
        /// </summary>
        /// <returns>json</returns>
        public int SelectCountByCondition(string stuID, string starttime, string endtime)
        {
            string sql = string.Format("WeekDaysStudentID={0} and WeekDaysStartTime='{1}'", stuID, starttime);
            string sql1 = string.Format("WeekDaysStudentID={0} and WeekDaysEndtTime='{1}'", stuID, endtime);
            int a = WeekDaysBLL.SelectCountByCondition(sql);
            int b = WeekDaysBLL.SelectCountByCondition(sql1);
            if (a == 0 && b == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }


        #endregion

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        protected int sendSMS(string contents)
        {
            string url = "http://utf8.api.smschinese.cn/?Uid=whitney&Key=d41d8cd98f00b204e980";
            string strRet = null;
            url += contents;
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(url);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.Default);
                strRet = ser.ReadToEnd();
            }
            catch
            {
                strRet = null;
            }
            return Convert.ToInt32(strRet);
        }


        /// <summary>
        /// 生成短信信息
        /// </summary>
        /// <returns></returns>
        protected int compStuContent(string RecordCategory, string TeacherTel, string TeacherName, string StudentName, int StudentNum, string LeaveRecordReason, int LeaveRecordSumLesson, string LeaveRecordStartTime, int LeaveRecordStartLesson, string LeaveRecordEndtTime, int LeaveRecordEndLesson, int LeaveRecordNumDays)
        {
            string contents;
            if (RecordCategory == "1")
            {
                contents = "&smsMob=" + TeacherTel + "&smsText=【请假通】" + TeacherName + "教师您好，您的学生" + StudentName + "(" + StudentNum + ")上课请假：因(" + LeaveRecordReason + ")事由，需请假(" + LeaveRecordSumLesson + ")节课,请假时间：" + LeaveRecordStartTime + "到" + LeaveRecordEndtTime + "止，共请假(" + LeaveRecordNumDays + ")天。请尽快予以批复。";
            }
            else if (RecordCategory == "2")
            {
                contents = "&smsMob=" + TeacherTel + "&smsText= 【请假通】" + TeacherName + "教师您好，您的学生" + StudentName + "(" + StudentNum + ")不留宿请假：因(" + LeaveRecordReason + ")事由，需请假(" + LeaveRecordNumDays + ")天不留宿住校，请予以批准,请假时间：" + LeaveRecordStartTime + "到" + LeaveRecordEndtTime + "止。 请尽快予以批复。";
            }
            else if (RecordCategory == "3")
            {
                contents = "&smsMob=" + TeacherTel + "&smsText=【请假通】" + TeacherName + "教师您好，您的学生" + StudentName + "(" + StudentNum + ")早自习请假：因(" + LeaveRecordReason + ")事由，需请假(" + LeaveRecordNumDays + ")天早自习，请予以批准,请假时间：" + LeaveRecordStartTime + "到" + LeaveRecordEndtTime + "止。 请尽快予以批复。";
            }
            else
            {
                contents = "&smsMob=" + TeacherTel + "&smsText=【请假通】" + TeacherName + "教师您好，您的学生" + StudentName + "(" + StudentNum + ")周末请假：因(" + LeaveRecordReason + ")事由，需请假周六周日(2)天，请予以批准,请假时间：" + LeaveRecordStartTime + "到" + LeaveRecordEndtTime + "止。 请尽快予以批复。";
            }
            return sendSMS(contents);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        protected static string MD5ToString(String argString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.Default.GetBytes(argString);
            byte[] result = md5.ComputeHash(data);
            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
                strReturn += result[i].ToString("x").PadLeft(2, '0');
            return strReturn;

        }
    }
}