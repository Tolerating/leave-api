using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model{
    /// <summary>
    /// Teachers
    /// </summary>
    public class Teachers{
      	/// <summary>
        /// 编号
        /// </summary>
        public int TeacherID { get; set; }
      	/// <summary>
        /// 工号
        /// </summary>
        public string TeacherNum { get; set; }

        public string open_id { get; set; }
      	/// <summary>
        /// 教师密码
        /// </summary>
        public string TeacherPass { get; set; }
      	/// <summary>
        /// 教师名称
        /// </summary>
        public string TeacherName { get; set; }
      	/// <summary>
        /// 教师性别
        /// </summary>
        public string TeacherSex { get; set; }
      	/// <summary>
        /// 教师电话
        /// </summary>
        public string TeacherTel { get; set; }
      	/// <summary>
        /// 职称
        /// </summary>
        public string Post { get; set; }
      	/// <summary>
        /// 学院id
        /// </summary>
        //public string TeacherCollegeNum { get; set; }
      	/// <summary>
        /// 专业id
        /// </summary>
        //public string TeacherSpecialtyNum { get; set; }
      	/// <summary>
        /// 身份证

        /// </summary>
        public string TeacherIDCard { get; set; }
      	/// <summary>
        /// 审批人
        /// </summary>
        public string TeacherApprover { get; set; }
      	/// <summary>
        /// 审批结果
        /// </summary>
        public string TeacherApprovalResult { get; set; }
      	/// <summary>
        /// 审批时间
        /// </summary>
        public string TeacherApprovalTime { get; set; }
    }
}