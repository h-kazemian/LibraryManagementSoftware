using System.Windows;

namespace WpfApp1
{
    public partial class Employees_Panel : Window
    {
        public Employees_Panel()
        {
            InitializeComponent();
        }
        //Books
        private void Books_Click(object sender, RoutedEventArgs e)
        {
            BooksTab.IsSelected = true;
        }
        private void WholeBooks_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void LoanedBooks_Click(object sender, RoutedEventArgs e)
        {
           
        }
        private void AvailableBooks_Click(object sender, RoutedEventArgs e)
        {
          
        }
        //Members
        private void Members_Click(object sender, RoutedEventArgs e)
        {

        }
        private void WholeMembers_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DelayDays_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeliveryDelayPayment_Click(object sender, RoutedEventArgs e)
        {

        }
        //Wallet
        private void Wallet_Click(object sender, RoutedEventArgs e)
        {

        }
        //EditInformation
        private void EditInformation_Click(object sender, RoutedEventArgs e)
        {

        }

        //Back
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuTab.IsSelected = true;
        }
        //Exit
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow main = new MainWindow();
            //main.Show();
            //this.Close();
        }
    }
}