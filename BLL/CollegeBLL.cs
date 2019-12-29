using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class CollegeBLL
    {
        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(College model)
        {
            return CollegeDAL.Insert(model);
        }
        /// <summary>
        /// 批量插入记录
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(College[] modelList)
        {
            CollegeDAL.Insert(modelList);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_CollegeID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByCollegeID(int _CollegeID)
        {
            return CollegeDAL.DeleteByCollegeID(_CollegeID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(College model)
        {
            return CollegeDAL.Delete(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(College model)
        {
            return CollegeDAL.Update(model);
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return CollegeDAL.SelectCount();
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return CollegeDAL.SelectCountByCondition(condition);
        }
        #endregion

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<College> SelectAll()
        {
            return CollegeDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<College> SelectAll(int number, int begin)
        {
            return CollegeDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCondition(string condition)
        {
            return CollegeDAL.SelectAllByCondition(condition);
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
            return CollegeDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCondition(int number, string condition)
        {
            return CollegeDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据学院编号查询所有数据
        /// </summary>
        /// <param name="_CollegeID">学院编号</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeID(int _CollegeID)
        {
            return CollegeDAL.SelectAllByCollegeID(_CollegeID);
        }
        /// <summary>
        /// 根据学院名称查询所有数据
        /// </summary>
        /// <param name="_CollegeName">学院名称</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeName(string _CollegeName)
        {
            return CollegeDAL.SelectAllByCollegeName(_CollegeName);
        }
        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_CollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<College> SelectAllByCollegeNum(string _CollegeNum)
        {
            return CollegeDAL.SelectAllByCollegeNum(_CollegeNum);
        }
        /// <summary>
        /// 根据院领导ID查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">院领导ID</param>
        /// <returns></returns>
        public static IList<College> SelectAllByTeacherNum(string _TeacherNum)
        {
            return CollegeDAL.SelectAllByTeacherNum(_TeacherNum);
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
            return CollegeDAL.SelectByCondition(condition);
        }
        /// <summary>
        /// 根据学院编号查询数据
        /// </summary>
        /// <param name="condition">学院编号</param>
        /// <returns></returns>
        public static College SelectByCollegeID(int _CollegeID)
        {
            return CollegeDAL.SelectByCollegeID(_CollegeID);
        }
        /// <summary>
        /// 根据学院名称查询数据
        /// </summary>
        /// <param name="condition">学院名称</param>
        /// <returns></returns>
        public static College SelectByCollegeName(string _CollegeName)
        {
            return CollegeDAL.SelectByCollegeName(_CollegeName);
        }
        /// <summary>
        /// 根据学院id查询数据
        /// </summary>
        /// <param name="condition">学院id</param>
        /// <returns></returns>
        public static College SelectByCollegeNum(string _CollegeNum)
        {
            return CollegeDAL.SelectByCollegeNum(_CollegeNum);
        }
        /// <summary>
        /// 根据院领导ID查询数据
        /// </summary>
        /// <param name="condition">院领导ID</param>
        /// <returns></returns>
        public static College SelectByTeacherNum(string _TeacherNum)
        {
            return CollegeDAL.SelectByTeacherNum(_TeacherNum);
        }
        #endregion

        #region 登录|注册|忘记密码
        /// <summary>
        /// 获取College表CollegeNum,CollegeName的数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getCollege()
        {
            return CollegeDAL.getCollege();
        }

        /// <summary>
        /// 检查学院表中院领导是否已经注册
        /// </summary>
        /// <returns></returns>
        //public static int checkStuAndTeaID(string College)
        //{
        //    return CollegeDAL.checkStuAndTeaID(College);
        //}


        /// <summary>
        /// 检查学院领导是否已经存在
        /// </summary>
        /// <param name="college">学院ID</param>
        /// <returns></returns>
        public static College SelectALLbyCollegeNum(string college)
        {
            return CollegeDAL.SelectALLbyCollegeNum(college);
        }


        /// <summary>
        /// 获取学院信息并存储session
        /// </summary>
        /// <param name="TeacherID"></param>
        /// <returns></returns>
        public static College getColInfo(string TeacherID)
        {
            return CollegeDAL.getColInfo(TeacherID);
        }

        #endregion
    }
}
