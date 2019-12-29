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
    public class WeekDaysDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;


        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static WeekDays SelectBySql(String strSql)
        {
            WeekDays model = new WeekDays();
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
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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
        public static WeekDays SelectBySql(String strSql, SqlParameter sqlParam)
        {
            WeekDays model = new WeekDays();
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
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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
        public static WeekDays SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            WeekDays model = new WeekDays();
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
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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
        public static IList<WeekDays> SelectAllBySql(string strSql)
        {
            IList<WeekDays> modelList = new List<WeekDays>();
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
                                WeekDays model = new WeekDays();
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysReason"] != DBNull.Value) model.WeekDaysReason = Convert.ToString(sdr["WeekDaysReason"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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
        public static IList<WeekDays> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<WeekDays> modelList = new List<WeekDays>();
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
                                WeekDays model = new WeekDays();
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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
        public static IList<WeekDays> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<WeekDays> modelList = new List<WeekDays>();
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
                                WeekDays model = new WeekDays();
                                if (sdr["WeekDaysID"] != DBNull.Value) model.WeekDaysID = Convert.ToInt32(sdr["WeekDaysID"]);
                                if (sdr["WeekDaysStudentID"] != DBNull.Value) model.WeekDaysStudentID = Convert.ToInt32(sdr["WeekDaysStudentID"]);
                                if (sdr["WeekDaysStartTime"] != DBNull.Value) model.WeekDaysStartTime = Convert.ToString(sdr["WeekDaysStartTime"]);
                                if (sdr["WeekDaysEndtTime"] != DBNull.Value) model.WeekDaysEndtTime = Convert.ToString(sdr["WeekDaysEndtTime"]);
                                if (sdr["WeekDaysNumDays"] != DBNull.Value) model.WeekDaysNumDays = Convert.ToString(sdr["WeekDaysNumDays"]);
                                if (sdr["WeekDaysApprover"] != DBNull.Value) model.WeekDaysApprover = Convert.ToString(sdr["WeekDaysApprover"]);
                                if (sdr["WeekDaysStage"] != DBNull.Value) model.WeekDaysStage = Convert.ToString(sdr["WeekDaysStage"]);
                                if (sdr["WeekDaysApprovalResult"] != DBNull.Value) model.WeekDaysApprovalResult = Convert.ToString(sdr["WeekDaysApprovalResult"]);
                                if (sdr["WeekDaysApprovalTime"] != DBNull.Value) model.WeekDaysApprovalTime = Convert.ToString(sdr["WeekDaysApprovalTime"]);
                                if (sdr["LeaveRecordClassNum"] != DBNull.Value) model.LeaveRecordClassNum = Convert.ToString(sdr["LeaveRecordClassNum"]);
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

        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(WeekDays model)
        {
            string strSql = "INSERT INTO [WeekDays] ([WeekDaysStudentID],[WeekDaysStartTime],[WeekDaysEndtTime],[WeekDaysNumDays],[WeekDaysReason],[WeekDaysApprover],[WeekDaysStage],[WeekDaysApprovalResult],[WeekDaysApprovalTime],[LeaveRecordClassNum]) VALUES (@WeekDaysStudentID,@WeekDaysStartTime,@WeekDaysEndtTime,@WeekDaysNumDays,@WeekDaysReason,@WeekDaysApprover,@WeekDaysStage,@WeekDaysApprovalResult,@WeekDaysApprovalTime,@LeaveRecordClassNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@WeekDaysStudentID", SqlDbType.Int,4),
                         new SqlParameter("@WeekDaysStartTime", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysEndtTime", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysNumDays", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysReason", SqlDbType.VarChar,100),
                         new SqlParameter("@WeekDaysApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@WeekDaysStage", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalTime", SqlDbType.VarChar,19),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                if (model.WeekDaysStudentID == null) { sqlCmd.Parameters["@WeekDaysStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStudentID"].Value = model.WeekDaysStudentID; }
                if (model.WeekDaysStartTime == null) { sqlCmd.Parameters["@WeekDaysStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStartTime"].Value = model.WeekDaysStartTime; }
                if (model.WeekDaysEndtTime == null) { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = model.WeekDaysEndtTime; }
                if (model.WeekDaysNumDays == null) { sqlCmd.Parameters["@WeekDaysNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysNumDays"].Value = model.WeekDaysNumDays; }
                if (model.WeekDaysReason == null) { sqlCmd.Parameters["@WeekDaysReason"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysReason"].Value = model.WeekDaysReason; }
                if (model.WeekDaysApprover == null) { sqlCmd.Parameters["@WeekDaysApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprover"].Value = model.WeekDaysApprover; }
                if (model.WeekDaysStage == null) { sqlCmd.Parameters["@WeekDaysStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStage"].Value = model.WeekDaysStage; }
                if (model.WeekDaysApprovalResult == null) { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = model.WeekDaysApprovalResult; }
                if (model.WeekDaysApprovalTime == null) { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = model.WeekDaysApprovalTime; }
                if (model.LeaveRecordClassNum == null) { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = model.LeaveRecordClassNum; }
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
        public static void Insert(WeekDays[] modelList)
        {
            string strSql = "INSERT INTO [WeekDays] ([WeekDaysStudentID],[WeekDaysStartTime],[WeekDaysEndtTime],[WeekDaysNumDays],[WeekDaysApprover],[WeekDaysStage],[WeekDaysApprovalResult],[WeekDaysApprovalTime],[LeaveRecordClassNum]) VALUES (@WeekDaysStudentID,@WeekDaysStartTime,@WeekDaysEndtTime,@WeekDaysNumDays,@WeekDaysApprover,@WeekDaysStage,@WeekDaysApprovalResult,@WeekDaysApprovalTime,@LeaveRecordClassNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@WeekDaysStudentID", SqlDbType.Int,4),
                         new SqlParameter("@WeekDaysStartTime", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysEndtTime", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysNumDays", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@WeekDaysStage", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalTime", SqlDbType.VarChar,19),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (WeekDays model in modelList)
                    {
                        if (model.WeekDaysStudentID == null) { sqlCmd.Parameters["@WeekDaysStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStudentID"].Value = model.WeekDaysStudentID; }
                        if (model.WeekDaysStartTime == null) { sqlCmd.Parameters["@WeekDaysStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStartTime"].Value = model.WeekDaysStartTime; }
                        if (model.WeekDaysEndtTime == null) { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = model.WeekDaysEndtTime; }
                        if (model.WeekDaysNumDays == null) { sqlCmd.Parameters["@WeekDaysNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysNumDays"].Value = model.WeekDaysNumDays; }
                        if (model.WeekDaysApprover == null) { sqlCmd.Parameters["@WeekDaysApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprover"].Value = model.WeekDaysApprover; }
                        if (model.WeekDaysStage == null) { sqlCmd.Parameters["@WeekDaysStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStage"].Value = model.WeekDaysStage; }
                        if (model.WeekDaysApprovalResult == null) { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = model.WeekDaysApprovalResult; }
                        if (model.WeekDaysApprovalTime == null) { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = model.WeekDaysApprovalTime; }
                        if (model.LeaveRecordClassNum == null) { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = model.LeaveRecordClassNum; }
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
        /// <param name="_WeekDaysID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByWeekDaysID(int _WeekDaysID)
        {
            string strSql = "DELETE FROM [WeekDays] WHERE [WeekDaysID]=@WeekDaysID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@WeekDaysID", SqlDbType.Int, 4) { Value = _WeekDaysID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(WeekDays model)
        {
            string strSql = "DELETE FROM [WeekDays] WHERE [WeekDaysID]=@WeekDaysID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@WeekDaysID", SqlDbType.Int, 4) { Value = model.WeekDaysID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [WeekDays]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [WeekDays] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(WeekDays model)
        {
            string strSql = "UPDATE [WeekDays] SET [WeekDaysStudentID] = ISNULL(@WeekDaysStudentID,[WeekDaysStudentID]),[WeekDaysStartTime] = ISNULL(@WeekDaysStartTime,[WeekDaysStartTime]),[WeekDaysEndtTime] = ISNULL(@WeekDaysEndtTime,[WeekDaysEndtTime]),[WeekDaysNumDays] = ISNULL(@WeekDaysNumDays,[WeekDaysNumDays]),[WeekDaysReason] = ISNULL(@WeekDaysReason,[WeekDaysReason]),[WeekDaysApprover] = ISNULL(@WeekDaysApprover,[WeekDaysApprover]),[WeekDaysStage] = ISNULL(@WeekDaysStage,[WeekDaysStage]),[WeekDaysApprovalResult] = ISNULL(@WeekDaysApprovalResult,[WeekDaysApprovalResult]),[WeekDaysApprovalTime] = ISNULL(@WeekDaysApprovalTime,[WeekDaysApprovalTime]),[LeaveRecordClassNum] = ISNULL(@LeaveRecordClassNum,[LeaveRecordClassNum]) WHERE [WeekDaysID]=@WeekDaysID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@WeekDaysID", SqlDbType.Int,4),
                         new SqlParameter("@WeekDaysStudentID", SqlDbType.Int,4),
                         new SqlParameter("@WeekDaysStartTime", SqlDbType.DateTime),
                         new SqlParameter("@WeekDaysEndtTime", SqlDbType.DateTime),
                         new SqlParameter("@WeekDaysNumDays", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysReason", SqlDbType.VarChar,100),
                         new SqlParameter("@WeekDaysApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@WeekDaysStage", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@WeekDaysApprovalTime", SqlDbType.DateTime),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                sqlCmd.Parameters["@WeekDaysID"].Value = model.WeekDaysID;
                if (model.WeekDaysStudentID == null) { sqlCmd.Parameters["@WeekDaysStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStudentID"].Value = model.WeekDaysStudentID; }
                if (model.WeekDaysStartTime == null) { sqlCmd.Parameters["@WeekDaysStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStartTime"].Value = model.WeekDaysStartTime; }
                if (model.WeekDaysEndtTime == null) { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysEndtTime"].Value = model.WeekDaysEndtTime; }
                if (model.WeekDaysNumDays == null) { sqlCmd.Parameters["@WeekDaysNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysNumDays"].Value = model.WeekDaysNumDays; }
                if (model.WeekDaysReason == null) { sqlCmd.Parameters["@WeekDaysReason"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysReason"].Value = model.WeekDaysReason; }
                if (model.WeekDaysApprover == null) { sqlCmd.Parameters["@WeekDaysApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprover"].Value = model.WeekDaysApprover; }
                if (model.WeekDaysStage == null) { sqlCmd.Parameters["@WeekDaysStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysStage"].Value = model.WeekDaysStage; }
                if (model.WeekDaysApprovalResult == null) { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalResult"].Value = model.WeekDaysApprovalResult; }
                if (model.WeekDaysApprovalTime == null) { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@WeekDaysApprovalTime"].Value = model.WeekDaysApprovalTime; }
                if (model.LeaveRecordClassNum == null) { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordClassNum"].Value = model.LeaveRecordClassNum; }
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

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<WeekDays> SelectAll()
        {
            string strSql = "SELECT * FROM [WeekDays];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [WeekDays] WHERE [WeekDaysID] NOT IN (SELECT TOP {1} [WeekDaysID] FROM [WeekDays]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [WeekDays] {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [WeekDays] WHERE ([WeekDaysID] NOT IN (SELECT TOP {1} [WeekDaysID] FROM [WeekDays] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [WeekDays] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据周六请假编号查询所有数据
        /// </summary>
        /// <param name="_WeekDaysID">周六请假编号</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysID(int _WeekDaysID)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysID]=@WeekDaysID;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysID", _WeekDaysID));
        }
        /// <summary>
        /// 根据学号查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStudentID">学号</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStudentID(int _WeekDaysStudentID)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysStudentID]=@WeekDaysStudentID;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysStudentID", _WeekDaysStudentID));
        }
        /// <summary>
        /// 根据请假开始时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStartTime">请假开始时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStartTime(string _WeekDaysStartTime)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysStartTime]=@WeekDaysStartTime;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysStartTime", _WeekDaysStartTime));
        }
        /// <summary>
        /// 根据请假结束时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysEndtTime">请假结束时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysEndtTime(string _WeekDaysEndtTime)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysEndtTime]=@WeekDaysEndtTime;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysEndtTime", _WeekDaysEndtTime));
        }
        /// <summary>
        /// 根据请假天数查询所有数据
        /// </summary>
        /// <param name="_WeekDaysNumDays">请假天数</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysNumDays(string _WeekDaysNumDays)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysNumDays]=@WeekDaysNumDays;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysNumDays", _WeekDaysNumDays));
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprover">审批人</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprover(string _WeekDaysApprover)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysApprover]=@WeekDaysApprover;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysApprover", _WeekDaysApprover));
        }
        /// <summary>
        /// 根据审批阶段查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStage">审批阶段</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStage(string _WeekDaysStage)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysStage]=@WeekDaysStage;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysStage", _WeekDaysStage));
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprovalResult(string _WeekDaysApprovalResult)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysApprovalResult]=@WeekDaysApprovalResult;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysApprovalResult", _WeekDaysApprovalResult));
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprovalTime(string _WeekDaysApprovalTime)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [WeekDaysApprovalTime]=@WeekDaysApprovalTime;";
            return SelectAllBySql(strSql, new SqlParameter("@WeekDaysApprovalTime", _WeekDaysApprovalTime));
        }
        /// <summary>
        /// 根据关联班级id查询所有数据
        /// </summary>
        /// <param name="_LeaveRecordClassNum">关联班级id</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByLeaveRecordClassNum(string _LeaveRecordClassNum)
        {
            string strSql = "SELECT * FROM [WeekDays] WHERE [LeaveRecordClassNum]=@LeaveRecordClassNum;";
            return SelectAllBySql(strSql, new SqlParameter("@LeaveRecordClassNum", _LeaveRecordClassNum));
        }

        #endregion
    }
}
