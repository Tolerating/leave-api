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
    public class SpecialtyBLL
    {
        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(Specialty model)
        {
            return SpecialtyDAL.Insert(model);
        }
        /// <summary>
        /// 批量插入记录
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Specialty[] modelList)
        {
            SpecialtyDAL.Insert(modelList);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_SpecialtyID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteBySpecialtyID(int _SpecialtyID)
        {
            return SpecialtyDAL.DeleteBySpecialtyID(_SpecialtyID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Specialty model)
        {
            return SpecialtyDAL.Delete(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Specialty model)
        {
            return SpecialtyDAL.Update(model);
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return SpecialtyDAL.SelectCount();
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return SpecialtyDAL.SelectCountByCondition(condition);
        }
        #endregion

        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static Specialty SelectByCondition(string condition)
        {
            return SpecialtyDAL.SelectByCondition(condition);
        }
        /// <summary>
        /// 根据专业编号查询数据
        /// </summary>
        /// <param name="condition">专业编号</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyID(int _SpecialtyID)
        {
            return SpecialtyDAL.SelectBySpecialtyID(_SpecialtyID);
        }
        /// <summary>
        /// 根据专业名称查询数据
        /// </summary>
        /// <param name="condition">专业名称</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyName(string _SpecialtyName)
        {
            return SpecialtyDAL.SelectBySpecialtyName(_SpecialtyName);
        }
        /// <summary>
        /// 根据所属学院Id查询数据
        /// </summary>
        /// <param name="condition">所属学院Id</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyCollegeID(int _SpecialtyCollegeID)
        {
            return SpecialtyDAL.SelectBySpecialtyCollegeID(_SpecialtyCollegeID);
        }
        /// <summary>
        /// 根据专业id查询数据
        /// </summary>
        /// <param name="condition">专业id</param>
        /// <returns></returns>
        public static Specialty SelectBySpecialtyNum(string _SpecialtyNum)
        {
            return SpecialtyDAL.SelectBySpecialtyNum(_SpecialtyNum);
        }
        /// <summary>
        /// 根据辅导员ID查询数据
        /// </summary>
        /// <param name="condition">辅导员ID</param>
        /// <returns></returns>
        public static Specialty SelectByTeacherNum(string _TeacherNum)
        {
            return SpecialtyDAL.SelectByTeacherNum(_TeacherNum);
        }
        #endregion


        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<Specialty> SelectAll()
        {
            return SpecialtyDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAll(int number, int begin)
        {
            return SpecialtyDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByCondition(string condition)
        {
            return SpecialtyDAL.SelectAllByCondition(condition);
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
            return SpecialtyDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByCondition(int number, string condition)
        {
            return SpecialtyDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据专业编号查询所有数据
        /// </summary>
        /// <param name="_SpecialtyID">专业编号</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyID(int _SpecialtyID)
        {
            return SpecialtyDAL.SelectAllBySpecialtyID(_SpecialtyID);
        }
        /// <summary>
        /// 根据专业名称查询所有数据
        /// </summary>
        /// <param name="_SpecialtyName">专业名称</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyName(string _SpecialtyName)
        {
            return SpecialtyDAL.SelectAllBySpecialtyName(_SpecialtyName);
        }
        /// <summary>
        /// 根据所属学院Id查询所有数据
        /// </summary>
        /// <param name="_SpecialtyCollegeID">所属学院Id</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyCollegeID(int _SpecialtyCollegeID)
        {
            return SpecialtyDAL.SelectAllBySpecialtyCollegeID(_SpecialtyCollegeID);
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_SpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllBySpecialtyNum(string _SpecialtyNum)
        {
            return SpecialtyDAL.SelectAllBySpecialtyNum(_SpecialtyNum);
        }
        /// <summary>
        /// 根据辅导员ID查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">辅导员ID</param>
        /// <returns></returns>
        public static IList<Specialty> SelectAllByTeacherNum(string _TeacherNum)
        {
            return SpecialtyDAL.SelectAllByTeacherNum(_TeacherNum);
        }
        #endregion

        /// <summary>
        ///  获取Specialty表SpecialtyName,SpecialtyCollegeID,SpecialtyNum的数据
        /// </summary>
        /// <returns></returns>
        public static DataTable getSpecialtysm()
        {
            return SpecialtyDAL.getSpecialtysm();
        }
    }
}
