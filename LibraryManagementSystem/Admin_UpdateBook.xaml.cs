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
    /// Interaction logic for Admin_UpdateBook.xaml
    /// </summary>
    public partial class Admin_UpdateBook : Window
    {
        BL_AdminUpdateBook bl_AdminUpdateBook = new BL_AdminUpdateBook();

        public Admin_UpdateBook()
        {
            InitializeComponent();
        }

        public Admin_UpdateBook(BookTable book)
        {
            InitializeComponent();

            txt_BookId.Text = book.Book_Id;
            txt_BookName.Text = book.Book_Name;
            txt_BookAuthor.Text = book.Book_Author;
            txt_BookPrice.Text = book.Book_Price;
            txt_BookCount.Text = book.Book_Count.ToString();
        }

        private void btn_AddBook_Click(object sender, RoutedEventArgs e)
        {
            BookTable book = new BookTable();
            book.Book_Id = txt_BookId.Text;
            book.Book_Name = txt_BookName.Text;
            book.Book_Author = txt_BookAuthor.Text;
            book.Book_Price = txt_BookPrice.Text;
            book.Book_Count = int.Parse(txt_BookCount.Text);

            bl_AdminUpdateBook.UpdateBookInfo(book);
            MessageBox.Show("信息修改成功！");
            this.Close();
            OpenNew();
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
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
