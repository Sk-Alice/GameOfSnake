using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Model;

namespace BL
{
    public class BL_ReaderBorrow
    {
        DA_ReaderBorrow da_ReaderBorrow = new DA_ReaderBorrow();

        public void AddBorrowInfo(string readerId, string bookId, string readerName, string bookName, string borrowTime, string returnTime)
        {
            da_ReaderBorrow.AddBorrowTable(readerId, bookId, readerName, bookName, borrowTime, returnTime);
        }

        public List<BookTable> GetAllBookInfo()
        {
            List<BookTable> books = new List<BookTable>();
            DataTable dt = da_ReaderBorrow.GetAllBookTable();

            foreach(DataRow dataRow in dt.Rows)
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

        public List<BookTable> GetSearchBookInfo(string name)
        {
            DataTable dt = da_ReaderBorrow.GetSearchBookTable(name);
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

        public List<BookTable> GetBorrowBookInfo(Object selecct)
        {
            DataTable dt = da_ReaderBorrow.GetAllBookTable();
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

        public bool IsBorrow(string readerId, string bookId)
        {
            DataTable dt = da_ReaderBorrow.GetBorrowTable(readerId, bookId);
            if(dt.Rows.Count > 0) return true;
            return false;
        }

        public void Stu_UpdateTable(string StuId, string BookId, int BookCount, int StuCount)
        {
            da_ReaderBorrow.UpdateBookTable(BookId, BookCount);
            da_ReaderBorrow.UpdateStuTable(StuId, StuCount);
        }

        public void Teacher_UpdateTable(string TeacherId, string BookId, int BookCount, int TeacherCount)
        {
            da_ReaderBorrow.UpdateBookTable(BookId, BookCount);
            da_ReaderBorrow.UpdateTeacherTable(TeacherId, TeacherCount);
        }
    }
}
