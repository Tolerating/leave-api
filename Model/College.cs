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
        /// ѧԺ���
        /// </summary>
        public int CollegeID { get; set; }

        /// <summary>
        /// ѧԺ����
        /// </summary>
        public string CollegeName { get; set; }

        /// <summary>
        /// ѧԺid
        /// </summary>
        public string CollegeNum { get; set; }

        /// <summary>
        /// Ժ�쵼ID
        /// </summary>
        public string TeacherNum { get; set; }

        /// <summary>
        /// ѧԺ�Ƿ�ɾ��,1��ɾ
        /// </summary>
        public int IsDelete { get; set; }
    }
}