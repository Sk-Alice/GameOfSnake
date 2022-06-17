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
    /// Interaction logic for Reader_Return.xaml
    /// </summary>
    public partial class Reader_Return : Window
    {
        StuTable Stu = null;
        TeacherTable Teacher = null;
        BL_ReaderReturn bl_ReaderReturn = new BL_ReaderReturn();
        BL_ReaderIn bl_ReaderIn = new BL_ReaderIn();
        Reader_LogIn reader_LogIn = new Reader_LogIn();

        public Reader_Return()
        {
            InitializeComponent();
        }

        public Reader_Return(StuTable stu)
        {
            InitializeComponent();

            this.Stu = stu;
        }

        public Reader_Return(TeacherTable teacher)
        {
            InitializeComponent();

            this.Teacher = teacher;
        }

        private void ShowInfo()
        {
            if (Stu == null && Teacher != null)
            {
                List<BorrowTable> borrows = bl_ReaderReturn.GetAllBorrowInfo(Teacher.Teacher_Id);
                listView.ItemsSource = borrows;
            }
            else if (Stu != null && Teacher == null)
            {
                List<BorrowTable> borrows = bl_ReaderReturn.GetAllBorrowInfo(Stu.Stu_Id);
                listView.ItemsSource = borrows;
            }
        }

        private void btn_Renew_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                BorrowTable book = (BorrowTable)listView.SelectedItem;
                // 教师续借
                if (Stu == null && Teacher != null)
                {
                    // borrow表更新数据
                    bl_ReaderReturn.UpdateBorrowInfo(Teacher.Teacher_Id, book.Book_Id, DateTime.Now.ToString(), DateTime.Now.AddMonths(1).ToString());
                    MessageBox.Show("续借成功");
                }
                // 学生续借
                else if (Stu != null && Teacher == null)
                {
                    // borrow表更新数据
                    bl_ReaderReturn.UpdateBorrowInfo(Stu.Stu_Id, book.Book_Id, DateTime.Now.ToString(), DateTime.Now.AddMonths(1).ToString());
                    MessageBox.Show("续借成功");
                }
            }
            else
            {
                MessageBox.Show("请选择续借的书籍！");
                return;
            }
            // 更新界面信息
            ShowInfo();
        }

        private void btn_Return_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = listView.SelectedIndex;
            // 选择的不是空行
            if (selectedIndex >= 0)
            {
                BorrowTable borrow = (BorrowTable)listView.SelectedItem;
                BookTable book = bl_ReaderReturn.GetBackBookInfo(borrow.Book_Id);
                int BookCount = book.Book_Count;
                // 教师还书
                if (Teacher != null && Stu == null)
                {
                    int TeacherCount = Teacher.Teacher_BorrowNum;
                    bl_ReaderReturn.Teacher_UpdateTable(Teacher.Teacher_Id, book.Book_Id, BookCount + 1 , TeacherCount + 1);
                    MessageBox.Show("归还成功");
                    // borrow表删除数据
                    bl_ReaderReturn.DeleteBorrowInfo(Teacher.Teacher_Id, book.Book_Id);
                    // 更新教师信息
                    Teacher = bl_ReaderIn.GetTeacherInfo(Teacher.Teacher_Id, Teacher.Teacher_Pwd);
                }
                // 学生还书
                else if (Stu != null && Teacher == null)
                {
                    int StuCount = Stu.Stu_BorrowNum;
                    bl_ReaderReturn.Stu_UpdateTable(Stu.Stu_Id, book.Book_Id, BookCount + 1, StuCount + 1);
                    MessageBox.Show("归还成功");
                    // 借书表删除数据
                    bl_ReaderReturn.DeleteBorrowInfo(Stu.Stu_Id, book.Book_Id);
                    // 更新学生数据
                    Stu = bl_ReaderIn.GetStuInfo(Stu.Stu_Id, Stu.Stu_Pwd);
                }
            }
            else
            {
                MessageBox.Show("请选择归还的书籍！");
                return;
            }
            // 更新界面信息
            ShowInfo();
            btn_Return.IsEnabled = false;
            btn_Renew.IsEnabled = false;
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Stu != null && Teacher == null)
            {
                reader_LogIn.OpenStuInterface(Stu.Stu_Id, Stu.Stu_Pwd);
            }
            else if (Teacher != null && Stu == null)
            {
                reader_LogIn.OpenTeacheInterface(Teacher.Teacher_Id, Teacher.Teacher_Pwd);
            }
            this.Close();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_Return.IsEnabled = true;
            btn_Renew.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }
    }
}
