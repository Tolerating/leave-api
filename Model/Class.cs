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
        /// �༶���
        /// </summary>
        public int ClassID { get; set; }
      	/// <summary>
        /// �༶����
        /// </summary>
        public string ClassName { get; set; }
      	/// <summary>
        /// ����רҵ
        /// </summary>
        public int ClassSpecialityID { get; set; }
      	/// <summary>
        /// ������Id
        /// </summary>
        public int ClassHeadTeacherID { get; set; }
      	/// <summary>
        /// �༶id
        /// </summary>
        public string ClassNum { get; set; }

        /// <summary>
        /// �༶����ԱID
        /// </summary>
        public int ClassSpecialityTeacherID { get; set; }
    }
}