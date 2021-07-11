using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System;

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
        public static bool Variz = false;

        public static bool IsPayment = false;
        //The amount the admin wants to pay
        public static string Money;

        public static bool IsAddEmployee = false;

        public Admin_Panel()
        {
            InitializeComponent();

            BindDataGridEmployee();

            BindDataGridBook();
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
                (MessageBoxResult)MessageBoxDefaultButton.Button1);

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
            InputBox.Visibility = Visibility.Visible;
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;

            String input = InputTextBox.Text;

            if (String.Compare(input.ToLower(), "admin") == 0)
            {
                Variz = true;
                MembershipPage page = new MembershipPage();
                page.Show();
                this.Close();
            }
            else
                InputTextBox.Text = String.Empty;

            InputTextBox.Text = String.Empty;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;

            InputTextBox.Text = String.Empty;
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
        public void BindDataGridBook()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string Command;
                Command = " SELECT * FROM Books";

                SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                DataSet data = new DataSet();
                
                adapter.Fill(data, "Books");
                
                BookGrid.ItemsSource = data.Tables["Books"].DefaultView;

                connection.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("    Database error !!!");
            }
        }
        private void BackBooksTab_Click(object sender, RoutedEventArgs e)
        {
            BooksTab.IsSelected = true;
        }
        private void SubmitBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int temp = int.Parse(PrintingNumber.Text);

                if (String.IsNullOrEmpty(NameBook.Text) || String.IsNullOrWhiteSpace(NameBook.Text) ||
                    String.IsNullOrEmpty(Writer.Text) || String.IsNullOrWhiteSpace(Writer.Text) ||
                    String.IsNullOrEmpty(GenreBook.Text) || String.IsNullOrWhiteSpace(GenreBook.Text))
                {
                    System.Windows.MessageBox.Show("    Invalid input!!!");
                }
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                try
                {
                    connection.Open();
                    string Command, Name = "", writer = "", genreBook = "";
                    Name += Extension.RemoveWhitespace(NameBook.Text);
                    writer += Extension.RemoveWhitespace(Writer.Text);
                    genreBook += Extension.RemoveWhitespace(GenreBook.Text);

                    try
                    {
                        Command = " SELECT *FROM Books WHERE Name = '" + Name + "'and Writer = '" + writer + "' and Genre = '" + genreBook + "' and PrintingNumber = '" + PrintingNumber.Text + "'";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        if (data.Rows.Count != 0)
                        {
                            int Temp = int.Parse(data.Rows[0][5].ToString());
                            Temp++;

                            Command = "UPDATE Books SET Numbers = '" + Temp + "' Where Name = '" + Name + "' ";
                            SqlCommand cmd = new SqlCommand(Command, connection);
                            try
                            {
                                cmd.ExecuteNonQuery();

                                System.Windows.MessageBox.Show("     Book added!!!");
                                NameBook.Text = null;
                                Writer.Text = null;
                                GenreBook.Text = null;
                                PrintingNumber.Text = null;

                                BooksTab.IsSelected = true;
                            }
                            catch
                            {
                                System.Windows.MessageBox.Show("     Database error!!!");
                                NameBook.Text = null;
                                Writer.Text = null;
                                GenreBook.Text = null;
                                PrintingNumber.Text = null;
                            }
                        }
                        else
                        {
                            try
                            {
                                int one = 1;
                                Command = "INSERT INTO Books (Name,Writer,Genre,PrintingNumber,Numbers) VALUES('" + Name + "', '" + writer + "','" + genreBook + "' , '" + PrintingNumber.Text + "','" + one + "')";

                                SqlCommand cmd = new SqlCommand(Command, connection);
                                cmd.ExecuteNonQuery();

                                System.Windows.MessageBox.Show("     Book added!!!");
                                NameBook.Text = null;
                                Writer.Text = null;
                                GenreBook.Text = null;
                                PrintingNumber.Text = null;

                                BooksTab.IsSelected = true;
                            }
                            catch
                            {
                                System.Windows.MessageBox.Show("      Database error!!!");
                                NameBook.Text = null;
                                Writer.Text = null;
                                GenreBook.Text = null;
                                PrintingNumber.Text = null;
                            }
                        }
                    }
                    catch
                    {
                        System.Windows.MessageBox.Show("     Database error!!!");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            catch
            {
                PrintingNumber.Text = null;
                System.Windows.MessageBox.Show("    Invalid input!!!");
            }
            BindDataGridBook();
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
            try
            {
                int temp = int.Parse(Cost.Text);
                Money = Cost.Text;
                MembershipPage membership = new MembershipPage();
                membership.Show();
                this.Close();
            }
            catch
            {
                System.Windows.MessageBox.Show("   Invalid Input!!!");
                Cost.Text = null;
            }
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