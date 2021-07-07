using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Employees_Panel.xaml
    /// </summary>
    public partial class Employees_Panel : Window
    {
        public Employees_Panel()
        {
            InitializeComponent();
        }
        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            BooksPanel.Visibility = Visibility.Visible;
            MembersOption.Visibility = Visibility.Collapsed;
        }
        private void btnMembers_Click(object sender, RoutedEventArgs e)
        {
            BooksPanel.Visibility = Visibility.Collapsed;
            MembersOption.Visibility = Visibility.Visible;
        }
        private void btnWallet_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEditinformation_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAllBooks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnBorrowedBooks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAvailableBooks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAllMembers_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleydBooks_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleyPay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
