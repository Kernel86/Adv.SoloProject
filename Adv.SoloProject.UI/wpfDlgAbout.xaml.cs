/*************************
 * [wpfDlgAbout.xaml.cs]
 * Advanced Programming
 * Shawn Novak
 * 2013-02-21
 *************************/

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
    /// Interaction logic for wpfDlgAbout.xaml
    /// </summary>
    public partial class wpfDlgAbout : Window
    {
        public wpfDlgAbout()
        {
            InitializeComponent();

            // Set assignment information
            lblAssignment.Text = "Advanced Programming - Solo Project - Media Vault";
            lblDate.Text = "2013-02-21";
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
