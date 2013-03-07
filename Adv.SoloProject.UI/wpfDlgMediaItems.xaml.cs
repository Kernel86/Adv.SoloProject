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
    }
}
