using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    /// <summary>
    /// Specialty
    /// </summary>
    public class Specialty
    {
        /// <summary>
        /// 专业编号
        /// </summary>
        public int SpecialtyID { get; set; }
        /// <summary>
        /// 专业名称
        /// </summary>
        public string SpecialtyName { get; set; }
        /// <summary>
        /// 所属学院Id
        /// </summary>
        public int SpecialtyCollegeID { get; set; }
        /// <summary>
        /// 专业id
        /// </summary>
        public string SpecialtyNum { get; set; }
        /// <summary>
        /// 辅导员ID
        /// </summary>
        public string TeacherNum { get; set; }
    }
}