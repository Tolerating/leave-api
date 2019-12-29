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
    public class LeaveRecordDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static LeaveRecord SelectBySql(String strSql)
        {
            LeaveRecord model = new LeaveRecord();
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
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static LeaveRecord SelectBySql(String strSql, SqlParameter sqlParam)
        {
            LeaveRecord model = new LeaveRecord();
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
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static LeaveRecord SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            LeaveRecord model = new LeaveRecord();
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
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static IList<LeaveRecord> SelectAllBySql(string strSql)
        {
            IList<LeaveRecord> modelList = new List<LeaveRecord>();
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
                                LeaveRecord model = new LeaveRecord();
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static IList<LeaveRecord> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<LeaveRecord> modelList = new List<LeaveRecord>();
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
                                LeaveRecord model = new LeaveRecord();
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static IList<LeaveRecord> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<LeaveRecord> modelList = new List<LeaveRecord>();
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
                                LeaveRecord model = new LeaveRecord();
                                if (sdr["LeaveRecordID"] != DBNull.Value) model.LeaveRecordID = Convert.ToInt32(sdr["LeaveRecordID"]);
                                if (sdr["LeaveRecordStudentID"] != DBNull.Value) model.LeaveRecordStudentID = Convert.ToInt32(sdr["LeaveRecordStudentID"]);
                                if (sdr["LeaveRecordReason"] != DBNull.Value) model.LeaveRecordReason = Convert.ToString(sdr["LeaveRecordReason"]);
                                if (sdr["LeaveRecordStartTime"] != DBNull.Value) model.LeaveRecordStartTime = Convert.ToString(sdr["LeaveRecordStartTime"]);
                                if (sdr["LeaveRecordEndtTime"] != DBNull.Value) model.LeaveRecordEndtTime = Convert.ToString(sdr["LeaveRecordEndtTime"]);
                                if (sdr["LeaveRecordStartLesson"] != DBNull.Value) model.LeaveRecordStartLesson = Convert.ToInt32(sdr["LeaveRecordStartLesson"]);
                                if (sdr["LeaveRecordEndLesson"] != DBNull.Value) model.LeaveRecordEndLesson = Convert.ToInt32(sdr["LeaveRecordEndLesson"]);
                                if (sdr["LeaveRecordCategory"] != DBNull.Value) model.LeaveRecordCategory = Convert.ToString(sdr["LeaveRecordCategory"]);
                                if (sdr["LeaveRecordNumDays"] != DBNull.Value) model.LeaveRecordNumDays = Convert.ToInt32(sdr["LeaveRecordNumDays"]);
                                if (sdr["LeaveRecordApprover"] != DBNull.Value) model.LeaveRecordApprover = Convert.ToString(sdr["LeaveRecordApprover"]);
                                if (sdr["LeaveRecordStage"] != DBNull.Value) model.LeaveRecordStage = Convert.ToInt32(sdr["LeaveRecordStage"]);
                                if (sdr["LeaveRecordApprovalResult"] != DBNull.Value) model.LeaveRecordApprovalResult = Convert.ToString(sdr["LeaveRecordApprovalResult"]);
                                if (sdr["LeaveRecordApprovalTime"] != DBNull.Value) model.LeaveRecordApprovalTime = Convert.ToString(sdr["LeaveRecordApprovalTime"]);
                                if (sdr["LeaveRecordSumLesson"] != DBNull.Value) model.LeaveRecordSumLesson = Convert.ToInt32(sdr["LeaveRecordSumLesson"]);
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
        public static int Insert(LeaveRecord model)
        {
            string strSql = "INSERT INTO [LeaveRecord] ([LeaveRecordStudentID],[LeaveRecordReason],[LeaveRecordStartTime],[LeaveRecordEndtTime],[LeaveRecordStartLesson],[LeaveRecordEndLesson],[LeaveRecordCategory],[LeaveRecordNumDays],[LeaveRecordApprover],[LeaveRecordStage],[LeaveRecordApprovalResult],[LeaveRecordApprovalTime],[LeaveRecordSumLesson],[LeaveRecordClassNum]) VALUES (@LeaveRecordStudentID,@LeaveRecordReason,@LeaveRecordStartTime,@LeaveRecordEndtTime,@LeaveRecordStartLesson,@LeaveRecordEndLesson,@LeaveRecordCategory,@LeaveRecordNumDays,@LeaveRecordApprover,@LeaveRecordStage,@LeaveRecordApprovalResult,@LeaveRecordApprovalTime,@LeaveRecordSumLesson,@LeaveRecordClassNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@LeaveRecordStudentID", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordReason", SqlDbType.VarChar,200),
                         new SqlParameter("@LeaveRecordStartTime", SqlDbType.VarChar,30),
                         new SqlParameter("@LeaveRecordEndtTime", SqlDbType.VarChar,30),
                         new SqlParameter("@LeaveRecordStartLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordEndLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordCategory", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordNumDays", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordStage", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@LeaveRecordApprovalTime", SqlDbType.VarChar,30),
                         new SqlParameter("@LeaveRecordSumLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                if (model.LeaveRecordStudentID == null) { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = model.LeaveRecordStudentID; }
                if (model.LeaveRecordReason == null) { sqlCmd.Parameters["@LeaveRecordReason"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordReason"].Value = model.LeaveRecordReason; }
                if (model.LeaveRecordStartTime == null) { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = model.LeaveRecordStartTime; }
                if (model.LeaveRecordEndtTime == null) { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = model.LeaveRecordEndtTime; }
                if (model.LeaveRecordStartLesson == null) { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = model.LeaveRecordStartLesson; }
                if (model.LeaveRecordEndLesson == null) { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = model.LeaveRecordEndLesson; }
                if (model.LeaveRecordCategory == null) { sqlCmd.Parameters["@LeaveRecordCategory"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordCategory"].Value = model.LeaveRecordCategory; }
                if (model.LeaveRecordNumDays == null) { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = model.LeaveRecordNumDays; }
                if (model.LeaveRecordApprover == null) { sqlCmd.Parameters["@LeaveRecordApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprover"].Value = model.LeaveRecordApprover; }
                if (model.LeaveRecordStage == null) { sqlCmd.Parameters["@LeaveRecordStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStage"].Value = model.LeaveRecordStage; }
                if (model.LeaveRecordApprovalResult == null) { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = model.LeaveRecordApprovalResult; }
                if (model.LeaveRecordApprovalTime == null) { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = model.LeaveRecordApprovalTime; }
                if (model.LeaveRecordSumLesson == null) { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = model.LeaveRecordSumLesson; }
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
        public static void Insert(LeaveRecord[] modelList)
        {
            string strSql = "INSERT INTO [LeaveRecord] ([LeaveRecordStudentID],[LeaveRecordReason],[LeaveRecordStartTime],[LeaveRecordEndtTime],[LeaveRecordStartLesson],[LeaveRecordEndLesson],[LeaveRecordCategory],[LeaveRecordNumDays],[LeaveRecordApprover],[LeaveRecordStage],[LeaveRecordApprovalResult],[LeaveRecordApprovalTime],[LeaveRecordSumLesson],[LeaveRecordClassNum]) VALUES (@LeaveRecordStudentID,@LeaveRecordReason,@LeaveRecordStartTime,@LeaveRecordEndtTime,@LeaveRecordStartLesson,@LeaveRecordEndLesson,@LeaveRecordCategory,@LeaveRecordNumDays,@LeaveRecordApprover,@LeaveRecordStage,@LeaveRecordApprovalResult,@LeaveRecordApprovalTime,@LeaveRecordSumLesson,@LeaveRecordClassNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@LeaveRecordStudentID", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordReason", SqlDbType.VarChar,200),
                         new SqlParameter("@LeaveRecordStartTime", SqlDbType.VarChar,10),
                         new SqlParameter("@LeaveRecordEndtTime", SqlDbType.VarChar,10),
                         new SqlParameter("@LeaveRecordStartLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordEndLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordCategory", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordNumDays", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordStage", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@LeaveRecordApprovalTime", SqlDbType.VarChar,30),
                         new SqlParameter("@LeaveRecordSumLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (LeaveRecord model in modelList)
                    {
                        if (model.LeaveRecordStudentID == null) { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = model.LeaveRecordStudentID; }
                        if (model.LeaveRecordReason == null) { sqlCmd.Parameters["@LeaveRecordReason"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordReason"].Value = model.LeaveRecordReason; }
                        if (model.LeaveRecordStartTime == null) { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = model.LeaveRecordStartTime; }
                        if (model.LeaveRecordEndtTime == null) { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = model.LeaveRecordEndtTime; }
                        if (model.LeaveRecordStartLesson == null) { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = model.LeaveRecordStartLesson; }
                        if (model.LeaveRecordEndLesson == null) { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = model.LeaveRecordEndLesson; }
                        if (model.LeaveRecordCategory == null) { sqlCmd.Parameters["@LeaveRecordCategory"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordCategory"].Value = model.LeaveRecordCategory; }
                        if (model.LeaveRecordNumDays == null) { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = model.LeaveRecordNumDays; }
                        if (model.LeaveRecordApprover == null) { sqlCmd.Parameters["@LeaveRecordApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprover"].Value = model.LeaveRecordApprover; }
                        if (model.LeaveRecordStage == null) { sqlCmd.Parameters["@LeaveRecordStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStage"].Value = model.LeaveRecordStage; }
                        if (model.LeaveRecordApprovalResult == null) { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = model.LeaveRecordApprovalResult; }
                        if (model.LeaveRecordApprovalTime == null) { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = model.LeaveRecordApprovalTime; }
                        if (model.LeaveRecordSumLesson == null) { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = model.LeaveRecordSumLesson; }
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
        /// <param name="_LeaveRecordID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByLeaveRecordID(int _LeaveRecordID)
        {
            string strSql = "DELETE FROM [LeaveRecord] WHERE [LeaveRecordID]=@LeaveRecordID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@LeaveRecordID", SqlDbType.Int, 4) { Value = _LeaveRecordID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(LeaveRecord model)
        {
            string strSql = "DELETE FROM [LeaveRecord] WHERE [LeaveRecordID]=@LeaveRecordID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@LeaveRecordID", SqlDbType.Int, 4) { Value = model.LeaveRecordID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [LeaveRecord]";
            return (int)tool.ExecuteScalar(strSql);
        }

        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [LeaveRecord] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(LeaveRecord model)
        {
            string strSql = "UPDATE [LeaveRecord] SET [LeaveRecordStudentID] = ISNULL(@LeaveRecordStudentID,[LeaveRecordStudentID]),[LeaveRecordReason] = ISNULL(@LeaveRecordReason,[LeaveRecordReason]),[LeaveRecordStartTime] = ISNULL(@LeaveRecordStartTime,[LeaveRecordStartTime]),[LeaveRecordEndtTime] = ISNULL(@LeaveRecordEndtTime,[LeaveRecordEndtTime]),[LeaveRecordStartLesson] = ISNULL(@LeaveRecordStartLesson,[LeaveRecordStartLesson]),[LeaveRecordEndLesson] = ISNULL(@LeaveRecordEndLesson,[LeaveRecordEndLesson]),[LeaveRecordCategory] = ISNULL(@LeaveRecordCategory,[LeaveRecordCategory]),[LeaveRecordNumDays] = ISNULL(@LeaveRecordNumDays,[LeaveRecordNumDays]),[LeaveRecordApprover] = ISNULL(@LeaveRecordApprover,[LeaveRecordApprover]),[LeaveRecordStage] = ISNULL(@LeaveRecordStage,[LeaveRecordStage]),[LeaveRecordApprovalResult] = ISNULL(@LeaveRecordApprovalResult,[LeaveRecordApprovalResult]),[LeaveRecordApprovalTime] = ISNULL(@LeaveRecordApprovalTime,[LeaveRecordApprovalTime]),[LeaveRecordSumLesson] = ISNULL(@LeaveRecordSumLesson,[LeaveRecordSumLesson]),[LeaveRecordClassNum] = ISNULL(@LeaveRecordClassNum,[LeaveRecordClassNum]) WHERE [LeaveRecordID]=@LeaveRecordID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@LeaveRecordID", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordStudentID", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordReason", SqlDbType.VarChar,200),
                         new SqlParameter("@LeaveRecordStartTime", SqlDbType.DateTime),
                         new SqlParameter("@LeaveRecordEndtTime", SqlDbType.DateTime),
                         new SqlParameter("@LeaveRecordStartLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordEndLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordCategory", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordNumDays", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@LeaveRecordStage", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordApprovalResult", SqlDbType.VarChar,10),
                         new SqlParameter("@LeaveRecordApprovalTime", SqlDbType.DateTime),
                         new SqlParameter("@LeaveRecordSumLesson", SqlDbType.Int,4),
                         new SqlParameter("@LeaveRecordClassNum", SqlDbType.VarChar,10)
                     }
                 );
                sqlCmd.Parameters["@LeaveRecordID"].Value = model.LeaveRecordID;
                if (model.LeaveRecordStudentID == null) { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStudentID"].Value = model.LeaveRecordStudentID; }
                if (model.LeaveRecordReason == null) { sqlCmd.Parameters["@LeaveRecordReason"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordReason"].Value = model.LeaveRecordReason; }
                if (model.LeaveRecordStartTime == null) { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartTime"].Value = model.LeaveRecordStartTime; }
                if (model.LeaveRecordEndtTime == null) { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndtTime"].Value = model.LeaveRecordEndtTime; }
                if (model.LeaveRecordStartLesson == null) { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStartLesson"].Value = model.LeaveRecordStartLesson; }
                if (model.LeaveRecordEndLesson == null) { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordEndLesson"].Value = model.LeaveRecordEndLesson; }
                if (model.LeaveRecordCategory == null) { sqlCmd.Parameters["@LeaveRecordCategory"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordCategory"].Value = model.LeaveRecordCategory; }
                if (model.LeaveRecordNumDays == null) { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordNumDays"].Value = model.LeaveRecordNumDays; }
                if (model.LeaveRecordApprover == null) { sqlCmd.Parameters["@LeaveRecordApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprover"].Value = model.LeaveRecordApprover; }
                if (model.LeaveRecordStage == null) { sqlCmd.Parameters["@LeaveRecordStage"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordStage"].Value = model.LeaveRecordStage; }
                if (model.LeaveRecordApprovalResult == null) { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalResult"].Value = model.LeaveRecordApprovalResult; }
                if (model.LeaveRecordApprovalTime == null) { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordApprovalTime"].Value = model.LeaveRecordApprovalTime; }
                if (model.LeaveRecordSumLesson == null) { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = DBNull.Value; } else { sqlCmd.Parameters["@LeaveRecordSumLesson"].Value = model.LeaveRecordSumLesson; }
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
        /// 根据条件查询所有请假记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [LeaveRecord] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }

        #endregion

        #region 请假审核

        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<LeaveRecord> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [LeaveRecord] {0}", condition);
            return SelectAllBySql(strSql);
        }

        

        #endregion
    }
}
