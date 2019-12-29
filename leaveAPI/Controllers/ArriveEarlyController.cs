using BLL;
using leaveAPI.Filters;
using leaveAPI.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace leaveAPI.Controllers
{
    [ControllerGroup("早出晚归记录")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ArriveEarlyController : ApiController
    {
        /// <summary>
        /// 早出晚归请假记录查询
        /// </summary>
        /// <param name="numone"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string AdvanceSelect(string numone, string post)
        {
            string teaID = ((UserIdentity)User.Identity).ID.ToString();
            string strJson = "[";
            Class clas = new Class();
            if (post == "公寓中心" || post == "校领导")
            {
                IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAll();
                if (AdvanceDelays.Count == 0)
                {
                    return "0";
                }
                if (numone == "1")
                {
                    foreach (AdvanceDelay adone in AdvanceDelays)
                    {
                        Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        Class cla = ClassBLL.checkStuAndTeaID(adone.ClassNum);
                        if (cla.ClassName == null)
                            cla.ClassName = "暂无数据";
                        if (adone.AdvanceTime.ToString() == "0001/1/1 0:00:00")
                            continue;
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                        + cla.ClassName + "\",\"StudentName\":\"" + student.StudentName
                        + "\",\"AdvanceTime\":\"" + adone.AdvanceTime + "\",\"AdvanceStudentT\":\""
                        + adone.AdvanceStudentT + "\",\"AdvanceReson\":\"" + adone.AdvanceReson + "\"},";
                    }
                }
                else
                {
                    foreach (AdvanceDelay adone in AdvanceDelays)
                    {
                        Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                        if (adone.DelayStudentT.ToString() == "0001/1/1 0:00:00")
                            continue;
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        Class cla = ClassBLL.checkStuAndTeaID(adone.ClassNum);
                        if (cla.ClassName == null)
                            cla.ClassName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                        + clas.ClassName + "\",\"StudentName\":\"" + student.StudentName
                        + "\",\"DelayTime\":\"" + adone.DelayTime + "\",\"DelayStudentT\":\""
                        + adone.DelayStudentT + "\",\"DeatReson\":\"" + adone.DeatReson + "\"},";
                    }
                }
            }
            else if (post == "班主任")
            {

                clas = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(teaID));
                IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAllByClassNum(clas.ClassNum);
                if (AdvanceDelays.Count == 0)
                {
                    return "0";
                }
                if (numone == "1")
                {
                    foreach (AdvanceDelay AD in AdvanceDelays)
                    {
                        if (AD.AdvanceTime.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(AD.StudentNum);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + AD.StudentNum + "\",\"ClassName\":\""
                                + clas.ClassName + "\",\"StudentName\":\"" + student.StudentName
                                + "\",\"AdvanceTime\":\"" + AD.AdvanceTime + "\",\"AdvanceStudentT\":\""
                                + AD.AdvanceStudentT + "\",\"AdvanceReson\":\"" + AD.AdvanceReson + "\"},";
                    }
                }
                else
                {
                    foreach (AdvanceDelay adone in AdvanceDelays)
                    {
                        if (adone.DelayStudentT.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                                + clas.ClassName + "\",\"StudentName\":\"" + student.StudentName
                                + "\",\"DelayTime\":\"" + adone.DelayTime + "\",\"DelayStudentT\":\""
                                + adone.DelayStudentT + "\",\"DeatReson\":\"" + adone.DeatReson + "\"},";
                    }
                }
            }
            else if (post == "辅导员")
            {
                IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAllByCondition("WHERE ClassNum like '" + clas.ClassNum.Substring(0, 2) + "%'");
                if (AdvanceDelays.Count == 0)
                {
                    return "0";
                }
                if (numone == "1")
                {
                    foreach (AdvanceDelay AdvanceDelay in AdvanceDelays)
                    {
                        if (AdvanceDelay.AdvanceTime.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(AdvanceDelay.StudentNum);
                        Class cla = ClassBLL.checkStuAndTeaID(student.StudentClassID);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + AdvanceDelay.StudentNum + "\",\"ClassName\":\""
                                    + cla.ClassName + "\",\"StudentName\":\"" + student.StudentName
                                        + "\",\"AdvanceTime\":\"" + AdvanceDelay.AdvanceTime + "\",\"AdvanceStudentT\":\""
                                        + AdvanceDelay.AdvanceStudentT + "\",\"AdvanceReson\":\"" + AdvanceDelay.AdvanceReson + "\"},";
                    }
                }
                else
                {
                    foreach (AdvanceDelay adone in AdvanceDelays)
                    {
                        if (adone.DelayStudentT.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                        Class cla = ClassBLL.checkStuAndTeaID(student.StudentClassID);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                        + cla.ClassName + "\",\"StudentName\":\"" + student.StudentName
                        + "\",\"DelayTime\":\"" + adone.DelayTime + "\",\"DelayStudentT\":\""
                        + adone.DelayStudentT + "\",\"DeatReson\":\"" + adone.DeatReson + "\"},";
                    }
                }
            }
            else if (post == "院领导")
            {
                College col = CollegeBLL.SelectByTeacherNum(teaID);
                IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAllByCondition("WHERE ClassNum like '" + col.CollegeNum + "%'");
                if (numone == "1")
                {
                    foreach (AdvanceDelay AdvanceDelay in AdvanceDelays)
                    {
                        if (AdvanceDelay.AdvanceTime.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(AdvanceDelay.StudentNum);
                        Class cla = ClassBLL.checkStuAndTeaID(student.StudentClassID);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + AdvanceDelay.StudentNum + "\",\"ClassName\":\""
                                    + cla.ClassName + "\",\"StudentName\":\"" + student.StudentName
                                        + "\",\"AdvanceTime\":\"" + AdvanceDelay.AdvanceTime + "\",\"AdvanceStudentT\":\""
                                        + AdvanceDelay.AdvanceStudentT + "\",\"AdvanceReson\":\"" + AdvanceDelay.AdvanceReson + "\"},";
                    }
                }
                else
                {
                    foreach (AdvanceDelay adone in AdvanceDelays)
                    {
                        if (adone.DelayStudentT.ToString() == "0001/1/1 0:00:00")
                            continue;
                        Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                        Class cla = ClassBLL.checkStuAndTeaID(student.StudentClassID);
                        if (student.StudentName == null)
                            student.StudentName = "暂无数据";
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                        + cla.ClassName + "\",\"StudentName\":\"" + student.StudentName
                        + "\",\"DelayTime\":\"" + adone.DelayTime + "\",\"DelayStudentT\":\""
                        + adone.DelayStudentT + "\",\"DeatReson\":\"" + adone.DeatReson + "\"},";
                    }
                }
            }
            else
            {
                strJson += "";
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
        /// 有条件的查询早出记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string searchLeaveAdvance(string start, string end, string College, string Specialty, string grade, string class1, string Sex)
        {
            string addContidion = "WHERE ";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", College + "__" + grade + "_");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                addContidion += string.Format("ClassNum='{0}'", Specialty + grade + class1);
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                addContidion += string.Format("ClassNum like '{0}'", College + "%");
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                addContidion += string.Format("ClassNum like '{0}'", Specialty + "%");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", Specialty + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", "____" + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                addContidion = "";
            }

            if (start != null && addContidion != "")
            {
                addContidion += string.Format(" and (AdvanceStudentT between '{0}' and '{1}');", start, end);
            } else if (start != null && addContidion == "") {
                addContidion += string.Format("WHERE (AdvanceStudentT between '{0}' and '{1}');", start, end);
            }

            if (addContidion == "WHERE ") {
                addContidion = "";
            }
            string strJson = "[";
            IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAllByCondition(addContidion);
            if (AdvanceDelays.Count == 0)
            {
                return "[]";
            }
            else
            {
                foreach (AdvanceDelay adone in AdvanceDelays)
                {
                    Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                    if (student.StudentName == null) { student.StudentName = "暂无数据"; }
                    Class clas = ClassBLL.checkStuAndTeaID(adone.ClassNum);
                    if (clas.ClassName == null) { clas.ClassName = "暂无数据"; }
                    if (adone.AdvanceTime.ToString() == "0001/1/1 0:00:00") { continue; }
                    if (Sex == "0" || Sex == student.StudentSex) {
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                        + clas.ClassName + "\",\"StudentName\":\"" + student.StudentName
                        + "\",\"AdvanceTime\":\"" + adone.AdvanceTime + "\",\"AdvanceStudentT\":\""
                        + adone.AdvanceStudentT + "\",\"AdvanceReson\":\"" + adone.AdvanceReson + "\"},";
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

            return strJson;

        }


        /// <summary>
        /// 有条件的查询晚归记录
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="College"></param>
        /// <param name="Specialty"></param>
        /// <param name="grade"></param>
        /// <param name="class1"></param>
        /// <param name="Sex"></param>
        /// <returns></returns>
        [HttpGet]
        [TokenCheck]
        public string searchLeaveDelay(string start, string end, string College, string Specialty, string grade, string class1, string Sex)
        {
            string addContidion = "WHERE ";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", College + "__" + grade + "_");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                addContidion += string.Format("ClassNum='{0}'", Specialty + grade + class1);
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                addContidion += string.Format("ClassNum like '{0}'", College + "%");
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                addContidion += string.Format("ClassNum like '{0}'", Specialty + "%");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", Specialty + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                addContidion += string.Format("ClassNum like '{0}'", "____" + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                addContidion = "";
            }
            if (start != null && addContidion != "")
            {
                addContidion += string.Format(" and (DelayStudentT between '{0}' and '{1}');", start, end);
            }
            else if (start != null && addContidion == "")
            {
                addContidion += string.Format("WHERE (DelayStudentT between '{0}' and '{1}');", start, end);
            }
            if (addContidion == "WHERE ")
            {
                addContidion = "";
            }

            string strJson = "[";
            IList<AdvanceDelay> AdvanceDelays = AdvanceDelayBLL.SelectAllByCondition(addContidion);
            if (AdvanceDelays.Count == 0)
            {
                return "[]";
            }
            else
            {
                foreach (AdvanceDelay adone in AdvanceDelays)
                {
                    Students student = StudentsBLL.getStuInfo(adone.StudentNum);
                    if (student.StudentName == null) { student.StudentName = "暂无数据"; }
                    Class clas = ClassBLL.checkStuAndTeaID(adone.ClassNum);
                    if (clas.ClassName == null) { clas.ClassName = "暂无数据"; }
                    if (adone.AdvanceTime.ToString() == "0001/1/1 0:00:00") { continue; }
                    if (Sex == "0" || Sex == student.StudentSex) {
                        strJson += "{\"StudentNum\":\"" + adone.StudentNum + "\",\"ClassName\":\""
                           + clas.ClassName + "\",\"StudentName\":\"" + student.StudentName
                           + "\",\"DelayTime\":\"" + adone.DelayTime + "\",\"DelayStudentT\":\""
                           + adone.DelayStudentT + "\",\"DeatReson\":\"" + adone.DeatReson + "\"},";
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

            return strJson;

        }
    }
}