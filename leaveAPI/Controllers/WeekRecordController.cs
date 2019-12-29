using BLL;
using leaveAPI.Filters;
using leaveAPI.Models;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace leaveAPI.Controllers
{
    [ControllerGroup("周末历史记录")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class WeekRecordController : ApiController
    {

        /// <summary>
        /// 查询周末请假情况(公寓中心与校领导权限)
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        [TokenCheck]
        public string selectWeekDays(string post)
        {
            string strJson = "[";
            string condition = "";
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            if (post == "班主任" || post == "辅导员")
            {
                Class clas = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(teaID));
                if (post == "班主任")
                {
                    condition = "WHERE LeaveRecordClassNum ='" + clas.ClassNum + "'";
                }
                else if (post == "辅导员")
                {
                    condition = "WHERE LeaveRecordClassNum like '" + clas.ClassNum.Substring(0, 4) + "'";
                }
            }
            else if (post == "院领导")
            {
                College col = CollegeBLL.SelectByTeacherNum(teaID);
                condition = "WHERE LeaveRecordClassNum like'" + col.CollegeNum.ToString() + "%' ";
            }
            else if (post == "公寓中心" || post == "校领导")
            {
                condition = "order by LeaveRecordClassNum";
            }
            JArray Leave = JArray.Parse(Helper.ObjToJson<List<WeekDays>>(WeekDaysBLL.SelectAllByCondition(condition) as List<WeekDays>));
            strJson = "[";
            foreach (JToken item in Leave)
            {
                Students stus = StudentsBLL.getStuInfo(item["WeekDaysStudentID"].ToString());
                Class cls1 = ClassBLL.checkStuAndTeaID(stus.StudentClassID);
                if (item["WeekDaysApprover"].ToString() == "")
                {
                    continue;
                }
                strJson += "{\"WeekDaysID\":\"" + item["WeekDaysID"].ToString() + "\",\"WeekDaysStudentID\":\""
                    + item["WeekDaysStudentID"].ToString() + "\",\"StudentName\":\"" + stus.StudentName.ToString()
                    + "\",\"StudentTel\":\"" + stus.StudentTel.ToString() + "\",\"StudentBedroomNum\":\"" + stus.StudentBedroomNum.ToString() + "\",\"ClassName\":\"" + cls1.ClassName.ToString()
                    + "\",\"WeekDaysStartTime\":\""
                    + item["WeekDaysStartTime"].ToString() + "\",\"WeekDaysEndtTime\":\"" + item["WeekDaysEndtTime"].ToString()
                    + "\",\"WeekDaysNumDays\":\"" + item["WeekDaysNumDays"].ToString() + "\",\"LeaveRecordClassNum\":\"" + cls1.ClassName.ToString() + "\"},";
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
            return strJson.ToString();
        }


        /// <summary>
        /// 有条件的查询周末请假
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="College"></param>
        /// <param name="Specialty"></param>
        /// <param name="grade"></param>
        /// <param name="class1"></param>
        /// <param name="Sex"></param>
        /// <param name="LeaveRecordCategory"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string selectWeekbycondition1(string start, string end, string College, string Specialty, string grade, string class1, string Sex, string post)
        {
            string addContidion = "WHERE ";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                addContidion += string.Format("LeaveRecordClassNum like '{0}'", College + "__" + grade + "_");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                addContidion += string.Format("LeaveRecordClassNum='{0}'", Specialty + grade + class1);
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                addContidion += string.Format("LeaveRecordClassNum like '{0}'", College + "%");
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                addContidion += string.Format("LeaveRecordClassNum like '{0}'", Specialty + "%");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                addContidion += string.Format("LeaveRecordClassNum like '{0}'", Specialty + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                addContidion += string.Format("LeaveRecordClassNum like '{0}'", "____" + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                addContidion = "";
            }

            if (start != null && addContidion != "")
            {
                addContidion += string.Format(" and (WeekDaysStartTime between '{0}' and '{1}') and (WeekDaysEndtTime between '{2}' and '{3}');", start, end, start, end);
            } else if (start != null && addContidion =="") {
                addContidion += string.Format("WHERE (WeekDaysStartTime between '{0}' and '{1}') and (WeekDaysEndtTime between '{2}' and '{3}');", start, end, start, end);
            }
            if (addContidion == "WHERE ")
            {
                addContidion = "";
            }
            //string contidion = "";
            //if (post == "班主任")
            //{
            //    contidion = addContidion;
            //}
            //else if (post == "辅导员")
            //{
            //    contidion = addContidion;
            //}
            //else if (post == "院领导")
            //{
            //    contidion = addContidion;
            //}
            //else if (post == "校领导")
            //{
            //    contidion = addContidion;
            //}
            //else if (post == "公寓中心")
            //{
            //    contidion = addContidion;
            //}
            JArray Leave = JArray.Parse(Helper.ObjToJson<List<WeekDays>>(WeekDaysBLL.SelectAllByCondition(addContidion) as List<WeekDays>));
            string strJson = "[";
            foreach (JToken item in Leave)
            {
                Students stus = StudentsBLL.getStuInfo(item["WeekDaysStudentID"].ToString());
                Class cls1 = ClassBLL.checkStuAndTeaID(stus.StudentClassID);
                if (item["WeekDaysApprover"].ToString() == "")
                {
                    continue;
                }

                if (Sex == "0" || Sex == stus.StudentSex)
                {
                    strJson += "{\"WeekDaysID\":\"" + item["WeekDaysID"].ToString() + "\",\"WeekDaysStudentID\":\""
                     + item["WeekDaysStudentID"].ToString() + "\",\"StudentName\":\"" + stus.StudentName.ToString()
                     + "\",\"StudentTel\":\"" + stus.StudentTel.ToString() + "\",\"StudentNum\":\""
                     + stus.StudentNum.ToString() + "\",\"StudentBedroomNum\":\"" + stus.StudentBedroomNum.ToString() + "\",\"ClassName\":\"" + cls1.ClassName.ToString()
                     + "\",\"WeekDaysStartTime\":\""
                     + item["WeekDaysStartTime"].ToString() + "\",\"WeekDaysEndtTime\":\"" + item["WeekDaysEndtTime"].ToString()
                     + "\",\"WeekDaysNumDays\":\"" + item["WeekDaysNumDays"].ToString() + "\",\"LeaveRecordClassNum\":\"" + cls1.ClassName.ToString() + "\"},";
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
            return strJson;

        }
    }
}