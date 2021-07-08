using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace WpfApp1
{
    public class Book
    {
        public void Search()
        {

        }
        public void Borrow()
        {

        }
        public void BorrowingConditions()
        {

        }
        public void ReturnBook()
        {

        }
    }
    public partial class Admin_Panel : Window
    {
        public ObservableCollection<Employees_Panel> EmployeesReport { get; set; }
        public static bool IsPayment = false;
        //The amount the admin wants to pay
        public static string Money;

        public static bool IsAddEmployee = false;
        public Admin_Panel()
        {
            InitializeComponent();
            BindDataGrid();
        }
        //Employees
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTab.IsSelected = true;
        }
        public void BindDataGrid()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                           + "Integrated Security=True;Connect Timeout=30");
            connection.Open();
            string Command;
            Command = "SELECT * FROM Employee";

            SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
            DataSet data = new DataSet();
            adapter.Fill(data, "Employee");

            MyGrid.ItemsSource = data.Tables["Employee"].DefaultView;

            connection.Close();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            IsAddEmployee = true;
            MembershipPage page = new MembershipPage();
            page.Show();
            this.Close();
        }
        private void SalaryPayment_Click(object sender, RoutedEventArgs e)
        {

        }
        //Books
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BooksTab.IsSelected = true;
        }
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookTab.IsSelected = true;
        }
        //Money Bank
        private void MoneyBank_Click(object sender, RoutedEventArgs e)
        {
            MoneyBankTab.IsSelected = true;
        }
        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            IsPayment = true;
            Money = Cost.Text;
            MembershipPage membership = new MembershipPage();
            membership.Show();
            this.Close();
        }
        //Back
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.IsSelected = true;
        }
        //Exit
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}