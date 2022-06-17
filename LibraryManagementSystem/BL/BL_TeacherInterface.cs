using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;

namespace BL
{
    public class BL_TeacherInterface
    {
        DA_TeacherInterface da_TeacherInterface = new DA_TeacherInterface();
        public void UpdateTeacherInfo(string id, string name, string pwd)
        {
            da_TeacherInterface.UpdateTeacherTable(id, name, pwd);
        }
    }
}
