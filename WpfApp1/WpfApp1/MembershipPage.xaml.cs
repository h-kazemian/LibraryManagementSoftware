using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public partial class MembershipPage : Window
    {
        public MembershipPage()
        {
            InitializeComponent();
            if (Admin_Panel.IsPayment == true)
            {
                PaymentTab.IsSelected = true;
                Admin_Panel.IsPayment = false;
                CardHolder.Text = "Admin";
                Cost.Text = "$" + Admin_Panel.Money;
                BackPayment.IsEnabled = false;
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
        private void BackPayment_Click(object sender, RoutedEventArgs e)
        {
            RegisterTab.IsSelected = true;
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
        private void Payment_Click(object sender, RoutedEventArgs e)
        {
            PaymentTab.IsSelected = true;
          
            CardHolder.Text = FirstName.Text + " " + LastName.Text;
        }
        private void BackLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
