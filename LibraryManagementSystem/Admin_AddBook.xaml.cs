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
    /// Interaction logic for Admin_AddBook.xaml
    /// </summary>
    public partial class Admin_AddBook : Window
    {
        BL_AdminAddBooks bl_AdminAddBooks = new BL_AdminAddBooks();
        public Admin_AddBook()
        {
            InitializeComponent();
        }

        private void ClearAll()
        {
            txt_BookId.Clear();
            txt_BookName.Clear();
            txt_BookAuthor.Clear();
            txt_BookPrice.Clear();
            txt_BookCount.Clear();
        }

        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            BookTable book = new BookTable();

            if (txt_BookId.Text != "" || txt_BookName.Text != "" || txt_BookAuthor.Text != "" || txt_BookPrice.Text != "" || txt_BookCount.Text != "")
            {
                book.Book_Id = txt_BookId.Text;
                book.Book_Name = txt_BookName.Text;
                book.Book_Author = txt_BookAuthor.Text;
                book.Book_Price = txt_BookPrice.Text;
                book.Book_Count = int.Parse(txt_BookCount.Text);

                bl_AdminAddBooks.AddBooksInfo(book);
                MessageBox.Show("添加成功！");
                ClearAll();
            }
            else
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }

            this.Close();
            OpenNew();
        }

        private void btn_Back_Click_(object sender, RoutedEventArgs e)
        {
            this.Close();
            OpenNew();
        }

        private void OpenNew()
        {
            Admin_OperBooks admin_OperBooks = new Admin_OperBooks();
            Application.Current.MainWindow = admin_OperBooks;
            admin_OperBooks.Show();
        }
    }
}
