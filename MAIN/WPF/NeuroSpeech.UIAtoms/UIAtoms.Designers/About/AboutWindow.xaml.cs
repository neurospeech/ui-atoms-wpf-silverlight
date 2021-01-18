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
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Design.About
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();
        }

        public static void ShowAboutDialog(bool isDemo) {
            AboutWindow aw = new AboutWindow();
            aw.IsDemo = isDemo;
            aw.ShowDialog();
        }

        private bool IsDemo = false;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsDemo)
            {
                licenseType.Text = "Unlicensed (Demo)";
                licenseType.Foreground = Brushes.Red;
            }
            else
            {
                licenseType.Text = "Registered";
                buyNowButton.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void buyNowButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("http://go.neurospeech.com/12");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
