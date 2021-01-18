using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UIAtomsDemo.Common
{
    public class LocalFrame : Frame
    {


        #region Dependency Property UrlSource
        ///<summary>
        ///
        ///</summary>
        [System.ComponentModel.Category("Category")]
        public string UrlSource
        {
            get { return (string)GetValue(UrlSourceProperty); }
            set { SetValue(UrlSourceProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
        public static readonly DependencyProperty UrlSourceProperty =
            DependencyProperty.Register("UrlSource", typeof(string), typeof(LocalFrame), new PropertyMetadata("", new PropertyChangedCallback(UrlSourceChangedCallback)));

        public event DependencyPropertyChangedEventHandler UrlSourceChanged;

        protected void OnUrlSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            string url = e.NewValue as string;

            if (string.IsNullOrEmpty(url))
            {
                this.Source = new Uri("/Views/BlankPage.xaml", UriKind.Relative);
            }
            else
            {
                this.Source = new Uri(url, UriKind.Relative);
            }
            if (this.UrlSourceChanged != null)
            {
                this.UrlSourceChanged(this, e);
            }
        }

        private static void UrlSourceChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            LocalFrame obj = sender as LocalFrame;
            obj.OnUrlSourceChanged(e);
        }

        #endregion



    }
}
