#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Browser;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Browser;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NeuroSpeech.UIAtoms.Dialogs
{
    public partial class AtomDemoWindow : ChildWindow
    {
        public AtomDemoWindow()
        {
            InitializeComponent();

        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        private static AtomDemoWindow ADW = null;

        internal static void ShowDemo(bool force)
        {

            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            {

                if (force)
                {
                    ADW = null;
                }

                if (ADW == null)
                {
                    ADW = new AtomDemoWindow();
                    ADW.Show();
                }
            });

        }

        private void clickMe_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(new Uri("http://uiatoms.neurospeech.com/purchase"), "_blank");
        }
    }
}

