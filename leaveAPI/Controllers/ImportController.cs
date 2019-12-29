using BLL;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using leaveAPI.Content;

namespace leaveAPI.Controllers
{
    [ControllerGroup("数据导入")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ImportController : ApiController
    {
        #region 数据导入

        #region 学生数据导入
        /// <summary>
        /// 查询所有学生，并联历班级
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[TokenCheck]
        public string selectStudentAll()
        {
            IList<Students> student = StudentsBLL.SelectAll();
            string strJson = "[";
            foreach (Students stu in student)
            {
                Class clas = ClassBLL.checkStuAndTeaID(stu.StudentClassID);
                strJson += "{\"StudentID\":\"" + stu.StudentNum + "\",\"StudentName\":\""
                    + stu.StudentName + "\",\"StudentTel\":\"" + stu.StudentTel + "\",\"StudenClass\":\""
                    + clas.ClassName + "\",\"StudentParentTel\":\"" + stu.StudentParentTel + "\",\"StudentAp\":\""
                    + stu.StudentApprovalResult + "\",\"StudentHome\":\"" + stu.StudentHomeAddress + "\"},";
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
        /// 学生数据导入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[TokenCheck]
        public List<int> importStu([FromBody] JObject Data)
        {
            List<int> result = new List<int>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string data = Data["Data"].ToString();
            //将学生数据转成IList
            List<Students> students = jss.Deserialize<List<Students>>(data);

            //存放已存在的学生信息
            List<Students> reInfo = new List<Students>();

            //获取数据库中所有学生的学号
            List<int> studnetNum = (List<int>)StudentsBLL.SelectStudentNumAll();

            //检查数据中的学号是否已经存在数据库中
            foreach (var item in students)
            {
                int indexOf = studnetNum.IndexOf(Convert.ToInt32(item.StudentNum));
                item.open_id = "1231";
                item.StudentPass = Tool.MD5ToString(item.StudentPass);
                item.StudentApprovalResult = "通过";
                item.StudentApprovalTime = DateTime.Now.ToString();
                item.StudentApprover = "刘凯";
                if (indexOf != -1)
                {
                    result.Add(Convert.ToInt32(item.StudentNum));
                    reInfo.Add(item);
                }
            }
            foreach (var item in reInfo)
            {
                students.Remove(item);
            }
            List<AdminInfo> admin = new List<AdminInfo>();
            foreach (var item in students)
            {
                admin.Add(new AdminInfo
                {
                    AdminLoginID = Convert.ToInt32(item.StudentNum),
                    AdnminPasssword = item.StudentPass,
                    AdminName = item.StudentName,
                    AdminJurisdictionID = 0
                });
            }

            DataTable studentTable = StuToDataTable(students);
            DataTable adminTable = AdminToDataTable(admin);
            StudentsBLL.importByBulk(studentTable, "Students");
            StudentsBLL.importByBulk(adminTable, "AdminInfo");
            return result;
        }


        #endregion

        #region 教师数据导入
        /// <summary>
        /// 查询所有教师列表信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string selectTeacherAll()
        {
            IList<Teachers> teacher = TeachersBLL.SelectAll();
            string strJson = "[";
            foreach (Teachers tea in teacher)
            {
                strJson += "{\"TeacherNum\":\"" + tea.TeacherNum + "\",\"TeacherName\":\""
                    + tea.TeacherName + "\",\"Post\":\"" + tea.Post + "\",\"TeacherTel\":\""
                    + tea.TeacherTel + "\",\"TeacherApprovalResult\":\"" + tea.TeacherApprovalResult + "\"},";
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
        /// 教师数据导入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[TokenCheck]
        public List<int> importTeacher([FromBody] JObject Data)
        {
            List<int> result = new List<int>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string data = Data["Data"].ToString();
            //将学生数据转成IList
            List<Teachers> teachers = jss.Deserialize<List<Teachers>>(data);

            //存放已存在的学生信息
            List<Teachers> reInfo = new List<Teachers>();

            //获取数据库中所有学生的学号
            List<int> teacherNum = (List<int>)TeachersBLL.SelectTeacherNumAll();

            //检查数据中的学号是否已经存在数据库中
            foreach (var item in teachers)
            {
                string post = item.Post;
                string ID = item.TeacherNum;
                if (post == "班主任")
                {
                    item.TeacherNum = ID + "1";
                }
                else if (post == "辅导员")
                {
                    item.TeacherNum = ID + "2";
                }
                else if (post == "院领导")
                {
                    item.TeacherNum = ID + "3";
                }
                item.open_id = "1231";
                item.TeacherPass = Tool.MD5ToString(item.TeacherPass);
                item.TeacherApprovalResult = "通过";
                item.TeacherApprovalTime = DateTime.Now.ToString();
                item.TeacherApprover = "刘凯";
                int indexOf = teacherNum.IndexOf(Convert.ToInt32(item.TeacherNum));
                if (indexOf != -1)
                {
                    result.Add(Convert.ToInt32(item.TeacherNum));
                    reInfo.Add(item);
                }
            }
            foreach (var item in reInfo)
            {
                teachers.Remove(item);
            }
            List<AdminInfo> admin = new List<AdminInfo>();
            foreach (var item in teachers)
            {
                admin.Add(new AdminInfo
                {
                    AdminLoginID = Convert.ToInt32(item.TeacherNum),
                    AdnminPasssword = item.TeacherPass,
                    AdminName = item.TeacherName,
                    AdminJurisdictionID = 0
                });
            }

            DataTable teacherTable = TeaToDataTable(teachers);
            DataTable adminTable = AdminToDataTable(admin);
            StudentsBLL.importByBulk(teacherTable, "Teachers");
            StudentsBLL.importByBulk(adminTable, "AdminInfo");
            return result;
        }

        #endregion

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage StudentExcel(string ExcelType)
        {
            var path = HttpContext.Current.Server.MapPath("~/Content/ExcelModule/ExcleStudent.xls"); ;
            if (ExcelType == "S")
            {
                path = HttpContext.Current.Server.MapPath("~/Content/ExcelModule/ExcleStudent.xls");
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("~/Content/ExcelModule/ExcleTeacher.xls");
            }
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;
            return result;
        }

        #endregion


        /// <summary>
        /// List<Students>转DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static DataTable StuToDataTable(List<Students> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("StudentID", typeof(int));
            dt.Columns.Add("StudentNum", typeof(string));
            dt.Columns.Add("open_id", typeof(string));
            dt.Columns.Add("StudentPass", typeof(string));
            dt.Columns.Add("StudentName", typeof(string));
            dt.Columns.Add("StudentSex", typeof(string));
            dt.Columns.Add("StudentTel", typeof(string));
            dt.Columns.Add("StudentClassID", typeof(string));
            dt.Columns.Add("StudentIDCard", typeof(string));
            dt.Columns.Add("StudentBedroomNum", typeof(string));
            dt.Columns.Add("StudentParentTel", typeof(string));
            dt.Columns.Add("StudentHomeAddress", typeof(string));
            dt.Columns.Add("StudentApprover", typeof(string));
            dt.Columns.Add("StudentApprovalResult", typeof(string));
            dt.Columns.Add("StudentApprovalTime", typeof(string));
            foreach (var item in list)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = item.StudentID;
                newRow[1] = item.StudentNum;
                newRow[2] = item.open_id;
                newRow[3] = item.StudentPass;
                newRow[4] = item.StudentName;
                newRow[5] = item.StudentSex;
                newRow[6] = item.StudentTel;
                newRow[7] = item.StudentClassID;
                newRow[8] = item.StudentIDCard;
                newRow[9] = item.StudentBedroomNum;
                newRow[10] = item.StudentParentTel;
                newRow[11] = item.StudentHomeAddress;
                newRow[12] = item.StudentApprover;
                newRow[13] = item.StudentApprovalResult;
                newRow[14] = item.StudentApprovalTime;
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        /// <summary>
        /// List<Teachers>转DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static DataTable TeaToDataTable(List<Teachers> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TeacherID", typeof(int));
            dt.Columns.Add("TeacherNum", typeof(string));
            dt.Columns.Add("open_id", typeof(string));
            dt.Columns.Add("TeacherPass", typeof(string));
            dt.Columns.Add("TeacherName", typeof(string));
            dt.Columns.Add("TeacherSex", typeof(string));
            dt.Columns.Add("TeacherTel", typeof(string));
            dt.Columns.Add("Post", typeof(string));
            dt.Columns.Add("TeacherIDCard", typeof(string));
            dt.Columns.Add("TeacherApprover", typeof(string));
            dt.Columns.Add("TeacherApprovalResult", typeof(string));
            dt.Columns.Add("TeacherApprovalTime", typeof(string));
            foreach (var item in list)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = item.TeacherID;
                newRow[1] = item.TeacherNum;
                newRow[2] = item.open_id;
                newRow[3] = item.TeacherPass;
                newRow[4] = item.TeacherName;
                newRow[5] = item.TeacherSex;
                newRow[6] = item.TeacherTel;
                newRow[7] = item.Post;
                newRow[8] = item.TeacherIDCard;
                newRow[9] = item.TeacherApprover;
                newRow[10] = item.TeacherApprovalResult;
                newRow[11] = item.TeacherApprovalTime;
                dt.Rows.Add(newRow);
            }
            return dt;
        }

        /// <summary>
        ///  List<AdminInfo>转DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static DataTable AdminToDataTable(List<AdminInfo> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("AdminID", typeof(int));
            dt.Columns.Add("AdminLoginID", typeof(int));
            dt.Columns.Add("AdnminPasssword", typeof(string));
            dt.Columns.Add("AdminName", typeof(string));
            dt.Columns.Add("AdminJurisdictionID", typeof(int));
            foreach (var item in list)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = item.AdminID;
                newRow[1] = item.AdminLoginID;
                newRow[2] = item.AdnminPasssword;
                newRow[3] = item.AdminName;
                newRow[4] = item.AdminJurisdictionID;
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}