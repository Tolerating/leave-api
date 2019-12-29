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
    public class CollegeDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;


        #region tool
        /// <summary>
        /// 通过sql语句进行数据库College表的查询,返回College
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>College</returns>
        public static College SelectBysql(string sql)
        {
            College model = new College();
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
                            }
                        }
                        return model;
                    }
                    catch (Exception)
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
        public static College SelectBySql(String strSql, SqlParameter sqlParam)
        {
            College model = new College();
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
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
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
        public static College SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            College model = new College();
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
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
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
        public static IList<College> SelectAllBySql(string strSql)
        {
            IList<College> modelList = new List<College>();
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
                                College model = new College();
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
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
        public static IList<College> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<College> modelList = new List<College>();
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
                                College model = new College();
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
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
        public static IList<College> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<College> modelList = new List<College>();
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
                                College model = new College();
                                if (sdr["CollegeID"] != DBNull.Value) model.CollegeID = Convert.ToInt32(sdr["CollegeID"]);
                                if (sdr["CollegeName"] != DBNull.Value) model.CollegeName = Convert.ToString(sdr["CollegeName"]);
                                if (sdr["CollegeNum"] != DBNull.Value) model.CollegeNum = Convert.ToString(sdr["CollegeNum"]);
                                if (sdr["TeacherNum"] != DBNull.Value) model.TeacherNum = Convert.ToString(sdr["TeacherNum"]);
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
        public static int Insert(College model)
        {
            string strSql = "INSERT INTO [College] ([CollegeName],[CollegeNum],[TeacherNum]) VALUES (@CollegeName,@CollegeNum,@TeacherNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@CollegeName", SqlDbType.VarChar,50),
                         new SqlParameter("@CollegeNum", SqlDbType.VarChar,10),
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12)
                     }
                 );
                if (model.CollegeName == null) { sqlCmd.Parameters["@CollegeName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeName"].Value = model.CollegeName; }
                if (model.CollegeNum == null) { sqlCmd.Parameters["@CollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeNum"].Value = model.CollegeNum; }
                if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
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
        public static void Insert(College[] modelList)
        {
            string strSql = "INSERT INTO [College] ([CollegeName],[CollegeNum],[TeacherNum]) VALUES (@CollegeName,@CollegeNum,@TeacherNum);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@CollegeName", SqlDbType.VarChar,50),
                         new SqlParameter("@CollegeNum", SqlDbType.VarChar,10),
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (College model in modelList)
                    {
                        if (model.CollegeName == null) { sqlCmd.Parameters["@CollegeName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeName"].Value = model.CollegeName; }
                        if (model.CollegeNum == null) { sqlCmd.Parameters["@CollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeNum"].Value = model.CollegeNum; }
                        if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
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
        /// <param name="_CollegeID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByCollegeID(int _CollegeID)
        {
            string strSql = "DELETE FROM [College] WHERE [CollegeID]=@CollegeID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@CollegeID", SqlDbType.Int, 4) { Value = _CollegeID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(College model)
        {
            string strSql = "DELETE FROM [College] WHERE [CollegeID]=@CollegeID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@CollegeID", SqlDbType.Int, 4) { Value = model.CollegeID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [College]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [College] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(College model)
        {
            string strSql = "UPDATE [College] SET [CollegeName] = ISNULL(@CollegeName,[CollegeName]),[CollegeNum] = ISNULL(@CollegeNum,[CollegeNum]),[TeacherNum] = ISNULL(@TeacherNum,[TeacherNum]) WHERE [CollegeID]=@CollegeID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@CollegeID", SqlDbType.Int,4),
                         new SqlParameter("@CollegeName", SqlDbType.VarChar,50),
                         new SqlParameter("@CollegeNum", SqlDbType.VarChar,10),
                         new SqlParameter("@TeacherNum", SqlDbType.VarChar,12)
                     }
                 );
                sqlCmd.Parameters["@CollegeID"].Value = model.CollegeID;
                if (model.CollegeName == null) { sqlCmd.Parameters["@CollegeName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeName"].Value = model.CollegeName; }
                if (model.CollegeNum == null) { sqlCmd.Parameters["@CollegeNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@CollegeNum"].Value = model.CollegeNum; }
                if (model.TeacherNum == null) { sqlCmd.Parameters["@TeacherNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@TeacherNum"].Value = model.TeacherNum; }
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
        public static IList<College> SelectAll()
        {
            string strSql = "SELECT * FROM [College];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<College> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [College] WHERE [CollegeID] NOT IN (SELECT TOP {1} [CollegeID] FROM [College]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [College] WHERE {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [College] WHERE ([CollegeID] NOT IN (SELECT TOP {1} [CollegeID] FROM [College] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [College] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据学院编号查询所有数据
        /// </summary>
        /// <param name="_CollegeID">学院编号</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeID(int _CollegeID)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeID]=@CollegeID;";
            return SelectAllBySql(strSql, new SqlParameter("@CollegeID", _CollegeID));
        }
        /// <summary>
        /// 根据学院名称查询所有数据
        /// </summary>
        /// <param name="_CollegeName">学院名称</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeName(string _CollegeName)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeName]=@CollegeName;";
            return SelectAllBySql(strSql, new SqlParameter("@CollegeName", _CollegeName));
        }
        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_CollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeNum(string _CollegeNum)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeNum]=@CollegeNum;";
            return SelectAllBySql(strSql, new SqlParameter("@CollegeNum", _CollegeNum));
        }
        /// <summary>
        /// 根据院领导ID查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">院领导ID</param>
        /// <returns></returns>
        public static IList<College> SelectAllByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [College] WHERE [TeacherNum]=@TeacherNum;";
            return SelectAllBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        #endregion



        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static College SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [College] WHERE {0};", condition);
            return SelectBySql(strSql);
        }
        /// <summary>
        /// 根据学院编号查询数据
        /// </summary>
        /// <param name="_CollegeID">学院编号</param>
        /// <returns></returns>
        public static College SelectByCollegeID(int _CollegeID)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeID]=@CollegeID;";
            return SelectBySql(strSql, new SqlParameter("@CollegeID", _CollegeID));
        }
        /// <summary>
        /// 根据学院名称查询数据
        /// </summary>
        /// <param name="_CollegeName">学院名称</param>
        /// <returns></returns>
        public static College SelectByCollegeName(string _CollegeName)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeName]=@CollegeName;";
            return SelectBySql(strSql, new SqlParameter("@CollegeName", _CollegeName));
        }
        /// <summary>
        /// 根据学院id查询数据
        /// </summary>
        /// <param name="_CollegeNum">学院id</param>
        /// <returns></returns>
        public static College SelectByCollegeNum(string _CollegeNum)
        {
            string strSql = "SELECT * FROM [College] WHERE [CollegeNum]=@CollegeNum;";
            return SelectBySql(strSql, new SqlParameter("@CollegeNum", _CollegeNum));
        }
        /// <summary>
        /// 根据院领导ID查询数据
        /// </summary>
        /// <param name="_TeacherNum">院领导ID</param>
        /// <returns></returns>
        public static College SelectByTeacherNum(string _TeacherNum)
        {
            string strSql = "SELECT * FROM [College] WHERE [TeacherNum]=@TeacherNum;";
            return SelectBySql(strSql, new SqlParameter("@TeacherNum", _TeacherNum));
        }
        #endregion

        /// <summary>
        /// 通过sql语句进行数据库College表的查询,返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataTable</returns>
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


        #region 登录|注册|忘记密码


        /// <summary>
        /// 获取College表CollegeNum,CollegeName的数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getCollege()
        {
            string sql = "select CollegeNum,CollegeName from [College]";
            DataTable ds = SelectAllBysql(sql);
            return ds;
        }

        public static College SelectALLbyCollegeNum(string college)
        {
            string sql = string.Format("select * from College where CollegeNum = {0}", college);
            return SelectBysql(sql);
        }

        /// <summary>
        /// 检查学院表中院领导是否已经注册
        /// </summary>
        /// <returns></returns>
        //public static int checkStuAndTeaID(string College) {
        //    string sql = string.Format("select * from College where TeacherNum = {0}", College);
        //    return (int)tool.ExecuteScalar(sql);
        //}

        /// <summary>
        /// 获取学院信息并存储session
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        public static College getColInfo(string TeacherID)
        {
            string sql = string.Format("select * from College where TeacherNum = {0}", TeacherID);
            return SelectBysql(sql);
        }
        #endregion
    }
}
