using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Login
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
 
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                            + "Integrated Security=True;Connect Timeout=30");
            connection.Open();

            string Command = "", Name = "", Password = ""; 
            int KindPanel = 0;

            if (!String.IsNullOrEmpty(Username.Text) || !String.IsNullOrWhiteSpace(Username.Text))
            {
                //Employee
                if (Check_Employee.IsChecked == true)
                {
                    Command = "SELECT * FROM Employee WHERE Name = '" + Username.Text.ToLower() + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count != 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            Name = data.Rows[i][0].ToString();
                            Password = data.Rows[i][3].ToString();
                        }
                        KindPanel = 1;
                    }
                }
                //Member
                else
                {
                    Command = "SELECT * FROM Member WHERE Name = '" + Username.Text.ToLower() + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    if (data.Rows.Count != 0)
                    {
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            Name = data.Rows[i][0].ToString();
                            Password = data.Rows[i][3].ToString();
                        }
                        KindPanel = 2;
                    }
                }
            }
            bool Login = false;
            if (String.Compare(Username.Text.ToLower(), Name) == 0)
            {
                if (Check_Password.IsChecked == false)
                {
                    ShowPassword_Checked(sender, e);
                    string Temp = passwordTxtBox.Text;
                    ShowPassword_Unchecked(sender, e);

                    if (string.Compare(Password, Temp) != 0)
                    {
                        ShowPassword_Checked(sender, e);
                        passwordTxtBox.Text = null;
                        ShowPassword_Unchecked(sender, e);
                        Username.Text = null;
                        KindPanel = 0;
                    }
                    else
                        Login = true;
                }
                else
                {
                    if (string.Compare(Password, passwordTxtBox.Text) != 0)
                    {
                        passwordTxtBox.Text = null;
                        Username.Text = null;
                        KindPanel = 0;
                    }
                    else
                        Login = true;
                }
            }
            else
            {
                if (Check_Password.IsChecked == false)
                {
                    ShowPassword_Checked(sender, e);
                    ShowPassword_Unchecked(sender, e);
                    ShowPassword_Checked(sender, e);
                    passwordTxtBox.Text = null;
                    ShowPassword_Unchecked(sender, e);
                }
                else
                    passwordTxtBox.Text = null;
            }
            if(KindPanel == 0)
            {
                Username.Text = null;
                MessageBox.Show("      Username or Password incorrect!!!");
            }
            else if (Login == true)
            {
                if (KindPanel == 1)
                {
                    if(String.Compare(Name.ToLower(), "admin") == 0)
                    {
                        Admin_Panel admin = new Admin_Panel();
                        admin.Show();
                        this.Close();
                    }
                    else
                    {
                        Employees_Panel employees = new Employees_Panel();
                        employees.Show();
                        this.Close();
                    }
                }
                else
                {
                    Members_Panel members = new Members_Panel();
                    members.Show();
                    this.Close();
                }
            }
            connection.Close();
        }
        private void Request(object sender, RoutedEventArgs e)
        {
            MembershipPage membership = new MembershipPage();
            membership.Show();
            this.Close();
        }
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = PasswordBox.Password;
            PasswordBox.Visibility = Visibility.Collapsed;
            passwordTxtBox.Visibility = Visibility.Visible;
        }
        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Collapsed;
            PasswordBox.Visibility = Visibility.Visible;
        }
    }
}