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

namespace NeuroSpeech.UIAtoms.MathControls
{
    /// <summary>
    /// </summary>
    public class AtomMath9Slice : ContentControl
    {

#if SILVERLIGHT
        public AtomMath9Slice()
        {
            DefaultStyleKey = typeof(AtomMath9Slice);
        }
#else
        static AtomMath9Slice()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMath9Slice), new FrameworkPropertyMetadata(typeof(AtomMath9Slice)));
        }
#endif



        ///<summary>
        /// Dependency Property TopLeft
        ///</summary>
        #region Dependency Property TopLeft
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
    DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnTopLeftChangedCallback));
    
private static void OnTopLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty TopLeftProperty =
            DependencyProperty.Register("TopLeft", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        ///<summary>
        /// Dependency Property TopRight
        ///</summary>
        #region Dependency Property TopRight
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
    DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnTopRightChangedCallback));
    
private static void OnTopRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
    AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty TopRightProperty =
            DependencyProperty.Register("TopRight", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion



        ///<summary>
        /// Dependency Property Top
        ///</summary>
        #region Dependency Property Top
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Top
        {
            get { return (object)GetValue(TopProperty); }
            set { SetValue(TopProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Top.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty TopProperty =
    DependencyProperty.Register("Top", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnTopChangedCallback));
    
private static void OnTopChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
    AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty TopProperty =
            DependencyProperty.Register("Top", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property Left
        ///</summary>
        #region Dependency Property Left
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Left
        {
            get { return (object)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Left.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty LeftProperty =
    DependencyProperty.Register("Left", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnLeftChangedCallback));
    
private static void OnLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
    AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.Register("Left", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property Right
        ///</summary>
        #region Dependency Property Right
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Right
        {
            get { return (object)GetValue(RightProperty); }
            set { SetValue(RightProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Right.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty RightProperty =
    DependencyProperty.Register("Right", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnRightChangedCallback));
    
private static void OnRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
    AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty RightProperty =
            DependencyProperty.Register("Right", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property BottomLeft
        ///</summary>
        #region Dependency Property BottomLeft
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
    DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnBottomLeftChangedCallback));
    
private static void OnBottomLeftChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty BottomLeftProperty =
            DependencyProperty.Register("BottomLeft", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        ///<summary>
        /// Dependency Property Bottom
        ///</summary>
        #region Dependency Property Bottom
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Bottom
        {
            get { return (object)GetValue(BottomProperty); }
            set { SetValue(BottomProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Bottom.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty BottomProperty = 
    DependencyProperty.Register("Bottom", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnBottomChangedCallback));
    
private static void OnBottomChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty BottomProperty =
            DependencyProperty.Register("Bottom", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion





        ///<summary>
        /// Dependency Property BottomRight
        ///</summary>
        #region Dependency Property BottomRight
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
    DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMath9Slice), new PropertyMetadata(null, OnBottomRightChangedCallback));
    
private static void OnBottomRightChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomMath9Slice obj = d as AtomMath9Slice;
}
    
#else
        public static readonly DependencyProperty BottomRightProperty =
            DependencyProperty.Register("BottomRight", typeof(object), typeof(AtomMath9Slice), new FrameworkPropertyMetadata(null));
#endif

        #endregion








    }
}
