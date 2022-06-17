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
    public class AdminTable
    {
        public string Admin_Id { get; set; }

        public string Admin_Name { get; set; }

        public string Admin_Pwd { get; set; }
    }
}
