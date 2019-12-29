using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace leaveAPI
{

    ///
    /// Controller描述信息 ///
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ControllerGroupAttribute : Attribute
    { ///
        /// 当前Controller所属模块 请用中文 
        public string GroupName { get; private set; } 
                                                        
        /// 当前controller用途 请用中文 ///
        ///public string Useage { get; private set; } 

        /// Controller描述信息 构造 ///
        /// 模块名称 /// 当前controller用途 
        public ControllerGroupAttribute(string groupName)
        {
            //if (string.IsNullOrEmpty(groupName) || string.IsNullOrEmpty(useage))
            //{
            //    throw new ArgumentNullException("分组信息不能为空");
            //}
            if (string.IsNullOrEmpty(groupName))
            {
                throw new ArgumentNullException("分组信息不能为空");
            }
            GroupName = groupName;
            //Useage = useage;
        }

    }
}