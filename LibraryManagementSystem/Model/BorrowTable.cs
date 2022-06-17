using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BorrowTable
    {
        public string Reader_Id { get; set; }

        public string Book_Id { get; set; }

        public string Reader_Name { get; set; }

        public string Book_Name { get; set; }

        public string Borrow_Time { get; set; } 

        public string Return_Time { get; set; }
    }
}
