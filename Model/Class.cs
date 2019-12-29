using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /// <summary>
    /// Class
    /// </summary>
    public class Class{
      	/// <summary>
        /// 班级编号
        /// </summary>
        public int ClassID { get; set; }
      	/// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
      	/// <summary>
        /// 所属专业
        /// </summary>
        public int ClassSpecialityID { get; set; }
      	/// <summary>
        /// 班主任Id
        /// </summary>
        public int ClassHeadTeacherID { get; set; }
      	/// <summary>
        /// 班级id
        /// </summary>
        public string ClassNum { get; set; }

        /// <summary>
        /// 班级辅导员ID
        /// </summary>
        public int ClassSpecialityTeacherID { get; set; }
    }
}