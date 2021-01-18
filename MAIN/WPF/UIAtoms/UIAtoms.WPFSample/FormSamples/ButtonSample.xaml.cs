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

namespace UIAtoms.WPFSamples.BasicSamples
{
    /// <summary>
    /// Interaction logic for ButonSample.xaml
    /// </summary>
    public partial class ButonSample : Page
    {
        public ButonSample()
        {
            InitializeComponent();
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSubmit.VerificationMessage == "Are you sure?")
            {
                btnSubmit.Visibility = System.Windows.Visibility.Hidden;
                txtbSubmit.Text = "Submitted";
            }
        }

    }
}
