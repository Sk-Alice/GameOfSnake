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
    public class BL_AdminOperTeacher
    {
        DA_AdminOperTeacher da_AdminOperTeacher = new DA_AdminOperTeacher();

        public List<TeacherTable> GetAllTeacherInfo()
        {
            List<TeacherTable> teachers = new List<TeacherTable>();
            DataTable dt = da_AdminOperTeacher.GetAllTeacherTable();

            foreach (DataRow dataRow in dt.Rows)
            {
                TeacherTable teacher = new TeacherTable();
                teacher.Teacher_Id = dataRow[0].ToString();
                teacher.Teacher_Name = dataRow[1].ToString();
                teacher.Teacher_Pwd = dataRow[2].ToString();
                teacher.Teacher_BorrowNum = int.Parse(dataRow[3].ToString());

                teachers.Add(teacher);
            }

            return teachers;
        }

        public List<TeacherTable> GetSearchTeacherInfo(string name)
        {
            DataTable dt = da_AdminOperTeacher.GetSearchTeacherTable(name);
            List<TeacherTable> teachers = new List<TeacherTable>();

            foreach (DataRow dataRow in dt.Rows)
            {
                TeacherTable teacher = new TeacherTable();
                teacher.Teacher_Id = dataRow[0].ToString();
                teacher.Teacher_Name = dataRow[1].ToString();
                teacher.Teacher_Pwd = dataRow[2].ToString();
                teacher.Teacher_BorrowNum = int.Parse(dataRow[3].ToString());

                teachers.Add(teacher);
            }

            return teachers;
        }

        public void DeleteTeacherInfo(string id)
        {
            da_AdminOperTeacher.DeleteTeacherTable(id);
        }
    }
}
