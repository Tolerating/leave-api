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
        /// ���
        /// </summary>
        public int TeacherID { get; set; }
      	/// <summary>
        /// ����
        /// </summary>
        public string TeacherNum { get; set; }

      	/// <summary>
        /// ��ʦ����
        /// </summary>
        public string TeacherPass { get; set; }
      	/// <summary>
        /// ��ʦ����
        /// </summary>
        public string TeacherName { get; set; }
      	/// <summary>
        /// ��ʦ�Ա�
        /// </summary>
        public string TeacherSex { get; set; }
      	/// <summary>
        /// ��ʦ�绰
        /// </summary>
        public string TeacherTel { get; set; }
      	/// <summary>
        /// ְ��
        /// </summary>
        public string Post { get; set; }
      	
      	/// <summary>
        /// ���֤
        /// </summary>
        public string TeacherIDCard { get; set; }
      	/// <summary>
        /// ������
        /// </summary>
        public string TeacherApprover { get; set; }
      	/// <summary>
        /// �������
        /// </summary>
        public string TeacherApprovalResult { get; set; }
      	/// <summary>
        /// ����ʱ��
        /// </summary>
        public string TeacherApprovalTime { get; set; }

        /// <summary>
        /// ��ʦ�Ƿ�ɾ��,1��ɾ
        /// </summary>
        public int IsDelete { get; set; }
    }
}