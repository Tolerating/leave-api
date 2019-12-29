using BLL;
using DAL;
using leaveAPI.Content;
using leaveAPI.Filters;
using leaveAPI.Models;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace leaveAPI.Controllers
{
    [ControllerGroup("教师审核")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class TeacherAuditController : ApiController
    {
        #region 请假审核
        /// <summary>
        /// 查询请假信息数据表
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult selectLeaveRecord(string post,string classNum,string collegeNum)
        {
            
            JArray Leave = null;
            if (post == "班主任")
            {
                Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordClassNum ='" + classNum + "' and LeaveRecordStage='1'") as List<LeaveRecord>));//根据班级编号和状态查询
            }
            else if (post == "辅导员")
            {
                Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordClassNum like'" + classNum.Substring(0, 4) + "___' and LeaveRecordStage='2'") as List<LeaveRecord>));//根据班级编号和状态查询
            }
            else if (post == "院领导")
            {
                Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordClassNum like'" + collegeNum + "_____' and LeaveRecordStage='3'") as List<LeaveRecord>));//根据班级编号和状态查询
            }
            else if (post == "校领导")
            {
                Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition("WHERE LeaveRecordStage='4'") as List<LeaveRecord>));//根据班级编号和状态查询
            }
            string strJson = "";
            strJson = "[";
            foreach (JToken item in Leave)
            {
                if (post == "班主任")
                {
                    item["LeaveRecordApprover"] = "暂无";
                }

                if (item["LeaveRecordCategory"].ToString() == "1")
                    item["LeaveRecordCategory"] = "上课请假";
                else if (item["LeaveRecordCategory"].ToString() == "2")
                    item["LeaveRecordCategory"] = "不留宿请假";
                else if (item["LeaveRecordCategory"].ToString() == "3")
                    item["LeaveRecordCategory"] = "早自习请假";
                else if (item["LeaveRecordCategory"].ToString() == "4")
                    item["LeaveRecordCategory"] = "周末请假";

                Students stus = StudentsBLL.SelectStuPhone(item["LeaveRecordStudentID"].ToString());
                Class cls1 = ClassBLL.getClassInfo(stus.StudentClassID);
                strJson += "{\"LeaveRecordID\":\"" + item["LeaveRecordID"].ToString() + "\",\"StudentName\":\"" + stus.StudentName.ToString()
                    + "\",\"StudentTel\":\"" + stus.StudentTel.ToString() + "\",\"StudentNum\":\""
                    + stus.StudentNum.ToString() + "\",\"StudentBedroomNum\":\"" + stus.StudentBedroomNum.ToString()
                    + "\",\"LeaveRecordReason\":\"" + item["LeaveRecordReason"].ToString() + "\",\"LeaveRecordStartTime\":\""
                    + item["LeaveRecordStartTime"].ToString() + "\",\"LeaveRecordEndtTime\":\"" + item["LeaveRecordEndtTime"].ToString()
                    + "\",\"LeaveRecordStartLesson\":\"" + item["LeaveRecordStartLesson"].ToString() + "\",\"LeaveRecordEndLesson\":\"" + item["LeaveRecordEndLesson"].ToString()
                    + "\",\"LeaveRecordNumDays\":\"" + item["LeaveRecordNumDays"].ToString() + "\",\"LeaveRecordApprover\":\"" + item["LeaveRecordApprover"].ToString()
                    + "\",\"LeaveRecordStage\":\"" + item["LeaveRecordStage"].ToString() + "\",\"LeaveRecordApprovalResult\":\"" + item["LeaveRecordApprovalResult"].ToString()
                    + "\",\"LeaveRecordApprovalTime\":\"" + item["LeaveRecordApprovalTime"].ToString() + "\",\"LeaveRecordSumLesson\":\"" + item["LeaveRecordSumLesson"].ToString()
                    + "\",\"LeaveRecordCategory\":\"" + item["LeaveRecordCategory"].ToString()
                    + "\",\"LeaveRecordClassName\":\"" + cls1.ClassName.ToString() + "\",\"StudentTel\":\"" + stus.StudentTel
                    + "\"},";
            }
            if (strJson != "[")
            {
                strJson = strJson.Substring(0, strJson.Length - 1);
                strJson += "]";
            }
            else
            {
                strJson = "[]";
            }

            return Json<dynamic>(new
            {
                success = true,
                result = 0,
                item = strJson.ToString()
            });


        }

        /// <summary>
        /// 通过请假信息数据表
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult updateLeaveRecord(string leaveID,string specTeacherID,string SpecialityID)
        {
            HttpRequest request = HttpContext.Current.Request;
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            string sql = string.Format("select * from [LeaveRecord] WHERE LeaveRecordID={0}", leaveID);
            Teachers teaInfo = TeachersBLL.SelectByTeacherID(Convert.ToInt32(teaID));
            LeaveRecord lea = LeaveRecordBLL.SelectBySql(sql);
            string content = "";
            int stuSMS = 0;
            int teaSMS = 0;
            Students stus = StudentsBLL.getStuInfo(lea.LeaveRecordStudentID.ToString()); //获取请假学生的信息
            Teachers tea = new Teachers();
            int Num = lea.LeaveRecordNumDays;
            if (lea.LeaveRecordCategory == "2" && Num == 1)
            {
                Num = 2;
            }
            if (Num == 1)
            {
                lea.LeaveRecordStage = 0;
                lea.LeaveRecordApprovalResult = "通过";
                lea.LeaveRecordApprovalTime = DateTime.Now.ToString();
            }
            else if (Num > 1 && Num <= 3)//辅导员级别
            {
                if (lea.LeaveRecordStage == 2)
                {
                    lea.LeaveRecordStage = 0;
                    lea.LeaveRecordApprovalResult = "通过";
                    lea.LeaveRecordApprovalTime = DateTime.Now.ToString();
                }

                else
                {
                    lea.LeaveRecordStage += 1;
                }

            }
            else if (Num > 3 && Num <= 30)//院领导级别
            {
                if (lea.LeaveRecordStage == 3)
                {
                    lea.LeaveRecordStage = 0;
                    lea.LeaveRecordApprovalResult = "通过";
                    lea.LeaveRecordApprovalTime = DateTime.Now.ToString();
                }
                else
                {
                    lea.LeaveRecordStage += 1;
                }

            }
            else if (Num > 30)//校院领导级别
            {
                if (lea.LeaveRecordStage == 4)
                {
                    lea.LeaveRecordStage = 0;
                    lea.LeaveRecordApprovalResult = "通过";
                    lea.LeaveRecordApprovalTime = DateTime.Now.ToString();
                }
                else
                {
                    lea.LeaveRecordStage += 1;
                }

            }
            if (lea.LeaveRecordStage == 0)
            {

                if (lea.LeaveRecordCategory == "1")
                {
                    content = "&smsMob=" + stus.StudentTel + "&smsText=亲爱的" + stus.StudentName + "同学你好,你的：上课请假：因'" + lea.LeaveRecordReason + " '事由，需请假'" + lea.LeaveRecordSumLesson + "'节课,请假时间：'" + lea.LeaveRecordStartTime + ",到" + lea.LeaveRecordEndtTime + "'止，请假已通过审核。【请假通】";
                }
                else if (lea.LeaveRecordCategory == "2")
                {
                    content = "&smsMob=" + stus.StudentTel + "&smsText=亲爱的" + stus.StudentName + "同学你好你的:不留宿请假：因_" + lea.LeaveRecordReason + "_事由，需请假(" + lea.LeaveRecordNumDays + ")天不留宿住校,请假时间：" + lea.LeaveRecordStartTime + ",到" + lea.LeaveRecordEndtTime + "'止。请假已通过审核。【请假通】";
                }
                else if (lea.LeaveRecordCategory == "3")
                {
                    content = "&smsMob=" + stus.StudentTel + "&smsText=亲爱的" + stus.StudentName + "同学你好你的:早自习请假：因_" + lea.LeaveRecordReason + "_事由，需请假(" + lea.LeaveRecordNumDays + ")天早自习,请假时间：" + lea.LeaveRecordStartTime + ",到" + lea.LeaveRecordEndtTime + "'止。请假已通过审核。【请假通】";
                }

                stuSMS = sendSMS(content);
            }
            else if (lea.LeaveRecordStage == 2)
            {
                //string headTeacherID = request.Cookies["LEAVEAPP"]["ClassSpecialityTeacherID"];
                tea = TeachersBLL.SelectTeaPhone(specTeacherID);//辅导员级别准备发送信息的教师的信息
            }
            else if (lea.LeaveRecordStage == 3)
            {
                //string ClassSpecialityID = request.Cookies["LEAVEAPP"]["ClassSpecialityID"];
                College col = CollegeBLL.SelectALLbyCollegeNum(SpecialityID);
                tea = TeachersBLL.SelectTeaPhone(col.TeacherNum);//院长级别准备发送信息的教师的信息
            }
            else if (lea.LeaveRecordStage == 4)
            {
                tea = TeachersBLL.getInfobyPost("校领导");
            }

            if (lea.LeaveRecordStage != 0)
            {
                if (lea.LeaveRecordCategory == "1")
                    teaSMS = compStuContent(lea.LeaveRecordCategory, tea.TeacherTel, tea.TeacherName, stus.StudentName, lea.LeaveRecordStudentID, lea.LeaveRecordReason, lea.LeaveRecordSumLesson, lea.LeaveRecordStartTime, lea.LeaveRecordStartLesson, lea.LeaveRecordEndtTime, lea.LeaveRecordEndLesson, lea.LeaveRecordNumDays);
                else if (lea.LeaveRecordCategory == "2")
                    teaSMS = compStuContent(lea.LeaveRecordCategory, tea.TeacherTel, tea.TeacherName, stus.StudentName, lea.LeaveRecordStudentID, lea.LeaveRecordReason, 0, lea.LeaveRecordStartTime, 0, lea.LeaveRecordEndtTime, 0, lea.LeaveRecordNumDays);
                else if (lea.LeaveRecordCategory == "3")
                    teaSMS = compStuContent(lea.LeaveRecordCategory, tea.TeacherTel, tea.TeacherName, stus.StudentName, lea.LeaveRecordStudentID, lea.LeaveRecordReason, 0, lea.LeaveRecordStartTime, 0, lea.LeaveRecordEndtTime, 0, lea.LeaveRecordNumDays);
                else
                    teaSMS = compStuContent(lea.LeaveRecordCategory, tea.TeacherTel, tea.TeacherName, stus.StudentName, lea.LeaveRecordStudentID, lea.LeaveRecordReason, 0, lea.LeaveRecordStartTime, 0, lea.LeaveRecordEndtTime, 0, lea.LeaveRecordNumDays);

            }
            lea.LeaveRecordApprover = teaInfo.TeacherName;
            lea.LeaveRecordClassNum = stus.StudentClassID;
            if (teaSMS > 0 || stuSMS > 0)
            {
                int res = LeaveRecordBLL.Update(lea);
                if (res > 0)
                {
                    return Json<dynamic>(new
                    {
                        success = true,
                        result = 0,
                        message = "success"
                    });
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "更新数据库失败"
                    });
                }
            }
            else
            {
                return Json<dynamic>(new
                {
                    success = false,
                    result = -2,
                    message = "短信发送失败，数据库未更新"
                }); ;
            }
        }

        /// <summary>
        /// 不通过请假信息
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult Notthrough(string leaveID)
        {
            HttpRequest request = HttpContext.Current.Request;
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            string sql = string.Format("select * from [LeaveRecord] WHERE LeaveRecordID={0}", leaveID);
            LeaveRecord lea = LeaveRecordBLL.SelectBySql(sql);
            Teachers teanow = TeachersBLL.SelectTeaPhone(teaID);
            Students stus = StudentsBLL.getStuInfo(lea.LeaveRecordStudentID.ToString());
            lea.LeaveRecordClassNum = stus.StudentClassID;
            lea.LeaveRecordStage = -1;
            lea.LeaveRecordApprovalResult = "不通过";
            lea.LeaveRecordApprovalTime = DateTime.Now.ToString();
            lea.LeaveRecordApprover += "" + teanow.TeacherName + "(不通过),";
            string content = "&smsMob=" + stus.StudentTel + "&smsText=亲爱的" + stus.StudentName + "同学，你的请假申请在" + teanow.Post + "" + teanow.TeacherName + "老师处审核不通过，详细信息请联系" + teanow.TeacherTel + "。【请假通】";
            if (sendSMS(content) > 0)
            {
                int res = LeaveRecordBLL.Update(lea);
                if (res > 0)
                {
                    return Json<dynamic>(new
                    {
                        success = true,
                        result = 0,
                        message = "success"
                    });
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "更新数据库失败"
                    });
                }

            }
            else
            {
                return Json<dynamic>(new
                {
                    success = false,
                    result = -2,
                    message = "短信发送失败，数据库未更新"
                });
            }

        }

        #endregion


        #region 本周周末审核


        /// <summary>
        /// 查询周末学生在校和离校情况;
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult WeekDayNow(string start, string end,string classNum,string post)
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            Class cla = ClassBLL.SelectByClassNum(classNum);
            string strJson = "";
            strJson = "[";
            if (post == "班主任")
            {
                string sql = string.Format("where LeaveRecordClassNum={0} and (WeekDaysStartTime BETWEEN '{1}' AND '{2}') and WeekDaysApprovalResult='未审核' or WeekDaysApprovalResult='辅导员审核'", classNum, start, end);
                IList<WeekDays> weekdays = WeekDaysBLL.SelectAllByCondition(sql);
                if (weekdays.Count == 0)
                {
                    return Json<dynamic>(new
                    {
                        success = true,
                        result = 0,
                        item = "[]"
                    });
                }
                else
                {
                    foreach (WeekDays wee in weekdays)
                    {
                        Students Stu = StudentsBLL.getStuInfo(wee.WeekDaysStudentID.ToString());
                        string one = "", two = "";
                        if (wee.WeekDaysStartTime == start + " 0:00:00")
                        {
                            one = "离校";
                        }
                        else
                        {
                            one = "在校";
                        }

                        if (wee.WeekDaysEndtTime == end + " 0:00:00")
                        {
                            two = "离校";
                        }
                        else
                        {
                            two = "在校";
                        }
                        strJson += "{\"StudentID\":\"" + Stu.StudentNum.ToString() + "\",\"WeekDaysID\":\"" + wee.WeekDaysID + "\",\"StudentName\":\""
                        + Stu.StudentName + "\",\"ClassName\":\"" + cla.ClassName + "\",\"WeekDaysApprovalResult\":\"" + wee.WeekDaysApprovalResult + "\",\"Saturdayn\":\"" + two + "\",\"Fridayn\":\"" + one + "\",\"Tel\":\"" + Stu.StudentTel + "\"},";

                    }
                }
            }
            else if (post == "辅导员")
            {
                IList<Class> classones = ClassBLL.SelectAllByClassSpecialityID(Convert.ToInt32(teaID));
                foreach (Class claone in classones)
                {
                    string sql = string.Format("where LeaveRecordClassNum={0} and (WeekDaysStartTime BETWEEN '{1}' AND '{2}') and WeekDaysApprovalResult='未审核' or WeekDaysApprovalResult='班主任审核'", claone.ClassNum, start, end);
                    IList<WeekDays> weekdays = WeekDaysBLL.SelectAllByCondition(sql);
                    if (weekdays.Count == 0)
                    {
                        return Json<dynamic>(new
                        {
                            success = true,
                            result = 0,
                            item = "[]"
                        });
                    }
                    else
                    {
                        foreach (WeekDays wee in weekdays)
                        {
                            Students Stu = StudentsBLL.getStuInfo(wee.WeekDaysStudentID.ToString());
                            string one = "", two = "";
                            if (wee.WeekDaysStartTime == start + " 0:00:00")
                            {
                                one = "离校";
                            }
                            else
                            {
                                one = "在校";
                            }

                            if (wee.WeekDaysEndtTime == end + " 0:00:00")
                            {
                                two = "离校";
                            }
                            else
                            {
                                two = "在校";
                            }
                            strJson += "{\"StudentID\":\"" + Stu.StudentNum.ToString() + "\",\"WeekDaysID\":\"" + wee.WeekDaysID + "\",\"StudentName\":\""
                            + Stu.StudentName + "\",\"ClassName\":\"" + cla.ClassName + "\",\"WeekDaysApprovalResult\":\"" + wee.WeekDaysApprovalResult + "\",\"Saturdayn\":\"" + two + "\",\"Fridayn\":\"" + one + "\",\"Tel\":\"" + Stu.StudentTel + "\"},";
                            // continue;
                        }
                    }
                }
            }
            if (strJson != "[")
            {
                strJson = strJson.Substring(0, strJson.Length - 1);
                strJson += "]";
            }
            else
            {
                strJson = "[]";
            }
            return Json<dynamic>(new
            {
                success = true,
                result = 0,
                item = strJson
            });

        }




        /// <summary>
        /// 查询学生是否周末请假
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        private DataTable Lr(string Student, string start, string end)
        {
            string sql = "select * from WeekDays where WeekDaysStudentID=" + Student + " and (WeekDaysStartTime BETWEEN '" + start + "' AND ' " + end + " ' )  ";
            DataTable table = tool.Select(sql);
            return table;
        }

        private DataTable Lw(string clas, string start, string end)
        {
            string sql = "select * from WeekDays where LeaveRecordClassNum='" + clas + "' and (WeekDaysStartTime BETWEEN '" + start + "' AND ' " + end + " ' )  ";
            DataTable table = tool.Select(sql);
            return table;
        }


        /// <summary>
        /// 教师(班主任，辅导员)周末审核
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult TeacherAppr(string start, string end,string classNum,string post)
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            if (post == "班主任")
            {
                DataTable dt = Lw(classNum, start, end);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        WeekDays wd = new WeekDays();
                        wd.WeekDaysID = Convert.ToInt32(dt.Rows[i]["WeekDaysID"]);
                        wd.WeekDaysStudentID = Convert.ToInt32(dt.Rows[i]["WeekDaysStudentID"]);
                        wd.WeekDaysStartTime = dt.Rows[i]["WeekDaysStartTime"].ToString();
                        wd.WeekDaysEndtTime = dt.Rows[i]["WeekDaysEndtTime"].ToString();
                        wd.WeekDaysNumDays = dt.Rows[i]["WeekDaysNumDays"].ToString();
                        wd.WeekDaysApprover = dt.Rows[i]["WeekDaysApprover"].ToString();
                        if (dt.Rows[i]["WeekDaysApprovalTime"].ToString() == "")
                        {
                            wd.WeekDaysApprovalTime = "1900/01/01";
                        }
                        else
                        {
                            wd.WeekDaysApprovalTime = dt.Rows[i]["WeekDaysApprovalTime"].ToString();
                        }
                        wd.LeaveRecordClassNum = dt.Rows[i]["LeaveRecordClassNum"].ToString();
                        if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "未审核")
                        {
                            wd.WeekDaysApprovalResult = "班主任审核";
                        }
                        else if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "班主任审核")
                        {
                            continue;
                        }
                        else if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "辅导员审核")
                        {
                            wd.WeekDaysApprovalResult = "审核通过";
                        }
                        else
                        {
                            ;
                        }
                        if (dt.Rows[i]["WeekDaysStage"].ToString() == "1") { wd.WeekDaysStage = "01"; }
                        else if (dt.Rows[i]["WeekDaysStage"].ToString() == "10") { wd.WeekDaysStage = "11"; }
                        else
                        {
                            continue;
                        }
                        WeekDaysBLL.Update(wd);
                    }
                }
            }
            else if (post == "辅导员")
            {
                IList<Class> classones = ClassBLL.SelectAllByClassSpecialityID(Convert.ToInt32(teaID));
                foreach (Class grade in classones)
                {
                    DataTable dt = Lw(classNum.ToString(), start, end);
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            WeekDays wd = new WeekDays();
                            wd.WeekDaysID = Convert.ToInt32(dt.Rows[i]["WeekDaysID"]);
                            wd.WeekDaysStudentID = Convert.ToInt32(dt.Rows[i]["WeekDaysStudentID"]);
                            wd.WeekDaysStartTime = dt.Rows[i]["WeekDaysStartTime"].ToString();
                            wd.WeekDaysEndtTime = dt.Rows[i]["WeekDaysEndtTime"].ToString();
                            wd.WeekDaysNumDays = dt.Rows[i]["WeekDaysNumDays"].ToString();
                            wd.WeekDaysApprover = dt.Rows[i]["WeekDaysApprover"].ToString();
                            if (dt.Rows[i]["WeekDaysApprovalTime"].ToString() == "")
                            {
                                wd.WeekDaysApprovalTime = "1900/01/01";
                            }
                            else
                            {
                                wd.WeekDaysApprovalTime = dt.Rows[i]["WeekDaysApprovalTime"].ToString();
                            }
                            wd.LeaveRecordClassNum = dt.Rows[i]["LeaveRecordClassNum"].ToString();
                            if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "未审核")
                            {
                                wd.WeekDaysApprovalResult = "辅导员审核";
                            }
                            else if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "辅导员审核")
                            {
                                continue;
                            }
                            else if (dt.Rows[i]["WeekDaysApprovalResult"].ToString() == "班主任审核")
                            {
                                wd.WeekDaysApprovalResult = "审核通过";
                            }
                            else
                            {
                                ;
                            }
                            if (dt.Rows[i]["WeekDaysStage"].ToString() == "1") { wd.WeekDaysStage = "10"; }
                            else if (dt.Rows[i]["WeekDaysStage"].ToString() == "01") { wd.WeekDaysStage = "11"; }
                            else
                            {
                                continue;
                            }
                            WeekDaysBLL.Update(wd);
                        }
                    }
                }
            }
            return Json<dynamic>(new
            {
                success = true,
                result = 0,
                message = "success"
            });



        }

        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public IHttpActionResult getTeacherInfo()
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            Teachers tea = TeachersBLL.SelectByTeacherNum(teaID);
            string strJson = "";
            if (tea != null)
            {
                strJson = "{\"TeacherNum\":\"" + tea.TeacherNum + "\",\"TeacherName\":\"" + tea.TeacherName + "\",\"Post\":\"" + tea.Post + "\",\"TeacherTel\":\"" + tea.TeacherTel + "\"}";
            }
            else
            {
                strJson = "{}";
            }
            return Json<dynamic>(new
            {
                success = true,
                result = 0,
                item = strJson
            });
        }

        #endregion    
        

        #region 学院、专业、班级信息获取

        /// <summary>
        /// 获取College表CollegeNum,CollegeName的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string getCollegesm()
        {
            string college = Tool.DataTableToJson(CollegeBLL.getCollege());
            return college;
        }

        /// <summary>
        /// 获取Specialty表SpecialtyName,SpecialtyCollegeID,SpecialtyNum的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string getSpecialtysm()
        {
            string specialty = Tool.DataTableToJson(SpecialtyBLL.getSpecialtysm());
            return specialty;
        }

        /// <summary>
        /// 获取全部的班级ID和班级名字
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string getClassNum()
        {
            DataTable dt = ClassBLL.getClassID();
            return Tool.DataTableToJson(dt);
        }
        #endregion

        

        /// <summary>
        /// 更新教师密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [TokenCheck]
        public IHttpActionResult updatePwd([FromBody]JObject obj)
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            string pwd = Tool.MD5ToString(obj["pwd"].ToString());
            if (AdminInfoBLL.updatePwd(Convert.ToInt32(teaID), pwd) > 0 && TeachersBLL.updateTeaPwdbyAdmin(Convert.ToInt32(teaID)) > 0)
            {
                return Json<dynamic>(new
                {
                    success = true,
                    result = 0,
                    message = "success"
                });
            }
            else
            {
                return Json<dynamic>(new
                {
                    success = false,
                    result = -1,
                    message = "密码更新失败"
                });
            }
        }

        /// <summary>
        /// 生成短信信息
        /// </summary>
        /// <returns></returns>
        private int compStuContent(string RecordCategory, string TeacherTel, string TeacherName, string StudentName, int StudentNum, string LeaveRecordReason, int LeaveRecordSumLesson, string LeaveRecordStartTime, int LeaveRecordStartLesson, string LeaveRecordEndtTime, int LeaveRecordEndLesson, int LeaveRecordNumDays)
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
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        private int sendSMS(string contents)
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
    }
}