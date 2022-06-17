using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Model;
using System.Data;

namespace BL
{
    public class BL_AdminOperBooks
    {
        DA_AdminOperBooks da_AdminOperBooks = new DA_AdminOperBooks();

        public List<BookTable> GetAllBookInfo()
        {
            List<BookTable> books = new List<BookTable>();
            DataTable dt = da_AdminOperBooks.GetAllBookTable();

            foreach (DataRow dataRow in dt.Rows)
            {
                BookTable book = new BookTable();
                book.Book_Id = dataRow[0].ToString();
                book.Book_Name = dataRow[1].ToString();
                book.Book_Author = dataRow[2].ToString();
                book.Book_Price = dataRow[3].ToString();
                book.Book_Count = int.Parse(dataRow[4].ToString());

                books.Add(book);
            }

            return books;
        }

        public bool IsGetSelectBorrowBook(string id)
        {
            DataTable dt = da_AdminOperBooks.GetSelectBorrowBook(id);
            if (dt.Rows.Count > 0) return true;
            return false;
        }

        public List<BookTable> GetSearchBookInfo(string name)
        {
            DataTable dt = da_AdminOperBooks.GetSearchBookTable(name);
            List<BookTable> books = new List<BookTable>();

            foreach (DataRow dataRow in dt.Rows)
            {
                BookTable book = new BookTable();
                book.Book_Id = dataRow[0].ToString();
                book.Book_Name = dataRow[1].ToString();
                book.Book_Author = dataRow[2].ToString();
                book.Book_Price = dataRow[3].ToString();
                book.Book_Count = int.Parse(dataRow[4].ToString());

                books.Add(book);
            }

            return books;
        }

        public void DeleteBookInfo(string bookId)
        {
            da_AdminOperBooks.DeleteBookTable(bookId);
        }
    }
}
