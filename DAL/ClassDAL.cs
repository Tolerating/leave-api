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
    public class ClassDAL
    {
        public static string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;


        #region tool
        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public static Class SelectBySql(String strSql)
        {
            Class model = new Class();
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
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static Class SelectBySql(String strSql, SqlParameter sqlParam)
        {
            Class model = new Class();
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
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static Class SelectBySql1(String strSql, SqlParameter sqlParam)
        {
            Class model = new Class();
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
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);

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
        public static Class SelectBySql(String strSql, params SqlParameter[] sqlParams)
        {
            Class model = new Class();
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
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static IList<Class> SelectAllBySql(string strSql)
        {
            IList<Class> modelList = new List<Class>();
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
                                Class model = new Class();
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static IList<Class> SelectAllBySql(string strSql, SqlParameter sqlParam)
        {
            IList<Class> modelList = new List<Class>();
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
                                Class model = new Class();
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static IList<Class> SelectAllBySql(string strSql, params SqlParameter[] sqlParams)
        {
            IList<Class> modelList = new List<Class>();
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
                                Class model = new Class();
                                if (sdr["ClassID"] != DBNull.Value) model.ClassID = Convert.ToInt32(sdr["ClassID"]);
                                if (sdr["ClassName"] != DBNull.Value) model.ClassName = Convert.ToString(sdr["ClassName"]);
                                if (sdr["ClassSpecialityID"] != DBNull.Value) model.ClassSpecialityID = Convert.ToInt32(sdr["ClassSpecialityID"]);
                                if (sdr["ClassHeadTeacherID"] != DBNull.Value) model.ClassHeadTeacherID = Convert.ToInt32(sdr["ClassHeadTeacherID"]);
                                if (sdr["ClassNum"] != DBNull.Value) model.ClassNum = Convert.ToString(sdr["ClassNum"]);
                                if (sdr["ClassSpecialityTeacherID"] != DBNull.Value) model.ClassSpecialityTeacherID = Convert.ToInt32(sdr["ClassSpecialityTeacherID"]);
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
        public static int Insert(Class model)
        {
            string strSql = "INSERT INTO [Class] ([ClassName],[ClassSpecialityID],[ClassHeadTeacherID],[ClassNum],[ClassSpecialityTeacherID]) VALUES (@ClassName,@ClassSpecialityID,@ClassHeadTeacherID,@ClassNum,@ClassSpecialityTeacherID);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                         new SqlParameter("@ClassSpecialityID", SqlDbType.Int,4),
                         new SqlParameter("@ClassHeadTeacherID", SqlDbType.Int,4),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassSpecialityTeacherID", SqlDbType.Int,4)
                     }
                 );
                if (model.ClassName == null) { sqlCmd.Parameters["@ClassName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassName"].Value = model.ClassName; }
                if (model.ClassSpecialityID == 0) { sqlCmd.Parameters["@ClassSpecialityID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassSpecialityID"].Value = model.ClassSpecialityID; }
                if (model.ClassHeadTeacherID == 0) { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = model.ClassHeadTeacherID; }
                if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                if (model.ClassSpecialityTeacherID == 0) { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = 0; } else { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = model.ClassSpecialityTeacherID; }
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
        public static void Insert(Class[] modelList)
        {
            string strSql = "INSERT INTO [Class] ([ClassName],[ClassSpecialityID],[ClassHeadTeacherID],[ClassNum],[ClassSpecialityTeacherID]) VALUES (@ClassName,@ClassSpecialityID,@ClassHeadTeacherID,@ClassNum,@ClassSpecialityTeacherID);";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                         new SqlParameter("@ClassSpecialityID", SqlDbType.Int,4),
                         new SqlParameter("@ClassHeadTeacherID", SqlDbType.Int,4),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassSpecialityTeacherID", SqlDbType.Int,4)
                     }
                 );
                try
                {
                    sqlConn.Open();
                    foreach (Class model in modelList)
                    {
                        if (model.ClassName == null) { sqlCmd.Parameters["@ClassName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassName"].Value = model.ClassName; }
                        if (model.ClassSpecialityID == null) { sqlCmd.Parameters["@ClassSpecialityID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassSpecialityID"].Value = model.ClassSpecialityID; }
                        if (model.ClassHeadTeacherID == null) { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = model.ClassHeadTeacherID; }
                        if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                        if (model.ClassNum == null) { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = model.ClassNum; }
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
        /// <param name="_ClassID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByClassID(int _ClassID)
        {
            string strSql = "DELETE FROM [Class] WHERE [ClassID]=@ClassID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@ClassID", SqlDbType.Int, 4) { Value = _ClassID });
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Class model)
        {
            string strSql = "DELETE FROM [Class] WHERE [ClassID]=@ClassID;";
            return tool.ExecuteNonQuery(strSql, new SqlParameter("@ClassID", SqlDbType.Int, 4) { Value = model.ClassID });
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            string strSql = "SELECT COUNT(*) FROM [Class]";
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            string strSql = string.Format("SELECT COUNT(*) FROM [Class] WHERE {0};", condition);
            return (int)tool.ExecuteScalar(strSql);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Class model)
        {
            string strSql = "UPDATE [Class] SET [ClassName] = ISNULL(@ClassName,[ClassName]),[ClassSpecialityID] = ISNULL(@ClassSpecialityID,[ClassSpecialityID]),[ClassHeadTeacherID] = ISNULL(@ClassHeadTeacherID,[ClassHeadTeacherID]),[ClassNum] = ISNULL(@ClassNum,[ClassNum]),[ClassSpecialityTeacherID] = ISNULL(@ClassSpecialityTeacherID,[ClassSpecialityTeacherID]) WHERE [ClassID]=@ClassID;";
            using (SqlConnection sqlConn = new SqlConnection(strConn))
            {
                SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
                sqlCmd.Parameters.AddRange(
                    new SqlParameter[]{
                         new SqlParameter("@ClassID", SqlDbType.Int,4),
                         new SqlParameter("@ClassName", SqlDbType.VarChar,50),
                         new SqlParameter("@ClassSpecialityID", SqlDbType.Int,4),
                         new SqlParameter("@ClassHeadTeacherID", SqlDbType.Int,4),
                         new SqlParameter("@ClassNum", SqlDbType.VarChar,10),
                         new SqlParameter("@ClassSpecialityTeacherID", SqlDbType.Int,4)
                     }
                 );
                sqlCmd.Parameters["@ClassID"].Value = model.ClassID;
                if (model.ClassName == null) { sqlCmd.Parameters["@ClassName"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassName"].Value = model.ClassName; }
                if (model.ClassSpecialityID == null) { sqlCmd.Parameters["@ClassSpecialityID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassSpecialityID"].Value = model.ClassSpecialityID; }
                if (model.ClassHeadTeacherID == null) { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassHeadTeacherID"].Value = model.ClassHeadTeacherID; }
                if (model.ClassNum == null) { sqlCmd.Parameters["@ClassNum"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassNum"].Value = model.ClassNum; }
                if (model.ClassNum == null) { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = DBNull.Value; } else { sqlCmd.Parameters["@ClassSpecialityTeacherID"].Value = model.ClassNum; }
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
        public static IList<Class> SelectAll()
        {
            string strSql = "SELECT * FROM [Class];";
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Class> SelectAll(int number, int begin)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Class] WHERE [ClassID] NOT IN (SELECT TOP {1} [ClassID] FROM [Class]);", number, begin);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Class] WHERE {0};", condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByCondition(int number, int begin, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Class] WHERE ([ClassID] NOT IN (SELECT TOP {1} [ClassID] FROM [Class] WHERE {2})) AND {2};", number, begin, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByCondition(int number, string condition)
        {
            string strSql = string.Format("SELECT TOP {0} * FROM [Class] WHERE {1};", number, condition);
            return SelectAllBySql(strSql);
        }
        /// <summary>
        /// 根据班级编号查询所有数据
        /// </summary>
        /// <param name="_ClassID">班级编号</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassID(int _ClassID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassID]=@ClassID;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassID", _ClassID));
        }
        /// <summary>
        /// 根据班级名称查询所有数据
        /// </summary>
        /// <param name="_ClassName">班级名称</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassName(string _ClassName)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassName]=@ClassName;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassName", _ClassName));
        }

        /// <summary>
        /// 根据班主任Id查询所有数据
        /// </summary>
        /// <param name="_ClassHeadTeacherID">班主任Id</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassHeadTeacherID(int _ClassHeadTeacherID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassHeadTeacherID]=@ClassHeadTeacherID;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassHeadTeacherID", _ClassHeadTeacherID));
        }
        /// <summary>
        /// 根据班级id查询所有数据
        /// </summary>
        /// <param name="_ClassNum">班级id</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassNum(string _ClassNum)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassNum]=@ClassNum;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassNum", _ClassNum));
        }
        #endregion

        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static Class SelectByCondition(string condition)
        {
            string strSql = string.Format("SELECT * FROM [Class] WHERE {0};", condition);
            return SelectBySql(strSql);
        }
        /// <summary>
        /// 根据班级编号查询数据
        /// </summary>
        /// <param name="_ClassID">班级编号</param>
        /// <returns></returns>
        public static Class SelectByClassID(int _ClassID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassID]=@ClassID;";
            return SelectBySql(strSql, new SqlParameter("@ClassID", _ClassID));
        }
        /// <summary>
        /// 根据班级名称查询数据
        /// </summary>
        /// <param name="_ClassName">班级名称</param>
        /// <returns></returns>
        public static Class SelectByClassName(string _ClassName)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassName]=@ClassName;";
            return SelectBySql(strSql, new SqlParameter("@ClassName", _ClassName));
        }
        /// <summary>
        /// 根据所属专业查询数据
        /// </summary>
        /// <param name="_ClassSpecialityID">所属专业</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityID(int _ClassSpecialityID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassSpecialityID]=@ClassSpecialityID;";
            return SelectBySql(strSql, new SqlParameter("@ClassSpecialityID", _ClassSpecialityID));
        }

        /// <summary>
        /// 根据所属专业查询数据
        /// </summary>
        /// <param name="_ClassSpecialityID">所属专业</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityID1(int _ClassSpecialityID1)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassSpecialityID]=@ClassSpecialityID;";
            return SelectBySql1(strSql, new SqlParameter("@ClassSpecialityID", _ClassSpecialityID1));
        }

        /// <summary>
        /// 根据班主任Id查询数据
        /// </summary>
        /// <param name="_ClassHeadTeacherID">班主任Id</param>
        /// <returns></returns>
        public static Class SelectByClassHeadTeacherID(int _ClassHeadTeacherID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassHeadTeacherID]=@ClassHeadTeacherID;";
            return SelectBySql(strSql, new SqlParameter("@ClassHeadTeacherID", _ClassHeadTeacherID));
        }

        /// <summary>
        /// 根据辅导员Id查询数据
        /// </summary>
        /// <param name="_ClassHeadTeacherID">班主任Id</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityTeacherID(int _ClassSpecialityTeacherID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassSpecialityTeacherID]=@ClassSpecialityTeacherID;";
            return SelectBySql(strSql, new SqlParameter("@ClassSpecialityTeacherID", _ClassSpecialityTeacherID));
        }

        /// <summary>
        /// 根据班级id查询数据
        /// </summary>
        /// <param name="_ClassNum">班级id</param>
        /// <returns></returns>
        public static Class SelectByClassNum(string _ClassNum)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassNum]=@ClassNum;";
            return SelectBySql(strSql, new SqlParameter("@ClassNum", _ClassNum));
        }
        #endregion

        #region 登录|注册|忘记密码
        /// <summary>
        /// 检查班级是否已经存在
        /// </summary>
        /// <returns></returns>
        public static Class checkStuAndTeaID(string ClassNum)
        {
            string sql = string.Format("select * from Class where ClassNum = '{0}'", ClassNum);
            return SelectBySql(sql);
        }

        /// <summary>
        /// 通过班主任ID获取班级信息并存储到session
        /// </summary>
        /// <returns></returns>
        public static Class getBInfo(int TeacherID)
        {
            string sql = string.Format("select * from Class where ClassHeadTeacherID = {0}", TeacherID);
            return SelectBySql(sql);
        }

        /// <summary>
        /// 通过辅导员ID获取班级信息并存储到session
        /// </summary>
        /// <returns></returns>
        public static Class getFInfo(int TeacherID)
        {
            string sql = string.Format("select * from Class where ClassSpecialityTeacherID = {0}", TeacherID);
            return SelectBySql(sql);
        }

        #endregion

        #region 学生请假/个人信息

        /// <summary>
        /// 获取班级全部信息
        /// </summary>
        /// <param name="classNum">班级ID</param>
        /// <returns></returns>
        public static Class getClassInfo(string classNum)
        {
            string sql = string.Format("select * from [Class] where ClassNum='{0}'", classNum);
            return SelectBySql(sql);
        }
        #endregion

        #region 本周周末审核


        /// <summary>
        /// 根据所属专业查询所有数据
        /// </summary>
        /// <param name="_ClassSpecialityID">所属专业</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassSpecialityID(int TeacherID)
        {
            string strSql = "SELECT * FROM [Class] WHERE [ClassSpecialityTeacherID]=@ClassSpecialityTeacherID;";
            return SelectAllBySql(strSql, new SqlParameter("@ClassSpecialityTeacherID", TeacherID));
        }
        #endregion

        #region 其他历史记录

        /// <summary>
        /// 选择全部的班级ID
        /// </summary>
        /// <returns></returns>
        public static DataTable getClassID()
        {
            string sql = "select ClassNum,ClassName from Class";
            return tool.Select(sql);
        }

        #endregion
    }
}
