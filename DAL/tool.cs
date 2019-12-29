using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Net;
using System.IO;
using System.Threading;
using System.IO.Compression;
using Excel = Microsoft.Office.Interop.Excel;
namespace DAL
{

    public class tool
    {
        /// <summary>
        /// 数据库连接字
        /// </summary>
        private static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region strSql server tool
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>受影响的行数。</returns>
        public static int ExecuteNonQuery(string strSql)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlConn.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParam"></param>
        /// <returns>受影响的行数。</returns>
        public static int ExecuteNonQuery(string strSql, SqlParameter sqlParam)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.Add(sqlParam);
                    sqlConn.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns>受影响的行数。</returns>
        public static int ExecuteNonQuery(string strSql, params SqlParameter[] sqlParams)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.AddRange(sqlParams);
                    sqlConn.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public static object ExecuteScalar(string strSql)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlConn.Open();
                    return sqlCmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParam"></param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public static object ExecuteScalar(string strSql, SqlParameter sqlParam)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.Add(sqlParam);
                    sqlConn.Open();
                    return sqlCmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public static object ExecuteScalar(string strSql, params SqlParameter[] sqlParams)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.AddRange(sqlParams);
                    sqlConn.Open();
                    return sqlCmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static DataTable Select(string strSql)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sqlConn.Open();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public static DataTable Select(string strSql, SqlParameter sqlParam)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn))
                {
                    sda.SelectCommand.Parameters.Add(sqlParam);
                    using (DataTable dt = new DataTable())
                    {
                        sqlConn.Open();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataTable Select(string strSql, params SqlParameter[] sqlParams)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(strSql, sqlConn))
                {
                    sda.SelectCommand.Parameters.AddRange(sqlParams);
                    using (DataTable dt = new DataTable())
                    {
                        sqlConn.Open();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static int update(string strSql)
        {
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlConn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 大块方式批量插入记录
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strTableName"></param>
        public static void BulkToDB(DataTable dt, string strTableName)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            SqlConnection sqlConn = new SqlConnection(strConn);
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sqlConn);
            sqlBulkCopy.DestinationTableName = strTableName;
            sqlBulkCopy.BatchSize = dt.Rows.Count;
            try
            {
                sqlConn.Open();
                sqlBulkCopy.WriteToServer(dt);
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                if (sqlBulkCopy != null) sqlBulkCopy.Close();
            }
        }
        /// <summary>
        /// 表值型参数方式批量插入记录
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strSql">INSERT INTO 表名 (name,pwd) SELECT nc.name,nc.pwd FROM @参数名 AS nc</param>
        /// <param name="strParam">@参数名</param>
        /// <param name="strTypeName">dbo.TypeName(表值型)</param>
        public static void TableValuedToDB(DataTable dt, string strSql, string strParam, string strTypeName)
        {
            if (dt == null || dt.Rows.Count == 0) return;
            SqlConnection sqlConn = new SqlConnection(strConn);
            SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
            SqlParameter sqlParam = sqlCmd.Parameters.AddWithValue(strParam, dt);
            sqlParam.SqlDbType = SqlDbType.Structured;
            sqlParam.TypeName = strTypeName;
            try
            {
                sqlConn.Open();
                sqlCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConn.Close(); sqlConn.Dispose();
            }
        }
        #endregion

        #region Excel
        /// <summary>
        ///  Excel转化为DataTable
        /// </summary>
        /// <param name="strFilePath">文件的路径（要求绝对路径）</param>
        /// <param name="strHDR">第一行是否标题（Yes/No）</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public static DataTable ExcelToDT(string strFilePath, string strHDR, string strTableName)
        {
            string strConn = string.Empty;
            string strExt = strFilePath.Substring(strFilePath.LastIndexOf(".") + 1).ToLower();
            if (strExt == "xls")
            {
                strConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};" + "Extended Properties='Excel 8.0;HDR={1};IMEX=1';", strFilePath, strHDR);
            }
            else if (strExt == "xlsx")
            {
                strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1};IMEX=1';", strFilePath, strHDR);
            }
            else
            {
                return null;
            }
            OleDbConnection sqlConn = new OleDbConnection(strConn);
            try
            {
                sqlConn.Open();
                string strSQL = string.Format("SELECT * FROM [{0}$];", strTableName);
                DataTable dt = new DataTable();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strSQL, strConn);
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                sqlConn.Close(); sqlConn.Dispose();
            }
        }
        #endregion

        #region json
        /// <summary>
        /// Json转对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToObj<T>(string json)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }
        /// <summary>
        /// 对象转JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string ObjToJson<T>(T data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(data);
        }
        /// <summary>  
        /// dataTable转换成Json格式
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTableToJson(DataTable dt)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");
            int rowsCount = dt.Rows.Count, columnsCount = dt.Columns.Count;
            for (int i = 0, count = rowsCount; i < count; i++)
            {
                json.Append("{");
                for (int j = 0; j < columnsCount; j++)
                {
                    json.Append("\"");
                    json.Append(dt.Columns[j].ColumnName);
                    json.Append("\":\"");
                    json.Append(dt.Rows[i][j].ToString());
                    json.Append("\",");
                }
                json.Remove(json.Length - 1, 1);
                if (i < count - 1) { json.Append("},"); }
                else { json.Append("}"); }
            }
            json.Append("]");
            return json.ToString();
        }
        /// <summary>
        /// dataTable转换成Json格式
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="flag">false</param>
        /// <returns></returns>
        public static string SerializeDataTable(DataTable dt)
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
        #endregion

        #region tool
        /// <summary>
        /// 将Unicode编码转换为汉字,支持英文数字等字符串和Unicode编码字符串混合  
        /// </summary>  
        /// <param name="str">含有Unicode编码字符串</param>  
        /// <returns>汉字字符串</returns>
        public static string UniToGB(string str)
        {
            StringBuilder StrGb = new StringBuilder(str);
            string r;
            MatchCollection mc = Regex.Matches(str, @"\\u([\w]{2})([\w]{2})", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            byte[] bts = new byte[2];
            if (mc.Count != 0)
            {
                foreach (Match m in mc)
                {
                    bts[0] = (byte)int.Parse(m.Groups[2].Value, NumberStyles.HexNumber);
                    bts[1] = (byte)int.Parse(m.Groups[1].Value, NumberStyles.HexNumber);
                    r = Encoding.Unicode.GetString(bts);//Unicode转为汉字
                    StrGb.Replace(m.Groups[0].Value, r);
                }
                return StrGb.ToString();
            }
            else
            {
                return str;
            }
        }
        /// <summary>
        /// Datatable转ObjectList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> DTToObj<T>(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0) return null;
            int i;

            List<T> modelList = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                i = 0;
                //因为T没有new,故用Activator.CreateInstance<T>()
                string tempName = string.Empty;
                T model = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfos = model.GetType().GetProperties();
                foreach (PropertyInfo proInfo in propertyInfos)
                {
                    if (i < 9)
                    {
                        if (proInfo != null && dr[i] != DBNull.Value)
                        {
                            try
                            {
                                proInfo.SetValue(model, dr[i].ToString(), null);
                            }
                            catch
                            {
                                proInfo.SetValue(model, int.Parse(dr[i].ToString()), null);
                            }
                            //proInfo.SetValue(model,dr[i],null);
                        }
                        i++;
                    }
                }
                modelList.Add(model);

            }
            return modelList;
        }
        #endregion

        #region http
        public static string http_post(string url, string data)
        {
            string strResponse = string.Empty;
            HttpWebRequest hwrRequest = (HttpWebRequest)WebRequest.Create(url);
            hwrRequest.Method = "POST";
            hwrRequest.Referer = url;
            hwrRequest.ContentType = "application/x-www-form-urlencoded";
            hwrRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.75 Safari/537.36";
            hwrRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            hwrRequest.Headers.Add("Accept-Encoding: gzip, deflate");
            hwrRequest.Headers.Add("Accept-Language: zh-CN,zh;q=0.8");
            byte[] bytesResponse = Encoding.UTF8.GetBytes(data);
            try
            {
                hwrRequest.GetRequestStream().Write(bytesResponse, 0, bytesResponse.Length);
                using (HttpWebResponse hwpResponse = (HttpWebResponse)hwrRequest.GetResponse())
                {
                    using (StreamReader srResponse = new StreamReader(hwpResponse.GetResponseStream()))
                    {
                        strResponse = srResponse.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
            return strResponse;
        }
        public static string http_get(string url)
        {
            string strResponse = string.Empty;
            HttpWebRequest hwrRequest = (HttpWebRequest)WebRequest.Create(url);
            hwrRequest.Method = "GET";
            hwrRequest.Referer = url;
            hwrRequest.ContentType = "application/x-www-form-urlencoded";
            hwrRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.75 Safari/537.36";
            hwrRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            hwrRequest.Headers.Add("Accept-Encoding: gzip, deflate");
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)hwrRequest.GetResponse())
                {
                    using (StreamReader srResponse = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)))
                    {
                        strResponse = srResponse.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
            return strResponse;
        }
        public static string http_get(string url, string encoding)
        {
            string strResponse = string.Empty;
            HttpWebRequest hwrRequest = (HttpWebRequest)WebRequest.Create(url);
            hwrRequest.Method = "GET";
            hwrRequest.Referer = url;
            hwrRequest.ContentType = "application/x-www-form-urlencoded";
            hwrRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.75 Safari/537.36";
            hwrRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            hwrRequest.Headers.Add("Accept-Encoding: gzip, deflate");
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)hwrRequest.GetResponse())
                {
                    using (StreamReader srResponse = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress), Encoding.GetEncoding(encoding)))
                    {
                        strResponse = srResponse.ReadToEnd();
                    }
                }
            }
            catch
            {
                throw;
            }
            return strResponse;
        }
        #endregion

        #region 提示框
        /// <summary>
        /// 提示框
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        public static void Message(string strMsg)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');</script>", strMsg));
        }
        /// <summary>
        /// 提示框、页面跳转
        /// </summary>
        /// <param name="strMsg">提示信息</param>
        /// <param name="strUrl">跳转到的URL</param>
        public static void Message(string strMsg, string strUrl)
        {
            HttpContext.Current.Response.Write(string.Format("<script>alert('{0}');location.href='{1}';</script>", strMsg, strUrl));
        }
        #endregion

        #region 定时事件
        public static void TimedEvents()
        {
            DateTime DT = DateTime.Now;
            string timeone = DT.AddDays(0).ToShortDateString();
            string timetwo = DT.AddDays(1).ToShortDateString();
            int Year = DT.Year;
            if (DT.Month < 9)
            {
                Year = Year - 1;
            }
            Year = Year % 1000;
            int Res = 3;
            while (Res >= 0)
            {
                Res--;
                string sql = "select * from  Students where StudentNum like '" + (Year - Res) + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, strConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string sqlone = "select count(*) from WeekDays where WeekDaysStudentID=" + dr[1] + " and (WeekDaysStartTime='" + timeone + "' or  WeekDaysStartTime='" + timetwo + "'  )";
                    SqlConnection conn = new SqlConnection(strConn);
                    try
                    {
                        conn.Open();
                        SqlCommand comm = new SqlCommand(sqlone, conn);
                        string number = comm.ExecuteScalar().ToString();
                        if (number == "0")
                        {
                            string sqltwo = "insert into WeekDays(WeekDaysStudentID,WeekDaysStartTime,WeekDaysEndtTime,WeekDaysNumDays,WeekDaysStage,WeekDaysApprovalResult,WeekDaysApprovalTime,LeaveRecordClassNum) values('" + dr[1] + "','" + timeone + "','2000-1-1','0','1','未审核','1900-1-1','" + dr[6] + "')";
                            SqlCommand commed = new SqlCommand(sqltwo, conn);
                            int i = commed.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }


            }

        }

        #endregion
    }
}
