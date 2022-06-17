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
    public class BL_AdminOperStu
    {
        DA_AdminOperStu da_AdminOperStu = new DA_AdminOperStu();

        public List<StuTable> GetAllStuInfo()
        {
            List<StuTable> stus = new List<StuTable>();
            DataTable dt = da_AdminOperStu.GetAllStuTable();

            foreach (DataRow dataRow in dt.Rows)
            {
                StuTable stu = new StuTable();
                stu.Stu_Id = dataRow[0].ToString();
                stu.Stu_Name = dataRow[1].ToString();
                stu.Stu_Grade = dataRow[2].ToString();
                stu.Stu_Pro = dataRow[3].ToString();
                stu.Stu_Pwd = dataRow[4].ToString();
                stu.Stu_BorrowNum = int.Parse(dataRow[5].ToString());

                stus.Add(stu);
            }

            return stus;
        }

        public List<StuTable> GetSearchStuInfo(string name)
        {
            DataTable dt = da_AdminOperStu.GetSearchStuTable(name);
            List<StuTable> stus = new List<StuTable>();

            foreach (DataRow dataRow in dt.Rows)
            {
                StuTable stu = new StuTable();
                stu.Stu_Id = dataRow[0].ToString();
                stu.Stu_Name = dataRow[1].ToString();
                stu.Stu_Grade = dataRow[2].ToString();
                stu.Stu_Pro = dataRow[3].ToString();
                stu.Stu_Pwd = dataRow[4].ToString();
                stu.Stu_BorrowNum = int.Parse(dataRow[5].ToString());

                stus.Add(stu);
            }

            return stus;
        }

        public void DeleteStuInfo(string id)
        {
            da_AdminOperStu.DeleteStuTable(id);
        }
    }
}
