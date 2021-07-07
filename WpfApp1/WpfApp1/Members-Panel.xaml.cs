using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class Members_Panel : Window
    {
        public static bool IsPaymentForWallet = false;
        public static string Wallet;
        public Members_Panel()
        {
            InitializeComponent();
        }
        //Books
        private void Books_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Borrow_Click(object sender, RoutedEventArgs e)
        {

        }
        //My Books
        private void MyBooks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {

        }
        //Subscription
        private void Subscription_Click(object sender, RoutedEventArgs e)
        {

        }
        //Wallet
        private void Wallet_Click(object sender, RoutedEventArgs e)
        {
            WalletTab.IsSelected = true;
        }
        private void IncreaseBalance_Click(object sender, RoutedEventArgs e)
        {
            IsPaymentForWallet = true;
            Wallet = Cost.Text;
            MembershipPage membership = new MembershipPage();
            membership.Show();
            this.Close();
        }
        //EditInformation
        private void EditInformation_Click(object sender, RoutedEventArgs e)
        {
            EditInformationTab.IsSelected = true;
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
