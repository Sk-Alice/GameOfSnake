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
    public class DA_StuInterface
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public void UpdateStuTable(string id, string name, string pro, string grade, string pwd)
        {
            SqlCommand cmd = new SqlCommand("update Student set Stu_Name = @name, Stu_Pro = @pro, Stu_Grade = @grade, Stu_Pwd = @pwd where Stu_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
            cmd.Parameters.Add("@pro", SqlDbType.NVarChar, 50).Value = pro;
            cmd.Parameters.Add("@grade", SqlDbType.NVarChar, 50).Value = grade;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = pwd;

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
