#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Dialogs
{
    /// <summary>
    /// Interaction logic for AtomDemoWindow.xaml
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomDemoWindow : Window
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomDemoWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(AtomDemoWindow_Loaded);
        }

        void AtomDemoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = "UI Atoms - Version " + this.GetType().Assembly.GetName().Version.ToString();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private static AtomDemoWindow ADW = null;

        /// <summary>
        /// 
        /// </summary>
        public static void ShowDemo(bool force) 
        { 
#if DEMO
            System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate() {
                ShowDemoWindow(force);
            });
#endif
        }

        private static void ShowDemoWindow(bool force)
        {
            if (force)
                ADW = null;
            if (ADW == null) {
                ADW = new AtomDemoWindow();
                ADW.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                ADW.ShowDialog();
            }
        }

        private void hlDemo_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(hlDemo.NavigateUri.ToString());
        }
    }
}
