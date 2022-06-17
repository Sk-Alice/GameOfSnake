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
using BL;
using Model;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for Select_ReaderIdentity.xaml
    /// </summary>
    public partial class Select_ReaderIdentity : Window
    {
        public Select_ReaderIdentity()
        {
            InitializeComponent();
        }

        private void btn_Resiger_Click(object sender, RoutedEventArgs e)
        {
            // 判断身份为学生
            if ((bool)RB_Student.IsChecked)
            {
                Stu_Resiger stu_Resiger = new Stu_Resiger();
                Application.Current.MainWindow = stu_Resiger;
                this.Close();
                stu_Resiger.Show();
            }
            // 判断身份为教师
            else if ((bool)RB_Teacher.IsChecked)
            {
                Teacher_Resiger teacher_Resiger = new Teacher_Resiger();
                Application.Current.MainWindow = teacher_Resiger;
                this.Close();
                teacher_Resiger.Show();
            }
            else
            {
                MessageBox.Show("请选择读者身份！");
                return;
            }
        }

        private void btn_ShowReaderInfo_Click(object sender, RoutedEventArgs e)
        {
            // 判断身份为学生
            if ((bool)RB_Student.IsChecked)
            {
                Admin_OperStu admin_OperStu = new Admin_OperStu();
                Application.Current.MainWindow = admin_OperStu;
                this.Close();
                admin_OperStu.Show();
            }
            // 判断身份为教师
            else if ((bool)RB_Teacher.IsChecked)
            {
                Admin_OperTeacher admin_OperTeacher = new Admin_OperTeacher();
                Application.Current.MainWindow = admin_OperTeacher;
                this.Close();
                admin_OperTeacher.Show();
            }
            else
            {
                MessageBox.Show("请选择读者身份！");
                return;
            }
        }
    }
}
