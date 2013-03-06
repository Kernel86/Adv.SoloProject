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

using Adv.SoloProject.Business;

namespace Adv.SoloProject.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CCustomers _oCustomers;
        CMedias _oMedias;
        CFormats _oFormats;
        CMediaItems _oMediaItems;
        CMediaItemPricings _oMediaItemPricings;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _oCustomers = new CCustomers();
                _oCustomers.Load();

                dgCustomers.ItemsSource = null;
                dgCustomers.ItemsSource = _oCustomers.Items;

                _oMedias = new CMedias();
                _oMedias.Load();

                gridManagement.Visibility = gridRental.Visibility = gridNewCustomer.Visibility = Visibility.Hidden;
                gridHome.Visibility = Visibility.Visible;

                lblStatus.Content = "Loaded";
            }
            catch (Exception ex)
            {
                lblStatus.Content = ex.Message;
            }
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

        // Create new customer
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            gridNewCustomer.Visibility = Visibility.Hidden;
            btnNewCustomer.IsEnabled = btnManagement.IsEnabled = true;

            gridHome.Visibility = Visibility.Visible;

            // Register new customer with the system
            try
            {
                CCustomer oCustomer = new CCustomer();
                
              //oCustomer.CustomerId = 0;
                oCustomer.AccountNumber = txtFirstName.Text.Substring(0, 1) + txtLastName.Text.Substring(0, 1) + txtZipCode.Text.Substring(txtZipCode.Text.Length - 2, 2);
                oCustomer.FirstName = txtFirstName.Text;
                oCustomer.LastName = txtLastName.Text;
                oCustomer.Address = txtAddress.Text;
                oCustomer.City = txtCity.Text;
              //oCustomer.State = cbState.SelectedIndex;
                oCustomer.State = "UN";
                oCustomer.Zip = txtZipCode.Text;
                oCustomer.Phone = txtPhoneNumber.Text;
                oCustomer.Email = txtEmailAddress.Text;
                oCustomer.DateOfBirth = (DateTime)dpDOB.SelectedDate;
                oCustomer.CustomerStatusId = 0;

                oCustomer.Insert();
                _oCustomers.Add(oCustomer);
                //oCustomer = null;

                dgCustomers.ItemsSource = null;
                dgCustomers.ItemsSource = _oCustomers.Items;
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
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

            dgManagement.ItemsSource = null;
            dgManagement.ItemsSource = _oMedias.Items;
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

                dgManagement.ItemsSource = null;
                dgManagement.ItemsSource = _oMedias.Items;
            }
            else
            {
                gridHome.Visibility = Visibility.Visible;
                btnNewCustomer.IsEnabled = true;

                gridManagement.Visibility = gbMovies.Visibility = gbFormats.Visibility = gbPricing.Visibility = Visibility.Hidden;
                btnManagement.Content = "Management";
            }
        }

        // Show About dialog
        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            wpfDlgAbout wpfAbout = new wpfDlgAbout();
            wpfAbout.ShowDialog();
            wpfAbout = null;
        }

        // Create new movie
        private void btnManagementMoveNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CMedia oMedia = new CMedia();

                //oMedia.MediaId = 0;
                oMedia.ReleaseDate = (DateTime)dpManagementMovieReleaseDate.SelectedDate;
                oMedia.Title = txtManagementMovieTitle.Text;

                oMedia.Insert();
                _oMedias.Add(oMedia);

                dgManagement.ItemsSource = null;
                dgManagement.ItemsSource = _oMedias.Items;
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }

        // Delete a movie
        private void btnManagementMovieDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _oMedias[dgManagement.SelectedIndex].Delete();
                _oMedias.RemoveAt(dgManagement.SelectedIndex);

                dgManagement.ItemsSource = null; 
                dgManagement.ItemsSource = _oMedias.Items;
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }

        private void dgCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            dgCustomers.Columns[0].Visibility = Visibility.Hidden;
            dgCustomers.Columns[11].Visibility = Visibility.Hidden;

            // Format birth dates
            DataGridTextColumn dgTc = dgCustomers.Columns[10] as DataGridTextColumn;
            dgTc.Binding.StringFormat = "{0:dd/MM/yyy}";
        }
    }
}
