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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace leaveAPI.Controllers
{
    [ControllerGroup("登录操作")]
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
    public class LoginModuleController : ApiController
    {
        /// <summary>
        /// 学生登录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors(origins: "http://118.25.137.129:8282", headers: "*", methods: "*", SupportsCredentials = true)]
        public IHttpActionResult loginLeave([FromBody] JObject obj)
        {
            string loginNum = obj["Name"].ToString();
            AdminInfo model = AdminInfoBLL.loginLeave(obj["Name"].ToString(), MD5ToString(obj["Pwd"].ToString()));
            if (model.AdminID == 0)
            {
                return Json<dynamic>(new
                {
                    success = false,
                    result = -1,
                    message = "用户名或密码错误"
                });
            }
            else
            {
                return Json<dynamic>(new
                {
                    success = true,
                    result = 0,
                    message = JwtTool.EncodeJwt(new Dictionary<string, object>() {
                                        { "Name",model.AdminName},
                                        { "ID",model.AdminLoginID.ToString()}
                                    })
                });
            }
        }

        /// <summary>
        /// 教师登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
        public IHttpActionResult TeacherLogin([FromBody] JObject obj)
        {
            string Post = obj["Post"].ToString();
            string Name = obj["Name"].ToString();
            AdminInfo model = AdminInfoBLL.loginLeave(Name, MD5ToString(obj["Pwd"].ToString()));
            if (model.AdminID == 0)
            {
                return Json<dynamic>(new
                {
                    success = false,
                    result = -1,
                    message = "用户名或密码错误"
                });
            }
            else
            {
                return Json<dynamic>(new
                {
                    success = true,
                    result = 0,
                    message = JwtTool.EncodeJwt(new Dictionary<string, object>() {
                                        { "Name",model.AdminName},
                                        { "ID",model.AdminLoginID.ToString()}
                                    })
                });
            }
        }


        /// <summary>
        /// 学生更新密码
        /// </summary>
        /// <param name="ID">学号</param>
        /// <param name="passnew">新密码</param>
        /// <param name="Post">身份</param>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors(origins: "http://118.25.137.129:8282", headers: "*", methods: "*", SupportsCredentials = true)]
        public int upStuPwd([FromBody]JObject obj)
        {
            string pwd = MD5ToString(obj["passnew"].ToString());

            if (AdminInfoBLL.updatePwd(Convert.ToInt32(obj["ID"]), pwd) > 0)
            {
                if (StudentsBLL.updateStuPwd(pwd,Convert.ToInt32(obj["ID"].ToString())) > 0)
                {
                    return 1;
                }
            }
            return -1;
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
        [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*", SupportsCredentials = true)]
        public int sendSMS(string userID,string post)
        {
            string url = "http://utf8.api.smschinese.cn/?Uid=whitney&Key=d41d8cd98f00b204e980";
            string strRet = null;
            string phone = "";
            Random rad = new Random();
            int code = rad.Next(1000, 10000);
            if (post == "学生")
            {
                Students stu = StudentsBLL.SelectStuPhone(userID);
                phone = stu.StudentTel;
            }
            else {
                Teachers tea = TeachersBLL.SelectByTeacherNum(userID);
                phone = tea.TeacherTel;
            }
            
            if (phone == "" || phone == null)
            {
                return -7;
            }
            else
            {
                try
                {
                    url += "&smsMob='" + phone + "'&smsText=【请假通】 您的验证码为:'" + code + "',有效时间为: 10分钟,请不要把验证码泄露给其他人。如非本人操作，可不用理会！";
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
            }
            if (strRet == null || Convert.ToInt32(strRet) < 0)
            {
                return -1;
            }
            else
            {
                return code;
            }
        }


        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Post"></param>
        /// <returns></returns>
        [HttpGet]
        //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
        [TokenCheck]
        public IHttpActionResult getTeacherInfo(string Post)
        {
            string ID = ((UserIdentity)User.Identity).ID.ToString();
            string result = "{";
            if (Post == "班主任")
            {
                Class cla = ClassBLL.getBInfo(Convert.ToInt32(ID));
                if (cla != null)
                {
                    result += "\"ClassNum\":" + cla.ClassNum + ",\"ClassSpecialityID\":" + cla.ClassSpecialityID.ToString() + ",\"ClassSpecialityTeacherID\":" +
                   cla.ClassSpecialityTeacherID.ToString() + ",\"ClassHeadTeacherID\":" + cla.ClassHeadTeacherID.ToString() + ",";
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "信息获取失败"
                    });
                }


            }
            else if (Post == "辅导员")
            {
                Class cla = ClassBLL.getFInfo(Convert.ToInt32(ID));
                if (cla != null)
                {
                    result += "\"ClassNum\":" + cla.ClassNum + ",\"ClassSpecialityID\":" + cla.ClassSpecialityID.ToString() + ",\"ClassHeadTeacherID\":" +
                    cla.ClassHeadTeacherID.ToString() + ",\"ClassSpecialityTeacherID\":" + cla.ClassSpecialityTeacherID.ToString() + ",";
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "信息获取失败"
                    });
                }

            }
            else if (Post == "院领导")
            {
                College col = CollegeBLL.getColInfo(ID);
                if (col != null)
                {
                    result += "\"TeacherNum\":" + col.TeacherNum + ",\"CollegeNum\":" + col.CollegeNum + ",";
                }
                else
                {
                    return Json<dynamic>(new
                    {
                        success = false,
                        result = -1,
                        message = "信息获取失败"
                    });
                }


            }
            else
            {
                result += "\"TeacherNum\":" + ID + ",";
            }
            result += "\"Post\":\"" + Post + "\"}";

            return Json<dynamic>(new
            {
                success = true,
                result = 0,
                message = result.ToString()
            });
        }



        /// <summary>
        /// 更新教师密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        //[EnableCors(origins: "http://118.25.137.129:8181", headers: "*", methods: "*", SupportsCredentials = true)]
        public IHttpActionResult updateTeaPwd([FromBody]JObject obj)
        {
            string ID = obj["ID"].ToString();
            string passnew = obj["passnew"].ToString();
            if (AdminInfoBLL.updatePwd(Convert.ToInt32(ID), MD5ToString(passnew)) > 0)
            {
                if (TeachersBLL.updateTeaPwdbyAdmin(Convert.ToInt32(ID)) > 0)
                {
                    return Json<dynamic>(new
                    {
                        success = true,
                        result = 0,
                        message = "success"
                    });
                }
            }
            return Json<dynamic>(new
            {
                success = true,
                result = -1,
                message = "error"
            });
        }

       

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        private static string MD5ToString(String argString)
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