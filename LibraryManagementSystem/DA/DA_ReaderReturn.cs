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
    public class DA_ReaderReturn
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public DataTable GetAllBorrowTable(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Borrow where Reader_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }

        public DataTable GetBackBookTable(string id)
        {
            SqlCommand cmd = new SqlCommand("select * from Book where Book_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            return dt;
        }


        public void UpdateBorrowTable(string readerId, string bookId, string borrowTime, string returnTime)
        {
            SqlCommand cmd = new SqlCommand("Update Borrow set Borrow_Time = @BTime, Return_Time = @RTime where Reader_Id = @RId and Book_Id = @BId", conn);
            cmd.Parameters.Add("@RId", SqlDbType.NVarChar, 50).Value = readerId;
            cmd.Parameters.Add("@BId", SqlDbType.NVarChar, 50).Value = bookId;
            cmd.Parameters.Add("@BTime", SqlDbType.NVarChar, 50).Value = borrowTime;
            cmd.Parameters.Add("@RTime", SqlDbType.NVarChar, 50).Value = returnTime;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
        }

        // 归还书籍，reader的可借阅次数 +1，book的可借阅数量 +1
        public void UpdateBookTable(string id, int count)
        {
            SqlCommand cmd = new SqlCommand("update Book set Book_Count = @count where Book_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@count", SqlDbType.NVarChar, 50).Value = count;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateStuTable(string id, int count)
        {
            SqlCommand cmd = new SqlCommand("update Student set Stu_BorrowNum = @count where Stu_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@count", SqlDbType.NVarChar, 50).Value = count;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            { }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateTeacherTable(string id, int count)
        {
            SqlCommand cmd = new SqlCommand("update Teacher set Teacher_BorrowNum = @count where Teacher_Id = @id", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
            cmd.Parameters.Add("@count", SqlDbType.NVarChar, 50).Value = count;
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

        public void DeleteBorrowTable(string readerId, string bookId)
        {
            SqlCommand cmd = new SqlCommand("delete from Borrow where Reader_Id = @Rid and Book_Id = @BId", conn);
            cmd.Parameters.Add("@RId", SqlDbType.NVarChar, 50).Value = readerId;
            cmd.Parameters.Add("@BId", SqlDbType.NVarChar, 50).Value = bookId;
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
