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
    public class DA_AdminAddBooks
    {
        //static string strCon = @"server = .; database = DB_LibraryManagementSystem; user = sa; password = sa";
        static string strCon = @"Data Source=DESKTOP-SBQ60DA;Initial Catalog=DB_LibraryManagementSystem;Integrated Security=True";
        SqlConnection conn = new SqlConnection(strCon);

        public void AddBooksTable(BookTable book)
        {
            SqlCommand cmd = new SqlCommand("insert into Book(Book_Id, Book_Name, Book_Author, Book_Price, Book_Count) values(@id, @name, @author, @price, @count)", conn);
            cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = book.Book_Id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = book.Book_Name;
            cmd.Parameters.Add("@author", SqlDbType.NVarChar, 50).Value = book.Book_Author;
            cmd.Parameters.Add("@price", SqlDbType.NVarChar, 50).Value = book.Book_Price;
            cmd.Parameters.Add("@count", SqlDbType.NVarChar, 50).Value = book.Book_Count;
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
