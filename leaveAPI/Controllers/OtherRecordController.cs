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
    [ControllerGroup("其他历史记录")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class OtherRecordController : ApiController
    {

        /// <summary>
        /// 获取请假信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string OtherLeaveRecordHistory(string post)
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            //AdminInfo admin = (AdminInfo)Session["AdminInfo"];
            //string post = Session["Post"].ToString();
            string contidion = "WHERE ";            
            if (post == "班主任")
            {
                Class cla = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(teaID));
                contidion += "LeaveRecordClassNum ='" + cla.ClassNum + "' and( LeaveRecordStage ='0' or LeaveRecordStage='2'or LeaveRecordStage='-1') ";
            }
            else if (post == "辅导员")
            {
                Class cla = ClassBLL.SelectByClassSpecialityTeacherID(Convert.ToInt32(teaID));
                contidion += "LeaveRecordClassNum like'" + cla.ClassNum.Substring(0, 2) + "%' and ( LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1') ";
            }
            else if (post == "院领导")
            {
                College col = CollegeBLL.SelectByTeacherNum(teaID);
                contidion += "LeaveRecordClassNum like'" + col.CollegeNum + "%' and ( LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1') ";
            }
            else if (post == "校领导" || post == "公寓中心")
            {
                contidion += "LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1' or LeaveRecordStage='1' or LeaveRecordStage='2' or LeaveRecordStage='3'";
            }
            JArray Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition(contidion) as List<LeaveRecord>));
            string strJson = "[";
            foreach (JToken item in Leave)
            {
                if (item["LeaveRecordCategory"].ToString() == "1")
                    item["LeaveRecordCategory"] = "上课请假";
                else if (item["LeaveRecordCategory"].ToString() == "2")
                    item["LeaveRecordCategory"] = "不留宿请假";
                else if (item["LeaveRecordCategory"].ToString() == "3")
                    item["LeaveRecordCategory"] = "早自习请假";
                else if (item["LeaveRecordCategory"].ToString() == "4")
                    item["LeaveRecordCategory"] = "周末请假";
                Students stus = StudentsBLL.getStuInfo(item["LeaveRecordStudentID"].ToString());
                if (stus.StudentID == 0)
                {
                    continue;
                }
                if (item["LeaveRecordApprovalTime"].ToString() == "1900/1/1 0:00:00") {
                    item["LeaveRecordApprovalTime"] = "审核未结束";
                }
                Class cls1 = ClassBLL.checkStuAndTeaID(stus.StudentClassID);
                strJson += "{\"LeaveRecordID\":\"" + item["LeaveRecordID"].ToString() + "\",\"LeaveRecordStudentID\":\""
                    + item["LeaveRecordStudentID"].ToString() + "\",\"StudentName\":\"" + stus.StudentName.ToString()
                    + "\",\"StudentTel\":\"" + stus.StudentTel.ToString() + "\",\"StudentBedroomNum\":\"" + stus.StudentBedroomNum.ToString() + "\",\"ClassName\":\"" + cls1.ClassName.ToString()
                    + "\",\"LeaveRecordReason\":\"" + item["LeaveRecordReason"].ToString() + "\",\"LeaveRecordStartTime\":\""
                    + item["LeaveRecordStartTime"].ToString() + "\",\"LeaveRecordEndtTime\":\"" + item["LeaveRecordEndtTime"].ToString()
                    + "\",\"LeaveRecordStartLesson\":\"" + item["LeaveRecordStartLesson"].ToString() + "\",\"LeaveRecordEndLesson\":\"" + item["LeaveRecordEndLesson"].ToString()
                    + "\",\"LeaveRecordNumDays\":\"" + item["LeaveRecordNumDays"].ToString() + "\",\"LeaveRecordApprover\":\"" + item["LeaveRecordApprover"]
                    + "\",\"LeaveRecordStage\":\"" + item["LeaveRecordStage"].ToString() + "\",\"LeaveRecordApprovalResult\":\"" + item["LeaveRecordApprovalResult"].ToString()
                    + "\",\"LeaveRecordApprovalTime\":\"" + item["LeaveRecordApprovalTime"].ToString() + "\",\"LeaveRecordSumLesson\":\"" + item["LeaveRecordSumLesson"].ToString()
                    + "\",\"LeaveRecordCategory\":\"" + item["LeaveRecordCategory"].ToString()
                    + "\",\"LeaveRecordClassNum\":\"" + cls1.ClassName.ToString() + "\"},";
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


        /// <summary>
        /// 有条件的获取请假记录
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="College"></param>
        /// <param name="Specialty"></param>
        /// <param name="grade"></param>
        /// <param name="class1"></param>
        /// <param name="Sex"></param>
        /// <param name="LeaveRecordCategory"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string getLeaveInfoBycon(string start, string end, string College, string Specialty, string grade, string class1, string Sex, string LeaveRecordCategory, string post)
        {
            string addContidion = "";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                addContidion += string.Format(" and LeaveRecordClassNum like '{0}'", College + "__" + grade + "_");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                addContidion += string.Format(" and LeaveRecordClassNum='{0}'", Specialty + grade + class1);
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                addContidion += string.Format(" and LeaveRecordClassNum like '{0}'", College + "%");
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                addContidion += string.Format(" and LeaveRecordClassNum like '{0}'", Specialty + "%");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                addContidion += string.Format(" and LeaveRecordClassNum like '{0}'", Specialty + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                addContidion += string.Format(" and LeaveRecordClassNum like '{0}'", "____" + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                addContidion = "";
            }
            if (start != null)
            {
                addContidion += string.Format(" and (LeaveRecordStartTime between '{0}' and '{1}') and (LeaveRecordEndtTime between '{2}' and '{3}')", start, end, start, end);
            }
            if (LeaveRecordCategory != "0")
            {
                addContidion += string.Format(" and LeaveRecordCategory={0}", LeaveRecordCategory);
            }

            string contidion = "WHERE ";
            if (post == "班主任" || post == "辅导员")
            {
                if (post == "班主任")
                {
                    contidion += "(LeaveRecordStage ='0' or LeaveRecordStage='2' or LeaveRecordStage='-1')" + addContidion;
                }
                else if (post == "辅导员")
                {
                    contidion += "(LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1')" + addContidion;
                }
            }
            else if (post == "院领导")
            {
                contidion += "(LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1')" + addContidion;
            }
            else if (post == "校领导")
            {
                contidion += "(LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1' or LeaveRecordStage='1' or LeaveRecordStage='2' or LeaveRecordStage='3')" + addContidion;
            }
            else if (post == "公寓中心")
            {
                contidion += "(LeaveRecordStage ='0' or LeaveRecordStage='4' or LeaveRecordStage='-1' or LeaveRecordStage='1' or LeaveRecordStage='2' or LeaveRecordStage='3')" + addContidion;
            }
            JArray Leave = JArray.Parse(Helper.ObjToJson<List<LeaveRecord>>(LeaveRecordBLL.SelectAllByCondition(contidion) as List<LeaveRecord>));
            string strJson = "[";
            foreach (JToken item in Leave)
            {
                if (item["LeaveRecordCategory"].ToString() == "1")
                    item["LeaveRecordCategory"] = "上课请假";
                else if (item["LeaveRecordCategory"].ToString() == "2")
                    item["LeaveRecordCategory"] = "不留宿请假";
                else if (item["LeaveRecordCategory"].ToString() == "3")
                    item["LeaveRecordCategory"] = "早自习请假";
                else if (item["LeaveRecordCategory"].ToString() == "4")
                    item["LeaveRecordCategory"] = "周末请假";
                Students stus = StudentsBLL.getStuInfo(item["LeaveRecordStudentID"].ToString());
                Class cls1 = ClassBLL.checkStuAndTeaID(stus.StudentClassID);
                if (Sex == "0" || Sex == stus.StudentSex)
                {
                    strJson += "{\"LeaveRecordID\":\"" + item["LeaveRecordID"].ToString() + "\",\"LeaveRecordStudentID\":\""
                    + item["LeaveRecordStudentID"].ToString() + "\",\"StudentName\":\"" + stus.StudentName.ToString()
                    + "\",\"StudentTel\":\"" + stus.StudentTel.ToString() + "\",\"StudentBedroomNum\":\"" + stus.StudentBedroomNum.ToString() + "\",\"ClassName\":\"" + cls1.ClassName.ToString()
                    + "\",\"LeaveRecordReason\":\"" + item["LeaveRecordReason"].ToString() + "\",\"LeaveRecordStartTime\":\""
                    + item["LeaveRecordStartTime"].ToString() + "\",\"LeaveRecordEndtTime\":\"" + item["LeaveRecordEndtTime"].ToString()
                    + "\",\"LeaveRecordStartLesson\":\"" + item["LeaveRecordStartLesson"].ToString() + "\",\"LeaveRecordEndLesson\":\"" + item["LeaveRecordEndLesson"].ToString()
                    + "\",\"LeaveRecordNumDays\":\"" + item["LeaveRecordNumDays"].ToString() + "\",\"LeaveRecordApprover\":\"" + item["LeaveRecordApprover"]
                    + "\",\"LeaveRecordStage\":\"" + item["LeaveRecordStage"].ToString() + "\",\"LeaveRecordApprovalResult\":\"" + item["LeaveRecordApprovalResult"].ToString()
                    + "\",\"LeaveRecordApprovalTime\":\"" + item["LeaveRecordApprovalTime"].ToString() + "\",\"LeaveRecordSumLesson\":\"" + item["LeaveRecordSumLesson"].ToString()
                    + "\",\"LeaveRecordCategory\":\"" + item["LeaveRecordCategory"].ToString()
                    + "\",\"LeaveRecordClassNum\":\"" + cls1.ClassName.ToString() + "\"},";
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