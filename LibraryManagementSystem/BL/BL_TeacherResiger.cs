using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;

namespace BL
{
    public class BL_TeacherResiger
    {
        DA_TeacherResiger da_Teacher = new DA_TeacherResiger();

        public TeacherTable GetTeacherInfo(string id, string name, string pwd)
        {
            da_Teacher.Reader_Add(id);
            da_Teacher.Teacher_Add(id, name, pwd);
            TeacherTable teacher = new TeacherTable();

            teacher.Teacher_Id = id;
            teacher.Teacher_Name = name;
            teacher.Teacher_Pwd = pwd;

            return teacher;
        }
    }
}
