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
    /// Interaction logic for Admin_LogIn.xaml
    /// </summary>
    public partial class Admin_LogIn : Window
    {
        BL_AdminIn bl_Admin = new BL_AdminIn();

        public Admin_LogIn()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_AdminId.Clear();
            pwd_AdminPwd.Clear();
        }

        private void btn_AdminIn_Click(object sender, RoutedEventArgs e)
        {
            // 获取管理员输入的账号密码信息
            string id = txt_AdminId.Text;
            string pwd = pwd_AdminPwd.Password.ToString();

            if (id == "")
            {
                MessageBox.Show("账号不能为空！");
                return;
            }
            // 检查数据库中是否有该管理员
            if (bl_Admin.IsAdminSearch(id))
            {
                // 检查教师信息是否正确
                if (bl_Admin.IsAdminRight(id, pwd))
                {
                    // 获取数据库中该管理员的信息
                    AdminTable Admin = bl_Admin.GetAdminInfo(id, pwd);
                    // 打开管理员界面
                    Admin_Interface admin_Interface = new Admin_Interface(Admin);
                    Application.Current.MainWindow = admin_Interface;
                    this.Close();
                    admin_Interface.Show();
                }
                else
                {
                    MessageBox.Show("您的信息有误，请重新输入！");
                    ClearAll();
                }
            }
            else
            {
                MessageBox.Show("该管理员不存在！");
                ClearAll();
            }
        }

        private void btn_AdminResiger_Click(object sender, RoutedEventArgs e)
        {
            Admin_Resiger admin_Resiger = new Admin_Resiger();
            Application.Current.MainWindow = admin_Resiger;
            admin_Resiger.Show();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }

        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
