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
    /// Teacher_Interface.xaml 的交互逻辑
    /// </summary>
    public partial class Teacher_Interface : Window
    {
        TeacherTable Teacher = null;
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        BL_TeacherInterface bl_TeacherInterface = new BL_TeacherInterface();

        public Teacher_Interface()
        {
            InitializeComponent();
        }

        public Teacher_Interface(TeacherTable teacher)
        {
            InitializeComponent();

            this.Teacher = teacher;
            Teacher = bl_ReaderIn.GetTeacherInfo(Teacher.Teacher_Id, Teacher.Teacher_Pwd);
            txt_TeacherName.Text = Teacher.Teacher_Name;
            txt_TeacherId.Text = Teacher.Teacher_Id;
            txt_TeacherPwd.Text = Teacher.Teacher_Pwd;
            txt_BNum.Text = Teacher.Teacher_BorrowNum.ToString();
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            Reader_Return reader_Return = new Reader_Return(Teacher);
            Application.Current.MainWindow = reader_Return;
            this.Close();
            reader_Return.Show();
        }

        private void btn_Borrow_Click(object sender, RoutedEventArgs e)
        {
            Reader_Borrow reader_Borrow = new Reader_Borrow(Teacher);
            Application.Current.MainWindow = reader_Borrow;
            this.Close();
            reader_Borrow.Show();
        }

        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            Reader_LogIn reader_LogIn = new Reader_LogIn();
            Application.Current.MainWindow = reader_LogIn;
            this.Close();
            reader_LogIn.Show();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            bl_TeacherInterface.UpdateTeacherInfo(txt_TeacherId.Text, txt_TeacherName.Text, txt_TeacherPwd.Text);
            Teacher = bl_ReaderIn.GetTeacherInfo(Teacher.Teacher_Id, txt_TeacherPwd.Text);

            txt_TeacherName.Text = Teacher.Teacher_Name;
            MessageBox.Show("信息修改成功！");
        }
    }
}
