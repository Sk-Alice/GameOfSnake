using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;
using System.Data;

namespace BL
{
    public class BL_AdminInterface
    {
        DA_AdminInterface da_AdminInterface = new DA_AdminInterface();

        public AdminTable GetAdminInfo(string id, string pwd)
        {
            DataTable dt = da_AdminInterface.GetAdminTable(id, pwd);
            AdminTable admin = new AdminTable();

            admin.Admin_Id = id;
            admin.Admin_Name = dt.Rows[0][1].ToString();
            admin.Admin_Pwd = pwd;

            return admin;
        }

        public void UpdateAdminInfo(string id, string name, string pwd)
        {
            da_AdminInterface.UpdateAdminTable(id, name, pwd);
        }

        public void DeleteAdminInfo(string id)
        {
            da_AdminInterface.DeleteAdminTable(id);
        }
    }
}
