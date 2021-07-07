using System.Windows;
using System.Windows.Controls;

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