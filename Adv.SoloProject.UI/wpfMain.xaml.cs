using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Adv.SoloProject.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatus.Content = "Loaded";
            gridManagement.Visibility = gridRental.Visibility = gridNewCustomer.Visibility = Visibility.Hidden;
            gridHome.Visibility = Visibility.Visible;
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        private void btnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Hidden;
            btnManagement.IsEnabled = btnNewCustomer.IsEnabled = false;

            gridRental.Visibility = Visibility.Visible;
        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Hidden;

            gridNewCustomer.Visibility = Visibility.Visible;
            btnNewCustomer.IsEnabled = btnManagement.IsEnabled = false;

        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            gridNewCustomer.Visibility = Visibility.Hidden;
            btnNewCustomer.IsEnabled = btnManagement.IsEnabled = true;

            gridHome.Visibility = Visibility.Visible;
        }

        private void btnNewCustomerCancel_Click(object sender, RoutedEventArgs e)
        {
            gridNewCustomer.Visibility = Visibility.Hidden;
            btnNewCustomer.IsEnabled = btnManagement.IsEnabled = true;

            gridHome.Visibility = Visibility.Visible;
        }

        private void btnRentalCancel_Click(object sender, RoutedEventArgs e)
        {
            gridRental.Visibility = Visibility.Hidden;

            gridHome.Visibility = Visibility.Visible;
            btnManagement.IsEnabled = btnNewCustomer.IsEnabled = true;
        }

        private void btnRentalFinish_Click(object sender, RoutedEventArgs e)
        {
            gridRental.Visibility = Visibility.Hidden;

            gridHome.Visibility = Visibility.Visible;
            btnManagement.IsEnabled = btnNewCustomer.IsEnabled = true;
        }

        private void btnMovieLookup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRentalReturn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnManagementMovies_Click(object sender, RoutedEventArgs e)
        {
            gbFormats.Visibility = gbPricing.Visibility = Visibility.Hidden;
            gbMovies.Visibility = Visibility.Visible;
        }

        private void btnManagementFormats_Click(object sender, RoutedEventArgs e)
        {
            gbMovies.Visibility = gbPricing.Visibility = Visibility.Hidden;
            gbFormats.Visibility = Visibility.Visible;
        }

        private void btmManagementPricing_Click(object sender, RoutedEventArgs e)
        {
            gbMovies.Visibility = gbFormats.Visibility = Visibility.Hidden;
            gbPricing.Visibility = Visibility.Visible;
        }

        private void btnManagement_Click(object sender, RoutedEventArgs e)
        {
            if (!gridManagement.IsVisible)
            {
                gridHome.Visibility = Visibility.Hidden;
                btnNewCustomer.IsEnabled = false;

                gridManagement.Visibility = gbMovies.Visibility = Visibility.Visible;
                btnManagement.Content = "Home";
            }
            else
            {
                gridHome.Visibility = Visibility.Visible;
                btnNewCustomer.IsEnabled = true;

                gridManagement.Visibility = gbMovies.Visibility = gbFormats.Visibility = gbPricing.Visibility = Visibility.Hidden;
                btnManagement.Content = "Management";
            }
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            // Show About dialog
            wpfDlgAbout wpfAbout = new wpfDlgAbout();
            wpfAbout.ShowDialog();
            wpfAbout = null;
        }
    }
}
