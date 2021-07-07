using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

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
            MembersTab.IsSelected = true;
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