using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Model
{
    public class StuTable
    {
        public string Stu_Id { get; set; }

        public string Stu_Name { get; set; }

        public string Stu_Pro { get; set; }

        public string Stu_Grade { get; set; }

        public string Stu_Pwd { get; set; }

        public int Stu_BorrowNum { get; set; }
    }
}
