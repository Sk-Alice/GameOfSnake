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
    public class BL_ReaderReturn
    {
        DA_ReaderReturn da_ReaderReturn = new DA_ReaderReturn();

        public void DeleteBorrowInfo(string readerId, string bookId)
        {
            da_ReaderReturn.DeleteBorrowTable(readerId, bookId);
        }

        public BookTable GetBackBookInfo(string id)
        {
            DataTable dt = da_ReaderReturn.GetBackBookTable(id);
            BookTable book = new BookTable();
            book.Book_Id = id;
            book.Book_Name = dt.Rows[0][1].ToString();
            book.Book_Author = dt.Rows[0][2].ToString();
            book.Book_Price = dt.Rows[0][3].ToString();
            book.Book_Count = int.Parse(dt.Rows[0][4].ToString());

            return book;
        }

        public List<BorrowTable> GetAllBorrowInfo(string id)
        {
            List<BorrowTable> borrows = new List<BorrowTable>();
            DataTable dt = da_ReaderReturn.GetAllBorrowTable(id);

            foreach (DataRow dataRow in dt.Rows)
            {
                BorrowTable borrow = new BorrowTable();
                borrow.Reader_Id = dataRow[0].ToString();
                borrow.Book_Id = dataRow[1].ToString();
                borrow.Reader_Name = dataRow[2].ToString();
                borrow.Book_Name = dataRow[3].ToString();
                borrow.Borrow_Time = dataRow[4].ToString();
                borrow.Return_Time = dataRow[5].ToString();

                borrows.Add(borrow);
            }

            return borrows;
        }

        public List<BorrowTable> UpdateBorrowInfo(string readerId, string bookId, string borrowTime, string returnTime)
        {
            List<BorrowTable> borrows = new List<BorrowTable>();
            da_ReaderReturn.UpdateBorrowTable(readerId, bookId, borrowTime, returnTime);
            DataTable dt = da_ReaderReturn.GetAllBorrowTable(readerId);

            foreach (DataRow dataRow in dt.Rows)
            {
                BorrowTable borrow = new BorrowTable();
                borrow.Reader_Id = dataRow[0].ToString();
                borrow.Book_Id = dataRow[1].ToString();
                borrow.Reader_Name = dataRow[2].ToString();
                borrow.Book_Name = dataRow[3].ToString();
                borrow.Borrow_Time = dataRow[4].ToString();
                borrow.Return_Time = dataRow[5].ToString();

                borrows.Add(borrow);
            }

            return borrows;
        }

        public void Stu_UpdateTable(string StuId, string BookId, int BookCount, int StuCount)
        {
            da_ReaderReturn.UpdateBookTable(BookId, BookCount);
            da_ReaderReturn.UpdateStuTable(StuId, StuCount);
        }

        public void Teacher_UpdateTable(string TeacherId, string BookId, int BookCount, int TeacherCount)
        {
            da_ReaderReturn.UpdateBookTable(BookId, BookCount);
            da_ReaderReturn.UpdateTeacherTable(TeacherId, TeacherCount);
        }
    }
}
