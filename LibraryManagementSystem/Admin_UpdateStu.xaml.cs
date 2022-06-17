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
    /// Interaction logic for Admin_UpdateStu.xaml
    /// </summary>
    public partial class Admin_UpdateStu : Window
    {
        BL_AdminUpdateReader bl_AdminUpdateReader = new BL_AdminUpdateReader();

        public Admin_UpdateStu()
        {
            InitializeComponent();
        }

        public Admin_UpdateStu(StuTable stu)
        {
            InitializeComponent();

            txt_StuId.Text = stu.Stu_Id;
            txt_StuName.Text = stu.Stu_Name;
            txt_StuGrade.Text = stu.Stu_Grade;
            txt_StuPro.Text = stu.Stu_Pro;
            txt_Pwd.Text = stu.Stu_Pwd;
            txt_StuBNum.Text = stu.Stu_BorrowNum.ToString();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            StuTable stu = new StuTable();
            stu.Stu_Id = txt_StuId.Text;
            stu.Stu_Name = txt_StuName.Text;
            stu.Stu_Grade = txt_StuGrade.Text;  
            stu.Stu_Pro = txt_StuPro.Text;
            stu.Stu_BorrowNum = int.Parse(txt_StuBNum.Text);

            string pwd1 = pwd_First.Password.ToString();
            string pwd2 = pwd_Second.Password.ToString();

            if (pwd1.Equals(pwd2) && pwd2 != "")
            {
                stu.Stu_Pwd = pwd2;
            }
            else if(pwd1 != "" && pwd2 == "")
            {
                MessageBox.Show("请确定密码!");
                return;
            }
            else if(pwd1 != "" && pwd2 != "" && !pwd1.Equals(pwd2))
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            else
            {
                stu.Stu_Pwd = txt_Pwd.Text;
            }

            bl_AdminUpdateReader.UpdateStuInfo(stu);
            MessageBox.Show("信息修改成功！");
            this.Close();
            OpenNewStu();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenNewStu()
        {
            Admin_OperStu admin_OperStu = new Admin_OperStu();
            Application.Current.MainWindow = admin_OperStu;
            admin_OperStu.Show();
        }
    }
}
