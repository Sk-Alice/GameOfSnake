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
    /// Interaction logic for Admin_OperBooks.xaml
    /// </summary>
    public partial class Admin_OperBooks : Window
    {
        BL_AdminOperBooks bl_AdminOperBooks = new BL_AdminOperBooks();

        public Admin_OperBooks()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Admin_AddBook admin_AddBook = new Admin_AddBook();
            Application.Current.MainWindow = admin_AddBook;
            this.Close();
            admin_AddBook.Show();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                BookTable book = (BookTable)listView.SelectedItem;
                if (bl_AdminOperBooks.IsGetSelectBorrowBook(book.Book_Id)) 
                { 
                    MessageBox.Show("删除失败！该书被借阅中！");
                    return;
                }
                bl_AdminOperBooks.DeleteBookInfo(book.Book_Id);
                MessageBox.Show("删除成功");
            }
            // 更新界面信息
            ShowInfo();
            btn_Delete.IsEnabled = false;
            btn_Update.IsEnabled = false;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string name = txt_BookName.Text;
            if (name != "")
            {
                List<BookTable> books = bl_AdminOperBooks.GetSearchBookInfo(name);
                listView.ItemsSource = books;
            }
            else
            {
                MessageBox.Show("请输入查找书籍！");
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                BookTable book = (BookTable)listView.SelectedItem;
                Admin_UpdateBook admin_UpdateBook = new Admin_UpdateBook(book);
                Application.Current.MainWindow = admin_UpdateBook;
                this.Close();
                admin_UpdateBook.Show();
            }
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Delete.IsEnabled = true;
            btn_Update.IsEnabled = true;
        }

        private void ShowInfo()
        {
            List<BookTable> books = bl_AdminOperBooks.GetAllBookInfo();
            listView.ItemsSource = books;
        }
    }
}
