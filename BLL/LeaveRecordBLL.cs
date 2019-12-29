using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class LeaveRecordBLL
    {
        #region 学生请假
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <returns></returns>
        public static int Insert(LeaveRecord model)
        {
            return LeaveRecordDAL.Insert(model);
        }

        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return LeaveRecordDAL.SelectCountByCondition(condition);
        }

        #endregion

        #region 请假审核

        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static IList<LeaveRecord> SelectAllByCondition(string condition)
        {
            return LeaveRecordDAL.SelectAllByCondition(condition);
        }

        /// <summary>
        /// 更新LeaveRecord表的一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Update(LeaveRecord model)
        {
            return LeaveRecordDAL.Update(model);
        }

        /// <summary>
        /// 根据条件查询所有请假记录
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int SelectByCondition(string condition)
        {
            return LeaveRecordDAL.SelectByCondition(condition);
        }

        /// <summary>
        /// 根据SQL语句查询数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static LeaveRecord SelectBySql(string sql) {
            return LeaveRecordDAL.SelectBySql(sql);   
        }
        #endregion
    }
}
