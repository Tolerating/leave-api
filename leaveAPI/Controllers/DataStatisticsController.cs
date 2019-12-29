using BLL;
using DAL;
using leaveAPI.Filters;
using leaveAPI.Models;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace leaveAPI.Controllers
{
    [ControllerGroup("数据统计")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class DataStatisticsController : ApiController
    {

        /// <summary>
        /// 统计不同类别的请假人数
        /// </summary>   
        /// <returns>请假人数</returns>
        [HttpGet]
        public string GetOrderHistoryCount(string start, string end, string College, string Specialty, string grade, string class1, string Sex)
        {
            string total = "", str1 = "", str2 = "", str3 = "", str4 = "", str5 = "", str6 = "";
            string Num = "";
            //string addContidion = "";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                Num = College + "__" + grade + "_";
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                Num = Specialty + grade + class1;
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                Num = College + "%";
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                Num = Specialty + "%";
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                Num = Specialty + grade + "_";
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                Num = "____" + grade + "_";
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                Num = "%";
            }
            str1 = GetLeaveRecordCount(start, end, Num, Sex, 1);
            str2 = GetLeaveRecordCount(start, end, Num, Sex, 2);
            str3 = GetLeaveRecordCount(start, end, Num, Sex, 3);

            str4 = GetWeekDaysCount(start, end, Num, Sex);
            str5 = GetAdvance(start, end, Num, Sex);
            str6 = Delay(start, end, Num, Sex);
            total = Getstringplus(str1, str2, str3, str4, str5, str6);
            return "{\"Data\":[[\"上课请假\"," + str1 + "],[\"不留宿请假\"," + str2 + "],[\"早自习请假\"," + str3 + "],[\"周末请假\"," + str4 + "],[\"早出\"," + str5 + "],[\"晚归\"," + str6 + "]],\"Total\":" + total + ",\"Flag\":0}";


        }



        /// <summary>
        /// 统计不同级别同种类别的请假人数
        /// </summary>   
        /// <returns>请假人数</returns>
        [HttpGet]
        public string GetOrderHistoryCountByLeaveRecordCategory(string start, string end, string College, string Specialty, string grade, string class1, string Sex, int LeaveRecordCategory)
        {
            string addContidion = "";
            int share, total = 0;
            string str;
            if (start != null)
            {
                if (LeaveRecordCategory == 4)
                {

                    addContidion = "SELECT COUNT(*) FROM [WeekDays] as W inner join [Students] as S on S.StudentNum  = W.WeekDaysStudentID where";
                    addContidion += string.Format(" (W.WeekDaysApprovalTime BETWEEN '{0}' AND '{1}')", start, end);
                }
                else if (LeaveRecordCategory == 5)
                {

                    addContidion = "SELECT COUNT(AdvanceStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where";
                    addContidion += string.Format(" (W.AdvanceTime BETWEEN '{0}' AND '{1}')", start, end);
                }
                else if (LeaveRecordCategory == 6)
                {

                    addContidion = "SELECT COUNT(DelayStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where";
                    addContidion += string.Format(" (W.DelayTime BETWEEN '{0}' AND '{1}')", start, end);
                }
                else
                {

                    addContidion = string.Format("SELECT COUNT(*) FROM [LeaveRecord] as W inner join [Students] as S on S.StudentNum  = W.LeaveRecordStudentID where W.LeaveRecordCategory={0} and", LeaveRecordCategory);
                    addContidion += string.Format(" (W.LeaveRecordApprovalTime BETWEEN '{0}' AND '{1}')", start, end);
                }

            }
            else
            {
                if (LeaveRecordCategory == 4)
                {
                    addContidion = "SELECT COUNT(*) FROM [WeekDays] as W inner join [Students] as S on S.StudentNum  = W.WeekDaysStudentID where";
                }
                else if (LeaveRecordCategory == 5)
                {
                    addContidion = "SELECT COUNT(AdvanceStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where";
                }
                else if (LeaveRecordCategory == 6)
                {
                    addContidion = "SELECT COUNT(DelayStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where";
                }
                else
                {
                    addContidion = string.Format("SELECT COUNT(*) FROM [LeaveRecord] as W inner join [Students] as S on S.StudentNum  = W.LeaveRecordStudentID where W.LeaveRecordCategory={0} and", LeaveRecordCategory);
                }
            }

            if (Sex != "0")
            {
                if (start != null)
                {
                    addContidion += string.Format(" and S.StudentSex ='{0}' and", Sex);
                }
                else
                {
                    addContidion += string.Format(" S.StudentSex ='{0}' and", Sex);
                }

            }
            else
            {
                if (start != null)
                {
                    addContidion = addContidion + " and";
                }

            }

            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {

                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", College + "__" + grade + "_");
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum like '{0}'", College + "__" + grade + "_");
                }

                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":[[\"" + grade + "级\",\"" + Convert.ToInt32(str) + "\"]],\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", Specialty + grade + class1);
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum='{0}'", Specialty + grade + class1);
                }
                Class cla = ClassBLL.getClassInfo(Specialty + grade + class1);
                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":[[\"" + cla.ClassName + "\",\"" + Convert.ToInt32(str) + "\"]],\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")  //只查询学院
            {
                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", College + "%");
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum like '{0}'", College + "%");
                }

                College col = CollegeBLL.SelectByCollegeNum(College);
                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":[[\"" + col.CollegeName + "\",\"" + Convert.ToInt32(str) + "\"]],\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", Specialty + "%");
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum like '{0}'", Specialty + "%");
                }

                Specialty spe = SpecialtyBLL.SelectBySpecialtyNum(Specialty);
                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":[[\"" + spe.SpecialtyName + "\",\"" + Convert.ToInt32(str) + "\"]],\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", Specialty + grade + "_");
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum like '{0}'", Specialty + grade + "_");
                }

                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":[[\"" + grade + "级\",\"" + Convert.ToInt32(str) + "\"]],\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                {
                    addContidion += string.Format(" W.ClassNum like '{0}'", "____" + grade + "_");
                }
                else
                {
                    addContidion += string.Format(" W.LeaveRecordClassNum like '{0}'", "____" + grade + "_");
                }
                str = tool.Select(addContidion).Rows[0].ItemArray[0].ToString();
                return "{\"Data\":" + grade + ",\"Total\":" + Convert.ToInt32(str) + ",\"Flag\":" + 0 + "}";
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {


                List<College> college = CollegeBLL.SelectAll().ToList<College>();
                ArrayList list = new ArrayList();
                ArrayList temp = new ArrayList();
                foreach (College c in college)
                {
                    string sql = "";
                    if (LeaveRecordCategory == 5 || LeaveRecordCategory == 6)
                    {
                        sql = string.Format(" W.ClassNum like '{0}'", c.CollegeNum + "%");
                    }
                    else
                    {
                        sql = string.Format(" W.LeaveRecordClassNum like '{0}'", c.CollegeNum + "%");
                    }
                    str = tool.Select(addContidion + sql).Rows[0].ItemArray[0].ToString();
                    temp = new ArrayList();
                    temp.Add(c.CollegeName);
                    if (str != null && str != "")
                    {
                        share = Int32.Parse(str);
                        total += share;
                        temp.Add(share);
                    }
                    else
                    {
                        temp.Add(null);
                    }
                    list.Add(temp);
                }
                return "{\"Data\":" + tool.ObjToJson<ArrayList>(list) + ",\"Total\":" + total + ",\"Flag\":" + 0 + "}";
            }
            return "{\"Data\":[[\"错误\",null]],\"Total\":0,\"Flag\":-1}";

        }



        /// <summary>
        /// 条件查询LeaveRecord表
        /// </summary>
        /// <returns>json</returns>
        private string GetLeaveRecordCount(string start, string end, string Num, string sex, int LeaveRecordCategory)
        {
            string LeaveRecordCount = "";
            string sql = "";
            string contidion = "";
            if (start != null)
            {
                contidion = string.Format(" and LeaveRecordApprovalTime BETWEEN '{0}' AND '{1}'", start, end);
            }
            if (sex == "0")
            {
                sql = string.Format("SELECT COUNT(*) FROM [LeaveRecord] WHERE  LeaveRecordCategory= '{0}' and LeaveRecordClassNum like '{1}'", LeaveRecordCategory, Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            else
            {
                sql = string.Format("SELECT COUNT(*) FROM [LeaveRecord] as W inner join [Students] as S on S.StudentNum  = W.LeaveRecordStudentID where W.LeaveRecordCategory= '{0}' and S.StudentSex='{1}' and LeaveRecordClassNum like '{2}'", LeaveRecordCategory, sex, Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            return LeaveRecordCount;
        }


        /// <summary>
        /// 条件查询WeekDays表
        /// </summary>
        /// <returns>json</returns>
        private string GetWeekDaysCount(string start, string end, string Num, string sex)
        {
            string LeaveRecordCount = "";
            string sql = "";
            string contidion = "";
            if (start != null)
            {
                contidion = string.Format(" and WeekDaysStartTime BETWEEN '{0}' AND '{1}'", start, end);
            }
            if (sex == "0")
            {
                sql = string.Format("SELECT COUNT(*) FROM [WeekDays] WHERE LeaveRecordClassNum like '{0}'", Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            else
            {

                sql = string.Format("SELECT COUNT(*) FROM [WeekDays] as W inner join [Students] as S on S.StudentNum  = W.WeekDaysStudentID where S.StudentSex='{0}' and LeaveRecordClassNum like '{1}'", sex, Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            return LeaveRecordCount;
        }

        /// <summary>
        /// 查询早出记录
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="Num"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        private string GetAdvance(string start, string end, string Num, string sex)
        {
            string LeaveRecordCount = "";
            string sql = "";
            string contidion = "";
            if (start != null)
            {
                contidion = string.Format(" and AdvanceStudentT BETWEEN '{0}' AND '{1}'", start, end);
            }
            if (sex == "0")
            {
                sql = string.Format("SELECT COUNT(AdvanceStudentT) FROM [AdvanceDelay] WHERE ClassNum like '{0}'", Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            else
            {
                sql = string.Format("SELECT COUNT(AdvanceStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where S.StudentSex='{0}' and ClassNum like '{1}'", sex, Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            return LeaveRecordCount;
        }

        /// <summary>
        /// 查询晚归记录
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="Num"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        private string Delay(string start, string end, string Num, string sex)
        {
            string LeaveRecordCount = "";
            string sql = "";
            string contidion = "";
            if (start != null)
            {
                contidion = string.Format(" and DelayStudentT BETWEEN '{0}' AND '{1}'", start, end);
            }
            if (sex == "0")
            {
                sql = string.Format("SELECT COUNT(DelayStudentT) FROM [AdvanceDelay] WHERE ClassNum like '{0}'", Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            else
            {
                sql = string.Format("SELECT COUNT(DelayStudentT) FROM [AdvanceDelay] as W inner join [Students] as S on S.StudentNum  = W.StudentNum where S.StudentSex='{0}' and ClassNum like '{1}'", sex, Num) + contidion;
                LeaveRecordCount = (tool.Select(sql)).Rows[0].ItemArray[0].ToString();
            }
            return LeaveRecordCount;
        }



        /// <summary>
        /// string转int相加再转string
        /// </summary>
        /// <returns>json</returns>
        private string Getstringplus(string str1, string str2, string str3, string str4, string str5, string str6)
        {
            string total = "";
            total = (Convert.ToInt32(str1) + Convert.ToInt32(str2) + Convert.ToInt32(str3) + Convert.ToInt32(str4) + Convert.ToInt32(str5) + Convert.ToInt32(str6)).ToString();
            return total;
        }
    }
}