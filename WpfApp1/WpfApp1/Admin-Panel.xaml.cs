using System.Windows;
using System.Collections.ObjectModel;

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

        public Admin_Panel()
        {
            InitializeComponent();
        }
        //Employees
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTab.IsSelected = true;
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

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