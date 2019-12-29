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
    public class TeachersDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Teachers SelectBySql(String strSql)
        {
            Teachers model = new Teachers();
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
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static Teachers SelectBySql(String strSql, SqlParameter sqlParam)
        {
            Teachers model = new Teachers();
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
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static Teachers SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            Teachers model = new Teachers();
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
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static IList<Teachers> SelectAllBySql(string strSql)
        {
            IList<Teachers> modelList = new List<Teachers>();
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
                                Teachers model = new Teachers();
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static IList<Teachers> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<Teachers> modelList = new List<Teachers>();
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
                                Teachers model = new Teachers();
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static IList<Teachers> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<Teachers> modelList = new List<Teachers>();
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
                                Teachers model = new Teachers();
                                if (sdr["TeacherID"] != DBNull.Value) model.TeacherID = Convert.ToInt32(sdr["TeacherID"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                                if (sdr["TeacherPass"] != DBNull.Value) model.TeacherPass = Convert.ToString(sdr["TeacherPass"]);
                                if (sdr["TeacherName"] != DBNull.Value) model.TeacherName = Convert.ToString(sdr["TeacherName"]);
                                if (sdr["TeacherSex"] != DBNull.Value) model.TeacherSex = Convert.ToString(sdr["TeacherSex"]);
                                if (sdr["TeacherTel"] != DBNull.Value) model.TeacherTel = Convert.ToString(sdr["TeacherTel"]);
                                if (sdr["Post"] != DBNull.Value) model.Post = Convert.ToString(sdr["Post"]);
                                //if (sdr["TeacherCollegeNum"] != DBNull.Value) model.TeacherCollegeNum = Convert.ToString(sdr["TeacherCollegeNum"]);
                                //if (sdr["TeacherSpecialtyNum"] != DBNull.Value) model.TeacherSpecialtyNum = Convert.ToString(sdr["TeacherSpecialtyNum"]);
                                if (sdr["TeacherIDCard"] != DBNull.Value) model.TeacherIDCard = Convert.ToString(sdr["TeacherIDCard"]);
                                if (sdr["TeacherApprover"] != DBNull.Value) model.TeacherApprover = Convert.ToString(sdr["TeacherApprover"]);
                                if (sdr["TeacherApprovalResult"] != DBNull.Value) model.TeacherApprovalResult = Convert.ToString(sdr["TeacherApprovalResult"]);
                                if (sdr["TeacherApprovalTime"] != DBNull.Value) model.TeacherApprovalTime = Convert.ToString(sdr["TeacherApprovalTime"]);
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
        public static int Insert(Teachers model)
        {
            string strSql = "INSERT INTO [Teachers] ([TeacherNum],[TeacherPass],[TeacherName],[TeacherSex],[TeacherTel],[Post],[TeacherIDCard],[TeacherApprover],[TeacherApprovalResult],[TeacherApprovalTime]) VALUES (@TeacherNum,@TeacherPass,@TeacherName,@TeacherSex,@TeacherTel,@Post,@TeacherIDCard,@TeacherApprover,@TeacherApprovalResult,@TeacherApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12),
                         new SqlParameter("@TeacherPass", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherName", SqlDbType.VarChar,30),
                         new SqlParameter("@TeacherSex", SqlDbType.VarChar,2),
                         new SqlParameter("@TeacherTel", SqlDbType.VarChar,50),
                         new SqlParameter("@Post", SqlDbType.VarChar,26),
                         //new SqlParameter("@TeacherCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@TeacherSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
                if (model.TeacherPass == null) { sqlCmd.Parameters["@TeacherPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherPass"].Value = model.TeacherPass; }
                if (model.TeacherName == null) { sqlCmd.Parameters["@TeacherName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherName"].Value = model.TeacherName; }
                if (model.TeacherSex == null) { sqlCmd.Parameters["@TeacherSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSex"].Value = model.TeacherSex; }
                if (model.TeacherTel == null) { sqlCmd.Parameters["@TeacherTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherTel"].Value = model.TeacherTel; }
                if (model.Post == null) { sqlCmd.Parameters["@Post"].Value = DBNull.Value; } else { sqlCmd.Parameters["@Post"].Value = model.Post; }
                //if (model.TeacherCollegeNum == null) { sqlCmd.Parameters["@TeacherCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherCollegeNum"].Value = model.TeacherCollegeNum; }
                //if (model.TeacherSpecialtyNum == null) { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = model.TeacherSpecialtyNum; }
                if (model.TeacherIDCard == null) { sqlCmd.Parameters["@TeacherIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherIDCard"].Value = model.TeacherIDCard; }
                if (model.TeacherApprover == null) { sqlCmd.Parameters["@TeacherApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprover"].Value = model.TeacherApprover; }
                if (model.TeacherApprovalResult == null) { sqlCmd.Parameters["@TeacherApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalResult"].Value = model.TeacherApprovalResult; }
                if (model.TeacherApprovalTime == null) { sqlCmd.Parameters["@TeacherApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalTime"].Value = model.TeacherApprovalTime; }
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
        /// 批量插入教师记录(无注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Teachers[] modelList)
        {
            string strSql = "INSERT INTO [Teachers] ([TeacherNum],[TeacherPass],[TeacherName],[TeacherSex],[TeacherTel],[Post],[TeacherIDCard],[TeacherApprover],[TeacherApprovalResult],[TeacherApprovalTime]) VALUES (@TeacherNum,@TeacherPass,@TeacherName,@TeacherSex,@TeacherTel,@Post,@TeacherIDCard,@TeacherApprover,@TeacherApprovalResult,@TeacherApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12),
                         new SqlParameter("@TeacherPass", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherName", SqlDbType.VarChar,30),
                         new SqlParameter("@TeacherSex", SqlDbType.VarChar,2),
                         new SqlParameter("@TeacherTel", SqlDbType.VarChar,50),
                         new SqlParameter("@Post", SqlDbType.VarChar,26),
                         //new SqlParameter("@TeacherCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@TeacherSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Teachers model in modelList)
                    {
                        if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
                        if (model.TeacherPass == null) { sqlCmd.Parameters["@TeacherPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherPass"].Value = model.TeacherPass; }
                        if (model.TeacherName == null) { sqlCmd.Parameters["@TeacherName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherName"].Value = model.TeacherName; }
                        if (model.TeacherSex == null) { sqlCmd.Parameters["@TeacherSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSex"].Value = model.TeacherSex; }
                        if (model.TeacherTel == null) { sqlCmd.Parameters["@TeacherTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherTel"].Value = model.TeacherTel; }
                        if (model.Post == null) { sqlCmd.Parameters["@Post"].Value = DBNull.Value; } else { sqlCmd.Parameters["@Post"].Value = model.Post; }
                        //if (model.TeacherCollegeNum == null) { sqlCmd.Parameters["@TeacherCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherCollegeNum"].Value = model.TeacherCollegeNum; }
                        //if (model.TeacherSpecialtyNum == null) { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = model.TeacherSpecialtyNum; }
                        if (model.TeacherIDCard == null) { sqlCmd.Parameters["@TeacherIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherIDCard"].Value = model.TeacherIDCard; }
                        if (model.TeacherApprover == null) { sqlCmd.Parameters["@TeacherApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprover"].Value = model.TeacherApprover; }
                        if (model.TeacherApprovalResult == null) { sqlCmd.Parameters["@TeacherApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalResult"].Value = model.TeacherApprovalResult; }
                        if (model.TeacherApprovalTime == null) { sqlCmd.Parameters["@TeacherApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalTime"].Value = model.TeacherApprovalTime; }
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
        /// 批量插入教师记录(有注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static string InsertSingle(Teachers[] modelList)
        {
            string repeatTeacher = "";
            string strSql = "INSERT INTO [Teachers] ([TeacherNum],[TeacherPass],[TeacherName],[TeacherSex],[TeacherTel],[Post],[TeacherIDCard],[TeacherApprover],[TeacherApprovalResult],[TeacherApprovalTime]) VALUES (@TeacherNum,@TeacherPass,@TeacherName,@TeacherSex,@TeacherTel,@Post,@TeacherIDCard,@TeacherApprover,@TeacherApprovalResult,@TeacherApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12),
                         new SqlParameter("@TeacherPass", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherName", SqlDbType.VarChar,30),
                         new SqlParameter("@TeacherSex", SqlDbType.VarChar,2),
                         new SqlParameter("@TeacherTel", SqlDbType.VarChar,50),
                         new SqlParameter("@Post", SqlDbType.VarChar,26),
                         //new SqlParameter("@TeacherCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@TeacherSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Teachers model in modelList)
                    {
                        if (checkTeacher(model.TeacherNum) == 0)
                        {
                            if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
                            if (model.TeacherPass == null) { sqlCmd.Parameters["@TeacherPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherPass"].Value = model.TeacherPass; }
                            if (model.TeacherName == null) { sqlCmd.Parameters["@TeacherName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherName"].Value = model.TeacherName; }
                            if (model.TeacherSex == null) { sqlCmd.Parameters["@TeacherSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSex"].Value = model.TeacherSex; }
                            if (model.TeacherTel == null) { sqlCmd.Parameters["@TeacherTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherTel"].Value = model.TeacherTel; }
                            if (model.Post == null) { sqlCmd.Parameters["@Post"].Value = DBNull.Value; } else { sqlCmd.Parameters["@Post"].Value = model.Post; }
                            //if (model.TeacherCollegeNum == null) { sqlCmd.Parameters["@TeacherCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherCollegeNum"].Value = model.TeacherCollegeNum; }
                            //if (model.TeacherSpecialtyNum == null) { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = model.TeacherSpecialtyNum; }
                            if (model.TeacherIDCard == null) { sqlCmd.Parameters["@TeacherIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherIDCard"].Value = model.TeacherIDCard; }
                            if (model.TeacherApprover == null) { sqlCmd.Parameters["@TeacherApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprover"].Value = model.TeacherApprover; }
                            if (model.TeacherApprovalResult == null) { sqlCmd.Parameters["@TeacherApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalResult"].Value = model.TeacherApprovalResult; }
                            if (model.TeacherApprovalTime == null) { sqlCmd.Parameters["@TeacherApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalTime"].Value = model.TeacherApprovalTime; }
                            sqlCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            repeatTeacher += model.TeacherNum + ",";
                        }
                    }

                    return repeatTeacher;
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
        /// <param name="_TeacherID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByTeacherID(int _TeacherID)
        {
            string strSql = "DELETE FROM [Teachers] WHERE [TeacherID]=@TeacherID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@TeacherID", SqlDbType.Int, 4) { Value = _TeacherID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Teachers model)
        {
            string strSql = "DELETE FROM [Teachers] WHERE [TeacherID]=@TeacherID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@TeacherID", SqlDbType.Int, 4) { Value = model.TeacherID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [Teachers]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [Teachers] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Teachers model)
        {
            string strSql = "UPDATE [Teachers] SET [TeacherNum] = ISNULL(@TeacherNum,[TeacherNum]),[TeacherPass] = ISNULL(@TeacherPass,[TeacherPass]),[TeacherName] = ISNULL(@TeacherName,[TeacherName]),[TeacherSex] = ISNULL(@TeacherSex,[TeacherSex]),[TeacherTel] = ISNULL(@TeacherTel,[TeacherTel]),[Post] = ISNULL(@Post,[Post]),[TeacherIDCard] = ISNULL(@TeacherIDCard,[TeacherIDCard]),[TeacherApprover] = ISNULL(@TeacherApprover,[TeacherApprover]),[TeacherApprovalResult] = ISNULL(@TeacherApprovalResult,[TeacherApprovalResult]),[TeacherApprovalTime] = ISNULL(@TeacherApprovalTime,[TeacherApprovalTime]) WHERE [TeacherID]=@TeacherID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@TeacherID", SqlDbType.Int,4),
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12),
                         new SqlParameter("@TeacherPass", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherName", SqlDbType.VarChar,30),
                         new SqlParameter("@TeacherSex", SqlDbType.VarChar,2),
                         new SqlParameter("@TeacherTel", SqlDbType.VarChar,50),
                         new SqlParameter("@Post", SqlDbType.VarChar,26),
                         //new SqlParameter("@TeacherCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@TeacherSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@TeacherApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                sqlCmd.Parameters["@TeacherID"].Value = model.TeacherID;
                if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
                if (model.TeacherPass == null) { sqlCmd.Parameters["@TeacherPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherPass"].Value = model.TeacherPass; }
                if (model.TeacherName == null) { sqlCmd.Parameters["@TeacherName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherName"].Value = model.TeacherName; }
                if (model.TeacherSex == null) { sqlCmd.Parameters["@TeacherSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSex"].Value = model.TeacherSex; }
                if (model.TeacherTel == null) { sqlCmd.Parameters["@TeacherTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherTel"].Value = model.TeacherTel; }
                if (model.Post == null) { sqlCmd.Parameters["@Post"].Value = DBNull.Value; } else { sqlCmd.Parameters["@Post"].Value = model.Post; }
                //if (model.TeacherCollegeNum == null) { sqlCmd.Parameters["@TeacherCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherCollegeNum"].Value = model.TeacherCollegeNum; }
                //if (model.TeacherSpecialtyNum == null) { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherSpecialtyNum"].Value = model.TeacherSpecialtyNum; }
                if (model.TeacherIDCard == null) { sqlCmd.Parameters["@TeacherIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherIDCard"].Value = model.TeacherIDCard; }
                if (model.TeacherApprover == null) { sqlCmd.Parameters["@TeacherApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprover"].Value = model.TeacherApprover; }
                if (model.TeacherApprovalResult == null) { sqlCmd.Parameters["@TeacherApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalResult"].Value = model.TeacherApprovalResult; }
                if (model.TeacherApprovalTime == null) { sqlCmd.Parameters["@TeacherApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherApprovalTime"].Value = model.TeacherApprovalTime; }
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

        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static Teachers SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Teachers] WHERE {0};", condition);
            return SelectBySql(strSql);
        }
        /// <summary>
        /// 根据编号查询数据
        /// </summary>
        /// <param name="_TeacherID">编号</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherID(int _TeacherID)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherID]=@TeacherID;";
            return SelectBySql(strSql, new SqlParameter("@TeacherID", _TeacherID));
        }
        /// <summary>
        /// 根据工号查询数据
        /// </summary>
        /// <param name="_TeacherNum">工号</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherNum]=@TeacherNum;";
            return SelectBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        /// <summary>
        /// 根据教师密码查询数据
        /// </summary>
        /// <param name="_TeacherPass">教师密码</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherPass(string _TeacherPass)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherPass]=@TeacherPass;";
            return SelectBySql(strSql, new SqlParameter("@TeacherPass", _TeacherPass));
        }
        /// <summary>
        /// 根据教师名称查询数据
        /// </summary>
        /// <param name="_TeacherName">教师名称</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherName(string _TeacherName)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherName]=@TeacherName;";
            return SelectBySql(strSql, new SqlParameter("@TeacherName", _TeacherName));
        }
        /// <summary>
        /// 根据教师性别查询数据
        /// </summary>
        /// <param name="_TeacherSex">教师性别</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherSex(string _TeacherSex)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherSex]=@TeacherSex;";
            return SelectBySql(strSql, new SqlParameter("@TeacherSex", _TeacherSex));
        }
        /// <summary>
        /// 根据教师电话查询数据
        /// </summary>
        /// <param name="_TeacherTel">教师电话</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherTel(string _TeacherTel)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherTel]=@TeacherTel;";
            return SelectBySql(strSql, new SqlParameter("@TeacherTel", _TeacherTel));
        }
        /// <summary>
        /// 根据职称查询数据
        /// </summary>
        /// <param name="_Post">职称</param>
        /// <returns></returns>
        public static Teachers SelectByPost(string _Post)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [Post]=@Post;";
            return SelectBySql(strSql, new SqlParameter("@Post", _Post));
        }
        /// <summary>
        /// 根据学院id查询数据
        /// </summary>
        /// <param name="_TeacherCollegeNum">学院id</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherCollegeNum(string _TeacherCollegeNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherCollegeNum]=@TeacherCollegeNum;";
            return SelectBySql(strSql, new SqlParameter("@TeacherCollegeNum", _TeacherCollegeNum));
        }
        /// <summary>
        /// 根据专业id查询数据
        /// </summary>
        /// <param name="_TeacherSpecialtyNum">专业id</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherSpecialtyNum(string _TeacherSpecialtyNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherSpecialtyNum]=@TeacherSpecialtyNum;";
            return SelectBySql(strSql, new SqlParameter("@TeacherSpecialtyNum", _TeacherSpecialtyNum));
        }
        /// <summary>
        /// 根据身份证查询数据
        /// </summary>
        /// <param name="_TeacherIDCard">身份证</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherIDCard(string _TeacherIDCard)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherIDCard]=@TeacherIDCard;";
            return SelectBySql(strSql, new SqlParameter("@TeacherIDCard", _TeacherIDCard));
        }
        /// <summary>
        /// 根据审批人查询数据
        /// </summary>
        /// <param name="_TeacherApprover">审批人</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprover(string _TeacherApprover)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprover]=@TeacherApprover;";
            return SelectBySql(strSql, new SqlParameter("@TeacherApprover", _TeacherApprover));
        }
        /// <summary>
        /// 根据审批结果查询数据
        /// </summary>
        /// <param name="_TeacherApprovalResult">审批结果</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprovalResult(string _TeacherApprovalResult)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprovalResult]=@TeacherApprovalResult;";
            return SelectBySql(strSql, new SqlParameter("@TeacherApprovalResult", _TeacherApprovalResult));
        }
        /// <summary>
        /// 根据审批时间查询数据
        /// </summary>
        /// <param name="_TeacherApprovalTime">审批时间</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprovalTime(string _TeacherApprovalTime)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprovalTime]=@TeacherApprovalTime;";
            return SelectBySql(strSql, new SqlParameter("@TeacherApprovalTime", _TeacherApprovalTime));
        }
        #endregion

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<Teachers> SelectAll()
        {
            string strSql = "SELECT * FROM [Teachers];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Teachers] WHERE [TeacherID] NOT IN (SELECT TOP {1} [TeacherID] FROM [Teachers]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        //public static IList<Teachers> SelectAllByCondition(string condition)
        //{
        //    string strSql = string.Format("SELECT * FROM [Teachers] WHERE {0};", condition);
        //    return SelectAllBySql(strSql);
        //}
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Teachers] WHERE ([TeacherID] NOT IN (SELECT TOP {1} [TeacherID] FROM [Teachers] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Teachers] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据编号查询所有数据
        /// </summary>
        /// <param name="_TeacherID">编号</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherID(int _TeacherID)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherID]=@TeacherID;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherID", _TeacherID));
        }
        /// <summary>
        /// 根据工号查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">工号</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherNum]=@TeacherNum;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        /// <summary>
        /// 根据教师密码查询所有数据
        /// </summary>
        /// <param name="_TeacherPass">教师密码</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherPass(string _TeacherPass)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherPass]=@TeacherPass;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherPass", _TeacherPass));
        }
        /// <summary>
        /// 根据教师名称查询所有数据
        /// </summary>
        /// <param name="_TeacherName">教师名称</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherName(string _TeacherName)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherName]=@TeacherName;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherName", _TeacherName));
        }
        /// <summary>
        /// 根据教师性别查询所有数据
        /// </summary>
        /// <param name="_TeacherSex">教师性别</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherSex(string _TeacherSex)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherSex]=@TeacherSex;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherSex", _TeacherSex));
        }
        /// <summary>
        /// 根据教师电话查询所有数据
        /// </summary>
        /// <param name="_TeacherTel">教师电话</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherTel(string _TeacherTel)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherTel]=@TeacherTel;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherTel", _TeacherTel));
        }
        /// <summary>
        /// 根据职称查询所有数据
        /// </summary>
        /// <param name="_Post">职称</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByPost(string _Post)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [Post]=@Post;";
            return SelectAllBySql(strSql, new SqlParameter("@Post", _Post));
        }
        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_TeacherCollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherCollegeNum(string _TeacherCollegeNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherCollegeNum]=@TeacherCollegeNum;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherCollegeNum", _TeacherCollegeNum));
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_TeacherSpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherSpecialtyNum(string _TeacherSpecialtyNum)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherSpecialtyNum]=@TeacherSpecialtyNum;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherSpecialtyNum", _TeacherSpecialtyNum));
        }
        /// <summary>
        /// 根据身份证查询所有数据
        /// </summary>
        /// <param name="_TeacherIDCard">身份证</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherIDCard(string _TeacherIDCard)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherIDCard]=@TeacherIDCard;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherIDCard", _TeacherIDCard));
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_TeacherApprover">审批人</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprover(string _TeacherApprover)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprover]=@TeacherApprover;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherApprover", _TeacherApprover));
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_TeacherApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprovalResult(string _TeacherApprovalResult)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprovalResult]=@TeacherApprovalResult;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherApprovalResult", _TeacherApprovalResult));
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_TeacherApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprovalTime(string _TeacherApprovalTime)
        {
            string strSql = "SELECT * FROM [Teachers] WHERE [TeacherApprovalTime]=@TeacherApprovalTime;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherApprovalTime", _TeacherApprovalTime));
        }
        #endregion

        #region 登录|注册|忘记密码

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <returns></returns>
        public static int selectByconditions(string conditions)
        {
            string sql = string.Format("select * from [Teachers] where {0};", conditions);
            if (tool.ExecuteScalar(sql) == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 获取教师的电话(全部信息)
        /// </summary>
        /// <returns></returns>
        public static Teachers SelectTeaPhone(string TeacherNum)
        {
            string sql = string.Format("SELECT * FROM [Teachers] WHERE [TeacherNum]={0};", TeacherNum);
            return SelectBySql(sql);
        }



        /// <summary>
        /// 根据AdminInfo表中的密码进行修改
        /// </summary>
        /// <returns></returns>
        public static int updateTeaPwdbyAdmin(int UserID)
        {
            string sql = string.Format("UPDATE [Teachers] SET [Teachers].[TeacherPass] =c.[AdnminPasssword] from [AdminInfo] ,(select [AdminLoginID],[AdnminPasssword] from [AdminInfo] where [AdminLoginID]={0})as c where [Teachers].[TeacherNum]=c.[AdminLoginID]", UserID);
            return tool.update(sql);
        }

        #endregion

        #region 请假审核

        /// <summary>
        /// 通过职位获取教师的信息
        /// </summary>
        /// <returns></returns>
        public static Teachers getInfobyPost(string post)
        {
            string sql = string.Format("SELECT * FROM [Teachers] WHERE [Post]='{0}';", post);
            return SelectBySql(sql);
        }

        #endregion

        #region 教师审核


        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Teachers] WHERE {0};", condition);
            return SelectAllBySql(strSql);
        }
        #endregion

        #region 教师数据导入


        /// <summary>
        /// 导入数据是检查表示是否已经有该教师
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static int checkTeacher(string ID)
        {
            string sql = string.Format("select TeacherNum from [Teachers] where TeacherNum={0};", ID);
            if (tool.ExecuteScalar(sql) != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 查询所有教师的学号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static IList<int> SelectTeacherNumAll()
        {
            string strSql = "SELECT TeacherNum FROM [Teachers]";
            IList<int> modelList = new List<int>();
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
                                modelList.Add(Convert.ToInt32(sdr["TeacherNum"]));
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
    }
}
