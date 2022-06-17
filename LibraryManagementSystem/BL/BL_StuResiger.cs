using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DA;
using Model;

namespace BL
{
    public class BL_StuResiger
    {
        DA_StuResiger da_Stu = new DA_StuResiger();

        public StuTable GetStuInfo(string id, string name, string pwd, string grade, string pro)
        {
            da_Stu.Reader_Add(id);
            da_Stu.Stu_Add(id, name, pwd, grade, pro);
            StuTable stu = new StuTable();

            stu.Stu_Id = id;
            stu.Stu_Name = name;
            stu.Stu_Pro = pro;
            stu.Stu_Grade = grade;
            stu.Stu_Pwd = pwd;

            return stu;
        }
    }
}
