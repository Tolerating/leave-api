using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace leaveAPI.Content
{
    public class Tool
    {
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            //jsonBuilder.Append("{\"");
            jsonBuilder.Append("[");
            for (int i = 0, count = dt.Rows.Count; i < count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                    jsonBuilder.Replace("\n", "");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                if (i < count - 1)
                {
                    jsonBuilder.Append("},");
                }
                else
                {
                    jsonBuilder.Append("}");
                }
            }
            jsonBuilder.Append("]");
            //jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        public static string MD5ToString(String argString)
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