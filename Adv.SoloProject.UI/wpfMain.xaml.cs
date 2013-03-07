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
        public static CMediaItemDisplays _oMediaItemDisplays;
        wpfDlgMediaItems _wpfDlgMediaItems;
        CMediaItemPricings _oMediaItemPricings;
        CCreditCards _oCreditCards;
        CStateCodes _oStateCodes;
        CPaymentTypes _oPaymentTypes;
        CCreditCardTypes _oCreditCardTypes;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Populate Customers
                _oCustomers = new CCustomers();
                _oCustomers.Load();
                dgCustomers.ItemsSource = null;
                dgCustomers.ItemsSource = _oCustomers.Items;

                // Populate Media
                _oMedias = new CMedias();
                _oMedias.Load();

                // Populate Formats
                _oFormats = new CFormats();
                _oFormats.Load();

                // Populate MediaItemPricings
                _oMediaItemPricings = new CMediaItemPricings();
                _oMediaItemPricings.Load();

                // Populate MediaItems
                _oMediaItems = new CMediaItems();
                _oMediaItems.Load();
                _oMediaItemDisplays = new CMediaItemDisplays();
                _oMediaItemDisplays.Load();

                // Populate StateCodes
                _oStateCodes = new CStateCodes();
                _oStateCodes.Load();
                cbState.ItemsSource = _oStateCodes.Items;
                cbState.DisplayMemberPath = "Description";
                cbState.SelectedValuePath = "Code";

                // Populate PaymentTypes
                _oPaymentTypes = new CPaymentTypes();
                _oPaymentTypes.Load();
                cbRentalPaymentType.ItemsSource = _oPaymentTypes.Items;
                cbRentalPaymentType.DisplayMemberPath = "Description";
                cbRentalPaymentType.SelectedValuePath = "PaymentTypeId";

                // Populate CreditCardTypes
                _oCreditCardTypes = new CCreditCardTypes();
                _oCreditCardTypes.Load();
                cbRentalCardType.ItemsSource = _oCreditCardTypes.Items;
                cbRentalCardType.DisplayMemberPath = "Description";
                cbRentalCardType.SelectedValuePath = "CreditCardTypeId";

                gridManagement.Visibility = gridRental.Visibility = gridNewCustomer.Visibility = Visibility.Hidden;
                gridHome.Visibility = Visibility.Visible;

                lblStatus.Content = "Loaded";
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }

    // Menu Funcitons
        private void mnuExit_Click(object sender, RoutedEventArgs e) // File > Exit
        {
            Application.Current.Shutdown(0);
        }
        private void mnuAbout_Click(object sender, RoutedEventArgs e) // Help > About
        {
            wpfDlgAbout wpfAbout = new wpfDlgAbout();
            wpfAbout.ShowDialog();
            wpfAbout = null;
        }

        private void dgCustomers_Loaded(object sender, RoutedEventArgs e)
        {
            // Hide primary key fields
            dgCustomers.Columns[0].Visibility = Visibility.Hidden;
            dgCustomers.Columns[11].Visibility = Visibility.Hidden;

            // Format birth dates
            DataGridTextColumn dgTc = dgCustomers.Columns[10] as DataGridTextColumn;
            dgTc.Binding.StringFormat = "{0:dd/MM/yyy}";
        }

        private void btnSelectCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgCustomers.SelectedIndex != -1)
                {
                    gridHome.Visibility = Visibility.Hidden;
                    btnManagement.IsEnabled = btnNewCustomer.IsEnabled = false;

                    gridRental.Visibility = Visibility.Visible;

                    txtRentalAccount.Text = _oCustomers[dgCustomers.SelectedIndex].AccountNumber;
                    _oCreditCards = new CCreditCards();
                    _oCreditCards.LoadAccount(txtRentalAccount.Text);
                    cbRentalCreditCard.ItemsSource = _oCreditCards.Items;
                    cbRentalCreditCard.DisplayMemberPath = "CardNumber";
                    cbRentalCreditCard.SelectedValuePath = "CreditCardId";
                }
                else
                    MessageBox.Show("You must select a customer to continue.", "Notice", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
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
                
              //oCustomer.CustomerId = 0; // not used
                oCustomer.AccountNumber = txtFirstName.Text.Substring(0, 1) + txtLastName.Text.Substring(0, 1) + txtZipCode.Text.Substring(txtZipCode.Text.Length - 2, 2);
                oCustomer.FirstName = txtFirstName.Text;
                oCustomer.LastName = txtLastName.Text;
                oCustomer.Address = txtAddress.Text;
                oCustomer.City = txtCity.Text;
                oCustomer.State = (string)cbState.SelectedValue;
                oCustomer.Zip = txtZipCode.Text;
                oCustomer.Phone = txtPhoneNumber.Text;
                oCustomer.Email = txtEmailAddress.Text;
                oCustomer.DateOfBirth = (DateTime)dpDOB.SelectedDate;
                oCustomer.CustomerStatusId = 0;

                oCustomer.Insert();
                _oCustomers.Add(oCustomer);

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

            // Release credit card information
            cbRentalCreditCard.ItemsSource = null;
            cbRentalCreditCard.Items.Clear();
            _oCreditCards = null;
            txtRentalCardholder.Text = txtRentalCardNumber.Text = string.Empty;
        }

        private void btnRentalFinish_Click(object sender, RoutedEventArgs e)
        {
            gridRental.Visibility = Visibility.Hidden;

            gridHome.Visibility = Visibility.Visible;
            btnManagement.IsEnabled = btnNewCustomer.IsEnabled = true;
        }

        private void btnMovieLookup_Click(object sender, RoutedEventArgs e)
        {
            _wpfDlgMediaItems = new wpfDlgMediaItems();
            _wpfDlgMediaItems.ShowDialog();
        }

        private void btnRentalReturn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnManagement_Click(object sender, RoutedEventArgs e)
        {
            if (!gridManagement.IsVisible)
            {
                gridHome.Visibility = Visibility.Hidden;
                btnNewCustomer.IsEnabled = false;

                gridManagement.Visibility = Visibility.Visible;
                btnManagement.Content = "Home";

                // Load default page
                btnManagementMovies_Click(sender, e);
            }
            else
            {
                gridHome.Visibility = Visibility.Visible;
                btnNewCustomer.IsEnabled = true;

                gridManagement.Visibility = gbMovies.Visibility = gbFormats.Visibility = gbPricing.Visibility = Visibility.Hidden;
                btnManagement.Content = "Management";
            }
        }

        private void dgManagement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgManagement.SelectedIndex != -1)
            {
                if (gbMovies.IsVisible)
                {
                    txtManagementMovieId.Text = _oMedias[dgManagement.SelectedIndex].MediaId.ToString();
                    txtManagementMovieTitle.Text = _oMedias[dgManagement.SelectedIndex].Title;
                    dpManagementMovieReleaseDate.SelectedDate = _oMedias[dgManagement.SelectedIndex].ReleaseDate;
                    btnManagementMovieNew.Content = "Update";
                }
                else if (gbFormats.IsVisible)
                {
                    txtManagementFormatId.Text = _oFormats[dgManagement.SelectedIndex].FormatId.ToString();
                    txtManagementFormatDescription.Text = _oFormats[dgManagement.SelectedIndex].Description;
                    btnManagementFormatNew.Content = "Update";
                }
                else if (gbPricing.IsVisible)
                {
                    txtManagementPricingId.Text = _oMediaItemPricings[dgManagement.SelectedIndex].MediaItemPricingId.ToString();
                    txtManagementPricingDescription.Text = _oMediaItemPricings[dgManagement.SelectedIndex].Description;
                    txtManagementPricingPrice.Text = _oMediaItemPricings[dgManagement.SelectedIndex].Price.ToString();
                    txtManagementPricingLength.Text = _oMediaItemPricings[dgManagement.SelectedIndex].Length.ToString();
                    btnManagementPricingNew.Content = "Update";
                }
            }
        }

    // Management - Media Item Buttons
        private void btnManagementMovieManageCopies_Click(object sender, RoutedEventArgs e) // Select Media Item Management
        {

        }

        #region "Management - Movie Buttons"
    // Management - Movie Buttons
        private void btnManagementMovies_Click(object sender, RoutedEventArgs e) // Select Movies
        {
            gbFormats.Visibility = gbPricing.Visibility = Visibility.Hidden;
            gbMovies.Visibility = Visibility.Visible;
            btnManagementMovieNew.Content = "Add";

            // Set Media list as active
            dgManagement.ItemsSource = null;
            dgManagement.ItemsSource = _oMedias.Items;

            // Hide primary key fields
            dgManagement.Columns[0].Visibility = Visibility.Hidden;

            // Format release dates
            DataGridTextColumn dgTc = dgManagement.Columns[1] as DataGridTextColumn;
            dgTc.Binding.StringFormat = "{0:dd/MM/yyy}";
        }
        private void btnManagementMovieNew_Click(object sender, RoutedEventArgs e)  // Add/Update Movie
        {
            try
            {
                if ((string)btnManagementMovieNew.Content == "Add")
                {
                    // FIXME: Check for duplicates
                    CMedia oMedia = new CMedia();

                    //oMedia.MediaId = 0; // Not Used
                    oMedia.ReleaseDate = (DateTime)dpManagementMovieReleaseDate.SelectedDate;
                    oMedia.Title = txtManagementMovieTitle.Text;

                    oMedia.Insert();
                    _oMedias.Add(oMedia);

                    lblStatus.Content = "Record sucessfully added.";
                }
                else if ((string)btnManagementMovieNew.Content == "Update")
                {
                    if (_oMedias[dgManagement.SelectedIndex].MediaId.ToString() == txtManagementMovieId.Text)
                    {
                        _oMedias[dgManagement.SelectedIndex].ReleaseDate = (DateTime)dpManagementMovieReleaseDate.SelectedDate;
                        _oMedias[dgManagement.SelectedIndex].Title = txtManagementMovieTitle.Text;

                        _oMedias[dgManagement.SelectedIndex].Update();

                        lblStatus.Content = "Record successfully updated.";
                    }
                    else
                        throw new Exception("MediaId does not match, Update failed.");
                }

                // Call Movies initialization button (Handles formatting of DataGrid)
                btnManagementMovies_Click(sender, e);

                // Clear the form
                btnManagementMovieClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementMovieDelete_Click(object sender, RoutedEventArgs e) // Delete Movie
        {
            try
            {
                _oMedias[dgManagement.SelectedIndex].Delete();
                _oMedias.RemoveAt(dgManagement.SelectedIndex);

                lblStatus.Content = "Record sucessfully deleted.";

                // Call Movies initialization button (Handles formatting of DataGrid)
                btnManagementMovies_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementMovieClear_Click(object sender, RoutedEventArgs e) // Clear Movie Fields
        {
            txtManagementMovieId.Text = string.Empty;
            txtManagementMovieTitle.Text = string.Empty;
            txtManagementMovieCopies.Text = string.Empty;
            dpManagementMovieReleaseDate.SelectedDate = DateTime.Now;
            dgManagement.SelectedIndex = -1;
            btnManagementMovieNew.Content = "Add";
        }
        #endregion

        #region "Management - Format Buttons"
    // Management - Format Buttons
        private void btnManagementFormats_Click(object sender, RoutedEventArgs e) // Select Format
        {
            gbMovies.Visibility = gbPricing.Visibility = Visibility.Hidden;
            gbFormats.Visibility = Visibility.Visible;
            btnManagementFormatNew.Content = "Add";

            // Set Format list as active
            dgManagement.ItemsSource = null;
            dgManagement.ItemsSource = _oFormats.Items;

            // Hide primary key fields
            dgManagement.Columns[0].Visibility = Visibility.Hidden;
        }
        private void btnManagementFormatNew_Click(object sender, RoutedEventArgs e) // Add/Update Format
        {
            try
            {
                if ((string)btnManagementFormatNew.Content == "Add")
                {
                    CFormat oFormat = new CFormat();

                    //oFormat.FormatId = 0; // not used
                    oFormat.Description = txtManagementFormatDescription.Text;

                    oFormat.Insert();
                    _oFormats.Add(oFormat);

                    lblStatus.Content = "Record successfully added.";
                }
                else if ((string)btnManagementFormatNew.Content == "Update")
                {
                    if (_oFormats[dgManagement.SelectedIndex].FormatId.ToString() == txtManagementFormatId.Text)
                    {
                        _oFormats[dgManagement.SelectedIndex].Description = txtManagementFormatDescription.Text;

                        _oFormats[dgManagement.SelectedIndex].Update();

                        lblStatus.Content = "Record successfully updated.";
                    }
                    else
                        throw new Exception("FormatId does not match, Update failed.");
                }

                // Call Format initialization button (Handles formatting of DataGrid)
                btnManagementFormats_Click(sender, e);

                // Clear the form
                btnManagementFormatClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementFormatDelete_Click(object sender, RoutedEventArgs e) // Delete Format
        {
            try
            {
                _oFormats[dgManagement.SelectedIndex].Delete();
                _oFormats.RemoveAt(dgManagement.SelectedIndex);

                lblStatus.Content = "Record sucessfully deleted.";

                // Call Format initialization button (Handles formatting of DataGrid)
                btnManagementFormats_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementFormatClear_Click(object sender, RoutedEventArgs e) // Clear Format Fields
        {
            txtManagementFormatId.Text = string.Empty;
            txtManagementFormatDescription.Text = string.Empty;
            dgManagement.SelectedIndex = -1;
            btnManagementFormatNew.Content = "Add";
        }
        #endregion

        #region "Management - Pricing Buttons"
    // Management - Pricing Buttons
        private void btnManagementPricing_Click(object sender, RoutedEventArgs e) // Select Pricing
        {
            gbMovies.Visibility = gbFormats.Visibility = Visibility.Hidden;
            gbPricing.Visibility = Visibility.Visible;
            btnManagementPricingNew.Content = "Add";

            // Set Pricing list as active
            dgManagement.ItemsSource = null;
            dgManagement.ItemsSource = _oMediaItemPricings.Items;

            // Hide primary key fields
            dgManagement.Columns[0].Visibility = Visibility.Hidden;
        }
        private void btnManagementPricingNew_Click(object sender, RoutedEventArgs e) // Add/Update Pricing
        {
            try
            {
                if ((string)btnManagementPricingNew.Content == "Add")
                {
                    CMediaItemPricing oMediaItemPricing = new CMediaItemPricing();

                    //oMediaItemPricing.MediaItemPricingId = 0; // not used
                    oMediaItemPricing.Description = txtManagementPricingDescription.Text;
                    oMediaItemPricing.Price = decimal.Parse(txtManagementPricingPrice.Text);
                    oMediaItemPricing.Length = int.Parse(txtManagementPricingLength.Text);

                    oMediaItemPricing.Insert();
                    _oMediaItemPricings.Add(oMediaItemPricing);

                    lblStatus.Content = "Record successfully added.";
                }
                else if ((string)btnManagementPricingNew.Content == "Update")
                {
                    if (_oMediaItemPricings[dgManagement.SelectedIndex].MediaItemPricingId.ToString() == txtManagementPricingId.Text)
                    {
                        _oMediaItemPricings[dgManagement.SelectedIndex].Description = txtManagementPricingDescription.Text;
                        _oMediaItemPricings[dgManagement.SelectedIndex].Price = decimal.Parse(txtManagementPricingPrice.Text);
                        _oMediaItemPricings[dgManagement.SelectedIndex].Length = int.Parse(txtManagementPricingLength.Text);

                        _oMediaItemPricings[dgManagement.SelectedIndex].Update();

                        lblStatus.Content = "Record successfully updated.";
                    }
                    else
                        throw new Exception("PricingId does not match, Update failed.");
                }

                // Call Pricing initialization button (Handles formating of DataGrid)
                btnManagementPricing_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementPricingDelete_Click(object sender, RoutedEventArgs e) // Delete Pricing
        {
            try
            {
                _oMediaItemPricings[dgManagement.SelectedIndex].Delete();
                _oMediaItemPricings.RemoveAt(dgManagement.SelectedIndex);

                lblStatus.Content = "Record sucessfully deleted.";

                // Call Pricing initialization button (Handles formating of DataGrid)
                btnManagementPricing_Click(sender, e);

                // Clear the form
                btnManagementPricingClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                lblStatus.Content = "Error: " + ex.Message;
            }
        }
        private void btnManagementPricingClear_Click(object sender, RoutedEventArgs e) // Clear Pricing Fields
        {
            txtManagementPricingId.Text = string.Empty;
            txtManagementPricingDescription.Text = string.Empty;
            txtManagementPricingPrice.Text = string.Empty;
            txtManagementPricingLength.Text = string.Empty;
            dgManagement.SelectedIndex = -1;
            btnManagementPricingNew.Content = "Add";
        }
        #endregion

        private void cbRentalPaymentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_oPaymentTypes[cbRentalPaymentType.SelectedIndex].Description == "Credit")
            {
                gridCreditCard.IsEnabled = true;
            }
            else
                gridCreditCard.IsEnabled = false;
        }

        private void cbRentalCreditCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtRentalCardNumber.Text = _oCreditCards[cbRentalCreditCard.SelectedIndex].CardNumber;
            txtRentalCardholder.Text = _oCreditCards[cbRentalCreditCard.SelectedIndex].CardName;
            cbRentalCardType.SelectedValue = _oCreditCards[cbRentalCreditCard.SelectedIndex].CreditCardTypeId;
        }
    }
}
