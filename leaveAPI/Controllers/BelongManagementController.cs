using BLL;
using DAL;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace leaveAPI.Controllers
{
    [ControllerGroup("所属管理")]
    //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class BelongManagementController : ApiController
    {

        #region 班级管理


        /// <summary>
        /// 查询班级情况
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public string selectClass()
        {
            string strJson = "";
            strJson = "[";
            JArray clas = JArray.Parse(Helper.ObjToJson<List<Class>>(ClassBLL.SelectAllByCondition("IsDelete = 0") as List<Class>));
            foreach (JToken item in clas)
            {
                Teachers classTeacher = TeachersBLL.SelectTeaPhone(item["ClassHeadTeacherID"].ToString());
                Teachers speTeacher = TeachersBLL.SelectTeaPhone(item["ClassSpecialityTeacherID"].ToString());
                Specialty spe = SpecialtyBLL.SelectBySpecialtyNum(item["ClassSpecialityID"].ToString());
                if (spe == null || classTeacher == null || speTeacher == null)
                {
                    continue;
                }
                else
                {
                    strJson += "{\"ClassID\":\"" + item["ClassID"].ToString() + "\",\"ClassName\":\""
                    + item["ClassName"].ToString() + "\",\"ClassSpecialityID\":\"" + item["ClassSpecialityID"].ToString()
                    + "\",\"ClassHeadTeacherID\":\"" + item["ClassHeadTeacherID"].ToString().Substring(0, item["ClassHeadTeacherID"].ToString().Length - 1) + "\",\"ClassNum\":\""
                    + item["ClassNum"].ToString() + "\",\"classTeacherName\":\"" + classTeacher.TeacherName.ToString() + "\",\"ClassSpecialityTeacherID\":\"" + item["ClassSpecialityTeacherID"].ToString().Substring(0, item["ClassSpecialityTeacherID"].ToString().Length - 1) + "\","
                    + "\"speTeacherName\":\"" + speTeacher.TeacherName.ToString() + "\",\"SpecialtyName\":\"" + spe.SpecialtyName.ToString() + "\"},";
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
            return strJson.ToString();
        }



        /// <summary>
        /// 删除班级
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public int deleteClass(int ClassID)
        {
            return tool.ExecuteNonQuery(string.Format("UPDATE [Class] SET IsDelete = 1 WHERE [ClassID]={0};", ClassID));
        }


        /// <summary>
        /// 修改班级
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public IHttpActionResult updateClass(string ClassHeadTeacherID, string ClassHeadTeacherName, string ClassSpeTeacherID, int ClassID)
        {
            Class head = ClassBLL.SelectByClassHeadTeacherID(Convert.ToInt32(ClassHeadTeacherID));
            if (head.ClassID != 0)
            {
                if (head.ClassID == ClassID)
                {
                    int up = tool.ExecuteNonQuery(string.Format("update [Class] set ClassSpecialityTeacherID={0}, ClassHeadTeacherID={1} WHERE ClassID={2};", ClassSpeTeacherID, ClassHeadTeacherID, ClassID));
                    if (up > 0)
                    {
                        return Json<dynamic>(new
                        {
                            success = true,
                            result = 0,
                            message = "修改成功"
                        });
                    }
                    else
                    {
                        return Json<dynamic>(new
                        {
                            success = false,
                            result = -1,
                            message = "修改失败"
                        });
                    }
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -2,
                        message = ClassHeadTeacherName + "教师已经注册" + head.ClassName
                    });
                }
            }
            else {
                int up = tool.ExecuteNonQuery(string.Format("update [Class] set ClassSpecialityTeacherID={0}, ClassHeadTeacherID={1} WHERE ClassID={2};", ClassSpeTeacherID, ClassHeadTeacherID, ClassID));
                if (up > 0)
                {
                    return Json<dynamic>(new
                    {
                        success = true,
                        result = 0,
                        message = "修改成功"
                    });
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "修改失败"
                    });
                }
            }
            
        }
        



        /// <summary>
        /// 班级管理插入
        /// </summary>
        /// <returns>json</returns>
        [HttpPost]
        public int insertClass([FromBody] JObject obj)
        {
            int re = -1;
            int ClassHeadTeacherID = (int)obj["ClassHeadTeacherID"];
            if (ClassBLL.SelectCountByCondition("ClassNum =" + obj["ClassNum"].ToString()) == 0)
            {
                if (TeachersBLL.SelectCountByCondition("TeacherNum =" + ClassHeadTeacherID) != 0)//查询教师表中是否存在当前教师工号
                {
                    if (ClassBLL.SelectCountByCondition("ClassHeadTeacherID =" + ClassHeadTeacherID) == 0)//查看教师工号是否以已经注册班级
                    {
                        Class Cla = new Class();
                        Cla.ClassHeadTeacherID = ClassHeadTeacherID;
                        Cla.ClassName = obj["ClassName"].ToString();
                        Cla.ClassSpecialityID = (int)obj["ClassSpecialityID"];
                        Cla.ClassNum = obj["ClassNum"].ToString();
                        Cla.ClassSpecialityTeacherID = Convert.ToInt32(obj["speTeacherID"]);
                        Cla.IsDelete = 0;
                        if (ClassBLL.Insert(Cla) == 1)
                        {
                            re = 1;
                        }
                        else { re = -1; }
                    }
                    else { re = -3; }

                }
                else { re = -2; }

            }
            else { re = -4; }

            return re;//-2查询不到教师,-1插入失败,1插入成功,-3班主任工号已经注册班级,-4班级号已经注册(添加)

        }

        /// <summary>
        /// 查询所有的班主任
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string SelectTeacherInfoClass()
        {
            IList<Teachers> TS = TeachersBLL.SelectAllByPost("班主任");
            string strJson = "";
            strJson = "[";
            foreach (Teachers ts in TS)
            {
                strJson += "{\"TeacherNum\":\"" + ts.TeacherNum + "\",\"TeacherName\":\""
                    + ts.TeacherName + "\"},";
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
        /// 查询所有的辅导员
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string SelectTeacherInfoSpe()
        {
            IList<Teachers> TS = TeachersBLL.SelectAllByPost("辅导员");
            string strJson = "";
            strJson = "[";
            foreach (Teachers ts in TS)
            {
                strJson += "{\"TeacherNum\":\"" + ts.TeacherNum + "\",\"TeacherName\":\""
                    + ts.TeacherName + "\"},";
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

        #endregion

        #region 专业管理

        /// <summary>
        /// 查询专业情况
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public string selectSpecialty()
        {
            string strJson = "";
            strJson = "[";
            JArray spes = JArray.Parse(Helper.ObjToJson<List<Specialty>>(SpecialtyBLL.SelectAllByCondition("IsDelete = 0") as List<Specialty>));
            foreach (JToken item in spes)
            {
                College col = CollegeBLL.SelectALLbyCollegeNum(item["SpecialtyCollegeID"].ToString());
                if (col == null)
                {
                    continue;
                }
                else
                {
                    strJson += "{\"SpecialtyID\":\"" + item["SpecialtyID"].ToString() + "\",\"SpecialtyName\":\""
                                + item["SpecialtyName"].ToString() + "\",\"SpecialtyCollegeID\":\"" + item["SpecialtyCollegeID"].ToString()
                                + "\",\"SpecialtyNum\":\"" + item["SpecialtyNum"].ToString() + "\",\"CollegeName\":\"" + col.CollegeName.ToString() + "\"},";
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
            return strJson.ToString();
        }

        /// <summary>
        /// 删除专业
        /// </summary>
        /// <returns>json</returns>
        [HttpGet]
        public int deleteSpecialty(int SpecialtyID,int SpecialtyNum)
        {
            Class cla = ClassBLL.SelectByClassSpecialityID(SpecialtyNum);
            if (cla.ClassName != null)
            {
                return -1;
            }
            return tool.ExecuteNonQuery(string.Format("UPDATE [Specialty] SET IsDelete = 1 WHERE [SpecialtyID]={0};", SpecialtyID));
        }


        /// <summary>
        /// 添加专业
        /// </summary>
        /// <param name="TeacherId"></param>
        /// <returns>string</returns>
        [HttpGet]
        public string addSpecialty(string collegeID, string ClassSpecialityName, string ClassSpecialityID)
        {
            Specialty spName = SpecialtyBLL.SelectBySpecialtyName(ClassSpecialityName);
            if (spName.SpecialtyNum != null)
            {
                return "6";
            }
            Specialty spec = SpecialtyBLL.SelectBySpecialtyNum((collegeID + ClassSpecialityID));
            if (spec.SpecialtyName != null)
            {
                return "2";
            }
            else
            {
                Specialty specialtyTwo = new Specialty();
                specialtyTwo.SpecialtyName = ClassSpecialityName;
                specialtyTwo.SpecialtyCollegeID = Convert.ToInt32(collegeID);
                specialtyTwo.SpecialtyNum = (collegeID + ClassSpecialityID);
                specialtyTwo.IsDelete = 0;
                int i = SpecialtyBLL.Insert(specialtyTwo);
                if (i > 0)
                {
                    return "5";
                }
                else
                {
                    return "3";
                }
            }
        }

        /// <summary>
        /// 下载 学院命名规则
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage downloadNamingRules()
        {
            var path = HttpContext.Current.Server.MapPath("~/Content/ExcelModule/学院专业编号命名规则.docx"); ;
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

        #region 学院管理
        /// <summary>
        /// 学院信息（管理/ALL）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string CollegeManagerInfo()
        {
            IList<College> Colleges = CollegeBLL.SelectAllByCondition("IsDelete = 0");
            string strJson = "[";
            foreach (College one in Colleges)
            {
                string Name = "暂无院领导";
                if (one.TeacherNum != "")
                {
                    Teachers T = TeachersBLL.SelectTeaPhone(one.TeacherNum);
                    Name = T.TeacherName;
                    if (Name == "")
                    {
                        Name = "暂无院领导";
                    }
                }
                strJson += "{\"Num\":\"" + one.CollegeID + "\",\"CollegeNum\":\"" + one.CollegeNum + "\",\"CollegeName\":\"" + one.CollegeName + "\",\"TeacherNum\":\"" + one.TeacherNum.Substring(0, one.TeacherNum.Length - 1) + "\",\"TeacherName\":\"" + Name + "\"},";
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

        [HttpGet]
        public string CollegeOneInfo(string CollegeNum)
        {
            string strJson = "[";
            College one = CollegeBLL.SelectByCollegeID(Convert.ToInt32(CollegeNum));
            string Name = "暂无院领导";
            if (one.TeacherNum != null)
            {
                Teachers T = TeachersBLL.SelectTeaPhone(one.TeacherNum);
                Name = T.TeacherName;
                if (Name == "")
                {
                    Name = "暂无院领导";
                }
            }
            strJson += "{\"Num\":\"" + one.CollegeID + "\",\"CollegeNum\":\"" + one.CollegeNum.ToString() + "\",\"CollegeName\":\"" + one.CollegeName + "\",\"TeacherName\":\"" + Name + "\"},";
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
        /// 删除学院
        /// </summary>
        /// <param name="CollegeNum">学院ID</param>
        /// <returns></returns>
        [HttpGet]
        public string CollegeDelete(string CollegeNum)
        {
            College co = CollegeBLL.SelectByCollegeID(Convert.ToInt32(CollegeNum));
            if (co.TeacherNum != null)
            {
                return "0";
            }
            else
            {
                Specialty spe = SpecialtyBLL.SelectBySpecialtyCollegeID(Convert.ToInt32(co.CollegeNum));
                if (spe.SpecialtyName != null)
                {
                    return "0";
                }
                else
                {
                    //int I = CollegeBLL.DeleteByCollegeID(Convert.ToInt32(CollegeNum));
                    int I = tool.ExecuteNonQuery(string.Format("UPDATE [College] SET IsDelete = 1 WHERE [CollegeID]={0};", CollegeNum));
                    if (I > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "-1";
                    }
                }
            }
        }

        /// <summary>
        /// 院领导查询
        /// </summary>
        /// <returns>工号+姓名</returns>
        [HttpGet]
        public string CollegeBossInfo()
        {
            IList<Teachers> T_Co = TeachersBLL.SelectAllByPost("院领导");
            string strJson = "[";
            foreach (Teachers T in T_Co)
            {
                strJson += "{\"TeacherID\":\"" + T.TeacherNum + "\",\"TeacherName\":\"" + T.TeacherName + "\"},";
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
        /// 更新学院信息
        /// </summary>
        /// <param name="CollegeNum"></param>
        /// <param name="TeacherNum"></param>
        /// <param name="CollegeBoss"></param>
        /// <returns></returns>
        [HttpGet]
        public string UpdateCollegeInfo(string CollegeID, string CollegeName, string TeacherNum)
        {
            College Col = CollegeBLL.SelectByCollegeID(Convert.ToInt32(CollegeID));
            College Col_T = CollegeBLL.SelectByTeacherNum(TeacherNum);
            if (TeacherNum == "1000")
            {
                Col.TeacherNum = "";
            }
            else
            {
                Col.TeacherNum = TeacherNum;
            }
            if (Col_T.CollegeName != null)
            {
                if (Col_T.CollegeID.ToString() == CollegeID)
                {
                    Col.CollegeName = CollegeName;
                    if (CollegeBLL.Update(Col) > 0)
                    {
                        return "1";
                    }
                    else
                    {
                        return "2";
                    }
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                Col.CollegeName = CollegeName;
                if (CollegeBLL.Update(Col) > 0)
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }


        }

        #endregion
    }
}