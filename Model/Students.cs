using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model{
    /// <summary>
    /// Students
    /// </summary>
    public class Students{

      	/// <summary>
        /// 学生编号
        /// </summary>
        public int StudentID { get; set; }
      	/// <summary>
        /// 学号
        /// </summary>
        public string StudentNum { get; set; }

        /// <summary>
        /// 微信ID
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// 学生密码
        /// </summary>
        public string StudentPass { get; set; }
      	/// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
      	/// <summary>
        /// 学生性别
        /// </summary>
        public string StudentSex { get; set; }
      	/// <summary>
        /// 学生电话
        /// </summary>
        public string StudentTel { get; set; }
      	/// <summary>
        /// 学生班级ID
        /// </summary>
        public string StudentClassID { get; set; }
      
      	/// <summary>
        /// 身份证
        /// </summary>
        public string StudentIDCard { get; set; }
      	/// <summary>
        /// 寝室号
        /// </summary>
        public string StudentBedroomNum { get; set; }
      	/// <summary>
        /// 父母一方的联系方式
        /// </summary>
        public string StudentParentTel { get; set; }
      	/// <summary>
        /// 家庭住址
        /// </summary>
        public string StudentHomeAddress { get; set; }
      	/// <summary>
        /// 审批人
        /// </summary>
        public string StudentApprover { get; set; }
      	/// <summary>
        /// 审批结果
        /// </summary>
        public string StudentApprovalResult { get; set; }
      	/// <summary>
        /// 审批时间
        /// </summary>
        public string StudentApprovalTime { get; set; }

        /// <summary>
        /// 学生是否被删除,1表被删
        /// </summary>
        public int IsDelete { get; set; }
    }
}