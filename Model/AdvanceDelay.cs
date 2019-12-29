using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    /// <summary>
    /// AdvanceDelay
    /// </summary>
    public class AdvanceDelay
    {
        /// <summary>
        /// ZCWGID
        /// </summary>
        public int ZCWGID { get; set; }
        /// <summary>
        /// 学生学号
        /// </summary>
        public string StudentNum { get; set; }
        /// <summary>
        /// 学生班级ID
        /// </summary>
        public string ClassNum { get; set; }
        /// <summary>
        /// 早出请假时间
        /// </summary>
        public DateTime AdvanceTime { get; set; }
        /// <summary>
        /// 早出理由
        /// </summary>
        public string AdvanceReson { get; set; }
        /// <summary>
        /// 学生早出时间
        /// </summary>
        public DateTime AdvanceStudentT { get; set; }
        /// <summary>
        /// 晚归请假时间
        /// </summary>
        public DateTime DelayTime { get; set; }
        /// <summary>
        /// 晚归理由
        /// </summary>
        public string DeatReson { get; set; }
        /// <summary>
        /// 学生晚归时间
        /// </summary>
        public DateTime DelayStudentT { get; set; }
    }
}