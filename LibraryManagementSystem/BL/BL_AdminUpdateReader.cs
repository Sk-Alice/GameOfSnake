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
    public class BL_AdminUpdateReader
    {
        DA_AdminUpdateReader da_AdminUpdateReader = new DA_AdminUpdateReader();

        public void UpdateStuInfo(StuTable stu)
        {
            da_AdminUpdateReader.UpdateStuTable(stu);
        }

        public void UpdateTeacherInfo(TeacherTable teacher)
        {
            da_AdminUpdateReader.UpdateTeacherTable(teacher);
        }
    }
}
