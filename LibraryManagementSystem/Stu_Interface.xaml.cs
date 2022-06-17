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
    /// Stu_Interface.xaml 的交互逻辑
    /// </summary>
    public partial class Stu_Interface : Window
    {
        StuTable Stu = null;
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        BL_StuInterface bl_StuInterface = new BL_StuInterface();

        public Stu_Interface()
        {
            InitializeComponent();
        }

        public Stu_Interface(StuTable stu)
        {
            InitializeComponent();

            this.Stu = stu;
            Stu = bl_ReaderIn.GetStuInfo(Stu.Stu_Id, Stu.Stu_Pwd);
            
            txt_StuName.Text = Stu.Stu_Name;
            txt_StuId.Text = Stu.Stu_Id;
            txt_StuGrade.Text = Stu.Stu_Grade;
            txt_StuPro.Text = Stu.Stu_Pro;
            txt_StuPwd.Text = Stu.Stu_Pwd;
            txt_BNum.Text = Stu.Stu_BorrowNum.ToString();
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            Reader_Return reader_Return = new Reader_Return(Stu);
            Application.Current.MainWindow = reader_Return;
            this.Close();
            reader_Return.Show();
        }

        private void btn_Out_Click(object sender, RoutedEventArgs e)
        {
            Reader_LogIn reader_LogIn = new Reader_LogIn();
            Application.Current.MainWindow = reader_LogIn;
            this.Close();
            reader_LogIn.Show();
        }

        private void btn_Borrow_Click(object sender, RoutedEventArgs e)
        {
            Reader_Borrow reader_Borrow = new Reader_Borrow(Stu);
            Application.Current.MainWindow = reader_Borrow;
            this.Close();
            reader_Borrow.Show();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            bl_StuInterface.UpdateStuInfo(txt_StuId.Text, txt_StuName.Text, txt_StuPro.Text, txt_StuGrade.Text, txt_StuPwd.Text);
            Stu = bl_ReaderIn.GetStuInfo(Stu.Stu_Id, txt_StuPwd.Text);

            txt_StuName.Text = Stu.Stu_Name;
            txt_StuGrade.Text = Stu.Stu_Grade;
            txt_StuPro.Text = Stu.Stu_Pro;
            txt_StuPwd.Text = Stu.Stu_Pwd;
            MessageBox.Show("信息修改成功！");
        }
    }
}
