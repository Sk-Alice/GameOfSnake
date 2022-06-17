using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;

namespace BL
{
    public class BL_AdminAddBooks
    {
        DA_AdminAddBooks da_AdminAddBooks = new DA_AdminAddBooks();

        public void AddBooksInfo(BookTable book)
        {
            da_AdminAddBooks.AddBooksTable(book);
        }

    }
}
