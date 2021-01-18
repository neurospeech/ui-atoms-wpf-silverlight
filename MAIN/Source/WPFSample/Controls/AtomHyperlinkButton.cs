using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace UIAtoms.WPFSamples.Controls
{
    public class AtomHyperlinkButton : Button
    {


        ///<summary>
        /// Dependency Property NavigateUri
        ///</summary>
        #region Dependency Property NavigateUri
        public Uri NavigateUri
        {
            get { return (Uri)GetValue(NavigateUriProperty); }
            set { SetValue(NavigateUriProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for NavigateUri.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty NavigateUriProperty = 
            DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(AtomHyperlinkButton), new PropertyMetadata(null, OnNavigateUriChangedCallback));
            
        private static void OnNavigateUriChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
          AtomHyperlinkButton obj = d as AtomHyperlinkButton;
        }
    
#else
        public static readonly DependencyProperty NavigateUriProperty =
            DependencyProperty.Register("NavigateUri", typeof(Uri), typeof(AtomHyperlinkButton), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        protected override void OnClick()
        {
            base.OnClick();

            Uri uri = NavigateUri;
            if (uri != null) {
                Process.Start(uri.ToString());
            }

        }


    }
}
