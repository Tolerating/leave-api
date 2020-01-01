using BLL;
using DAL;
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
    [ControllerGroup("用户管理")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UserManagementController : ApiController
    {

        #region 教师管理

        /// <summary>
        /// 查询所有教师信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string TeacherInfoAll()
        {
            IList<Teachers> TeachersInfo = TeachersBLL.SelectAllByCondition("IsDelete = 0");
            string strJson = "[";
            Class cla = new Class();
            Specialty spe = new Specialty();
            College col = new College();
            foreach (Teachers oneT in TeachersInfo)
            {
                if (oneT.Post == "班主任")
                {
                    cla = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(oneT.TeacherNum));
                    spe = SpecialtyBLL.SelectBySpecialtyNum(cla.ClassSpecialityID.ToString());
                    col = CollegeBLL.SelectByCollegeNum(spe.SpecialtyCollegeID.ToString());
                }
                else if (oneT.Post == "辅导员")
                {
                    cla = ClassBLL.SelectByClassSpecialityTeacherID(Convert.ToInt32(oneT.TeacherNum));
                    spe = SpecialtyBLL.SelectBySpecialtyNum(cla.ClassSpecialityID.ToString());
                    col = CollegeBLL.SelectByCollegeNum(spe.SpecialtyCollegeID.ToString());
                }
                else if (oneT.Post == "院领导")
                {
                    col = CollegeBLL.SelectByTeacherNum(oneT.TeacherNum);
                }
                strJson += "{\"Num\":\"" + oneT.TeacherID + "\",\"TeacherNum\":\"" + oneT.TeacherNum.Substring(0, 8) + "\",\"TeacherName\":\"" + oneT.TeacherName + "\",\"TeacherSex\":\"" + oneT.TeacherSex +
                    "\",\"TeacherIDCard\":\"" + oneT.TeacherIDCard + "\",\"Post\":\"" + oneT.Post + "\",\"TeacherTel\":\"" + oneT.TeacherTel + "\",\"CollegeName\":\"" + col.CollegeName + "\"},";

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
        /// 根据教师编号删除教师
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        [HttpGet]
        public string DelectTeacherOne(string TeacherID, string Post)
        {
            Teachers T = TeachersBLL.SelectByTeacherID(Convert.ToInt32(TeacherID));
            AdminInfo admin = AdminInfoBLL.SelectByAdminLoginID(Convert.ToInt32(T.TeacherNum));
            if (Post == "班主任")
            {
                Class clas = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(T.TeacherNum));
                if (clas.ClassHeadTeacherID == Convert.ToInt32(T.TeacherNum))
                {
                    return "3";
                }
            }
            else if (Post == "辅导员")
            {
                Class speInfo = ClassBLL.SelectByCondition("ClassSpecialityTeacherID='" + T.TeacherNum + "'");
                if (speInfo.ClassSpecialityTeacherID == Convert.ToInt32(T.TeacherNum))
                {
                    return "3";
                }
            }
            else if (Post == "院领导")
            {
                College col = CollegeBLL.SelectByTeacherNum(T.TeacherNum);
                if (col.TeacherNum == T.TeacherNum)
                {
                    return "3";
                }
            }
            try
            {
                //int one = TeachersBLL.DeleteByTeacherID(Convert.ToInt32(TeacherID));
                int one = tool.ExecuteNonQuery(string.Format("UPDATE [Teachers] SET IsDelete = 1 WHERE [TeacherID]={0};", TeacherID));
                int two = AdminInfoBLL.DeleteByAdminID(admin.AdminID);
                if (one + two > 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch
            {
                return "0";
                throw;
            }

        }


        /// <summary>
        /// 更新教师信息
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <param name="TeacherName"></param>
        /// <param name="TeacherSex"></param>
        /// <param name="TeacherTel"></param>
        /// <param name="TeacherCode"></param>
        /// string TeacherID, string TeacherNum, string TeacherName, string TeacherSex, string TeacherTel, string TeacherCode
        /// <returns></returns>
        [HttpPost]
        public string UpdateTeacherInfo([FromBody] JObject obj)
        {
            Teachers T = TeachersBLL.SelectByTeacherID(Convert.ToInt32(obj["TeacherID"].ToString()));
            AdminInfo admin = AdminInfoBLL.SelectByAdminLoginID(Convert.ToInt32(T.TeacherNum));
            if (admin.AdminLoginID == 0)
            {
                return "0";
            }
            admin.AdminName = obj["TeacherName"].ToString();
            T.TeacherName = obj["TeacherName"].ToString();
            T.TeacherSex = obj["TeacherSex"].ToString();
            T.TeacherTel = obj["TeacherTel"].ToString();
            T.TeacherIDCard = obj["TeacherCode"].ToString();
            try
            {
                int one = TeachersBLL.Update(T);
                int two = AdminInfoBLL.Update(admin);
                if (one + two > 1)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch
            {
                return "0";
                throw;
            }

        }


        #endregion

        #region 学生管理


        /// <summary>
        /// 按条件查询不同班级、专业、学院、年级的学生
        /// </summary>
        /// <param name="College"></param>
        /// <param name="Specialty"></param>
        /// <param name="grade"></param>
        /// <param name="class1"></param>
        /// <param name="Sex"></param>
        /// <returns></returns>
        [HttpGet]
        public string StudentInfoAll(string College, string Specialty, string grade, string class1,string Sex)
        {
            string addContidion = "WHERE";
            if (College != "0" && Specialty == "0" && grade != "0")     //按学院和年级查
            {
                addContidion += string.Format("StudentClassID like '{0}'", College + "__" + grade + "_");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 != "0")   //按班级ID查
            {
                addContidion += string.Format("StudentClassID='{0}'", Specialty + grade + class1);
            }
            else if (College != "0" && Specialty == "0" && grade == "0" && class1 == "0")
            {  //只查询学院
                addContidion += string.Format("StudentClassID like '{0}'", College + "%");
            }
            else if (College != "0" && Specialty != "0" && grade == "0")    //按学院和专业查
            {
                addContidion += string.Format("StudentClassID like '{0}'", Specialty + "%");
            }
            else if (College != "0" && Specialty != "0" && grade != "0" && class1 == "0")   //按学院 专业 年级查
            {
                addContidion += string.Format("StudentClassID like '{0}'", Specialty + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade != "0" && class1 == "0")  //按年级查
            {
                addContidion += string.Format("StudentClassID like '{0}'", "____" + grade + "_");
            }
            else if (College == "0" && Specialty == "0" && grade == "0" && class1 == "0")   //查询全部
            {
                addContidion = "";
            }

            if (addContidion == "")
            {
                addContidion += "WHERE IsDelete = 0";
            }
            else {
                addContidion += " and IsDelete = 0";
            }
            IList<Students> Students = StudentsBLL.SelectAllByCondition(addContidion);
            string strJson = "[";
            foreach (Students Student in Students)
            {
                Class classone = ClassBLL.SelectByClassNum(Student.StudentClassID);
                Specialty spe = SpecialtyBLL.SelectBySpecialtyNum(classone.ClassSpecialityID.ToString());
                College col = CollegeBLL.SelectByCollegeNum(spe.SpecialtyCollegeID.ToString());
                if (Sex == "0") {
                    strJson += "{\"StudentID\":\"" + Student.StudentID + "\",\"StudentNum\":\"" + Student.StudentNum + "\",\"StudentName\":\"" + Student.StudentName + "\",\"Sex\":\"" + Student.StudentSex +
                     "\",\"ClassName\":\"" + classone.ClassName + "\",\"ClassNum\":\"" + Student.StudentClassID + "\",\"Tel\":\"" + Student.StudentTel + "\",\"IDCode\":\"" + Student.StudentIDCard + "\",\"Address\":\"" +
                     Student.StudentHomeAddress + "\",\"StudentParentTel\":\"" + Student.StudentParentTel + "\",\"CollegeName\":\"" + col.CollegeName + "\",\"bedroom\":\"" + Student.StudentBedroomNum + "\"},";
                } else if (Sex == Student.StudentSex) {
                    strJson += "{\"StudentID\":\"" + Student.StudentID + "\",\"StudentNum\":\"" + Student.StudentNum + "\",\"StudentName\":\"" + Student.StudentName + "\",\"Sex\":\"" + Student.StudentSex +
                     "\",\"ClassName\":\"" + classone.ClassName + "\",\"ClassNum\":\"" + Student.StudentClassID + "\",\"Tel\":\"" + Student.StudentTel + "\",\"IDCode\":\"" + Student.StudentIDCard + "\",\"Address\":\"" +
                     Student.StudentHomeAddress + "\",\"StudentParentTel\":\"" + Student.StudentParentTel + "\",\"CollegeName\":\"" + col.CollegeName + "\",\"bedroom\":\"" + Student.StudentBedroomNum + "\"},";
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
        /// 根据学号删除学生
        /// </summary>
        /// <param name="StudentNum"></param>
        /// <returns></returns>
        [HttpGet]
        public string DelectStudentone(string StudentNum)
        {
            Students stuone = StudentsBLL.getStuInfo(StudentNum);
            //int Res = StudentsBLL.DeleteByStudentID(stuone.StudentID);
            int Res = tool.ExecuteNonQuery(string.Format("UPDATE [Students] SET IsDelete = 1 WHERE [StudentNum]={0};", StudentNum));
            AdminInfo admin = AdminInfoBLL.SelectByAdminLoginID(Convert.ToInt32(stuone.StudentNum));
            Res += AdminInfoBLL.DeleteByAdminID(admin.AdminID);
            if (Res > 1)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }


        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public string UpdateStudent([FromBody] JObject obj)
        {
            Students stuone = StudentsBLL.getStuInfo(obj["StudentID"].ToString());
            stuone.StudentName = obj["StudentName"].ToString();
            stuone.StudentSex = obj["StudentSex"].ToString();
            stuone.StudentClassID = obj["StudentClassID"].ToString();
            stuone.StudentTel = obj["StudentTel"].ToString();
            stuone.StudentIDCard = obj["StudentCode"].ToString();
            stuone.StudentHomeAddress = obj["StudentAddress"].ToString();
            stuone.StudentParentTel = obj["StudentParentTel"].ToString();
            stuone.StudentBedroomNum = obj["bedroomNum"].ToString();
            if (StudentsBLL.Update(stuone) > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }
        #endregion
    }
}