using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DA
{
    public class DA_AdminIn
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        // 用来id来检查数据库是否存在该用户
        public DataTable GetAdminSearch(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Admin where Admin_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        // 返回对应管理员的信息表
        public DataTable GetAdminTable(string id, string pwd)
        {
            SqlCommand cmd = new SqlCommand("select * from Admin where Admin_Id = @id and Admin_Pwd = @pwd", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = pwd;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }
    }
}
