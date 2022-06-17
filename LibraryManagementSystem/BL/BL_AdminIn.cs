using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using System.Data;
using Model;

namespace BL
{
    public class BL_AdminIn
    {
        DA_AdminIn da_Admin = new DA_AdminIn();

        // 通过id检查数据库中是否存在该管理员
        public bool IsAdminSearch(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            DataTable dt = null;
            dt = da_Admin.GetAdminSearch(id);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 通过id与pwd检查数据库中该组信息是否正确
        public bool IsAdminRight(string id, string pwd)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd)) return false;
            DataTable dt = null;
            dt = da_Admin.GetAdminTable(id, pwd);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 将获取到的管理员信息赋值给管理员，返回该管理员
        public AdminTable GetAdminInfo(string id, string pwd)
        {
            DataTable dt = da_Admin.GetAdminTable(id, pwd);
            AdminTable admin = new AdminTable();

            admin.Admin_Id = id;
            admin.Admin_Name = dt.Rows[0][1].ToString();
            admin.Admin_Pwd = pwd;

            return admin;
        }
    }
}
