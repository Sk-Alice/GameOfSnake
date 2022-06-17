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
    public class DA_AdminOperTeacher
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public DataTable GetAllTeacherTable()
        {
            SqlCommand cmd = new SqlCommand("select * from Teacher", conn);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public DataTable GetSearchTeacherTable(string name)
        {
            SqlCommand cmd = new SqlCommand("select * from Teacher where Teacher_Name = @name", conn);
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public void DeleteTeacherTable(string id)
        {
            SqlCommand cmd = new SqlCommand("delete from Teacher where Teacher_Id = @id", conn);
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
