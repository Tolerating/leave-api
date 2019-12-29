using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model{
    /// <summary>
    /// LeaveRecord
    /// </summary>
    public class LeaveRecord{
      	/// <summary>
        /// ���
        /// </summary>
        public int LeaveRecordID { get; set; }
      	/// <summary>
        /// ѧ��ID
        /// </summary>
        public int LeaveRecordStudentID { get; set; }
      	/// <summary>
        /// �������
        /// </summary>
        public string LeaveRecordReason { get; set; }
      	/// <summary>
        /// ��ʼʱ��
        /// </summary>
        public string LeaveRecordStartTime { get; set; }
      	/// <summary>
        /// ����ʱ��
        /// </summary>
        public string LeaveRecordEndtTime { get; set; }
      	/// <summary>
        /// �ڼ��ڿο�ʼ
        /// </summary>
        public int LeaveRecordStartLesson { get; set; }
      	/// <summary>
        /// �ڼ��ڿν���
        /// </summary>
        public int LeaveRecordEndLesson { get; set; }
      	/// <summary>
        /// ������
        /// </summary>
        public string LeaveRecordCategory { get; set; }
      	/// <summary>
        /// �������
        /// </summary>
        public int LeaveRecordNumDays { get; set; }
      	/// <summary>
        /// ������
        /// </summary>
        public string LeaveRecordApprover { get; set; }
      	/// <summary>
        /// �����׶�
        /// </summary>
        public int LeaveRecordStage { get; set; }
      	/// <summary>
        /// �������
        /// </summary>
        public string LeaveRecordApprovalResult { get; set; }
      	/// <summary>
        /// ����ʱ��
        /// </summary>
        public string LeaveRecordApprovalTime { get; set; }
      	/// <summary>
        /// �����ٽڿ�
        /// </summary>
        public int LeaveRecordSumLesson { get; set; }
      	/// <summary>
        /// �����༶id
        /// </summary>
        public string LeaveRecordClassNum { get; set; }
    }
}