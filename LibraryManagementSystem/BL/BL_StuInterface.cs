using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;
using System.Data;

namespace BL
{
    public class BL_StuInterface
    {
        DA_StuInterface da_StuInterface = new DA_StuInterface();

        public void UpdateStuInfo(string id, string name, string pro, string grade, string pwd)
        {
            da_StuInterface.UpdateStuTable(id, name, pro, grade, pwd);
        }
    }
}
