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
        /// ѧ�����
        /// </summary>
        public int StudentID { get; set; }
      	/// <summary>
        /// ѧ��
        /// </summary>
        public string StudentNum { get; set; }

        /// <summary>
        /// ΢��ID
        /// </summary>
        public string open_id { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        public string StudentPass { get; set; }
      	/// <summary>
        /// ѧ������
        /// </summary>
        public string StudentName { get; set; }
      	/// <summary>
        /// ѧ���Ա�
        /// </summary>
        public string StudentSex { get; set; }
      	/// <summary>
        /// ѧ���绰
        /// </summary>
        public string StudentTel { get; set; }
      	/// <summary>
        /// ѧ���༶ID
        /// </summary>
        public string StudentClassID { get; set; }
      
      	/// <summary>
        /// ���֤
        /// </summary>
        public string StudentIDCard { get; set; }
      	/// <summary>
        /// ���Һ�
        /// </summary>
        public string StudentBedroomNum { get; set; }
      	/// <summary>
        /// ��ĸһ������ϵ��ʽ
        /// </summary>
        public string StudentParentTel { get; set; }
      	/// <summary>
        /// ��ͥסַ
        /// </summary>
        public string StudentHomeAddress { get; set; }
      	/// <summary>
        /// ������
        /// </summary>
        public string StudentApprover { get; set; }
      	/// <summary>
        /// �������
        /// </summary>
        public string StudentApprovalResult { get; set; }
      	/// <summary>
        /// ����ʱ��
        /// </summary>
        public string StudentApprovalTime { get; set; }

        /// <summary>
        /// ѧ���Ƿ�ɾ��,1��ɾ
        /// </summary>
        public int IsDelete { get; set; }
    }
}