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
        /// רҵ���
        /// </summary>
        public int SpecialtyID { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        public string SpecialtyName { get; set; }
        /// <summary>
        /// ����ѧԺId
        /// </summary>
        public int SpecialtyCollegeID { get; set; }
        /// <summary>
        /// רҵid
        /// </summary>
        public string SpecialtyNum { get; set; }
        /// <summary>
        /// ����ԱID
        /// </summary>
        public string TeacherNum { get; set; }
    }
}