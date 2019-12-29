using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /// <summary>
    /// LeaveRecord
    /// </summary>
    public class LeaveRecord{
      	/// <summary>
        /// 编号
        /// </summary>
        public int LeaveRecordID { get; set; }
      	/// <summary>
        /// 学生ID
        /// </summary>
        public int LeaveRecordStudentID { get; set; }
      	/// <summary>
        /// 请假事由
        /// </summary>
        public string LeaveRecordReason { get; set; }
      	/// <summary>
        /// 开始时间
        /// </summary>
        public string LeaveRecordStartTime { get; set; }
      	/// <summary>
        /// 结束时间
        /// </summary>
        public string LeaveRecordEndtTime { get; set; }
      	/// <summary>
        /// 第几节课开始
        /// </summary>
        public int LeaveRecordStartLesson { get; set; }
      	/// <summary>
        /// 第几节课结束
        /// </summary>
        public int LeaveRecordEndLesson { get; set; }
      	/// <summary>
        /// 请假类别
        /// </summary>
        public string LeaveRecordCategory { get; set; }
      	/// <summary>
        /// 请假天数
        /// </summary>
        public int LeaveRecordNumDays { get; set; }
      	/// <summary>
        /// 审批人
        /// </summary>
        public string LeaveRecordApprover { get; set; }
      	/// <summary>
        /// 审批阶段
        /// </summary>
        public int LeaveRecordStage { get; set; }
      	/// <summary>
        /// 审批结果
        /// </summary>
        public string LeaveRecordApprovalResult { get; set; }
      	/// <summary>
        /// 审批时间
        /// </summary>
        public string LeaveRecordApprovalTime { get; set; }
      	/// <summary>
        /// 共多少节课
        /// </summary>
        public int LeaveRecordSumLesson { get; set; }
      	/// <summary>
        /// 关联班级id
        /// </summary>
        public string LeaveRecordClassNum { get; set; }
    }
}