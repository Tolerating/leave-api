using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Configuration;


namespace DAL
{
    public class StudentsDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool

        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Students SelectBySql(String strSql)
        {
            Students model = new Students();
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
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static Students SelectBySql(String strSql, SqlParameter sqlParam)
        {
            Students model = new Students();
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
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static Students SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            Students model = new Students();
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
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static IList<Students> SelectAllBySql(string strSql)
        {
            IList<Students> modelList = new List<Students>();
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
                                Students model = new Students();
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static IList<Students> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<Students> modelList = new List<Students>();
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
                                Students model = new Students();
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static IList<Students> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<Students> modelList = new List<Students>();
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
                                Students model = new Students();
                                if (sdr["StudentID"] != DBNull.Value) model.StudentID = Convert.ToInt32(sdr["StudentID"]);
                                if (sdr["StudentNum"] != DBNull.Value) model.StudentNum = Convert.ToString(sdr["StudentNum"]);
                                if (sdr["StudentPass"] != DBNull.Value) model.StudentPass = Convert.ToString(sdr["StudentPass"]);
                                if (sdr["StudentName"] != DBNull.Value) model.StudentName = Convert.ToString(sdr["StudentName"]);
                                if (sdr["StudentSex"] != DBNull.Value) model.StudentSex = Convert.ToString(sdr["StudentSex"]);
                                if (sdr["StudentTel"] != DBNull.Value) model.StudentTel = Convert.ToString(sdr["StudentTel"]);
                                if (sdr["StudentClassID"] != DBNull.Value) model.StudentClassID = Convert.ToString(sdr["StudentClassID"]);
                                //if (sdr["StudentCollegeNum"] != DBNull.Value) model.StudentCollegeNum = Convert.ToString(sdr["StudentCollegeNum"]);
                                //if (sdr["StudentSpecialtyNum"] != DBNull.Value) model.StudentSpecialtyNum = Convert.ToString(sdr["StudentSpecialtyNum"]);
                                if (sdr["StudentIDCard"] != DBNull.Value) model.StudentIDCard = Convert.ToString(sdr["StudentIDCard"]);
                                if (sdr["StudentBedroomNum"] != DBNull.Value) model.StudentBedroomNum = Convert.ToString(sdr["StudentBedroomNum"]);
                                if (sdr["StudentParentTel"] != DBNull.Value) model.StudentParentTel = Convert.ToString(sdr["StudentParentTel"]);
                                if (sdr["StudentHomeAddress"] != DBNull.Value) model.StudentHomeAddress = Convert.ToString(sdr["StudentHomeAddress"]);
                                if (sdr["StudentApprover"] != DBNull.Value) model.StudentApprover = Convert.ToString(sdr["StudentApprover"]);
                                if (sdr["StudentApprovalResult"] != DBNull.Value) model.StudentApprovalResult = Convert.ToString(sdr["StudentApprovalResult"]);
                                if (sdr["StudentApprovalTime"] != DBNull.Value) model.StudentApprovalTime = Convert.ToString(sdr["StudentApprovalTime"]);
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
        public static int Insert(Students model)
        {
            string strSql = "INSERT INTO [Students] ([StudentNum],[StudentPass],[StudentName],[StudentSex],[StudentTel],[StudentClassID],[StudentIDCard],[StudentBedroomNum],[StudentParentTel],[StudentHomeAddress],[StudentApprover],[StudentApprovalResult],[StudentApprovalTime]) VALUES (@StudentNum,@StudentPass,@StudentName,@StudentSex,@StudentTel,@StudentClassID,@StudentIDCard,@StudentBedroomNum,@StudentParentTel,@StudentHomeAddress,@StudentApprover,@StudentApprovalResult,@StudentApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@StudentPass", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentName", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentSex", SqlDbType.VarChar,2),
                         new SqlParameter("@StudentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentClassID", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentBedroomNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentParentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentHomeAddress", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                if (model.StudentPass == null) { sqlCmd.Parameters["@StudentPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentPass"].Value = model.StudentPass; }
                if (model.StudentName == null) { sqlCmd.Parameters["@StudentName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentName"].Value = model.StudentName; }
                if (model.StudentSex == null) { sqlCmd.Parameters["@StudentSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSex"].Value = model.StudentSex; }
                if (model.StudentTel == null) { sqlCmd.Parameters["@StudentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentTel"].Value = model.StudentTel; }
                if (model.StudentClassID == null) { sqlCmd.Parameters["@StudentClassID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentClassID"].Value = model.StudentClassID; }
                //if (model.StudentCollegeNum == null) { sqlCmd.Parameters["@StudentCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentCollegeNum"].Value = model.StudentCollegeNum; }
                //if (model.StudentSpecialtyNum == null) { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = model.StudentSpecialtyNum; }
                if (model.StudentIDCard == null) { sqlCmd.Parameters["@StudentIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentIDCard"].Value = model.StudentIDCard; }
                if (model.StudentBedroomNum == null) { sqlCmd.Parameters["@StudentBedroomNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentBedroomNum"].Value = model.StudentBedroomNum; }
                if (model.StudentParentTel == null) { sqlCmd.Parameters["@StudentParentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentParentTel"].Value = model.StudentParentTel; }
                if (model.StudentHomeAddress == null) { sqlCmd.Parameters["@StudentHomeAddress"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentHomeAddress"].Value = model.StudentHomeAddress; }
                if (model.StudentApprover == null) { sqlCmd.Parameters["@StudentApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprover"].Value = model.StudentApprover; }
                if (model.StudentApprovalResult == null) { sqlCmd.Parameters["@StudentApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalResult"].Value = model.StudentApprovalResult; }
                if (model.StudentApprovalTime == null) { sqlCmd.Parameters["@StudentApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalTime"].Value = model.StudentApprovalTime; }
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
        /// 批量插入学生记录(有注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static string InsertSingle(Students[] modelList)
        {
            string notInsert = "";
            string strSql = "INSERT INTO [Students] ([StudentNum],[StudentPass],[StudentName],[StudentSex],[StudentTel],[StudentClassID],[StudentIDCard],[StudentBedroomNum],[StudentParentTel],[StudentHomeAddress],[StudentApprover],[StudentApprovalResult],[StudentApprovalTime]) VALUES (@StudentNum,@StudentPass,@StudentName,@StudentSex,@StudentTel,@StudentClassID,@StudentIDCard,@StudentBedroomNum,@StudentParentTel,@StudentHomeAddress,@StudentApprover,@StudentApprovalResult,@StudentApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@StudentPass", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentName", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentSex", SqlDbType.VarChar,2),
                         new SqlParameter("@StudentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentClassID", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentBedroomNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentParentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentHomeAddress", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Students model in modelList)
                    {
                        if (checkStu(model.StudentNum) == 0)
                        {
                            if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                            if (model.StudentPass == null) { sqlCmd.Parameters["@StudentPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentPass"].Value = model.StudentPass; }
                            if (model.StudentName == null) { sqlCmd.Parameters["@StudentName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentName"].Value = model.StudentName; }
                            if (model.StudentSex == null) { sqlCmd.Parameters["@StudentSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSex"].Value = model.StudentSex; }
                            if (model.StudentTel == null) { sqlCmd.Parameters["@StudentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentTel"].Value = model.StudentTel; }
                            if (model.StudentClassID == null) { sqlCmd.Parameters["@StudentClassID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentClassID"].Value = model.StudentClassID; }
                            //if (model.StudentCollegeNum == null) { sqlCmd.Parameters["@StudentCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentCollegeNum"].Value = model.StudentCollegeNum; }
                            //if (model.StudentSpecialtyNum == null) { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = model.StudentSpecialtyNum; }
                            if (model.StudentIDCard == null) { sqlCmd.Parameters["@StudentIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentIDCard"].Value = model.StudentIDCard; }
                            if (model.StudentBedroomNum == null) { sqlCmd.Parameters["@StudentBedroomNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentBedroomNum"].Value = model.StudentBedroomNum; }
                            if (model.StudentParentTel == null) { sqlCmd.Parameters["@StudentParentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentParentTel"].Value = model.StudentParentTel; }
                            if (model.StudentHomeAddress == null) { sqlCmd.Parameters["@StudentHomeAddress"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentHomeAddress"].Value = model.StudentHomeAddress; }
                            if (model.StudentApprover == null) { sqlCmd.Parameters["@StudentApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprover"].Value = model.StudentApprover; }
                            if (model.StudentApprovalResult == null) { sqlCmd.Parameters["@StudentApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalResult"].Value = model.StudentApprovalResult; }
                            if (model.StudentApprovalTime == null) { sqlCmd.Parameters["@StudentApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalTime"].Value = model.StudentApprovalTime; }
                            sqlCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            notInsert += model.StudentNum + ",";
                        }
                    }
                    return notInsert;
                }
                catch
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// 批量插入学生记录(无注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Students[] modelList)
        {
            //string notInsert = "";
            string strSql = "INSERT INTO [Students] ([StudentNum],[StudentPass],[StudentName],[StudentSex],[StudentTel],[StudentClassID],[StudentIDCard],[StudentBedroomNum],[StudentParentTel],[StudentHomeAddress],[StudentApprover],[StudentApprovalResult],[StudentApprovalTime]) VALUES (@StudentNum,@StudentPass,@StudentName,@StudentSex,@StudentTel,@StudentClassID,@StudentIDCard,@StudentBedroomNum,@StudentParentTel,@StudentHomeAddress,@StudentApprover,@StudentApprovalResult,@StudentApprovalTime);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@StudentPass", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentName", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentSex", SqlDbType.VarChar,2),
                         new SqlParameter("@StudentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentClassID", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentBedroomNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentParentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentHomeAddress", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalTime", SqlDbType.VarChar,20)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Students model in modelList)
                    {
                        if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                        if (model.StudentPass == null) { sqlCmd.Parameters["@StudentPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentPass"].Value = model.StudentPass; }
                        if (model.StudentName == null) { sqlCmd.Parameters["@StudentName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentName"].Value = model.StudentName; }
                        if (model.StudentSex == null) { sqlCmd.Parameters["@StudentSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSex"].Value = model.StudentSex; }
                        if (model.StudentTel == null) { sqlCmd.Parameters["@StudentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentTel"].Value = model.StudentTel; }
                        if (model.StudentClassID == null) { sqlCmd.Parameters["@StudentClassID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentClassID"].Value = model.StudentClassID; }
                        //if (model.StudentCollegeNum == null) { sqlCmd.Parameters["@StudentCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentCollegeNum"].Value = model.StudentCollegeNum; }
                        //if (model.StudentSpecialtyNum == null) { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = model.StudentSpecialtyNum; }
                        if (model.StudentIDCard == null) { sqlCmd.Parameters["@StudentIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentIDCard"].Value = model.StudentIDCard; }
                        if (model.StudentBedroomNum == null) { sqlCmd.Parameters["@StudentBedroomNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentBedroomNum"].Value = model.StudentBedroomNum; }
                        if (model.StudentParentTel == null) { sqlCmd.Parameters["@StudentParentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentParentTel"].Value = model.StudentParentTel; }
                        if (model.StudentHomeAddress == null) { sqlCmd.Parameters["@StudentHomeAddress"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentHomeAddress"].Value = model.StudentHomeAddress; }
                        if (model.StudentApprover == null) { sqlCmd.Parameters["@StudentApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprover"].Value = model.StudentApprover; }
                        if (model.StudentApprovalResult == null) { sqlCmd.Parameters["@StudentApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalResult"].Value = model.StudentApprovalResult; }
                        if (model.StudentApprovalTime == null) { sqlCmd.Parameters["@StudentApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalTime"].Value = model.StudentApprovalTime; }
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
        /// <param name="_StudentID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByStudentID(int _StudentID)
        {
            string strSql = string.Format("DELETE FROM [Students] WHERE [StudentID]={0};", _StudentID);
            return tool.ExecuteNonQuery(strSql);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Students model)
        {
            string strSql = "DELETE FROM [Students] WHERE [StudentID]=@StudentID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@StudentID", SqlDbType.Int, 4) { Value = model.StudentID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [Students]";
            return (int)tool.ExecuteScalar(strSql);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Students model)
        {
            string strSql = "UPDATE [Students] SET [StudentNum] = ISNULL(@StudentNum,[StudentNum]),[StudentPass] = ISNULL(@StudentPass,[StudentPass]),[StudentName] = ISNULL(@StudentName,[StudentName]),[StudentSex] = ISNULL(@StudentSex,[StudentSex]),[StudentTel] = ISNULL(@StudentTel,[StudentTel]),[StudentClassID] = ISNULL(@StudentClassID,[StudentClassID]),[StudentIDCard] = ISNULL(@StudentIDCard,[StudentIDCard]),[StudentBedroomNum] = ISNULL(@StudentBedroomNum,[StudentBedroomNum]),[StudentParentTel] = ISNULL(@StudentParentTel,[StudentParentTel]),[StudentHomeAddress] = ISNULL(@StudentHomeAddress,[StudentHomeAddress]),[StudentApprover] = ISNULL(@StudentApprover,[StudentApprover]),[StudentApprovalResult] = ISNULL(@StudentApprovalResult,[StudentApprovalResult]),[StudentApprovalTime] = ISNULL(@StudentApprovalTime,[StudentApprovalTime]) WHERE [StudentID]=@StudentID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@StudentID", SqlDbType.Int,4),
                         new SqlParameter("@StudentNum", SqlDbType.VarChar,10),
                         new SqlParameter("@StudentPass", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentName", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentSex", SqlDbType.VarChar,2),
                         new SqlParameter("@StudentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentClassID", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentCollegeNum", SqlDbType.VarChar,50),
                         //new SqlParameter("@StudentSpecialtyNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentIDCard", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentBedroomNum", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentParentTel", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentHomeAddress", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprover", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalResult", SqlDbType.VarChar,50),
                         new SqlParameter("@StudentApprovalTime", SqlDbType.DateTime)
                     }
                 );
                sqlCmd.Parameters["@StudentID"].Value = model.StudentID;
                if (model.StudentNum == null) { sqlCmd.Parameters["@StudentNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentNum"].Value = model.StudentNum; }
                if (model.StudentPass == null) { sqlCmd.Parameters["@StudentPass"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentPass"].Value = model.StudentPass; }
                if (model.StudentName == null) { sqlCmd.Parameters["@StudentName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentName"].Value = model.StudentName; }
                if (model.StudentSex == null) { sqlCmd.Parameters["@StudentSex"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSex"].Value = model.StudentSex; }
                if (model.StudentTel == null) { sqlCmd.Parameters["@StudentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentTel"].Value = model.StudentTel; }
                if (model.StudentClassID == null) { sqlCmd.Parameters["@StudentClassID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentClassID"].Value = model.StudentClassID; }
                //if (model.StudentCollegeNum == null) { sqlCmd.Parameters["@StudentCollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentCollegeNum"].Value = model.StudentCollegeNum; }
                //if (model.StudentSpecialtyNum == null) { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentSpecialtyNum"].Value = model.StudentSpecialtyNum; }
                if (model.StudentIDCard == null) { sqlCmd.Parameters["@StudentIDCard"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentIDCard"].Value = model.StudentIDCard; }
                if (model.StudentBedroomNum == null) { sqlCmd.Parameters["@StudentBedroomNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentBedroomNum"].Value = model.StudentBedroomNum; }
                if (model.StudentParentTel == null) { sqlCmd.Parameters["@StudentParentTel"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentParentTel"].Value = model.StudentParentTel; }
                if (model.StudentHomeAddress == null) { sqlCmd.Parameters["@StudentHomeAddress"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentHomeAddress"].Value = model.StudentHomeAddress; }
                if (model.StudentApprover == null) { sqlCmd.Parameters["@StudentApprover"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprover"].Value = model.StudentApprover; }
                if (model.StudentApprovalResult == null) { sqlCmd.Parameters["@StudentApprovalResult"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalResult"].Value = model.StudentApprovalResult; }
                if (model.StudentApprovalTime == null) { sqlCmd.Parameters["@StudentApprovalTime"].Value = DBNull.Value; } else { sqlCmd.Parameters["@StudentApprovalTime"].Value = model.StudentApprovalTime; }
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
        public static IList<Students> SelectAll()
        {
            string strSql = "SELECT * FROM [Students];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Students> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Students] WHERE [StudentID] NOT IN (SELECT TOP {1} [StudentID] FROM [Students]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Students] {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Students] WHERE ([StudentID] NOT IN (SELECT TOP {1} [StudentID] FROM [Students] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Students] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据学生编号查询所有数据
        /// </summary>
        /// <param name="_StudentID">学生编号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentID(int _StudentID)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentID]=@StudentID;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentID", _StudentID));
        }
        /// <summary>
        /// 根据学号查询所有数据
        /// </summary>
        /// <param name="_StudentNum">学号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentNum(string _StudentNum)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentNum]=@StudentNum;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentNum", _StudentNum));
        }
        /// <summary>
        /// 根据学生密码查询所有数据
        /// </summary>
        /// <param name="_StudentPass">学生密码</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentPass(string _StudentPass)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentPass]=@StudentPass;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentPass", _StudentPass));
        }
        /// <summary>
        /// 根据学生姓名查询所有数据
        /// </summary>
        /// <param name="_StudentName">学生姓名</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentName(string _StudentName)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentName]=@StudentName;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentName", _StudentName));
        }
        /// <summary>
        /// 根据学生性别查询所有数据
        /// </summary>
        /// <param name="_StudentSex">学生性别</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentSex(string _StudentSex)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentSex]=@StudentSex;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentSex", _StudentSex));
        }
        /// <summary>
        /// 根据学生电话查询所有数据
        /// </summary>
        /// <param name="_StudentTel">学生电话</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentTel(string _StudentTel)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentTel]=@StudentTel;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentTel", _StudentTel));
        }

        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_StudentCollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentCollegeNum(string _StudentCollegeNum)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentCollegeNum]=@StudentCollegeNum;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentCollegeNum", _StudentCollegeNum));
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_StudentSpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentSpecialtyNum(string _StudentSpecialtyNum)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentSpecialtyNum]=@StudentSpecialtyNum;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentSpecialtyNum", _StudentSpecialtyNum));
        }
        /// <summary>
        /// 根据身份证查询所有数据
        /// </summary>
        /// <param name="_StudentIDCard">身份证</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentIDCard(string _StudentIDCard)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentIDCard]=@StudentIDCard;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentIDCard", _StudentIDCard));
        }
        /// <summary>
        /// 根据寝室号查询所有数据
        /// </summary>
        /// <param name="_StudentBedroomNum">寝室号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentBedroomNum(string _StudentBedroomNum)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentBedroomNum]=@StudentBedroomNum;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentBedroomNum", _StudentBedroomNum));
        }
        /// <summary>
        /// 根据父母一方的联系方式查询所有数据
        /// </summary>
        /// <param name="_StudentParentTel">父母一方的联系方式</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentParentTel(string _StudentParentTel)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentParentTel]=@StudentParentTel;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentParentTel", _StudentParentTel));
        }
        /// <summary>
        /// 根据家庭住址查询所有数据
        /// </summary>
        /// <param name="_StudentHomeAddress">家庭住址</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentHomeAddress(string _StudentHomeAddress)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentHomeAddress]=@StudentHomeAddress;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentHomeAddress", _StudentHomeAddress));
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_StudentApprover">审批人</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprover(string _StudentApprover)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentApprover]=@StudentApprover;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentApprover", _StudentApprover));
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_StudentApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprovalResult(string _StudentApprovalResult)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentApprovalResult]=@StudentApprovalResult;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentApprovalResult", _StudentApprovalResult));
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_StudentApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprovalTime(string _StudentApprovalTime)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentApprovalTime]=@StudentApprovalTime;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentApprovalTime", _StudentApprovalTime));
        }
        #endregion

        #region 登录|注册|忘记密码

        /// <summary>
        /// 获取学生的电话号码
        /// </summary>
        /// <returns></returns>
        public static Students SelectStuPhone(string StudentNum)
        {
            string sql = string.Format("SELECT * FROM [Students] WHERE [StudentNum]={0};", StudentNum);
            return SelectBySql(sql);
        }

        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string sql = string.Format("SELECT COUNT(*) FROM [Students] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(sql);
        }

        /// <summary>
        /// 根据AdminInfo表中的密码进行修改
        /// </summary>
        /// <returns></returns>
        public static int updateStuPwdbyAdmin(int UserID)
        {
            string sql = string.Format("UPDATE [Students] SET [Students].[StudentPass] =c.[AdnminPasssword] from [AdminInfo] ,(select [AdminLoginID],[AdnminPasssword] from [AdminInfo] where [AdminLoginID]={0})as c where [Students].[StudentNum]=c.[AdminLoginID];", UserID);
            return tool.update(sql);
        }

        /// <summary>
        /// 修改学生表中的密码
        /// </summary>
        /// <returns></returns>
        public static int updateStuPwd(string pwd,int UserID)
        {
            string sql = string.Format("UPDATE [Students] SET [StudentPass] = '{0}' where StudentNum='{1}';", pwd,UserID);
            return tool.update(sql);
        }


        #endregion

        #region 学生请假/个人信息

        /// <summary>
        /// 获取Students表的全部信息
        /// </summary>
        /// <returns></returns>
        public static Students getStuInfo(string StuNum)
        {
            string sql = string.Format("SELECT * FROM [Students] WHERE [StudentNum]='{0}';", StuNum);
            return SelectBySql(sql);
        }

        /// <summary>
        /// 更新学生的电话号码
        /// </summary>
        /// <returns></returns>
        public static int updateStuTel(string StuTel, string StuNum)
        {
            string sql = string.Format("update [Students] set [StudentTel]='{0}' where [StudentNum]='{1}';", StuTel, StuNum);
            return tool.update(sql);
        }
        #endregion

        #region 学生数据导入

        public static int checkStu(string ID)
        {
            string sql = string.Format("SELECT StudentNum FROM [Students] WHERE StudentNum={0};", ID);
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
        /// 使用datatable导入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="TableName"></param>
        public static void importByBulk(DataTable dt, string TableName) {
            SqlConnection sqlConn = new SqlConnection(strConn);
            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn);
            bulkCopy.DestinationTableName = TableName;
            bulkCopy.BatchSize = dt.Rows.Count;
            try
            {
                sqlConn.Open();
                if (dt != null && dt.Rows.Count != 0) {
                    bulkCopy.WriteToServer(dt);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
                if (bulkCopy != null) {
                    bulkCopy.Close();
                }                    
            }
        }

        /// <summary>
        /// 查询所有学生的学号
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static IList<int> SelectStudentNumAll()
        {
            string strSql = "SELECT StudentNum FROM [Students]";
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
                                modelList.Add(Convert.ToInt32(sdr["StudentNum"]));
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

        #region 本周末审核


        /// <summary>
        /// 根据学生专业查询所有数据
        /// </summary>
        /// <param name="_StudentClassID">学生专业</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentClassID(string _StudentClassID)
        {
            string strSql = "SELECT * FROM [Students] WHERE [StudentClassID]=@StudentClassID;";
            return SelectAllBySql(strSql, new SqlParameter("@StudentClassID", _StudentClassID));
        }
        #endregion
    }
}
