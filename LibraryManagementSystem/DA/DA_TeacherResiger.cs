using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DA
{
    public class DA_TeacherResiger
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public DataTable Teacher_Add(string id, string name, string pwd)
        {
            SqlCommand cmd = new SqlCommand("insert into Teacher(Teacher_Id, Teacher_Name, Teacher_Pwd) values(@id, @name, @pwd)", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = pwd;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public void Reader_Add(string id)
        {
            SqlCommand cmd = new SqlCommand("insert into Reader(Reader_Id) values(@id)", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            { }
            finally
            {
                conn.Close();
            }
        }
    }
}
