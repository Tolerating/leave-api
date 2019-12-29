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
    public class ClassBLL
    {
        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<Class> SelectAll()
        {
            return ClassDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Class> SelectAll(int number, int begin)
        {
            return ClassDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByCondition(string condition)
        {
            return ClassDAL.SelectAllByCondition(condition);
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
            return ClassDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByCondition(int number, string condition)
        {
            return ClassDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据班级编号查询所有数据
        /// </summary>
        /// <param name="_ClassID">班级编号</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassID(int _ClassID)
        {
            return ClassDAL.SelectAllByClassID(_ClassID);
        }
        /// <summary>
        /// 根据班级名称查询所有数据
        /// </summary>
        /// <param name="_ClassName">班级名称</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassName(string _ClassName)
        {
            return ClassDAL.SelectAllByClassName(_ClassName);
        }

        /// <summary>
        /// 根据班主任Id查询所有数据
        /// </summary>
        /// <param name="_ClassHeadTeacherID">班主任Id</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassHeadTeacherID(int _ClassHeadTeacherID)
        {
            return ClassDAL.SelectAllByClassHeadTeacherID(_ClassHeadTeacherID);
        }
        /// <summary>
        /// 根据班级id查询所有数据
        /// </summary>
        /// <param name="_ClassNum">班级id</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassNum(string _ClassNum)
        {
            return ClassDAL.SelectAllByClassNum(_ClassNum);
        }
        #endregion


        #region insert update delete

        /// <summary>
        /// 批量插入记录
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Class[] modelList)
        {
            ClassDAL.Insert(modelList);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_ClassID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByClassID(int _ClassID)
        {
            return ClassDAL.DeleteByClassID(_ClassID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Class model)
        {
            return ClassDAL.Delete(model);
        }

        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return ClassDAL.SelectCount();
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return ClassDAL.SelectCountByCondition(condition);
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
            return ClassDAL.SelectByCondition(condition);
        }
        /// <summary>
        /// 根据班级编号查询数据
        /// </summary>
        /// <param name="condition">班级编号</param>
        /// <returns></returns>
        public static Class SelectByClassID(int _ClassID)
        {
            return ClassDAL.SelectByClassID(_ClassID);
        }
        /// <summary>
        /// 根据班级名称查询数据
        /// </summary>
        /// <param name="condition">班级名称</param>
        /// <returns></returns>
        public static Class SelectByClassName(string _ClassName)
        {
            return ClassDAL.SelectByClassName(_ClassName);
        }
        /// <summary>
        /// 根据所属专业查询数据
        /// </summary>
        /// <param name="condition">所属专业</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityID(int _ClassSpecialityID)
        {
            return ClassDAL.SelectByClassSpecialityID(_ClassSpecialityID);
        }

        /// <summary>
        /// 根据所属专业查询数据
        /// </summary>
        /// <param name="condition">所属专业</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityID1(int _ClassSpecialityID1)
        {
            return ClassDAL.SelectByClassSpecialityID1(_ClassSpecialityID1);
        }

        /// <summary>
        /// 根据班主任Id查询数据
        /// </summary>
        /// <param name="condition">班主任Id</param>
        /// <returns></returns>
        public static Class SelectByClassHeadTeacherID(int _ClassHeadTeacherID)
        {
            return ClassDAL.SelectByClassHeadTeacherID(_ClassHeadTeacherID);
        }


        /// <summary>
        /// 根据辅导员Id查询数据
        /// </summary>
        /// <param name="_ClassHeadTeacherID">班主任Id</param>
        /// <returns></returns>
        public static Class SelectByClassSpecialityTeacherID(int _ClassSpecialityTeacherID)
        {
            return ClassDAL.SelectByClassSpecialityTeacherID(_ClassSpecialityTeacherID);
        }


        /// <summary>
        /// 根据班级id查询数据
        /// </summary>
        /// <param name="condition">班级id</param>
        /// <returns></returns>
        public static Class SelectByClassNum(string _ClassNum)
        {
            return ClassDAL.SelectByClassNum(_ClassNum);
        }
        #endregion

        #region 登录|注册|忘记密码

        /// <summary>
        /// 插入一条班级记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(Class model)
        {
            return ClassDAL.Insert(model);
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Update(Class model)
        {
            return ClassDAL.Update(model);
        }

        /// <summary>
        /// 检查班级是否已经存在
        /// </summary>
        /// <returns></returns>
        public static Class checkStuAndTeaID(string ClassNum)
        {
            return ClassDAL.checkStuAndTeaID(ClassNum);
        }

        /// <summary>
        /// 通过班主任ID获取班级信息并存储到session
        /// </summary>
        /// <returns></returns>
        public static Class getBInfo(int TeacherID)
        {
            return ClassDAL.getBInfo(TeacherID);
        }

        /// <summary>
        /// 通过辅导员ID获取班级信息并存储到session
        /// </summary>
        /// <returns></returns>
        public static Class getFInfo(int TeacherID)
        {
            return ClassDAL.getFInfo(TeacherID);
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
            return ClassDAL.getClassInfo(classNum);
        }

        #endregion


        #region 本周周末审核


        /// <summary>
        /// 根据辅导员ID查询所有数据
        /// </summary>
        /// <param name="_ClassSpecialityID">辅导员ID</param>
        /// <returns></returns>
        public static IList<Class> SelectAllByClassSpecialityID(int TeacherID)
        {
            return ClassDAL.SelectAllByClassSpecialityID(TeacherID);
        }
        #endregion

        #region 其他历史记录

        /// <summary>
        /// 选择全部的班级ID
        /// </summary>
        /// <returns></returns>
        public static DataTable getClassID()
        {
            return ClassDAL.getClassID();
        }

        #endregion 
    }
}
