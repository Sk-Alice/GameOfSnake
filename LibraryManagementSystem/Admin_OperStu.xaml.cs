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
    /// Interaction logic for Admin_OperStu.xaml
    /// </summary>
    public partial class Admin_OperStu : Window
    {
        BL_AdminOperStu bl_AdminOperStu = new BL_AdminOperStu();

        public Admin_OperStu()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Stu_Resiger stu_Resiger = new Stu_Resiger();
            Application.Current.MainWindow = stu_Resiger;
            this.Close();
            stu_Resiger.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                StuTable stu = (StuTable)listView.SelectedItem;
                bl_AdminOperStu.DeleteStuInfo(stu.Stu_Id);
                MessageBox.Show("删除成功");
            }
            // 更新界面信息
            ShowInfo();
            btn_Delete.IsEnabled = false;
            btn_Update.IsEnabled = false;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string name = txt_ReaderName.Text;
            if (name != "")
            {
                List<StuTable> stus = bl_AdminOperStu.GetSearchStuInfo(name);
                listView.ItemsSource = stus;
            }
            else
            {
                MessageBox.Show("请输入要查找的学生！");
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Delete.IsEnabled = true;
            btn_Update.IsEnabled = true;
        }

        private void ShowInfo()
        {
            List<StuTable> stus = bl_AdminOperStu.GetAllStuInfo();
            listView.ItemsSource = stus;
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                StuTable stu = (StuTable)listView.SelectedItem;
                Admin_UpdateStu admin_UpdateStu = new Admin_UpdateStu(stu);
                Application.Current.MainWindow = admin_UpdateStu;
                this.Close();
                admin_UpdateStu.Show();
            }
        }
    }
}
