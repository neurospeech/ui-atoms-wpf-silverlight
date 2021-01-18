using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace UIAtomsDemo.Views.LayoutSamples
{
    public partial class ButtonSample : Page
    {
        public ButtonSample()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSubmit.VerificationMessage == "Are you sure?")
            {
                btnSubmit.Visibility = System.Windows.Visibility.Collapsed;
                txtbSubmit.Text = "Submitted";
            }
        }

    }
}
