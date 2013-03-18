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
using System.Windows.Shapes;

namespace Adv.SoloProject.UI
{
    /// <summary>
    /// Interaction logic for wpfDlgMediaItems.xaml
    /// </summary>
    public partial class wpfDlgMediaItems : Window
    {
        public wpfDlgMediaItems()
        {
            InitializeComponent();

            dpMovieInventoryDate.SelectedDate = DateTime.Now;
        }

        private void dgMediaItems_Loaded(object sender, RoutedEventArgs e)
        {

            dgMediaItems.ItemsSource = null;
            dgMediaItems.ItemsSource = MainWindow._oMediaItemDisplays.Items;
            
            // Hide primary key fields
            dgMediaItems.Columns[0].Visibility = Visibility.Hidden;
            dgMediaItems.Columns[1].Visibility = Visibility.Hidden;

            // Format dates
            DataGridTextColumn dgTc;
            dgTc = dgMediaItems.Columns[4] as DataGridTextColumn;
            dgTc.Binding.StringFormat = "{0:dd/MM/yyy}";
            dgTc = null;
            dgTc = dgMediaItems.Columns[6] as DataGridTextColumn;
            dgTc.Binding.StringFormat = "{0:dd/MM/yyy}";
            dgTc = null;
        }

        private void btnMovieItemCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMovieItemRental_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMovieItemAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMovieItemClear_Click(object sender, RoutedEventArgs e)
        {
            cbMovies.SelectedIndex = -1;
            txtMovieTitle.Text = string.Empty;
            dpMovieReleaseDate.SelectedDate = DateTime.Now;
            txtMovieBarcode.Text = string.Empty;
            dpMovieInventoryDate.SelectedDate = DateTime.Now;
            cbMovieItemState.SelectedIndex = 0;
            cbMoviePricing.SelectedIndex = 0;
            cbMovieFormat.SelectedIndex = 0;
        }

        private void btnMovieItemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MainWindow._oMedias[MainWindow._oMediaItemDisplays[dgMediaItems.SelectedIndex].MediaItemId].Delete();
                //MainWindow._oMediaItemDisplays.RemoveAt(dgMediaItems.SelectedIndex);
                //MainWindow._oMedias.RemoveAt(dgMediaItems.SelectedIndex);

                //lblStatus.Content = "Record sucessfully deleted.";

                // Call initialization method (Handles formatting of DataGrid)
                dgMediaItems_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                //lblStatus.Content = "Error: " + ex.Message;
            }
        }

        private void cbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtMovieTitle.Text = MainWindow._oMedias[cbMovies.SelectedIndex].Title;
            dpMovieReleaseDate.SelectedDate = MainWindow._oMedias[cbMovies.SelectedIndex].ReleaseDate;
        }
    }
}
