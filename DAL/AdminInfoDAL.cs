using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminInfoDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static AdminInfo SelectBySql(String strSql)
        {
            AdminInfo model = new AdminInfo();
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
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static AdminInfo SelectBySql(String strSql, SqlParameter sqlParam)
        {
            AdminInfo model = new AdminInfo();
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
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static AdminInfo SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            AdminInfo model = new AdminInfo();
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
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static IList<AdminInfo> SelectAllBySql(string strSql)
        {
            IList<AdminInfo> modelList = new List<AdminInfo>();
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
                                AdminInfo model = new AdminInfo();
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static IList<AdminInfo> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<AdminInfo> modelList = new List<AdminInfo>();
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
                                AdminInfo model = new AdminInfo();
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static IList<AdminInfo> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<AdminInfo> modelList = new List<AdminInfo>();
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
                                AdminInfo model = new AdminInfo();
                                if (sdr["AdminID"] != DBNull.Value) model.AdminID = Convert.ToInt32(sdr["AdminID"]);
                                if (sdr["AdminLoginID"] != DBNull.Value) model.AdminLoginID = Convert.ToInt32(sdr["AdminLoginID"]);
                                if (sdr["AdnminPasssword"] != DBNull.Value) model.AdnminPasssword = Convert.ToString(sdr["AdnminPasssword"]);
                                if (sdr["AdminName"] != DBNull.Value) model.AdminName = Convert.ToString(sdr["AdminName"]);
                                if (sdr["AdminJurisdictionID"] != DBNull.Value) model.AdminJurisdictionID = Convert.ToInt32(sdr["AdminJurisdictionID"]);
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
        public static int Insert(AdminInfo model)
        {
            string strSql = "INSERT INTO [AdminInfo] ([AdminLoginID],[AdnminPasssword],[AdminName],[AdminJurisdictionID]) VALUES (@AdminLoginID,@AdnminPasssword,@AdminName,@AdminJurisdictionID);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@AdminLoginID", SqlDbType.Int,4),
                         new SqlParameter("@AdnminPasssword", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminName", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminJurisdictionID", SqlDbType.Int,4)
                     }
                 );
                if (model.AdminLoginID == null) { sqlCmd.Parameters["@AdminLoginID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminLoginID"].Value = model.AdminLoginID; }
                if (model.AdnminPasssword == null) { sqlCmd.Parameters["@AdnminPasssword"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdnminPasssword"].Value = model.AdnminPasssword; }
                if (model.AdminName == null) { sqlCmd.Parameters["@AdminName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminName"].Value = model.AdminName; }
                if (model.AdminJurisdictionID == null) { sqlCmd.Parameters["@AdminJurisdictionID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminJurisdictionID"].Value = model.AdminJurisdictionID; }
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
        public static void Insert(AdminInfo[] modelList)
        {
            string strSql = "INSERT INTO [AdminInfo] ([AdminLoginID],[AdnminPasssword],[AdminName],[AdminJurisdictionID]) VALUES (@AdminLoginID,@AdnminPasssword,@AdminName,@AdminJurisdictionID);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@AdminLoginID", SqlDbType.Int,4),
                         new SqlParameter("@AdnminPasssword", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminName", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminJurisdictionID", SqlDbType.Int,4)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (AdminInfo model in modelList)
                    {
                        if (model.AdminLoginID == null) { sqlCmd.Parameters["@AdminLoginID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminLoginID"].Value = model.AdminLoginID; }
                        if (model.AdnminPasssword == null) { sqlCmd.Parameters["@AdnminPasssword"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdnminPasssword"].Value = model.AdnminPasssword; }
                        if (model.AdminName == null) { sqlCmd.Parameters["@AdminName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminName"].Value = model.AdminName; }
                        if (model.AdminJurisdictionID == null) { sqlCmd.Parameters["@AdminJurisdictionID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminJurisdictionID"].Value = model.AdminJurisdictionID; }
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
        /// <param name="_AdminID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByAdminID(int _AdminID)
        {
            string strSql = "DELETE FROM [AdminInfo] WHERE [AdminID]=@AdminID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = _AdminID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(AdminInfo model)
        {
            string strSql = "DELETE FROM [AdminInfo] WHERE [AdminID]=@AdminID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@AdminID", SqlDbType.Int, 4) { Value = model.AdminID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [AdminInfo]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [AdminInfo] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(AdminInfo model)
        {
            string strSql = "UPDATE [AdminInfo] SET [AdminLoginID] = ISNULL(@AdminLoginID,[AdminLoginID]),[AdnminPasssword] = ISNULL(@AdnminPasssword,[AdnminPasssword]),[AdminName] = ISNULL(@AdminName,[AdminName]),[AdminJurisdictionID] = ISNULL(@AdminJurisdictionID,[AdminJurisdictionID]) WHERE [AdminID]=@AdminID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@AdminID", SqlDbType.Int,4),
                         new SqlParameter("@AdminLoginID", SqlDbType.Int,4),
                         new SqlParameter("@AdnminPasssword", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminName", SqlDbType.VarChar,50),
                         new SqlParameter("@AdminJurisdictionID", SqlDbType.Int,4)
                     }
                 );
                sqlCmd.Parameters["@AdminID"].Value = model.AdminID;
                if (model.AdminLoginID == null) { sqlCmd.Parameters["@AdminLoginID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminLoginID"].Value = model.AdminLoginID; }
                if (model.AdnminPasssword == null) { sqlCmd.Parameters["@AdnminPasssword"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdnminPasssword"].Value = model.AdnminPasssword; }
                if (model.AdminName == null) { sqlCmd.Parameters["@AdminName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminName"].Value = model.AdminName; }
                if (model.AdminJurisdictionID == null) { sqlCmd.Parameters["@AdminJurisdictionID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@AdminJurisdictionID"].Value = model.AdminJurisdictionID; }
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
        public static AdminInfo SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [AdminInfo] WHERE {0};", condition);
            return SelectBySql(strSql);
        }
        /// <summary>
        /// 根据管理员编号查询数据
        /// </summary>
        /// <param name="_AdminID">管理员编号</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminID(int _AdminID)
        {
            string strSql = "SELECT * FROM [AdminInfo] WHERE [AdminID]=@AdminID;";
            return SelectBySql(strSql, new SqlParameter("@AdminID", _AdminID));
        }
        /// <summary>
        /// 根据登录名查询数据
        /// </summary>
        /// <param name="_AdminLoginID">登录名</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminLoginID(int _AdminLoginID)
        {
            string strSql = "SELECT * FROM [AdminInfo] WHERE [AdminLoginID]=@AdminLoginID;";
            return SelectBySql(strSql, new SqlParameter("@AdminLoginID", _AdminLoginID));
        }
        /// <summary>
        /// 根据管理员密码查询数据
        /// </summary>
        /// <param name="_AdnminPasssword">管理员密码</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdnminPasssword(string _AdnminPasssword)
        {
            string strSql = "SELECT * FROM [AdminInfo] WHERE [AdnminPasssword]=@AdnminPasssword;";
            return SelectBySql(strSql, new SqlParameter("@AdnminPasssword", _AdnminPasssword));
        }
        /// <summary>
        /// 根据管理员名称查询数据
        /// </summary>
        /// <param name="_AdminName">管理员名称</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminName(string _AdminName)
        {
            string strSql = "SELECT * FROM [AdminInfo] WHERE [AdminName]=@AdminName;";
            return SelectBySql(strSql, new SqlParameter("@AdminName", _AdminName));
        }
        /// <summary>
        /// 根据权限ID查询数据
        /// </summary>
        /// <param name="_AdminJurisdictionID">权限ID</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminJurisdictionID(int _AdminJurisdictionID)
        {
            string strSql = "SELECT * FROM [AdminInfo] WHERE [AdminJurisdictionID]=@AdminJurisdictionID;";
            return SelectBySql(strSql, new SqlParameter("@AdminJurisdictionID", _AdminJurisdictionID));
        }
        #endregion

        #region 登录|注册


        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <returns></returns>
        public static AdminInfo loginLeave(string Name, string Pwd)
        {
            string sql = string.Format("select * from [AdminInfo] where AdminLoginID={0} and AdnminPasssword='{1}'", Name, Pwd);
            return SelectBySql(sql);
        }


        /// <summary>
        /// 新密码界面跟新密码
        /// </summary>
        /// <param name="LoginID"></param>
        /// <returns></returns>
        public static int updatePwd(int LoginID, string Pwd)
        {
            string sql = string.Format("update [AdminInfo] set [AdnminPasssword]='{0}' WHERE [AdminLoginID]={1};", Pwd, LoginID);
            return tool.update(sql);
        }

        #endregion
    }
}
