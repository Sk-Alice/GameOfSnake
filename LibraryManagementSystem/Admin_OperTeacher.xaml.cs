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
    /// Interaction logic for Admin_OperTeacher.xaml
    /// </summary>
    public partial class Admin_OperTeacher : Window
    {
        BL_AdminOperTeacher bl_AdminOperTeacher = new BL_AdminOperTeacher();

        public Admin_OperTeacher()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Teacher_Resiger teacher_Resiger = new Teacher_Resiger();
            Application.Current.MainWindow = teacher_Resiger;
            this.Close();
            teacher_Resiger.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                TeacherTable teacher = (TeacherTable)listView.SelectedItem;
                bl_AdminOperTeacher.DeleteTeacherInfo(teacher.Teacher_Id);
                MessageBox.Show("删除成功");
            }
            // 更新界面信息
            ShowInfo();
            btn_Delete.IsEnabled = false;
            btn_Update.IsEnabled = false;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string name = txt_ReaderName.Text;
            if (name != "")
            {
                List<TeacherTable> teachers = bl_AdminOperTeacher.GetSearchTeacherInfo(name);
                listView.ItemsSource = teachers;
            }
            else
            {
                MessageBox.Show("请输入要查找的教师！");
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Delete.IsEnabled = true;
            btn_Update.IsEnabled = true;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                TeacherTable teachers = (TeacherTable)listView.SelectedItem;
                Admin_UpdateTeacher admin_UpdateTeacher = new Admin_UpdateTeacher(teachers);
                Application.Current.MainWindow = admin_UpdateTeacher;
                this.Close();
                admin_UpdateTeacher.Show();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowInfo()
        {
            List<TeacherTable> teachers = bl_AdminOperTeacher.GetAllTeacherInfo();
            listView.ItemsSource = teachers;
        }
    }
}
