using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TeachersBLL
    {
        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(Teachers model)
        {
            return TeachersDAL.Insert(model);
        }
        /// <summary>
        /// 批量插入教师记录(无注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Teachers[] modelList)
        {
            TeachersDAL.Insert(modelList);
        }

        /// <summary>
        /// 批量插入教师记录(有注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static string InsertSingle(Teachers[] modelList)
        {
            return TeachersDAL.InsertSingle(modelList);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_TeacherID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByTeacherID(int _TeacherID)
        {
            return TeachersDAL.DeleteByTeacherID(_TeacherID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Teachers model)
        {
            return TeachersDAL.Delete(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Teachers model)
        {
            return TeachersDAL.Update(model);
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return TeachersDAL.SelectCount();
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return TeachersDAL.SelectCountByCondition(condition);
        }
        #endregion

        #region 登录|注册|忘记密码
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static int selectByconditions(string conditions)
        {
            return TeachersDAL.selectByconditions(conditions);
        }

        /// <summary>
        /// 获取教师的电话(全部信息)
        /// </summary>
        /// <returns></returns>
        public static Teachers SelectTeaPhone(string TeacherNum)
        {
            return TeachersDAL.SelectTeaPhone(TeacherNum);
        }

        /// <summary>
        /// 根据AdminInfo表中的密码进行修改
        /// </summary>
        /// <returns></returns>
        public static int updateTeaPwdbyAdmin(int UserID)
        {
            return TeachersDAL.updateTeaPwdbyAdmin(UserID);
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
            return TeachersDAL.SelectByCondition(condition);
        }
        /// <summary>
        /// 根据编号查询数据
        /// </summary>
        /// <param name="condition">编号</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherID(int _TeacherID)
        {
            return TeachersDAL.SelectByTeacherID(_TeacherID);
        }
        /// <summary>
        /// 根据身份证查询数据
        /// </summary>
        /// <param name="condition">身份证</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherIDCard(string _TeacherIDCard)
        {
            return TeachersDAL.SelectByTeacherIDCard(_TeacherIDCard);
        }
        /// <summary>
        /// 根据审批人查询数据
        /// </summary>
        /// <param name="condition">审批人</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprover(string _TeacherApprover)
        {
            return TeachersDAL.SelectByTeacherApprover(_TeacherApprover);
        }
        /// <summary>
        /// 根据审批结果查询数据
        /// </summary>
        /// <param name="condition">审批结果</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprovalResult(string _TeacherApprovalResult)
        {
            return TeachersDAL.SelectByTeacherApprovalResult(_TeacherApprovalResult);
        }
        /// <summary>
        /// 根据审批时间查询数据
        /// </summary>
        /// <param name="condition">审批时间</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherApprovalTime(string _TeacherApprovalTime)
        {
            return TeachersDAL.SelectByTeacherApprovalTime(_TeacherApprovalTime);
        }
        /// <summary>
        /// 根据工号查询数据
        /// </summary>
        /// <param name="condition">工号</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherNum(string _TeacherNum)
        {
            return TeachersDAL.SelectByTeacherNum(_TeacherNum);
        }
        /// <summary>
        /// 根据教师密码查询数据
        /// </summary>
        /// <param name="condition">教师密码</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherPass(string _TeacherPass)
        {
            return TeachersDAL.SelectByTeacherPass(_TeacherPass);
        }
        /// <summary>
        /// 根据教师名称查询数据
        /// </summary>
        /// <param name="condition">教师名称</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherName(string _TeacherName)
        {
            return TeachersDAL.SelectByTeacherName(_TeacherName);
        }
        /// <summary>
        /// 根据教师性别查询数据
        /// </summary>
        /// <param name="condition">教师性别</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherSex(string _TeacherSex)
        {
            return TeachersDAL.SelectByTeacherSex(_TeacherSex);
        }
        /// <summary>
        /// 根据教师电话查询数据
        /// </summary>
        /// <param name="condition">教师电话</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherTel(string _TeacherTel)
        {
            return TeachersDAL.SelectByTeacherTel(_TeacherTel);
        }
        /// <summary>
        /// 根据职称查询数据
        /// </summary>
        /// <param name="condition">职称</param>
        /// <returns></returns>
        public static Teachers SelectByPost(string _Post)
        {
            return TeachersDAL.SelectByPost(_Post);
        }
        /// <summary>
        /// 根据学院id查询数据
        /// </summary>
        /// <param name="condition">学院id</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherCollegeNum(string _TeacherCollegeNum)
        {
            return TeachersDAL.SelectByTeacherCollegeNum(_TeacherCollegeNum);
        }
        /// <summary>
        /// 根据专业id查询数据
        /// </summary>
        /// <param name="condition">专业id</param>
        /// <returns></returns>
        public static Teachers SelectByTeacherSpecialtyNum(string _TeacherSpecialtyNum)
        {
            return TeachersDAL.SelectByTeacherSpecialtyNum(_TeacherSpecialtyNum);
        }
        #endregion

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<Teachers> SelectAll()
        {
            return TeachersDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAll(int number, int begin)
        {
            return TeachersDAL.SelectAll(number, begin);
        }

        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByCondition(int number, int begin, string condition)
        {
            return TeachersDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByCondition(int number, string condition)
        {
            return TeachersDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据编号查询所有数据
        /// </summary>
        /// <param name="_TeacherID">编号</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherID(int _TeacherID)
        {
            return TeachersDAL.SelectAllByTeacherID(_TeacherID);
        }
        /// <summary>
        /// 根据身份证查询所有数据
        /// </summary>
        /// <param name="_TeacherIDCard">身份证</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherIDCard(string _TeacherIDCard)
        {
            return TeachersDAL.SelectAllByTeacherIDCard(_TeacherIDCard);
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_TeacherApprover">审批人</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprover(string _TeacherApprover)
        {
            return TeachersDAL.SelectAllByTeacherApprover(_TeacherApprover);
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_TeacherApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprovalResult(string _TeacherApprovalResult)
        {
            return TeachersDAL.SelectAllByTeacherApprovalResult(_TeacherApprovalResult);
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_TeacherApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherApprovalTime(string _TeacherApprovalTime)
        {
            return TeachersDAL.SelectAllByTeacherApprovalTime(_TeacherApprovalTime);
        }
        /// <summary>
        /// 根据工号查询所有数据
        /// </summary>
        /// <param name="_TeacherNum">工号</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherNum(string _TeacherNum)
        {
            return TeachersDAL.SelectAllByTeacherNum(_TeacherNum);
        }
        /// <summary>
        /// 根据教师密码查询所有数据
        /// </summary>
        /// <param name="_TeacherPass">教师密码</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherPass(string _TeacherPass)
        {
            return TeachersDAL.SelectAllByTeacherPass(_TeacherPass);
        }
        /// <summary>
        /// 根据教师名称查询所有数据
        /// </summary>
        /// <param name="_TeacherName">教师名称</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherName(string _TeacherName)
        {
            return TeachersDAL.SelectAllByTeacherName(_TeacherName);
        }
        /// <summary>
        /// 根据教师性别查询所有数据
        /// </summary>
        /// <param name="_TeacherSex">教师性别</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherSex(string _TeacherSex)
        {
            return TeachersDAL.SelectAllByTeacherSex(_TeacherSex);
        }
        /// <summary>
        /// 根据教师电话查询所有数据
        /// </summary>
        /// <param name="_TeacherTel">教师电话</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherTel(string _TeacherTel)
        {
            return TeachersDAL.SelectAllByTeacherTel(_TeacherTel);
        }
        /// <summary>
        /// 根据职称查询所有数据
        /// </summary>
        /// <param name="_Post">职称</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByPost(string _Post)
        {
            return TeachersDAL.SelectAllByPost(_Post);
        }
        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_TeacherCollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherCollegeNum(string _TeacherCollegeNum)
        {
            return TeachersDAL.SelectAllByTeacherCollegeNum(_TeacherCollegeNum);
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_TeacherSpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Teachers> SelectAllByTeacherSpecialtyNum(string _TeacherSpecialtyNum)
        {
            return TeachersDAL.SelectAllByTeacherSpecialtyNum(_TeacherSpecialtyNum);
        }
        #endregion

        #region 请假审核

        /// <summary>
        /// 通过职位获取教师的信息
        /// </summary>
        /// <returns></returns>
        public static Teachers getInfobyPost(string post)
        {
            return TeachersDAL.getInfobyPost(post);
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
            return TeachersDAL.SelectAllByCondition(condition);
        }

        #endregion

        /// <summary>
        /// 查询所有教师的学号
        /// </summary>
        /// <returns></returns>
        public static IList<int> SelectTeacherNumAll() {
            return TeachersDAL.SelectTeacherNumAll();
        }
    }
}
