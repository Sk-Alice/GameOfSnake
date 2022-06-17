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
    /// Interaction logic for Admin_Resiger.xaml
    /// </summary>
    public partial class Admin_Resiger : Window
    {
        BL_AdminResiger bl_AdminResiger = new BL_AdminResiger();
        BL_AdminIn bl_AdminIn = new BL_AdminIn();

        public Admin_Resiger()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_AdminId.Clear();
            txt_AdminName.Clear();
            pwd_First.Clear();
            pwd_Second.Clear();
        }

        private void AdminResiger()
        {
            string id = txt_AdminId.Text;
            string name = txt_AdminName.Text;
            string pwd = null;

            string pwd_first = pwd_First.Password.ToString();
            string pwd_second = pwd_Second.Password.ToString();

            if (string.IsNullOrEmpty(pwd_first))
            {
                MessageBox.Show("请输入密码！");
                return;
            }
            else if (string.IsNullOrEmpty(pwd_second))
            {
                MessageBox.Show("请确认密码！");
                return;
            }

            if (!pwd_first.Equals(pwd_second))
            {
                MessageBox.Show("两次密码输入不一致！");
                pwd_First.Clear();
                pwd_Second.Clear();
                return;
            }
            else
            {
                pwd = pwd_first;
            }

            if (name == "" || id == "" || pwd == "")
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            else
            {
                if (!bl_AdminIn.IsAdminSearch(id))
                {
                    AdminTable admin = bl_AdminResiger.GetAdminInfo(id, name, pwd);
                    MessageBox.Show("注册成功！");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("该用户已存在！");
                    ClearAll();
                }
            }
        }

        private void btn_Resiger_Click(object sender, RoutedEventArgs e)
        {
            AdminResiger();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
