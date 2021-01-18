#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Threading;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /*
    /// <summary>
    /// </summary>
    public class AtomBusyIndicator : Control
    {
        static AtomBusyIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomBusyIndicator), new FrameworkPropertyMetadata(typeof(AtomBusyIndicator)));
        }

        private Border PART_Border;
        private RotateTransform RT;

        private UIElement errorIndicator;
        private UIElement successIndicator;
        private UIElement busyIndicator;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Border = (Border)GetTemplateChild("PART_Border");
            errorIndicator = (UIElement)GetTemplateChild("errorIndicator");
            busyIndicator = (UIElement)GetTemplateChild("busyIndicator");
            successIndicator = (UIElement)GetTemplateChild("successIndicator");

            errorIndicator.Visibility = System.Windows.Visibility.Collapsed;
            busyIndicator.Visibility = System.Windows.Visibility.Collapsed;
            successIndicator.Visibility = System.Windows.Visibility.Collapsed;

            RT = new RotateTransform();
            PART_Border.RenderTransform = RT;
        }



        private DispatcherTimer Timer;

        /// <summary>
        /// Starts spinning animation, you can call this from other thread
        /// </summary>
        public void StartAnimation()
        {
            Dispatcher.BeginInvoke(
                (Action)delegate()
            {
                if (Timer != null)
                    throw new InvalidOperationException("Animation is already running");

                ToolTip = null;

                if (busyIndicator != null)
                {
                    Show(true, false, false);
                }

                Timer = new DispatcherTimer();
                Timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                Timer.Tick += new EventHandler(Timer_Tick);
                Timer.Start();
            });
        }

        private void Show(bool busy, bool success, bool error)
        {
            if (busyIndicator != null)
            {
                busyIndicator.Visibility = busy ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
            if (successIndicator != null)
            {
                successIndicator.Visibility = success ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
            if (errorIndicator != null)
            {
                errorIndicator.Visibility = error ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            RT.Angle += 10;
            
        }

        /// <summary>
        /// Stops animation and indicates failure or success.., you can call this from other thread
        /// </summary>
        /// <param name="success"></param>
        /// <param name="errorMessage">Message displayed on Tooltip if failed</param>
        public void StopAnimation(bool success, string errorMessage)
        {

            Dispatcher.BeginInvoke(
                (Action)delegate()
            {
                Timer.Stop();
                Timer.Tick -= new EventHandler(Timer_Tick);
                Timer = null;

                RT.Angle = 0;
                bool show = ShowResult;
                if (success)
                {
                    Show(false, success, !success);
                }
                else
                {

                    Show(false, false, false);

                    this.ToolTip = errorMessage;
                }
            });
        }


        ///<summary>
        /// Dependency Property ShowResult
        ///</summary>
        #region Dependency Property ShowResult
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public bool ShowResult
        {
            get { return (bool)GetValue(ShowResultProperty); }
            set { SetValue(ShowResultProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ShowResult.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ShowResultProperty = 
            DependencyProperty.Register("ShowResult", typeof(bool), typeof(AtomBusyIndicator), new PropertyMetadata(true));
#else
        public static readonly DependencyProperty ShowResultProperty =
            DependencyProperty.Register("ShowResult", typeof(bool), typeof(AtomBusyIndicator), new FrameworkPropertyMetadata(true));
#endif

        #endregion
        

    }*/
}
