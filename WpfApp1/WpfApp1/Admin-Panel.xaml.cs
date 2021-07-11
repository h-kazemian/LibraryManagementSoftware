using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Windows.Forms;

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

            BindDataGridEmployee();
        }
        //Employees
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTab.IsSelected = true;
        }
        public void BindDataGridEmployee()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string Command;
                Command = " SELECT * FROM Employee where Name != 'admin' ";
               
                SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                DataSet data = new DataSet();
                adapter.Fill(data, "Employee");

                EmployeeGrid.ItemsSource = data.Tables["Employee"].DefaultView;

                connection.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("    Database error !!!");
            }
        }
        private void RemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            DialogResult result =
                (DialogResult)System.Windows.MessageBox.Show
                ("    Are you sure you want to delete this record?", "Delete",
                (MessageBoxButton)MessageBoxButtons.YesNo,
                (MessageBoxImage)MessageBoxIcon.Question,
                (MessageBoxResult)MessageBoxDefaultButton.Button1); ;

            DataRowView dataRowView = (DataRowView)((System.Windows.Controls.Button)e.Source).DataContext;

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                try
                {
                    connection.Open();
                    string Command;
                    Command = " DELETE FROM Employee WHERE Name = '" + dataRowView.Row[0] + "' ";

                    SqlCommand cmd = new SqlCommand(Command, connection);
     
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                dataRowView.Delete();
            }
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

            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                           + "Integrated Security=True;Connect Timeout=30");
            try
            {
                connection.Open();
                string Command;
                Command = " Select * FROM Employee WHERE Name = 'admin' ";

                SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                TotalBalance.Text = data.Rows[0][5].ToString();
               
            }
            finally
            {
                connection.Close();
            }

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