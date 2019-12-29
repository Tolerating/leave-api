using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdvanceDelayDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static AdvanceDelay SelectBySql(String strSql)
        {
            AdvanceDelay model = new AdvanceDelay();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                            }
                            return model;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public static AdvanceDelay SelectBySql(String strSql, SqlParameter sqlParam)
        {
            AdvanceDelay model = new AdvanceDelay();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.Add(sqlParam);
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                            }
                            return model;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static AdvanceDelay SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            AdvanceDelay model = new AdvanceDelay();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.AddRange(sqlParams);
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                            }
                            return model;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 根据SQL语句查询所有数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllBySql(string strSql)
        {
            IList<AdvanceDelay> modelList = new List<AdvanceDelay>();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                AdvanceDelay model = new AdvanceDelay();
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                                modelList.Add(model);
                            }
                            return modelList;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 根据SQL语句查询所有数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<AdvanceDelay> modelList = new List<AdvanceDelay>();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.Add(sqlParam);
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                AdvanceDelay model = new AdvanceDelay();
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                                modelList.Add(model);
                            }
                            return modelList;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 根据SQL语句查询所有数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<AdvanceDelay> modelList = new List<AdvanceDelay>();
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                using (SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn))
                {
                    sqlCmd.Parameters.AddRange(sqlParams);
                    try
                    {
                        sqlConn.Open();
                        using (SqlDataReader sdr = sqlCmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                AdvanceDelay model = new AdvanceDelay();
                                if (sdr["ZCWGID"] != DBNull.Value) model.ZCWGID = Convert.ToInt32(sdr["ZCWGID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["AdvanceTime"] != DBNull.Value) model.AdvanceTime = Convert.ToDateTime(sdr["AdvanceTime"]);
                                if (sdr["AdvanceReson"] != DBNull.Value) model.AdvanceReson = Convert.ToString(sdr["AdvanceReson"]);
                                if (sdr["AdvanceStudentT"] != DBNull.Value) model.AdvanceStudentT = Convert.ToDateTime(sdr["AdvanceStudentT"]);
                                if (sdr["DelayTime"] != DBNull.Value) model.DelayTime = Convert.ToDateTime(sdr["DelayTime"]);
                                if (sdr["DeatReson"] != DBNull.Value) model.DeatReson = Convert.ToString(sdr["DeatReson"]);
                                if (sdr["DelayStudentT"] != DBNull.Value) model.DelayStudentT = Convert.ToDateTime(sdr["DelayStudentT"]);
                                modelList.Add(model);
                            }
                            return modelList;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
        }
        #endregion



        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAll()
        {
            string strSql = "SELECT * FROM [AdvanceDelay];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [AdvanceDelay] WHERE [ZCWGID] NOT IN (SELECT TOP {1} [ZCWGID] FROM [AdvanceDelay]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [AdvanceDelay] {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [AdvanceDelay] WHERE ([ZCWGID] NOT IN (SELECT TOP {1} [ZCWGID] FROM [AdvanceDelay] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [AdvanceDelay] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据ZCWGID查询所有数据
        /// </summary>
        /// <param name="_ZCWGID">ZCWGID</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByZCWGID(int _ZCWGID)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [ZCWGID]=@ZCWGID;";
            return SelectAllBySql(strSql, new SqlParameter("@ZCWGID", _ZCWGID));
        }

        /// <summary>
        /// 根据学生班级ID查询所有数据
        /// </summary>
        /// <param name="_ClassNum">学生班级ID</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByClassNum(string _ClassNum)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [ClassNum]=@ClassNum;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassNum", _ClassNum));
        }
        /// <summary>
        /// 根据早出请假时间查询所有数据
        /// </summary>
        /// <param name="_AdvanceTime">早出请假时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceTime(DateTime _AdvanceTime)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [AdvanceTime]=@AdvanceTime;";
            return SelectAllBySql(strSql, new SqlParameter("@AdvanceTime", _AdvanceTime));
        }
        /// <summary>
        /// 根据早出理由查询所有数据
        /// </summary>
        /// <param name="_AdvanceReson">早出理由</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceReson(string _AdvanceReson)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [AdvanceReson]=@AdvanceReson;";
            return SelectAllBySql(strSql, new SqlParameter("@AdvanceReson", _AdvanceReson));
        }
        /// <summary>
        /// 根据学生早出时间查询所有数据
        /// </summary>
        /// <param name="_AdvanceStudentT">学生早出时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceStudentT(DateTime _AdvanceStudentT)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [AdvanceStudentT]=@AdvanceStudentT;";
            return SelectAllBySql(strSql, new SqlParameter("@AdvanceStudentT", _AdvanceStudentT));
        }
        /// <summary>
        /// 根据晚归请假时间查询所有数据
        /// </summary>
        /// <param name="_DelayTime">晚归请假时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDelayTime(DateTime _DelayTime)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [DelayTime]=@DelayTime;";
            return SelectAllBySql(strSql, new SqlParameter("@DelayTime", _DelayTime));
        }
        /// <summary>
        /// 根据晚归理由查询所有数据
        /// </summary>
        /// <param name="_DeatReson">晚归理由</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDeatReson(string _DeatReson)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [DeatReson]=@DeatReson;";
            return SelectAllBySql(strSql, new SqlParameter("@DeatReson", _DeatReson));
        }
        /// <summary>
        /// 根据学生晚归时间查询所有数据
        /// </summary>
        /// <param name="_DelayStudentT">学生晚归时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDelayStudentT(DateTime _DelayStudentT)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [DelayStudentT]=@DelayStudentT;";
            return SelectAllBySql(strSql, new SqlParameter("@DelayStudentT", _DelayStudentT));
        }
        #endregion


        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(AdvanceDelay model)
        {
            string strSql = "INSERT INTO [AdvanceDelay] ([StudentNum],[ClassNum],[AdvanceTime],[AdvanceReson],[AdvanceStudentT],[DelayTime],[DeatReson],[DelayStudentT]) VALUES (@StudentNum,@ClassNum,@AdvanceTime,@AdvanceReson,@AdvanceStudentT,@DelayTime,@DeatReson,@DelayStudentT);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@AdvanceTime", SqlDbType.DateTime),
                         new SqlParameter("@AdvanceReson", SqlDbType.VarChar,50),
                         new SqlParameter("@AdvanceStudentT", SqlDbType.DateTime),
                         new SqlParameter("@DelayTime", SqlDbType.DateTime),
                         new SqlParameter("@DeatReson", SqlDbType.VarChar,50),
                         new SqlParameter("@DelayStudentT", SqlDbType.DateTime)
                     }
                 );
                if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                if (model.AdvanceTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceTime"].Value = model.AdvanceTime; }
                if (model.AdvanceReson == null) { sqlCmd.Parameters["@AdvanceReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceReson"].Value = model.AdvanceReson; }
                if (model.AdvanceStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceStudentT"].Value = model.AdvanceStudentT; }
                if (model.DelayTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayTime"].Value = model.DelayTime; }
                if (model.DeatReson == null) { sqlCmd.Parameters["@DeatReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DeatReson"].Value = model.DeatReson; }
                if (model.DelayStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayStudentT"].Value = model.DelayStudentT; }
                try
                {
                    sqlConn.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 批量插入记录
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(AdvanceDelay[] modelList)
        {
            string strSql = "INSERT INTO [AdvanceDelay] ([StudentNum],[ClassNum],[AdvanceTime],[AdvanceReson],[AdvanceStudentT],[DelayTime],[DeatReson],[DelayStudentT]) VALUES (@StudentNum,@ClassNum,@AdvanceTime,@AdvanceReson,@AdvanceStudentT,@DelayTime,@DeatReson,@DelayStudentT);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@AdvanceTime", SqlDbType.DateTime),
                         new SqlParameter("@AdvanceReson", SqlDbType.VarChar,50),
                         new SqlParameter("@AdvanceStudentT", SqlDbType.DateTime),
                         new SqlParameter("@DelayTime", SqlDbType.DateTime),
                         new SqlParameter("@DeatReson", SqlDbType.VarChar,50),
                         new SqlParameter("@DelayStudentT", SqlDbType.DateTime)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (AdvanceDelay model in modelList)
                    {
                        if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                        if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                        if (model.AdvanceTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceTime"].Value = model.AdvanceTime; }
                        if (model.AdvanceReson == null) { sqlCmd.Parameters["@AdvanceReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceReson"].Value = model.AdvanceReson; }
                        if (model.AdvanceStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceStudentT"].Value = model.AdvanceStudentT; }
                        if (model.DelayTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayTime"].Value = model.DelayTime; }
                        if (model.DeatReson == null) { sqlCmd.Parameters["@DeatReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DeatReson"].Value = model.DeatReson; }
                        if (model.DelayStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayStudentT"].Value = model.DelayStudentT; }
                        sqlCmd.ExecuteNonQuery();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_ZCWGID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByZCWGID(int _ZCWGID)
        {
            string strSql = "DELETE FROM [AdvanceDelay] WHERE [ZCWGID]=@ZCWGID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@ZCWGID", SqlDbType.Int, 4) { Value = _ZCWGID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(AdvanceDelay model)
        {
            string strSql = "DELETE FROM [AdvanceDelay] WHERE [ZCWGID]=@ZCWGID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@ZCWGID", SqlDbType.Int, 4) { Value = model.ZCWGID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [AdvanceDelay]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [AdvanceDelay] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(AdvanceDelay model)
        {
            string strSql = "UPDATE [AdvanceDelay] SET [StudentNum] = ISNULL(@StudentNum,[StudentNum]),[ClassNum] = ISNULL(@ClassNum,[ClassNum]),[AdvanceTime] = ISNULL(@AdvanceTime,[AdvanceTime]),[AdvanceReson] = ISNULL(@AdvanceReson,[AdvanceReson]),[AdvanceStudentT] = ISNULL(@AdvanceStudentT,[AdvanceStudentT]),[DelayTime] = ISNULL(@DelayTime,[DelayTime]),[DeatReson] = ISNULL(@DeatReson,[DeatReson]),[DelayStudentT] = ISNULL(@DelayStudentT,[DelayStudentT]) WHERE [ZCWGID]=@ZCWGID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@ZCWGID", SqlDbType.Int,4),
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@AdvanceTime", SqlDbType.DateTime),
                         new SqlParameter("@AdvanceReson", SqlDbType.VarChar,50),
                         new SqlParameter("@AdvanceStudentT", SqlDbType.DateTime),
                         new SqlParameter("@DelayTime", SqlDbType.DateTime),
                         new SqlParameter("@DeatReson", SqlDbType.VarChar,50),
                         new SqlParameter("@DelayStudentT", SqlDbType.DateTime)
                     }
                 );
                sqlCmd.Parameters["@ZCWGID"].Value = model.ZCWGID;
                if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                if (model.AdvanceTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceTime"].Value = model.AdvanceTime; }
                if (model.AdvanceReson == null) { sqlCmd.Parameters["@AdvanceReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceReson"].Value = model.AdvanceReson; }
                if (model.AdvanceStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@AdvanceStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdvanceStudentT"].Value = model.AdvanceStudentT; }
                if (model.DelayTime.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayTime"].Value = model.DelayTime; }
                if (model.DeatReson == null) { sqlCmd.Parameters["@DeatReson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DeatReson"].Value = model.DeatReson; }
                if (model.DelayStudentT.ToString() == "0001/1/1 0:00:00") { sqlCmd.Parameters["@DelayStudentT"].Value = DBNull.Value; } else { sqlCmd.Parameters["@DelayStudentT"].Value = model.DelayStudentT; }
                try
                {
                    sqlConn.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
        #endregion

        /// <summary>
        /// 根据学生学号查询所有数据
        /// </summary>
        /// <param name="_StudentNum">学生学号</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByStudentNum(string _StudentNum)
        {
            string strSql = "SELECT * FROM [AdvanceDelay] WHERE [StudentNum]=@StudentNum;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentNum", _StudentNum));
        }
    }
}
