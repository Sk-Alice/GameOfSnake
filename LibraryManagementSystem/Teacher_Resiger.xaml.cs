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
    /// Teacher_Resiger.xaml 的交互逻辑
    /// </summary>
    public partial class Teacher_Resiger : Window
    {
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        BL_TeacherResiger bl_TeacherResiger = new BL_TeacherResiger();
        
        public Teacher_Resiger()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_TeacherId.Clear();
            txt_TeacherName.Clear();
            pwd_First.Clear();
            pwd_Second.Clear();
        }

        private void TeacherResiger()
        {
            string name = txt_TeacherName.Text;
            string id = txt_TeacherId.Text;
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
                if (!bl_ReaderIn.IsTeacherSearch(id))
                {
                    TeacherTable teacher = bl_TeacherResiger.GetTeacherInfo(id, name, pwd);
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
            TeacherResiger();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
