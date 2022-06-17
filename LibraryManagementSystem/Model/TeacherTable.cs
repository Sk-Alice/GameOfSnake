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
    public class TeacherTable
    {
        public string Teacher_Id { get; set; }

        public string Teacher_Name { get; set; }

        public string Teacher_Pwd { get; set; }

        public int Teacher_BorrowNum { get; set; }
    }
}
