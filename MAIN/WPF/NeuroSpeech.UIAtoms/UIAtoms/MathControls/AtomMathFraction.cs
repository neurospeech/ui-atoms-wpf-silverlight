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
    [XmlAlias("f")]
    public class AtomMathFraction : ContentControl
    {

#if SILVERLIGHT
        public AtomMathFraction()
        {
            DefaultStyleKey = typeof(AtomMathFraction);
        }
#else
        static AtomMathFraction()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMathFraction), new FrameworkPropertyMetadata(typeof(AtomMathFraction)));
        }
#endif



        ///<summary>
        ///DependencyProperty Denominator
        ///</summary>
        #region Dependency Property Denominator
        [XmlAttribute("d")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Denominator
        {
            get { return (object)GetValue(DenominatorProperty); }
            set { SetValue(DenominatorProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Denominator.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty DenominatorProperty = 
    DependencyProperty.Register("Denominator", typeof(object), typeof(AtomMathFraction), new PropertyMetadata(null,OnDenominatorChangedCallback));
#else
        public static readonly DependencyProperty DenominatorProperty =
            DependencyProperty.Register("Denominator", typeof(object), typeof(AtomMathFraction), new FrameworkPropertyMetadata(null, OnDenominatorChangedCallback));
#endif

        private static void OnDenominatorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomMathFraction obj = d as AtomMathFraction;
            if (obj != null)
            {
                obj.OnDenominatorChanged(e);
            }
        }

        /// <summary>
        /// Fires DenominatorChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDenominatorChanged(DependencyPropertyChangedEventArgs e)
        {
            if (DenominatorChanged != null)
            {
                DenominatorChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler DenominatorChanged;

        #endregion



    }
}
