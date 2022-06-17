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
    /// Interaction logic for Admin_Interface.xaml
    /// </summary>
    public partial class Admin_Interface : Window
    {
        AdminTable Admin = null;
        BL_AdminInterface bl_AdminInterface = new BL_AdminInterface();

        public Admin_Interface()
        {
            InitializeComponent();
        }

        public Admin_Interface(AdminTable admin)
        {
            InitializeComponent();

            this.Admin = admin;
            Admin = bl_AdminInterface.GetAdminInfo(Admin.Admin_Id, Admin.Admin_Pwd);

            txt_AdminId.Text = Admin.Admin_Id;
            txt_AdminName.Text = Admin.Admin_Name;
            txt_AdminPwd.Text = Admin.Admin_Pwd;
        }

        private void btn_OperBook_Click(object sender, RoutedEventArgs e)
        {
            Admin_OperBooks admin_OperBooks = new Admin_OperBooks();
            Application.Current.MainWindow = admin_OperBooks;
            admin_OperBooks.Show();
        }

        private void btn_OperReader_Click(object sender, RoutedEventArgs e)
        {
            Select_ReaderIdentity readerIdentity = new Select_ReaderIdentity();
            Application.Current.MainWindow = readerIdentity;
            readerIdentity.Show();
        }

        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            Admin_LogIn admin_LogIn = new Admin_LogIn();
            App.Current.MainWindow = admin_LogIn;
            this.Close();
            admin_LogIn.Show();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            bl_AdminInterface.UpdateAdminInfo(txt_AdminId.Text, txt_AdminName.Text, txt_AdminPwd.Text);
            Admin = bl_AdminInterface.GetAdminInfo(Admin.Admin_Id, txt_AdminPwd.Text);

            txt_AdminName.Text=Admin.Admin_Name;
            MessageBox.Show("信息修改完成！");
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            bl_AdminInterface.DeleteAdminInfo(txt_AdminId.Text);
            MessageBox.Show("注销成功！");

            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }
    }
}
