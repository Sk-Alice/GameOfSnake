using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Reader_Borrow.xaml
    /// </summary>
    public partial class Reader_Borrow : Window
    {
        BL_ReaderBorrow bl_ReaderBorrow = new BL_ReaderBorrow();
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        StuTable Stu = null;
        TeacherTable Teacher = null;
        Reader_LogIn reader_LogIn = new Reader_LogIn();

        public Reader_Borrow()
        {
            InitializeComponent();
        }

        public Reader_Borrow(StuTable stu)
        {
            InitializeComponent();

            this.Stu = stu;
        }

        public Reader_Borrow(TeacherTable teacher)
        {
            InitializeComponent();

            this.Teacher = teacher;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            string name = txt_BookName.Text;
            if(name != "")
            {
                List<BookTable> books = bl_ReaderBorrow.GetSearchBookInfo(name);
                listView.ItemsSource = books;
            }
            else
            {
                MessageBox.Show("请输入查找的书籍！");
            }
        }

        private void btn_Borrow_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if(selectedIndex >= 0)
            {
                BookTable book = (BookTable)listView.SelectedItem;
                int BookCount = book.Book_Count;
                // 教师借书
                if (Stu == null && Teacher != null)
                {
                    int TeacherCount = Teacher.Teacher_BorrowNum;
                    // 该书已被借阅
                    if(bl_ReaderBorrow.IsBorrow(Teacher.Teacher_Id, book.Book_Id))
                    {
                        MessageBox.Show("该图书已借阅!");
                        return;
                    }
                    // 满足借书条件--读者借阅数量未达上限，书籍有剩余
                    if (TeacherCount > 0 && BookCount > 0)
                    {
                        bl_ReaderBorrow.Teacher_UpdateTable(Teacher.Teacher_Id, book.Book_Id, BookCount - 1, TeacherCount - 1);
                        MessageBox.Show("借阅成功");
                    }
                    // 书籍没有剩余
                    else if(TeacherCount > 0 && BookCount == 0)
                    {
                        MessageBox.Show("该书已经全部借出！");
                        return;
                    }
                    // 读者借阅数量达到上限
                    else if (TeacherCount <= 0)
                    {
                        MessageBox.Show("您的借阅数量已达上限！");
                        return;
                    }
                    // borrow表添加数据
                    bl_ReaderBorrow.AddBorrowInfo(Teacher.Teacher_Id, book.Book_Id, Teacher.Teacher_Name, book.Book_Name, DateTime.Now.ToString(), DateTime.Now.AddMonths(1).ToString());
                    // 更新教师信息
                    Teacher = bl_ReaderIn.GetTeacherInfo(Teacher.Teacher_Id, Teacher.Teacher_Pwd);
                }
                // 学生借书
                else if (Stu != null && Teacher == null)
                {
                    int StuCount = Stu.Stu_BorrowNum;
                    // 该书已被借阅
                    if (bl_ReaderBorrow.IsBorrow(Stu.Stu_Id, book.Book_Id))
                    {
                        MessageBox.Show("该图书已借阅!");
                        return;
                    }
                    // 满足借书条件--读者借阅数量未达上限，书籍有剩余
                    if (StuCount > 0 && BookCount > 0)
                    {
                        bl_ReaderBorrow.Stu_UpdateTable(Stu.Stu_Id, book.Book_Id, BookCount - 1, StuCount - 1);
                        MessageBox.Show("借阅成功");
                    }
                    // 书籍没有剩余
                    else if (StuCount > 0 && BookCount == 0)
                    {
                        MessageBox.Show("该书已经全部借出！");
                        return;
                    }
                    // 读者借阅数量达到上限
                    else if (StuCount <= 0)
                    {
                        MessageBox.Show("您的借阅数量已达上限！");
                        return;
                    }
                    // 借书表添加数据
                    bl_ReaderBorrow.AddBorrowInfo(Stu.Stu_Id, book.Book_Id, Stu.Stu_Name, book.Book_Name, DateTime.Now.ToString(), DateTime.Now.AddMonths(1).ToString());
                    // 更新学生数据
                    Stu = bl_ReaderIn.GetStuInfo(Stu.Stu_Id, Stu.Stu_Pwd);
                }
            }
            else
            {
                MessageBox.Show("请选择借阅的书籍！");
                return;
            }
            // 更新界面信息
            ShowInfo();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Borrow.IsEnabled = true;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if(Stu != null && Teacher == null)
            {
                reader_LogIn.OpenStuInterface(Stu.Stu_Id, Stu.Stu_Pwd);
            }
            else if(Teacher != null && Stu == null)
            {
                reader_LogIn.OpenTeacheInterface(Teacher.Teacher_Id, Teacher.Teacher_Pwd);
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void ShowInfo()
        {
            if (Stu == null && Teacher != null)
            {
                tb_BNum.Text = Teacher.Teacher_BorrowNum.ToString();
                List<BookTable> books = bl_ReaderBorrow.GetAllBookInfo();
                listView.ItemsSource = books;
            }
            else if (Stu != null && Teacher == null)
            {
                tb_BNum.Text = Stu.Stu_BorrowNum.ToString();
                List<BookTable> books = bl_ReaderBorrow.GetAllBookInfo();
                listView.ItemsSource = books;
            }
        }
    }
}
