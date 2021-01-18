#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
#if SILVERLIGHT
    [ContentProperty("Child", false)]
#else
    [ContentProperty("Child")]
#endif
    public class Atom2CBorder : FrameworkElement
    {

        ///<summary>
        ///DependencyProperty OuterBorderBrush
        ///</summary>
        #region Dependency Property OuterBorderBrush
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public Brush OuterBorderBrush
        {
            get { return (Brush)GetValue(OuterBorderBrushProperty); }
            set { SetValue(OuterBorderBrushProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for OuterBorderBrush.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty OuterBorderBrushProperty = 
    DependencyProperty.Register("OuterBorderBrush", typeof(Brush), typeof(Atom2CBorder), new PropertyMetadata(null,OnOuterBorderBrushChangedCallback));

        private static void OnOuterBorderBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Atom2CBorder obj = d as Atom2CBorder;
        }


#else
        public static readonly DependencyProperty OuterBorderBrushProperty =
            DependencyProperty.Register("OuterBorderBrush", typeof(Brush), typeof(Atom2CBorder), new FrameworkPropertyMetadata(Brushes.Black , FrameworkPropertyMetadataOptions.AffectsRender));
#endif

        #endregion

        ///<summary>
        ///DependencyProperty CornerRadius
        ///</summary>
        #region Dependency Property CornerRadius
        [AtomDesign(
          Category = "Appearance",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Atom2CBorder), new PropertyMetadata(null,OnCornerRadiusChangedCallback));

        private static void OnCornerRadiusChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Atom2CBorder obj = d as Atom2CBorder;
        }

#else
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Atom2CBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
#endif


        #endregion

        ///<summary>
        /// Dependency Property BorderThickness
        ///</summary>
        #region Dependency Property BorderThickness
        [AtomDesign(
          Category = "Appearance",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty BorderThicknessProperty = 
    DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(Atom2CBorder), new PropertyMetadata(new Thickness(), OnBorderThicknessChangedCallback));
    
private static void OnBorderThicknessChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  Atom2CBorder obj = d as Atom2CBorder;
}
    
#else
        public static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(Atom2CBorder), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
#endif

        #endregion

        ///<summary>
        /// Dependency Property BorderBrush
        ///</summary>
        #region Dependency Property BorderBrush
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty BorderBrushProperty = 
    DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Atom2CBorder), new PropertyMetadata(null, OnBorderBrushChangedCallback));
    
private static void OnBorderBrushChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  Atom2CBorder obj = d as Atom2CBorder;
}
    
#else
        public static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(Atom2CBorder), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
#endif

        #endregion

        ///<summary>
        /// Dependency Property Padding
        ///</summary>
        #region Dependency Property Padding
        [AtomDesign(
          Category = "Appearnace",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Padding.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty PaddingProperty = 
    DependencyProperty.Register("Padding", typeof(Thickness), typeof(Atom2CBorder), new PropertyMetadata(new Thickness(), OnPaddingChangedCallback));
    
private static void OnPaddingChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  Atom2CBorder obj = d as Atom2CBorder;
}
    
#else
        public static readonly DependencyProperty PaddingProperty =
            DependencyProperty.Register("Padding", typeof(Thickness), typeof(Atom2CBorder), new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange));
#endif

        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            return base.ArrangeOverride(finalSize);
        }
    }
}
