using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class StudentsBLL
    {
        #region 登录|注册|忘记密码
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(Students model)
        {
            return StudentsDAL.Insert(model);
        }


        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return StudentsDAL.SelectCountByCondition(condition);
        }


        /// <summary>
        /// 获取学生的电话号码
        /// </summary>
        /// <returns></returns>
        public static Students SelectStuPhone(string StudentNum)
        {
            return StudentsDAL.SelectStuPhone(StudentNum);
        }

        /// <summary>
        /// 根据AdminInfo表中的密码进行修改 updateStuPwd
        /// </summary>
        /// <returns></returns>
        public static int updateStuPwdbyAdmin(int UserID)
        {
            return StudentsDAL.updateStuPwdbyAdmin(UserID);
        }

        /// <summary>
        /// 修改学生密码
        /// </summary>
        /// <returns></returns>
        public static int updateStuPwd(string pwd,int UserID)
        {
            return StudentsDAL.updateStuPwd(pwd,UserID);
        }

        #endregion

        #region 学生请假/个人信息
        /// <summary>
        /// 获取Students表的全部信息
        /// </summary>
        /// <returns></returns>
        public static Students getStuInfo(string StuNum)
        {
            return StudentsDAL.getStuInfo(StuNum);
        }

        /// <summary>
        /// 更新学生的电话号码
        /// </summary>
        /// <returns></returns>
        public static int updateStuTel(string StuTel, string StuNum)
        {
            return StudentsDAL.updateStuTel(StuTel, StuNum);
        }
        #endregion

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<Students> SelectAll()
        {
            return StudentsDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<Students> SelectAll(int number, int begin)
        {
            return StudentsDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByCondition(string condition)
        {
            return StudentsDAL.SelectAllByCondition(condition);
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
            return StudentsDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByCondition(int number, string condition)
        {
            return StudentsDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据学生编号查询所有数据
        /// </summary>
        /// <param name="_StudentID">学生编号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentID(int _StudentID)
        {
            return StudentsDAL.SelectAllByStudentID(_StudentID);
        }
        /// <summary>
        /// 根据身份证查询所有数据
        /// </summary>
        /// <param name="_StudentIDCard">身份证</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentIDCard(string _StudentIDCard)
        {
            return StudentsDAL.SelectAllByStudentIDCard(_StudentIDCard);
        }
        /// <summary>
        /// 根据寝室号查询所有数据
        /// </summary>
        /// <param name="_StudentBedroomNum">寝室号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentBedroomNum(string _StudentBedroomNum)
        {
            return StudentsDAL.SelectAllByStudentBedroomNum(_StudentBedroomNum);
        }
        /// <summary>
        /// 根据父母一方的联系方式查询所有数据
        /// </summary>
        /// <param name="_StudentParentTel">父母一方的联系方式</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentParentTel(string _StudentParentTel)
        {
            return StudentsDAL.SelectAllByStudentParentTel(_StudentParentTel);
        }
        /// <summary>
        /// 根据家庭住址查询所有数据
        /// </summary>
        /// <param name="_StudentHomeAddress">家庭住址</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentHomeAddress(string _StudentHomeAddress)
        {
            return StudentsDAL.SelectAllByStudentHomeAddress(_StudentHomeAddress);
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_StudentApprover">审批人</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprover(string _StudentApprover)
        {
            return StudentsDAL.SelectAllByStudentApprover(_StudentApprover);
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_StudentApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprovalResult(string _StudentApprovalResult)
        {
            return StudentsDAL.SelectAllByStudentApprovalResult(_StudentApprovalResult);
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_StudentApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentApprovalTime(string _StudentApprovalTime)
        {
            return StudentsDAL.SelectAllByStudentApprovalTime(_StudentApprovalTime);
        }
        /// <summary>
        /// 根据学号查询所有数据
        /// </summary>
        /// <param name="_StudentNum">学号</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentNum(string _StudentNum)
        {
            return StudentsDAL.SelectAllByStudentNum(_StudentNum);
        }
        /// <summary>
        /// 根据学生密码查询所有数据
        /// </summary>
        /// <param name="_StudentPass">学生密码</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentPass(string _StudentPass)
        {
            return StudentsDAL.SelectAllByStudentPass(_StudentPass);
        }
        /// <summary>
        /// 根据学生姓名查询所有数据
        /// </summary>
        /// <param name="_StudentName">学生姓名</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentName(string _StudentName)
        {
            return StudentsDAL.SelectAllByStudentName(_StudentName);
        }
        /// <summary>
        /// 根据学生性别查询所有数据
        /// </summary>
        /// <param name="_StudentSex">学生性别</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentSex(string _StudentSex)
        {
            return StudentsDAL.SelectAllByStudentSex(_StudentSex);
        }
        /// <summary>
        /// 根据学生电话查询所有数据
        /// </summary>
        /// <param name="_StudentTel">学生电话</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentTel(string _StudentTel)
        {
            return StudentsDAL.SelectAllByStudentTel(_StudentTel);
        }

        /// <summary>
        /// 根据学院id查询所有数据
        /// </summary>
        /// <param name="_StudentCollegeNum">学院id</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentCollegeNum(string _StudentCollegeNum)
        {
            return StudentsDAL.SelectAllByStudentCollegeNum(_StudentCollegeNum);
        }
        /// <summary>
        /// 根据专业id查询所有数据
        /// </summary>
        /// <param name="_StudentSpecialtyNum">专业id</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentSpecialtyNum(string _StudentSpecialtyNum)
        {
            return StudentsDAL.SelectAllByStudentSpecialtyNum(_StudentSpecialtyNum);
        }
        #endregion

        #region insert update delete

        /// <summary>
        /// 批量插入学生记录(有注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static string InsertSingle(Students[] modelList)
        {
            return StudentsDAL.InsertSingle(modelList);
        }

        /// <summary>
        /// 批量插入学生记录(无注册页面时使用)
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(Students[] modelList)
        {
            StudentsDAL.Insert(modelList);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_StudentID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByStudentID(int _StudentID)
        {
            return StudentsDAL.DeleteByStudentID(_StudentID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(Students model)
        {
            return StudentsDAL.Delete(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(Students model)
        {
            return StudentsDAL.Update(model);
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return StudentsDAL.SelectCount();
        }

        #endregion

        #region 本周末审核

        /// <summary>
        /// 根据学生班级查询所有数据
        /// </summary>
        /// <param name="_StudentClassID">学生班级</param>
        /// <returns></returns>
        public static IList<Students> SelectAllByStudentClassID(string _StudentClassID)
        {
            return StudentsDAL.SelectAllByStudentClassID(_StudentClassID);
        }

        #endregion

        public static IList<int> SelectStudentNumAll() {
            return StudentsDAL.SelectStudentNumAll();
        }

        public static void importByBulk(DataTable dt,string TableName) {
            StudentsDAL.importByBulk(dt, TableName);
        }
    }
}
