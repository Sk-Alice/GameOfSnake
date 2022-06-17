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
    public class BL_AdminUpdateBook
    {
        DA_AdminUpdateBook da_AdminUpdateBook = new DA_AdminUpdateBook();

        public void UpdateBookInfo(BookTable book)
        {
            da_AdminUpdateBook.UpdateBookTable(book);
        }
    }
}
