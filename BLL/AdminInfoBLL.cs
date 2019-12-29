using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class AdminInfoBLL
    {
        #region insert update delete
        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(AdminInfo model)
        {
            return AdminInfoDAL.Insert(model);
        }
        /// <summary>
        /// 批量插入记录
        /// </summary>
        /// <param name="modelList"></param>
        public static void Insert(AdminInfo[] modelList)
        {
            AdminInfoDAL.Insert(modelList);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="_AdminID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int DeleteByAdminID(int _AdminID)
        {
            return AdminInfoDAL.DeleteByAdminID(_AdminID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Delete(AdminInfo model)
        {
            return AdminInfoDAL.Delete(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Update(AdminInfo model)
        {
            return AdminInfoDAL.Update(model);
        }
        /// <summary>
        /// 查询总记录条数
        /// </summary>
        /// <returns></returns>
        public static int SelectCount()
        {
            return AdminInfoDAL.SelectCount();
        }
        /// <summary>
        /// 根据条件查询总记录条数
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static int SelectCountByCondition(string condition)
        {
            return AdminInfoDAL.SelectCountByCondition(condition);
        }
        #endregion

        #region select
        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="condition">条件</param>
        /// <returns></returns>
        public static AdminInfo SelectByCondition(string condition)
        {
            return AdminInfoDAL.SelectByCondition(condition);
        }
        /// <summary>
        /// 根据管理员编号查询数据
        /// </summary>
        /// <param name="condition">管理员编号</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminID(int _AdminID)
        {
            return AdminInfoDAL.SelectByAdminID(_AdminID);
        }
        /// <summary>
        /// 根据登录名查询数据
        /// </summary>
        /// <param name="condition">登录名</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminLoginID(int _AdminLoginID)
        {
            return AdminInfoDAL.SelectByAdminLoginID(_AdminLoginID);
        }
        /// <summary>
        /// 根据管理员密码查询数据
        /// </summary>
        /// <param name="condition">管理员密码</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdnminPasssword(string _AdnminPasssword)
        {
            return AdminInfoDAL.SelectByAdnminPasssword(_AdnminPasssword);
        }
        /// <summary>
        /// 根据管理员名称查询数据
        /// </summary>
        /// <param name="condition">管理员名称</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminName(string _AdminName)
        {
            return AdminInfoDAL.SelectByAdminName(_AdminName);
        }
        /// <summary>
        /// 根据权限ID查询数据
        /// </summary>
        /// <param name="condition">权限ID</param>
        /// <returns></returns>
        public static AdminInfo SelectByAdminJurisdictionID(int _AdminJurisdictionID)
        {
            return AdminInfoDAL.SelectByAdminJurisdictionID(_AdminJurisdictionID);
        }
        #endregion

        #region 登录|注册
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public static AdminInfo loginLeave(string Name, string Pwd)
        {
            return AdminInfoDAL.loginLeave(Name, Pwd);
        }

        /// <summary>
        /// 新密码界面跟新密码
        /// </summary>
        /// <param name="LoginID"></param>
        /// <returns></returns>
        public static int updatePwd(int LoginID, string Pwd)
        {
            return AdminInfoDAL.updatePwd(LoginID, Pwd);
        }

        #endregion
    }
}
