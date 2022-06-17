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
    public class DA_ReaderIn
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        // 用来id来检查数据库是否存在该学生
        public DataTable GetStuSearch(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Student where Stu_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        // 用来id来检查数据库是否存在该教师
        public DataTable GetTeacherSearch(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Teacher where Teacher_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        // 通过id与pwd返回对应学生的信息表
        public DataTable GetStuTable(string id, string pwd)
        {
            SqlCommand cmd = new SqlCommand("select * from Student where Stu_Id = @id and Stu_Pwd = @pwd", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = pwd;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            
            return dt;
        }

        // 通过id与pwd返回对应教师的信息表
        public DataTable GetTeacherTable(string id, string pwd)
        {
            SqlCommand cmd = new SqlCommand("select * from Teacher where Teacher_Id = @id and Teacher_Pwd = @pwd", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = pwd;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }
    }
}
