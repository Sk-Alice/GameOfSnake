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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // 读者登录
        private void btn_ReaderIn_Click(object sender, RoutedEventArgs e)
        {
            // 读者登录界面
            Reader_LogIn reader_LogIn = new Reader_LogIn();
            Application.Current.MainWindow = reader_LogIn;
            this.Close();
            reader_LogIn.Show();
        }

        // 管理员登录
        private void btn_AdminIn_Click(object sender, RoutedEventArgs e)
        {
            // 管理员登录界面
            Admin_LogIn admin_LogIn = new Admin_LogIn();
            Application.Current.MainWindow = admin_LogIn;
            this.Close();
            admin_LogIn.Show();
        }

        // 退出
        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
