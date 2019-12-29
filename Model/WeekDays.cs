using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    /// <summary>
    /// WeekDays
    /// </summary>
    public class WeekDays
    {
        /// <summary>
        /// 周六请假编号
        /// </summary>
        public int WeekDaysID { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        public int WeekDaysStudentID { get; set; }
        /// <summary>
        /// 请假开始时间
        /// </summary>
        public string WeekDaysStartTime { get; set; }
        /// <summary>
        /// 请假结束时间
        /// </summary>
        public string WeekDaysEndtTime { get; set; }
        /// <summary>
        /// 请假天数
        /// </summary>
        public string WeekDaysNumDays { get; set; }
        /// <summary>
        /// 请假事由
        /// </summary>
        public string WeekDaysReason { get; set; }
        /// <summary>
        /// 审批人
        /// </summary>
        public string WeekDaysApprover { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        public string WeekDaysStage { get; set; }
        /// <summary>
        /// 审批结果
        /// </summary>
        public string WeekDaysApprovalResult { get; set; }
        /// <summary>
        /// 审批时间
        /// </summary>
        public string WeekDaysApprovalTime { get; set; }
        /// <summary>
        /// 关联班级id
        /// </summary>
        public string LeaveRecordClassNum { get; set; }
      
    }
}