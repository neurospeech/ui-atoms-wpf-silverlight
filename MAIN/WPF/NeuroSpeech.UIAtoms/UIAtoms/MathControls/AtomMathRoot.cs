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
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.Xml.Serialization;

namespace NeuroSpeech.UIAtoms.MathControls
{
    /// <summary>
    /// </summary>
    
    [XmlAlias("rt")]
    public class AtomMathRoot : ContentControl
    {

#if SILVERLIGHT
        public AtomMathRoot()
        {
            DefaultStyleKey = typeof(AtomMathRoot);
        }
#else
        static AtomMathRoot()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMathRoot), new FrameworkPropertyMetadata(typeof(AtomMathRoot)));
        }
#endif



        ///<summary>
        ///DependencyProperty Power
        ///</summary>
        #region Dependency Property Power
        [XmlAttribute("p")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Power
        {
            get { return (object)GetValue(PowerProperty); }
            set { SetValue(PowerProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Power.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty PowerProperty = 
    DependencyProperty.Register("Power", typeof(object), typeof(AtomMathRoot), new PropertyMetadata(null,OnPowerChangedCallback));
#else
        public static readonly DependencyProperty PowerProperty =
            DependencyProperty.Register("Power", typeof(object), typeof(AtomMathRoot), new FrameworkPropertyMetadata(null, OnPowerChangedCallback));
#endif

        private static void OnPowerChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomMathRoot obj = d as AtomMathRoot;
            if (obj != null)
            {
                obj.OnPowerChanged(e);
            }
        }

        /// <summary>
        /// Fires PowerChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPowerChanged(DependencyPropertyChangedEventArgs e)
        {
            if (PowerChanged != null)
            {
                PowerChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler PowerChanged;

        #endregion



    }
}
