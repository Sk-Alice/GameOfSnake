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
    /// Interaction logic for Reader_LogIn.xaml
    /// </summary>
    public partial class Reader_LogIn : Window
    {
        BL_ReaderIn bl_Reader = new BL_ReaderIn();

        public Reader_LogIn()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_ReaderId.Clear();
            pwd_ReaderPwd.Clear();
        }

        private void ReaderLogIn()
        {
            // 获取用户输入的账号密码信息
            string id = txt_ReaderId.Text;
            string pwd = pwd_ReaderPwd.Password.ToString();

            // 判断身份为学生
            if ((bool)RB_Student.IsChecked)
            {
                if( id == "")
                {
                    MessageBox.Show("账号不能为空！");
                    return;
                }
                // 检查数据库中是否有该学生
                if (bl_Reader.IsStuSearch(id))
                {
                    // 检查学生数据是否正确
                    if(bl_Reader.IsStuRight(id, pwd))
                    {
                        OpenStuInterface(id, pwd);
                    }
                    else
                    {
                        MessageBox.Show("输入信息有误，请重新输入！");
                        ClearAll();
                    }
                }
                else
                {
                    MessageBox.Show("该学生不存在！");
                    ClearAll();
                }
            }
            // 判断身份为教师
            else if ((bool)RB_Teacher.IsChecked)
            {
                if (id == "")
                {
                    MessageBox.Show("账号不能为空！");
                    return;
                }
                // 检查数据库中是否有该教师 
                if (bl_Reader.IsTeacherSearch(id))
                {
                    // 检查教师数据是否正确
                    if (bl_Reader.IsTeacherRight(id, pwd))
                    {
                        OpenTeacheInterface(id, pwd);
                    }
                    else
                    {
                        MessageBox.Show("输入信息有误，请重新输入！");
                        ClearAll();
                    }
                }
                else
                {
                    MessageBox.Show("该教师不存在！");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("请选择您的登录身份！");
                return;
            }
        }

        private void btn_ReaderIn_Click(object sender, RoutedEventArgs e)
        {
            ReaderLogIn();
        }

        private void btn_ReaderResiger_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RB_Student.IsChecked)
            {
                Stu_Resiger stu_Resiger = new Stu_Resiger();
                Application.Current.MainWindow = stu_Resiger;
                stu_Resiger.Show();
            }
            else if ((bool)RB_Teacher.IsChecked)
            {
                Teacher_Resiger teacher_Resiger = new Teacher_Resiger();
                Application.Current.MainWindow = teacher_Resiger;
                teacher_Resiger.Show();
            }
            else
            {
                MessageBox.Show("请选择您的注册身份！");
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            
        }

        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void OpenStuInterface(string id, string pwd)
        {
            // 获取数据库中该学生的信息
            StuTable Stu = bl_Reader.GetStuInfo(id, pwd);
            // 打开该学生界面
            Stu_Interface stu_Interface = new Stu_Interface(Stu);
            Application.Current.MainWindow = stu_Interface;
            this.Close();
            stu_Interface.Show();
        }

        public void OpenTeacheInterface(string id, string pwd)
        {
            // 获取数据库中该教师的信息
            TeacherTable Teacher = bl_Reader.GetTeacherInfo(id, pwd);
            // 打开该教师界面
            Teacher_Interface teacher_Interface = new Teacher_Interface(Teacher);
            Application.Current.MainWindow = teacher_Interface;
            this.Close();
            teacher_Interface.Show();
        }
    }
}
