using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections;
using System.IO;
using System.Data;
using System.Web.Script.Serialization;
namespace BLL
{
    public class Helper
    {
        /// <summary>
        /// 对象转为Json
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">对象</param>
        /// <returns>对象对应的Json值</returns>
        public static string ObjToJson<T>(T data)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(data.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.WriteObject(ms, data);
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch
            {
                return null;
            }
        }
        public static T JsonToObj<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
                return (T)dcj.ReadObject(ms);
            }
        }
        /// <summary>序列化方法
        /// 不需要分页
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="flag">false</param>
        /// <returns></returns>
        public static string Serialize(DataTable dt, bool flag)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                foreach (DataColumn dc in dt.Columns)
                {
                    result.Add(dc.ColumnName, dr[dc].ToString());
                }
                list.Add(result);
            }
            return serializer.Serialize(list); ;
        }
    }
}
