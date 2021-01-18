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
using System.Windows.Threading;

namespace UIAtomsDemo.Views
{
    public partial class PreviewPage : Page
    {
        public PreviewPage()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
            this.Loaded += new RoutedEventHandler(PreviewPage_Loaded);
        }

        #region void  PreviewPage_Loaded(object sender, RoutedEventArgs e)
        void PreviewPage_Loaded(object sender, RoutedEventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 10);
            Timer.Start();
        }
        #endregion


        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        #region void  Timer_Tick(object sender, EventArgs e)
        void Timer_Tick(object sender, EventArgs e)
        {
            FlipStart.Begin();
        }
        #endregion


        private DispatcherTimer Timer = null;

        private void FlipStart_Completed(object sender, EventArgs e)
        {
            if (list.Children.Count == 0)
                return;
            if (list.SelectedIndex < list.Children.Count - 1)
                list.SelectedIndex++;
            else
                list.SelectedIndex = 0;
            FlipEnd.Begin();
        }

    }
}
