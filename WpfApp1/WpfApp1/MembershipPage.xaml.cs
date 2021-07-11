using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace WpfApp1
{
    static class Extension
    {
        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
    public partial class MembershipPage : Window
    {
        public bool IsMember = false;
        public int count = 0;
        public MembershipPage()
        {
            InitializeComponent();

            if(Admin_Panel.Variz == true)
            {
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                connection.Open();
                string Com;
                Com = " SELECT *FROM Employee";
                SqlDataAdapter adapter1 = new SqlDataAdapter(Com, connection);
                DataTable data1 = new DataTable();
                adapter1.Fill(data1);
                count = data1.Rows.Count;
                count--;
                connection.Close();

                PaymentTab.IsSelected = true;
                Cost.Text = "$" + count*300;
                CardHolder.Text = "Admin";
            }

            if (Admin_Panel.IsPayment == true)
            {
                PaymentTab.IsSelected = true;
                CardHolder.Text = "Admin";
                Cost.Text = "$" + Admin_Panel.Money;
            }
            if (Members_Panel.IsPaymentForWallet == true)
            {
                PaymentTab.IsSelected = true;
                Members_Panel.IsPaymentForWallet = false;
                CardHolder.Text = "Member";
                Cost.Text = "$" + Members_Panel.Wallet;
                BackPayment.IsEnabled = false;
            }
        }
        private void LoadPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Photo.Source = new BitmapImage(new Uri(op.FileName));
            }
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
        //Is Valid Fildes??
        public static bool IsValidName(string check)
        {
            string strRegex = @"^([a-zA-Z ]){3,32}$";
            if (Regex.IsMatch(check, strRegex)) 
                return true;
         
            return false;
        }
        bool IsValidEmail(string check)
        {
            string strRegex = "^[0-9a-zA-Z-_]{1,32}@[0-9a-zA-Z]{1,8}[.][a-zA-Z]{1,3}$";

            Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (re.IsMatch(check)) 
                return true;

            return false;
        }
        bool IsValidPhone(string check)
        {
            string strRegex = "^09[0-9]{9}$";
            if (Regex.IsMatch(check, strRegex)) 
                return true;

            return false;
        }
        bool IsValidPassword(string check)
        {
            string strRegex = "(?=.*[A-Z])";
            if (Regex.IsMatch(check, strRegex))
            {
                string strcheck = "^[^- ]{8,32}$";
                if (Regex.IsMatch(check, strcheck))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            bool ISTrue = true;
            FirstName.Text = Extension.RemoveWhitespace(FirstName.Text);
            LastName.Text = Extension.RemoveWhitespace(LastName.Text);

            if (!IsValidName(FirstName.Text + " " + LastName.Text) ||
               String.IsNullOrEmpty(FirstName.Text) || String.IsNullOrWhiteSpace(FirstName.Text) ||
               String.IsNullOrEmpty(LastName.Text) || String.IsNullOrWhiteSpace(LastName.Text))
            {
                FirstName.Text = null;
                LastName.Text = null;
                ISTrue = false;
            }
            if (!IsValidEmail(Email.Text))
            {
                Email.Text = null;
                ISTrue = false;
            }
            if (!IsValidPhone(Phone.Text))
            {
                Phone.Text = null;
                ISTrue = false;
            }
            if (Check_Password.IsChecked == false)
            {
                ShowPassword_Checked(sender, e);
                string Temp = passwordTxtBox.Text;
                ShowPassword_Unchecked(sender, e);

                if (!IsValidPassword(Temp))
                {
                    ShowPassword_Checked(sender, e);
                    passwordTxtBox.Text = null;
                    ISTrue = false;
                    ShowPassword_Unchecked(sender, e);
                }
            }
            else
            {
                if (!IsValidPassword(passwordTxtBox.Text))
                {
                    passwordTxtBox.Text = null;
                    ISTrue = false;
                }
            }
            if (ISTrue == false)
                MessageBox.Show("     Invalid Input!!!");
            else
            {
                string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                               + "Integrated Security=True;Connect Timeout=30");
                bool Check = true;

                if (Admin_Panel.IsAddEmployee == true)
                {
                    try
                    {
                        connection.Open();
                        string Command;
                        string Name = FirstName.Text + " " + LastName.Text;
                        Command = " Select * FROM Employee WHERE Name = '" + Name + "' ";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count != 0)
                            Check = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                else
                {
                    IsMember = true;
                    try
                    {
                        connection.Open();
                        string Command;
                        string Name = FirstName.Text + " " + LastName.Text;
                        Command = " Select * FROM Member WHERE Name = '" + Name + "' ";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        if (data.Rows.Count != 0)
                            Check = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                if(Check == false)
                {
                    MessageBox.Show("     Duplicated User!!!");
                    FirstName.Text = null;
                    LastName.Text = null;
                    Email.Text = null;
                    Phone.Text = null;

                    if (Check_Password.IsChecked == false)
                    {
                        ShowPassword_Checked(sender, e);
                        string Temp = passwordTxtBox.Text;
                        ShowPassword_Unchecked(sender, e);
                        ShowPassword_Checked(sender, e);
                        passwordTxtBox.Text = null;
                        ShowPassword_Unchecked(sender, e);
                    }
                    else
                        passwordTxtBox.Text = null;
                }
                else if(Admin_Panel.IsAddEmployee == false)
                {
                    Cost.Text = "$2";
                    PaymentTab.IsSelected = true;
                    CardHolder.Text = FirstName.Text + " " + LastName.Text;
                }
                else
                {
                    try
                    {
                        connection.Open();
                        string Command, Name = "", password = "";
                        Name += Extension.RemoveWhitespace(FirstName.Text) + " " +
                                Extension.RemoveWhitespace(LastName.Text);

                        if (Check_Password.IsChecked == false)
                        {
                            ShowPassword_Checked(sender, e);
                            password = passwordTxtBox.Text;
                            ShowPassword_Unchecked(sender, e);
                        }
                        else
                            password = passwordTxtBox.Text;

                        try
                        {
                            Command = "INSERT INTO Employee (Name,Email,Phone,Password,Photo,Salary) VALUES('" + Name + "','" + Email.Text + "', '" + Phone.Text + "','" + password + "' , '" + Photo + "','0' )";

                            SqlCommand cmd = new SqlCommand(Command, connection);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("   You have successfully registered!!!!");
                            Admin_Panel admin = new Admin_Panel();
                            admin.Show();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Database error!!!");
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
        //Payment page
        public static bool IsValidCardNumber(string check)
        {
            if (check.Length != 16) 
                return false;
            else
            {
                int s_c = 0;
                try
                {
                    for (int i = 14; i > -1; i -= 2)
                    {
                        int c = int.Parse(check[i].ToString()) * 2;
                        if (c.ToString().Length == 2) c = c % 10 + (c / 10);
                        s_c += c;
                    }
                    for (int i = 15; i > -1; i -= 2)
                    {
                        s_c += int.Parse(check[i].ToString());
                    }
                }
                catch
                {
                    return false;
                }
                if (s_c % 10 == 0) 
                    return true;
                else
                    return false;
            }
        }
        public static bool IsValid_CVV(string check)
        {
            string strRegex = "^[0-9]{3,4}$";
            if (Regex.IsMatch(check, strRegex))
                return true;

            return false;
        }
        public static bool ExpirationDate_validation(string month, string year)
        {
            DateTime t = DateTime.Now;
            if (int.Parse(year) - t.Year < 0) return false;
            else if (int.Parse(year) - t.Year > 1) return true;
            else if (int.Parse(year) - t.Year == 1)
            {
                if (int.Parse(month) + 12 - t.Month < 3 ||
                    int.Parse(month) > 12 || int.Parse(month) < 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                if (int.Parse(month) - t.Month < 3 ||
                    int.Parse(month) > 12 || int.Parse(month) < 0)
                {
                    return false;
                }
                return true;
            }
        }
        private void SubmitPayment_Click(object sender, RoutedEventArgs e)
        {
            bool ISTrue = true;

            if (!IsValidCardNumber(CardNumber.Text))
            {
                CardNumber.Text = null;
                ISTrue = false;
            }
            if (!IsValid_CVV(CVV.Text))
            {
                CVV.Text = null;
                ISTrue = false;
            }
            if (!ExpirationDate_validation(Month.Text, Year.Text))
            {
                Month.Text = null;
                Year.Text = null;
                ISTrue = false;
            }
            if (ISTrue == false)
                MessageBox.Show("     Invalid Input!!!");

            else
            {
                if (IsMember == true)
                {
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                                   + "Integrated Security=True;Connect Timeout=30");
                    try
                    {
                        connection.Open();
                        string Command, Name = "", password = "";
                        Name += Extension.RemoveWhitespace(FirstName.Text) + " " +
                                Extension.RemoveWhitespace(LastName.Text);

                        if (Check_Password.IsChecked == false)
                        {
                            ShowPassword_Checked(sender, e);
                            password = passwordTxtBox.Text;
                            ShowPassword_Unchecked(sender, e);
                        }
                        else
                            password = passwordTxtBox.Text;

                        try
                        {
                            Command = "INSERT INTO Member (Name,Email,Phone,Password,Photo) VALUES('" + Name + "','" + Email.Text + "', '" + Phone.Text + "','" + password + "' , '" + Photo + "')";

                            SqlCommand cmd = new SqlCommand(Command, connection);

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("   You have successfully registered!!!!");
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Database error!!!");
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                    int TotalMoney = -1;
                    try
                    {
                        connection.Open();
                        string Command;
                        Command = " SELECT *FROM Employee WHERE Name = 'admin'";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        TotalMoney = int.Parse(data.Rows[0][5].ToString());

                        TotalMoney += 2;
                        Command = "UPDATE Employee SET Salary = '" + TotalMoney + "' Where Name = 'admin'";
                        SqlCommand cmd = new SqlCommand(Command, connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("Database error!!!");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Database error!!!");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
                if (Admin_Panel.Variz == true)
                {
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                                   + "Integrated Security=True;Connect Timeout=30");

       
                    int TotalMoney = -1;
                    try
                    {
                        connection.Open();
                        string Command;
                        Command = " SELECT *FROM Employee WHERE Name = 'admin'";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        TotalMoney = int.Parse(data.Rows[0][5].ToString());
                     
                        if (TotalMoney >= 300 * count)
                        {
                            TotalMoney -= 300 * count;
                            Command = "UPDATE Employee SET Salary = '" + TotalMoney + "' Where Name = 'admin'";
                            SqlCommand cmd = new SqlCommand(Command, connection);
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show("   Database error!!!");
                            }
                        }
                        else
                            MessageBox.Show("         Not enough money!!!");

                        Admin_Panel admin = new Admin_Panel();
                        admin.Show();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Database error!!!");
                    }
                    finally
                    {
                        connection.Close();
                    }

                    Admin_Panel.Variz = false;
                }
                if (Admin_Panel.IsPayment == true)
                {
                    string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Asset\Database"));
                    SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + "\\Library.mdf;"
                                                                   + "Integrated Security=True;Connect Timeout=30");

                    int TotalMoney = -1;
                    try
                    {
                        connection.Open();
                        string Command;
                        Command = " SELECT *FROM Employee WHERE Name = 'admin'";
                        SqlDataAdapter adapter = new SqlDataAdapter(Command, connection);
                        DataTable data = new DataTable();
                        adapter.Fill(data);
                        TotalMoney = int.Parse(data.Rows[0][5].ToString());

                        var str = Cost.Text.Split('$');
                        TotalMoney += int.Parse(str[1]);

                        connection.Close();

                        connection.Open();
                        Command = "UPDATE Employee SET Salary = '" + TotalMoney + "' Where Name = 'admin'";
                        SqlCommand cmd = new SqlCommand(Command, connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            MessageBox.Show("   Database error!!!");
                        }

                        Admin_Panel.IsPayment = false;
                        Admin_Panel admin = new Admin_Panel();
                        admin.Show();
                        this.Close();
                        
                    }
                    catch
                    {
                        MessageBox.Show("Database error!!!");
                    }
                    finally
                    {
                        connection.Close();
                    }

                    Admin_Panel.Variz = false;
                }
            }
        }
        private void BackPayment_Click(object sender, RoutedEventArgs e)
        {
            if (Admin_Panel.IsPayment == true)
            {
                Admin_Panel.IsPayment = false;
                Admin_Panel admin = new Admin_Panel();
                admin.Show();
                this.Close();
            } 
            else
                RegisterTab.IsSelected = true;

            if(Admin_Panel.Variz == true)
            {
                Admin_Panel panel = new Admin_Panel();
                panel.Show();
                this.Close();
                Admin_Panel.Variz = false;
            }
        }
        private void BackLogin_Click(object sender, RoutedEventArgs e)
        {
            if (Admin_Panel.IsAddEmployee == true)
            {
                Admin_Panel admin = new Admin_Panel();
                admin.Show();
                this.Close();
            }
            else
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
        }
    }
}