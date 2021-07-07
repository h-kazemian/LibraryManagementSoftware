using System.Windows;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public partial class Admin_Panel : Window
    {
        //   public ObservableCollection<Employees_Panel> Employees { get; set; }
        public static bool IsPayment = false;
        //The amount the admin wants to pay
        public static string Money;
        public Admin_Panel()
        {
            InitializeComponent();
      
        }
        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            EmployeesTab.IsSelected = true;

        }
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BooksTab.IsSelected = true;
        }
        private void MoneyBank_Click(object sender, RoutedEventArgs e)
        {
            MoneyBankTab.IsSelected = true;
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }
        //Employees
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }
        //Books
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookTab.IsSelected = true;
        }
        //Money Bank
        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            IsPayment = true;
            Money = Cost.Text;
            MembershipPage membership = new MembershipPage();
            membership.Show();
            this.Close();
        }
    }
}
