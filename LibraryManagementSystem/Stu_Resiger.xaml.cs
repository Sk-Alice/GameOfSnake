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
    /// Stu_Resiger.xaml 的交互逻辑
    /// </summary>
    public partial class Stu_Resiger : Window
    {
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        BL_StuResiger bl_StuResiger = new BL_StuResiger();

        public Stu_Resiger()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_StuId.Clear();
            txt_StuName.Clear();
            txt_StuPro.Clear();
            txt_StuGrade.Clear();
            pwd_First.Clear();
            pwd_Second.Clear();
        }

        private void StuResiger()
        {
            string name = txt_StuName.Text;
            string id =  txt_StuId.Text;
            string grade = txt_StuGrade.Text;
            string pro = txt_StuPro.Text;
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

            if (name == "" || id == "" || grade == "" || pro == "" || pwd == "")
            {
                MessageBox.Show("请填写完整信息！");
                return;
            }
            else
            {
                if (!bl_ReaderIn.IsStuSearch(id))
                {
                    StuTable stu = bl_StuResiger.GetStuInfo(id, name, pwd, grade, pro);
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
            StuResiger();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
