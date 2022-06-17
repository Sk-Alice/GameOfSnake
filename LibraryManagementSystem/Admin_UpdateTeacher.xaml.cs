using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using BL;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for Admin_UpdateTeacher.xaml
    /// </summary>
    public partial class Admin_UpdateTeacher : Window
    {
        BL_AdminUpdateReader bl_AdminUpdateReader = new BL_AdminUpdateReader();

        public Admin_UpdateTeacher()
        {
            InitializeComponent();
        }

        public Admin_UpdateTeacher(TeacherTable teacher)
        {
            InitializeComponent();

            txt_TeacherId.Text = teacher.Teacher_Id;
            txt_TeacherName.Text = teacher.Teacher_Name;
            txt_TeacherBNumy.Text = teacher.Teacher_BorrowNum.ToString();
            txt_Pwd.Text = teacher.Teacher_Pwd.ToString();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            TeacherTable teacher = new TeacherTable();
            teacher.Teacher_Id = txt_TeacherId.Text;
            teacher.Teacher_Name = txt_TeacherName.Text;
            teacher.Teacher_BorrowNum = int.Parse(txt_TeacherBNumy.Text);

            string pwd1 = pwd_First.Password.ToString();
            string pwd2 = pwd_Second.Password.ToString();

            if (pwd1.Equals(pwd2) && pwd2 != "")
            {
                teacher.Teacher_Pwd = pwd2;
            }
            else if (pwd1 != "" && pwd2 == "")
            {
                MessageBox.Show("请确定密码!");
                return;
            }
            else if (pwd1 != "" && pwd2 != "" && !pwd1.Equals(pwd2))
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            else
            {
                teacher.Teacher_Pwd = txt_Pwd.Text;
            }

            bl_AdminUpdateReader.UpdateTeacherInfo(teacher);
            MessageBox.Show("信息修改成功！");
            this.Close();
            OpenNewTeacher();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenNewTeacher()
        {
            Admin_OperTeacher admin_OperTeacher = new Admin_OperTeacher();
            Application.Current.MainWindow = admin_OperTeacher;
            admin_OperTeacher.Show();
        }
    }
}
