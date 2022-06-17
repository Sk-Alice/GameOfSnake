using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DA;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class BL_ReaderIn
    {
        DA_ReaderIn da_Reader = new DA_ReaderIn();

        // 检查数据库中是否有该组信息(学生)
        public bool IsStuSearch(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            DataTable dt = null;
            dt = da_Reader.GetStuSearch(id);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 检查数据库中是否有该组信息(教师)
        public bool IsTeacherSearch(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            DataTable dt = null;
            dt = da_Reader.GetTeacherSearch(id);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 检查学生用户登录数据是否正确
        public bool IsStuRight(string id, string pwd)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd)) return false;
            DataTable dt = null;
            dt = da_Reader.GetStuTable(id, pwd);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 检查教师用户登录数据是否正确
        public bool IsTeacherRight(string id, string pwd)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwd)) return false;
            DataTable dt = null;
            dt = da_Reader.GetTeacherTable(id, pwd);

            if (dt != null && dt.Rows.Count > 0) return true;
            return false;
        }

        // 将获取到的学生信息赋值给学生，返回该学生
        public StuTable GetStuInfo(string id, string pwd)
        {
            DataTable dt = da_Reader.GetStuTable(id, pwd);
            StuTable stu = new StuTable();

            stu.Stu_Id = id;
            stu.Stu_Name = dt.Rows[0][1].ToString();
            stu.Stu_Grade = dt.Rows[0][2].ToString();
            stu.Stu_Pro = dt.Rows[0][3].ToString();
            stu.Stu_Pwd = pwd;
            stu.Stu_BorrowNum = (int)dt.Rows[0][5];

            return stu;
        }

        // 将获取到的教师信息赋值给教师，返回该教师
        public TeacherTable GetTeacherInfo(string id, string pwd)
        {
            DataTable dt = da_Reader.GetTeacherTable(id, pwd);
            TeacherTable teacher = new TeacherTable();

            teacher.Teacher_Id = id;
            teacher.Teacher_Name = dt.Rows[0][1].ToString();
            teacher.Teacher_Pwd = pwd;
            teacher.Teacher_BorrowNum = (int)dt.Rows[0][3];

            return teacher;
        }
    }
}
