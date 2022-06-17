using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Model;

namespace BL
{
    public class BL_AdminResiger
    {
        DA_AdminResiger da_Admin = new DA_AdminResiger();

        public AdminTable GetAdminInfo(string id, string name, string pwd)
        {
            // 添加管理员
            da_Admin.Admin_Add(id, name, pwd);
            AdminTable admin = new AdminTable();

            admin.Admin_Id = id;
            admin.Admin_Name = name;
            admin.Admin_Pwd = pwd;

            return admin;   
        }
    }
}
