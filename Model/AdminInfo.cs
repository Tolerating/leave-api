using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AdminInfo
    {
        /// <summary>
        /// 管理员编号
        /// </summary>
        public int AdminID { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public int AdminLoginID { get; set; }

        /// <summary>
        /// 管理员密码
        /// </summary>
        public string AdnminPasssword { get; set; }

        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName { get; set; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public int AdminJurisdictionID { get; set; }
    }
}
