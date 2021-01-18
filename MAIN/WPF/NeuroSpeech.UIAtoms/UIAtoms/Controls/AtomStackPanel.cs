#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Similar to stackpanel of WPF, but it provides ability to specify Gaps between controls.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomStackPanel : Panel
    {

        /// <summary>
        /// Orientation defines whether the StackPanel is a Horizontal StackPanel or a Vertical StackPanel
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// Orientation
        /// </listheader>
        /// 		<item>
        /// This property defines whether the AtomStackPanel displays contents in a Horizontal Layout or a Vertical Layout.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property Orientation
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Orientation.  This enables animation, styling, binding, etc...
        /// </summary>
#if SILVERLIGHT
        public static readonly DependencyProperty OrientationProperty =
            DependencyProperty.Register("Orientation", typeof(Orientation),typeof(AtomStackPanel), new PropertyMetadata(Orientation.Vertical, OnOrientationChangedCallback));
#else
        public static readonly DependencyProperty OrientationProperty =
            StackPanel.OrientationProperty.AddOwner(typeof(AtomStackPanel), new FrameworkPropertyMetadata(Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, OnOrientationChangedCallback));
#endif
        private static void OnOrientationChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomStackPanel obj = d as AtomStackPanel;
            if (obj != null)
            {
                obj.OnOrientationChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOrientationChanged(DependencyPropertyChangedEventArgs e)
        {
#if SILVERLIGHT
            AtomUtils.Invalidate(this);
#endif
            if (OrientationChanged != null)
            {
                OrientationChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OrientationChanged;

        #endregion

        /// <summary>
        /// HorizontalGap defines the Horizontal Gap between items in an AtomStackPanel
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// HorizontalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the horizontal gap between items in an AtomStackPanel.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property HorizontalGap
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public double HorizontalGap
        {
            get { return (double)GetValue(HorizontalGapProperty); }
            set { SetValue(HorizontalGapProperty, value); }
        }

        
        /// <summary>
        /// Using a DependencyProperty as the backing store for HorizontalGap.  This enables animation, styling, binding, etc...
        /// </summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HorizontalGapProperty =
            DependencyProperty.Register("HorizontalGap", typeof(double), typeof(AtomStackPanel), new PropertyMetadata((double)2, OnHorizontalGapChangedCallback));
#else
        public static readonly DependencyProperty HorizontalGapProperty =
            AtomFlexibleGrid.HorizontalGapProperty.AddOwner(typeof(AtomStackPanel), new FrameworkPropertyMetadata((double)2, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, OnHorizontalGapChangedCallback));
#endif
        private static void OnHorizontalGapChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomStackPanel obj = d as AtomStackPanel;
            if (obj != null)
            {
                obj.OnHorizontalGapChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
        {
#if SILVERLIGHT
            AtomUtils.Invalidate(this);
#endif
            if (HorizontalGapChanged != null)
            {
                HorizontalGapChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler HorizontalGapChanged;

        #endregion

        /// <summary>
        /// VerticalGap defines the vertical gap between items in an AtomStackPanel
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VerticalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the vertical gap between items in an AtomStackPanel.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property VerticalGap
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public double VerticalGap
        {
            get { return (double)GetValue(VerticalGapProperty); }
            set { SetValue(VerticalGapProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for VerticalGap.  This enables animation, styling, binding, etc...
        /// </summary>
#if SILVERLIGHT
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap",typeof(double),typeof(AtomStackPanel), new PropertyMetadata((double)2, OnVerticalGapChangedCallback));
#else
        public static readonly DependencyProperty VerticalGapProperty =
            AtomFlexibleGrid.VerticalGapProperty.AddOwner(typeof(AtomStackPanel), new FrameworkPropertyMetadata((double)2, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, OnVerticalGapChangedCallback));
#endif
        private static void OnVerticalGapChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomStackPanel obj = d as AtomStackPanel;
            if (obj != null)
            {
                obj.OnVerticalGapChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e)
        {
#if SILVERLIGHT
            AtomUtils.Invalidate(this);
#endif
            if (VerticalGapChanged != null)
            {
                VerticalGapChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler VerticalGapChanged;

        #endregion


        private readonly static Rect emptyRect = new Rect(0, 0, 0, 0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            double width = 0;
            double height = 0;
            bool bFirst = true;
            if (Orientation == Orientation.Vertical)
            {
                foreach (UIElement e in Children) {
                    e.Measure(availableSize);
                    if (e.Visibility == System.Windows.Visibility.Collapsed)
                        continue;

                    if (width < e.DesiredSize.Width)
                        width = e.DesiredSize.Width;

                    height += e.DesiredSize.Height;
                    if (!bFirst)
                        height += VerticalGap;
                    bFirst = false;
                }
            }
            else 
            {
                foreach (UIElement e in Children) {
                    e.Measure(availableSize);
                    if (e.Visibility == System.Windows.Visibility.Collapsed)
                        continue;
                    if (height < e.DesiredSize.Height)
                        height = e.DesiredSize.Height;
                    width += e.DesiredSize.Width;
                    if (!bFirst)
                        width += HorizontalGap;
                    bFirst = false;
                }
            }
            return new Size(width,height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            double left = 0;
            double top = 0;
            
            double finalWidth = finalSize.Width;
            double finalHeight = finalSize.Height;

            Rect lastRect = new Rect();
            bool bFirst = true;
            if (Orientation == Orientation.Vertical)
            {
                foreach (UIElement e in Children)
                {
                    if (e.Visibility == System.Windows.Visibility.Collapsed) {
                        e.Arrange(new Rect(0,0,0,0));
                        continue;
                    }
                    if (!bFirst)
                    {
                        top += VerticalGap + lastRect.Height;
                    }
                    bFirst = false;
                    lastRect = new Rect(left, top, finalWidth, e.DesiredSize.Height);
                    e.Arrange(lastRect);
                }
            }
            else 
            {
                if (Orientation == Orientation.Horizontal)
                {
                    foreach (UIElement e in Children)
                    {
                        if (e.Visibility == System.Windows.Visibility.Collapsed)
                        {
                            e.Arrange(new Rect(0,0,0,0));
                            continue;
                        }
                        if (!bFirst)
                        {
                            left += HorizontalGap + lastRect.Width;
                        }
                        bFirst = false;
                        lastRect = new Rect(left, top, e.DesiredSize.Width, finalHeight);
                        e.Arrange(lastRect);
                    }
                }
 
            }
            return base.ArrangeOverride(finalSize);
        }

    }
}
