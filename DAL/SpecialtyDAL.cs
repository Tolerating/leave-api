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
    public class SpecialtyDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Specialty SelectBySql(String strSql)
        {
            Specialty model = new Specialty();
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
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static Specialty SelectBySql(String strSql, SqlParameter sqlParam)
        {
            Specialty model = new Specialty();
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
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static Specialty SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            Specialty model = new Specialty();
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
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static IList<Specialty> SelectAllBySql(string strSql)
        {
            IList<Specialty> modelList = new List<Specialty>();
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
                                Specialty model = new Specialty();
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static IList<Specialty> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<Specialty> modelList = new List<Specialty>();
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
                                Specialty model = new Specialty();
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static IList<Specialty> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<Specialty> modelList = new List<Specialty>();
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
                                Specialty model = new Specialty();
                                if (sdr["SpecialtyID"] != DBNull.Value) model.SpecialtyID = Convert.ToInt32(sdr["SpecialtyID"]);
                                if (sdr["SpecialtyName"] != DBNull.Value) model.SpecialtyName = Convert.ToString(sdr["SpecialtyName"]);
                                if (sdr["SpecialtyCollegeID"] != DBNull.Value) model.SpecialtyCollegeID = Convert.ToInt32(sdr["SpecialtyCollegeID"]);
                                if (sdr["SpecialtyNum"] != DBNull.Value) model.SpecialtyNum = Convert.ToString(sdr["SpecialtyNum"]);
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
        public static int Insert(Specialty model)
        {
            string strSql = "INSERT INTO [Specialty] ([SpecialtyName],[SpecialtyCollegeID],[SpecialtyNum]) VALUES (@SpecialtyName,@SpecialtyCollegeID,@SpecialtyNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@SpecialtyName", SqlDbType.VarChar,50),
                         new SqlParameter("@SpecialtyCollegeID", SqlDbType.Int,4),
                         new SqlParameter("@SpecialtyNum", SqlDbType.VarChar,50),
                     }
                 );
                if (model.SpecialtyName == null) { sqlCmd.Parameters["@SpecialtyName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyName"].Value = model.SpecialtyName; }
                if (model.SpecialtyCollegeID == null) { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = model.SpecialtyCollegeID; }
                if (model.SpecialtyNum == null) { sqlCmd.Parameters["@SpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyNum"].Value = model.SpecialtyNum; }
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
        public static void Insert(Specialty[] modelList)
        {
            string strSql = "INSERT INTO [Specialty] ([SpecialtyName],[SpecialtyCollegeID],[SpecialtyNum]) VALUES (@SpecialtyName,@SpecialtyCollegeID,@SpecialtyNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@SpecialtyName", SqlDbType.VarChar,50),
                         new SqlParameter("@SpecialtyCollegeID", SqlDbType.Int,4),
                         new SqlParameter("@SpecialtyNum", SqlDbType.VarChar,50),
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Specialty model in modelList)
                    {
                        if (model.SpecialtyName == null) { sqlCmd.Parameters["@SpecialtyName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyName"].Value = model.SpecialtyName; }
                        if (model.SpecialtyCollegeID == null) { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = model.SpecialtyCollegeID; }
                        if (model.SpecialtyNum == null) { sqlCmd.Parameters["@SpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyNum"].Value = model.SpecialtyNum; }
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
        /// <param name="_SpecialtyID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteBySpecialtyID(int _SpecialtyID)
        {
            string strSql = "DELETE FROM [Specialty] WHERE [SpecialtyID]=@SpecialtyID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@SpecialtyID", SqlDbType.Int, 4) { Value = _SpecialtyID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Specialty model)
        {
            string strSql = "DELETE FROM [Specialty] WHERE [SpecialtyID]=@SpecialtyID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@SpecialtyID", SqlDbType.Int, 4) { Value = model.SpecialtyID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [Specialty]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [Specialty] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Specialty model)
        {
            string strSql = "UPDATE [Specialty] SET [SpecialtyName] = ISNULL(@SpecialtyName,[SpecialtyName]),[SpecialtyCollegeID] = ISNULL(@SpecialtyCollegeID,[SpecialtyCollegeID]),[SpecialtyNum] = ISNULL(@SpecialtyNum,[SpecialtyNum]) WHERE [SpecialtyID]=@SpecialtyID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@SpecialtyID", SqlDbType.Int,4),
                         new SqlParameter("@SpecialtyName", SqlDbType.VarChar,50),
                         new SqlParameter("@SpecialtyCollegeID", SqlDbType.Int,4),
                         new SqlParameter("@SpecialtyNum", SqlDbType.VarChar,50),
                     }
                 );
                sqlCmd.Parameters["@SpecialtyID"].Value = model.SpecialtyID;
                if (model.SpecialtyName == null) { sqlCmd.Parameters["@SpecialtyName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyName"].Value = model.SpecialtyName; }
                if (model.SpecialtyCollegeID == null) { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyCollegeID"].Value = model.SpecialtyCollegeID; }
                if (model.SpecialtyNum == null) { sqlCmd.Parameters["@SpecialtyNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@SpecialtyNum"].Value = model.SpecialtyNum; }
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
        public static IList<Specialty> SelectAll()
        {
            string strSql = "SELECT * FROM [Specialty] order by SpecialtyNum;";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Specialty] WHERE [SpecialtyID] NOT IN (SELECT TOP {1} [SpecialtyID] FROM [Specialty]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Specialty] WHERE {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Specialty] WHERE ([SpecialtyID] NOT IN (SELECT TOP {1} [SpecialtyID] FROM [Specialty] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Specialty] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据专业编号查询所有数据
        /// </summary>
        /// <param name="_SpecialtyID">专业编号</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyID(int _SpecialtyID)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyID]=@SpecialtyID;";
            return SelectAllBySql(strSql, new SqlParameter("@SpecialtyID", _SpecialtyID));
        }
        /// <summary>
        /// 根据专业名称查询所有数据
        /// </summary>
        /// <param name="_SpecialtyName">专业名称</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyName(string _SpecialtyName)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyName]=@SpecialtyName;";
            return SelectAllBySql(strSql, new SqlParameter("@SpecialtyName", _SpecialtyName));
        }
        /// <summary>
        /// 根据所属学院Id查询所有数据
        /// </summary>
        /// <param name="_SpecialtyCollegeID">所属学院Id</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyCollegeID(int _SpecialtyCollegeID)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyCollegeID]=@SpecialtyCollegeID;";
            return SelectAllBySql(strSql, new SqlParameter("@SpecialtyCollegeID", _SpecialtyCollegeID));
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_SpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyNum(string _SpecialtyNum)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyNum]=@SpecialtyNum;";
            return SelectAllBySql(strSql, new SqlParameter("@SpecialtyNum", _SpecialtyNum));
        }
        /// <summary>
        /// 根据辅导员ID查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">辅导员ID</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [TeacherNum]=@TeacherNum;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        #endregion

        /// <summary>
        /// 通过sql语句进行数据库Specialty表的查询,返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable SelectAllBysql(string sql)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable ds = new DataTable();
                        sda.Fill(ds);
                        return ds;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static Specialty SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Specialty] WHERE {0};", condition);
            return SelectBySql(strSql);
        }
        /// <summary>
        /// 根据专业编号查询数据
        /// </summary>
        /// <param name="_SpecialtyID">专业编号</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyID(int _SpecialtyID)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyID]=@SpecialtyID;";
            return SelectBySql(strSql, new SqlParameter("@SpecialtyID", _SpecialtyID));
        }
        /// <summary>
        /// 根据专业名称查询数据
        /// </summary>
        /// <param name="_SpecialtyName">专业名称</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyName(string _SpecialtyName)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyName]=@SpecialtyName;";
            return SelectBySql(strSql, new SqlParameter("@SpecialtyName", _SpecialtyName));
        }
        /// <summary>
        /// 根据所属学院Id查询数据
        /// </summary>
        /// <param name="_SpecialtyCollegeID">所属学院Id</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyCollegeID(int _SpecialtyCollegeID)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyCollegeID]=@SpecialtyCollegeID;";
            return SelectBySql(strSql, new SqlParameter("@SpecialtyCollegeID", _SpecialtyCollegeID));
        }
        /// <summary>
        /// 根据专业id查询数据
        /// </summary>
        /// <param name="_SpecialtyNum">专业id</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyNum(string _SpecialtyNum)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [SpecialtyNum]=@SpecialtyNum;";
            return SelectBySql(strSql, new SqlParameter("@SpecialtyNum", _SpecialtyNum));
        }
        /// <summary>
        /// 根据辅导员ID查询数据
        /// </summary>
        /// <param name="_TeacherNum">辅导员ID</param>
        /// <returns></returns>
        public static Specialty SelectByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [Specialty] WHERE [TeacherNum]=@TeacherNum;";
            return SelectBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        #endregion

        /// <summary>
        /// 获取Specialty表SpecialtyName,SpecialtyCollegeID,SpecialtyNum的数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getSpecialtysm()
        {
            string sql = "SELECT SpecialtyName,SpecialtyCollegeID,SpecialtyNum  FROM Specialty";
            return SelectAllBysql(sql);
        }
    }
}
