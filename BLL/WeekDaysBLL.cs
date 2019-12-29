using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class WeekDaysBLL
    {

        #region 学生请假

        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return WeekDaysDAL.SelectCountByCondition(condition);
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(WeekDays model)
        {
            return WeekDaysDAL.Insert(model);
        }

        #endregion

        #region 本周周末审核

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(WeekDays model)
        {
            return WeekDaysDAL.Update(model);
        }

        #endregion

        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<WeekDays> SelectAll()
        {
            return WeekDaysDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAll(int number, int begin)
        {
            return WeekDaysDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(string condition)
        {
            return WeekDaysDAL.SelectAllByCondition(condition);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(int number, int begin, string condition)
        {
            return WeekDaysDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByCondition(int number, string condition)
        {
            return WeekDaysDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据周六请假编号查询所有数据
        /// </summary>
        /// <param name="_WeekDaysID">周六请假编号</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysID(int _WeekDaysID)
        {
            return WeekDaysDAL.SelectAllByWeekDaysID(_WeekDaysID);
        }
        /// <summary>
        /// 根据关联班级id查询所有数据
        /// </summary>
        /// <param name="_LeaveRecordClassNum">关联班级id</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByLeaveRecordClassNum(string _LeaveRecordClassNum)
        {
            return WeekDaysDAL.SelectAllByLeaveRecordClassNum(_LeaveRecordClassNum);
        }
        /// <summary>
        /// 根据学号查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStudentID">学号</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStudentID(int _WeekDaysStudentID)
        {
            return WeekDaysDAL.SelectAllByWeekDaysStudentID(_WeekDaysStudentID);
        }
        /// <summary>
        /// 根据请假开始时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStartTime">请假开始时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStartTime(string _WeekDaysStartTime)
        {
            return WeekDaysDAL.SelectAllByWeekDaysStartTime(_WeekDaysStartTime);
        }
        /// <summary>
        /// 根据请假结束时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysEndtTime">请假结束时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysEndtTime(string _WeekDaysEndtTime)
        {
            return WeekDaysDAL.SelectAllByWeekDaysEndtTime(_WeekDaysEndtTime);
        }
        /// <summary>
        /// 根据请假天数查询所有数据
        /// </summary>
        /// <param name="_WeekDaysNumDays">请假天数</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysNumDays(string _WeekDaysNumDays)
        {
            return WeekDaysDAL.SelectAllByWeekDaysNumDays(_WeekDaysNumDays);
        }
        /// <summary>
        /// 根据审批人查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprover">审批人</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprover(string _WeekDaysApprover)
        {
            return WeekDaysDAL.SelectAllByWeekDaysApprover(_WeekDaysApprover);
        }
        /// <summary>
        /// 根据审批阶段查询所有数据
        /// </summary>
        /// <param name="_WeekDaysStage">审批阶段</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysStage(string _WeekDaysStage)
        {
            return WeekDaysDAL.SelectAllByWeekDaysStage(_WeekDaysStage);
        }
        /// <summary>
        /// 根据审批结果查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprovalResult">审批结果</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprovalResult(string _WeekDaysApprovalResult)
        {
            return WeekDaysDAL.SelectAllByWeekDaysApprovalResult(_WeekDaysApprovalResult);
        }
        /// <summary>
        /// 根据审批时间查询所有数据
        /// </summary>
        /// <param name="_WeekDaysApprovalTime">审批时间</param>
        /// <returns></returns>
        public static IList<WeekDays> SelectAllByWeekDaysApprovalTime(string _WeekDaysApprovalTime)
        {
            return WeekDaysDAL.SelectAllByWeekDaysApprovalTime(_WeekDaysApprovalTime);
        }
        #endregion
    }
}
