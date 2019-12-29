using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class AdvanceDelayBLL
    {
        #region select all
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAll()
        {
            return AdvanceDelayDAL.SelectAll();
        }
        /// <summary>
        /// 查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAll(int number, int begin)
        {
            return AdvanceDelayDAL.SelectAll(number, begin);
        }
        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(string condition)
        {
            return AdvanceDelayDAL.SelectAllByCondition(condition);
        }
        /// <summary>
        /// 根据条件查询所有数据(分页)
        /// </summary>
        /// <param name="number">要查询多少条数据</param>
        /// <param name="begin">从哪一条开始</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(int number, int begin, string condition)
        {
            return AdvanceDelayDAL.SelectAllByCondition(number, begin, condition);
        }
        /// <summary>
        /// 根据条件查询前N条数据
        /// </summary>
        /// <param name="number">number|percent(数字/百分比)</param>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByCondition(int number, string condition)
        {
            return AdvanceDelayDAL.SelectAllByCondition(number, condition);
        }
        /// <summary>
        /// 根据ZCWGID查询所有数据
        /// </summary>
        /// <param name="_ZCWGID">ZCWGID</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByZCWGID(int _ZCWGID)
        {
            return AdvanceDelayDAL.SelectAllByZCWGID(_ZCWGID);
        }

        /// <summary>
        /// 根据学生班级ID查询所有数据
        /// </summary>
        /// <param name="_ClassNum">学生班级ID</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByClassNum(string _ClassNum)
        {
            return AdvanceDelayDAL.SelectAllByClassNum(_ClassNum);
        }
        /// <summary>
        /// 根据早出请假时间查询所有数据
        /// </summary>
        /// <param name="_AdvanceTime">早出请假时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceTime(DateTime _AdvanceTime)
        {
            return AdvanceDelayDAL.SelectAllByAdvanceTime(_AdvanceTime);
        }
        /// <summary>
        /// 根据早出理由查询所有数据
        /// </summary>
        /// <param name="_AdvanceReson">早出理由</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceReson(string _AdvanceReson)
        {
            return AdvanceDelayDAL.SelectAllByAdvanceReson(_AdvanceReson);
        }
        /// <summary>
        /// 根据学生早出时间查询所有数据
        /// </summary>
        /// <param name="_AdvanceStudentT">学生早出时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByAdvanceStudentT(DateTime _AdvanceStudentT)
        {
            return AdvanceDelayDAL.SelectAllByAdvanceStudentT(_AdvanceStudentT);
        }
        /// <summary>
        /// 根据晚归请假时间查询所有数据
        /// </summary>
        /// <param name="_DelayTime">晚归请假时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDelayTime(DateTime _DelayTime)
        {
            return AdvanceDelayDAL.SelectAllByDelayTime(_DelayTime);
        }
        /// <summary>
        /// 根据晚归理由查询所有数据
        /// </summary>
        /// <param name="_DeatReson">晚归理由</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDeatReson(string _DeatReson)
        {
            return AdvanceDelayDAL.SelectAllByDeatReson(_DeatReson);
        }
        /// <summary>
        /// 根据学生晚归时间查询所有数据
        /// </summary>
        /// <param name="_DelayStudentT">学生晚归时间</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByDelayStudentT(DateTime _DelayStudentT)
        {
            return AdvanceDelayDAL.SelectAllByDelayStudentT(_DelayStudentT);
        }
        #endregion


        #region 学生请假/个人信息
        /// <summary>
        /// 根据学生学号查询所有数据
        /// </summary>
        /// <param name="_StudentNum">学生学号</param>
        /// <returns></returns>
        public static IList<AdvanceDelay> SelectAllByStudentNum(string _StudentNum)
        {
            return AdvanceDelayDAL.SelectAllByStudentNum(_StudentNum);
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(AdvanceDelay model)
        {
            return AdvanceDelayDAL.Insert(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(AdvanceDelay model)
        {
            return AdvanceDelayDAL.Update(model);
        }

        #endregion

        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return AdvanceDelayDAL.SelectCountByCondition(condition);
        }

    }
}
