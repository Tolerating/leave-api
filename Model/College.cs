using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    /// <summary>
    /// College
    /// </summary>
    public class College
    {
        /// <summary>
        /// 学院编号
        /// </summary>
        public int CollegeID { get; set; }

        /// <summary>
        /// 学院名称
        /// </summary>
        public string CollegeName { get; set; }

        /// <summary>
        /// 学院id
        /// </summary>
        public string CollegeNum { get; set; }

        /// <summary>
        /// 院领导ID
        /// </summary>
        public string TeacherNum { get; set; }

        /// <summary>
        /// 学院是否被删除,1表被删
        /// </summary>
        public int IsDelete { get; set; }
    }
}