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
    [XmlAlias("e")]
    public class AtomMathExp : ContentControl
    {
#if SILVERLIGHT
        public AtomMathExp()
        {
            DefaultStyleKey = typeof(AtomMathExp);
        }
#else
        static AtomMathExp()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMathExp), new FrameworkPropertyMetadata(typeof(AtomMathExp)));
        }
#endif




        ///<summary>
        /// Dependency Property TopLeft
        ///</summary>
        #region Dependency Property TopLeft
        [XmlAttribute("tl")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object TopLeft
        {
            get { return (object)GetValue(TopLeftProperty); }
            set { SetValue(TopLeftProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for TopLeft.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty TopLeftProperty = 
    DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMathExp), new PropertyMetadata(null, OnTopLeftChangedCallback));
    
private static void OnTopLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathExp obj = d as AtomMathExp;
}
    
#else
        public static readonly DependencyProperty TopLeftProperty =
            DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMathExp), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        ///<summary>
        /// Dependency Property TopRight
        ///</summary>
        #region Dependency Property TopRight
        [XmlAttribute("tr")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object TopRight
        {
            get { return (object)GetValue(TopRightProperty); }
            set { SetValue(TopRightProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for TopRight.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty TopRightProperty = 
    DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMathExp), new PropertyMetadata(null, OnTopRightChangedCallback));
    
private static void OnTopRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathExp obj = d as AtomMathExp;
}
    
#else
        public static readonly DependencyProperty TopRightProperty =
            DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMathExp), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property BottomLeft
        ///</summary>
        #region Dependency Property BottomLeft
        [XmlAttribute("bl")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object BottomLeft
        {
            get { return (object)GetValue(BottomLeftProperty); }
            set { SetValue(BottomLeftProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for BottomLeft.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty BottomLeftProperty = 
    DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMathExp), new PropertyMetadata(null, OnBottomLeftChangedCallback));
    
private static void OnBottomLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathExp obj = d as AtomMathExp;
}
    
#else
        public static readonly DependencyProperty BottomLeftProperty =
            DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMathExp), new FrameworkPropertyMetadata(null));
#endif

        #endregion






        ///<summary>
        /// Dependency Property BottomRight
        ///</summary>
        #region Dependency Property BottomRight
        [XmlAttribute("br")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object BottomRight
        {
            get { return (object)GetValue(BottomRightProperty); }
            set { SetValue(BottomRightProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for BottomRight.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty BottomRightProperty = 
    DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMathExp), new PropertyMetadata(null, OnBottomRightChangedCallback));
    
private static void OnBottomRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathExp obj = d as AtomMathExp;
}
    
#else
        public static readonly DependencyProperty BottomRightProperty =
            DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMathExp), new FrameworkPropertyMetadata(null));
#endif

        #endregion











        

    }
}
