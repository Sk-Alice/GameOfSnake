using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Model;

namespace DA
{
    public class DA_StuResiger
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public DataTable Stu_Add(string id, string name, string pwd, string grade, string pro)
        {
            SqlCommand cmd = new SqlCommand("insert into Student(Stu_Id, Stu_Name, Stu_Grade, Stu_Pro, Stu_Pwd) values(@id, @name, @grade, @pro, @pwd)", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add("@grade", SqlDbType.NVarChar, 50).Value = grade;
            cmd.Parameters.Add("@pro", SqlDbType.NVarChar, 50).Value = pro;
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
