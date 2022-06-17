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
    public class DA_AdminUpdateReader
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public void UpdateStuTable(StuTable stu)
        {
            SqlCommand cmd = new SqlCommand("update Student set Stu_Name = @name, Stu_Grade = @grade, Stu_Pro = @pro, Stu_BorrowNum = @bNum, Stu_Pwd = @pwd where Stu_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = stu.Stu_Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = stu.Stu_Name;
            cmd.Parameters.Add("@grade", SqlDbType.NVarChar, 50).Value = stu.Stu_Grade;
            cmd.Parameters.Add("@pro", SqlDbType.NVarChar, 50).Value = stu.Stu_Pro;
            cmd.Parameters.Add("@bNum", SqlDbType.NVarChar, 50).Value = stu.Stu_BorrowNum;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = stu.Stu_Pwd;


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

        public void UpdateTeacherTable(TeacherTable teacher)
        {
            SqlCommand cmd = new SqlCommand("update Teacher set Teacher_Name = @name, Teacher_BorrowNum = @bNum, Teacher_Pwd = @pwd where Teacher_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = teacher.Teacher_Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = teacher.Teacher_Name;
            cmd.Parameters.Add("@bNum", SqlDbType.NVarChar, 50).Value = teacher.Teacher_BorrowNum;
            cmd.Parameters.Add("@pwd", SqlDbType.NVarChar, 50).Value = teacher.Teacher_Pwd;

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
