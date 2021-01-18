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
using System.Xml.Serialization;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.MathControls
{
    /// <summary>
    /// </summary>
    [XmlAlias("sym")]
    public class AtomMathSymbol : ContentControl
    {

#if SILVERLIGHT
        public AtomMathSymbol()
        {
            DefaultStyleKey = typeof(AtomMathSymbol);
        }
#else
        static AtomMathSymbol()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMathSymbol), new FrameworkPropertyMetadata(typeof(AtomMathSymbol)));
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
    DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMathSymbol), new PropertyMetadata(null, OnTopLeftChangedCallback));
    
private static void OnTopLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathSymbol obj = d as AtomMathSymbol;
}
    
#else
        public static readonly DependencyProperty TopLeftProperty =
            DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMathSymbol), new FrameworkPropertyMetadata(null));
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
    DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMathSymbol), new PropertyMetadata(null, OnTopRightChangedCallback));
    
private static void OnTopRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathSymbol obj = d as AtomMathSymbol;
}
    
#else
        public static readonly DependencyProperty TopRightProperty =
            DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMathSymbol), new FrameworkPropertyMetadata(null));
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
    DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMathSymbol), new PropertyMetadata(null, OnBottomLeftChangedCallback));
    
private static void OnBottomLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathSymbol obj = d as AtomMathSymbol;
}
    
#else
        public static readonly DependencyProperty BottomLeftProperty =
            DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMathSymbol), new FrameworkPropertyMetadata(null));
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
    DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMathSymbol), new PropertyMetadata(null, OnBottomRightChangedCallback));
    
private static void OnBottomRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathSymbol obj = d as AtomMathSymbol;
}
    
#else
        public static readonly DependencyProperty BottomRightProperty =
            DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMathSymbol), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property Symbol
        ///</summary>
        #region Dependency Property Symbol
        [XmlAttribute("s")]
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public DataTemplate Symbol
        {
            get { return (DataTemplate)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty SymbolProperty = 
    DependencyProperty.Register("Symbol", typeof(DataTemplate), typeof(AtomMathSymbol), new PropertyMetadata(null, OnSymbolChangedCallback));
    
private static void OnSymbolChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMathSymbol obj = d as AtomMathSymbol;
}
    
#else
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(DataTemplate), typeof(AtomMathSymbol), new FrameworkPropertyMetadata(null));
#endif

        #endregion




    }
}
