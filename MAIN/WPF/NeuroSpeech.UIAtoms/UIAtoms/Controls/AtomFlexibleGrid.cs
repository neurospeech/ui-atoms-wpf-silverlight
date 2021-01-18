#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;
using System.Collections;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class AtomFlexibleGrid :  Panel
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomFlexibleGrid()
        {
            
        }

        ///<summary>
        /// Row layout can be specified simply by comma sperated numbers of number of items to be presented in each row e.g.
        /// 1,1,2,3,1 will put 2 items in 3rd row and 3 items on 4th row
        ///</summary>
        #region Dependency Property RowLayout
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string RowLayout
        {
            get { return (string)GetValue(RowLayoutProperty); }
            set { SetValue(RowLayoutProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for RowLayout.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty RowLayoutProperty = 
    DependencyProperty.Register("RowLayout", typeof(string), typeof(AtomFlexibleGrid), new PropertyMetadata("", OnRowLayoutChangedCallback));
    
private static void OnRowLayoutChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
    AtomUtils.Invalidate(d as UIElement);
}
    
#else
        public static readonly DependencyProperty RowLayoutProperty =
            DependencyProperty.Register("RowLayout", typeof(string), typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata("",
                 FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
#endif

        #endregion

        #region Dependency Property HorizontalGap
        /// <summary>
        /// Horizontal Gap defines the horizontal gap between AtomFlexibleGrid.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// HorizontalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the horizontal gap between items in the AtomFlexibleGrid.
        /// </item>
        /// 	</list>
        /// </remarks>
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("HorizontalGap")]
#if SILVERLIGHT
        [EditorBrowsable(EditorBrowsableState.Always)]
#else
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
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
            DependencyProperty.Register("HorizontalGap", typeof(double), typeof(AtomFlexibleGrid),
            new PropertyMetadata((double)2, OnHorizontalGapPropertyChanged));

        private static void OnHorizontalGapPropertyChanged(object sender, DependencyPropertyChangedEventArgs e) 
        {
            AtomUtils.Invalidate(sender as UIElement);
        }

#else
        public static readonly DependencyProperty HorizontalGapProperty =
            DependencyProperty.Register("HorizontalGap", typeof(double), typeof(AtomFlexibleGrid),
            new FrameworkPropertyMetadata((double)2, 
                FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.Inherits ));
#endif
        #endregion

        #region Dependency Property VerticalGap
        /// <summary>
        /// VerticalGap sets the vertical gap between items in an AtomFlexibleGrid.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VerticalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the vertical gap between items in an AtomFlexibleGrid.
        /// </item>
        /// 	</list>
        /// </remarks>
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("VerticalGap")]
#if !SILVERLIGHT
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
        public double VerticalGap
        {
            get { return (double)GetValue(VerticalGapProperty); }
            set { SetValue(VerticalGapProperty, value); }
        }

        ///<summary>
        ///Using a DependencyProperty as the backing store for VerticalGap.  This enables animation, styling, binding, etc...
        ///</summary> 
#if SILVERLIGHT
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap", typeof(double), typeof(AtomFlexibleGrid),
            new PropertyMetadata((double)2, OnVerticalGapPropertyChanged));

        private static void OnVerticalGapPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomUtils.Invalidate(sender as UIElement);
        }

#else
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap", typeof(double), typeof(AtomFlexibleGrid),
            new FrameworkPropertyMetadata((double)2, 
                FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.Inherits
                ));
#endif
        #endregion




        ///<summary>
        ///DependencyProperty SelectedIndex
        ///</summary>
        #region Dependency Property SelectedIndex
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(AtomFlexibleGrid), new PropertyMetadata(-1, OnSelectedIndexChangedCallback));
#else
public static readonly DependencyProperty SelectedIndexProperty = 
    DependencyProperty.Register("SelectedIndex", typeof(int), typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata(-1,OnSelectedIndexChangedCallback));
#endif

        private static void OnSelectedIndexChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFlexibleGrid obj = d as AtomFlexibleGrid;
            if (obj != null)
            {
                obj.OnSelectedIndexChanged(e);
            }
        }

        /// <summary>
        /// Fires SelectedIndexChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
        {

            InvalidateMeasure();
            InvalidateArrange();

            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler SelectedIndexChanged;

        #endregion





        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (SelectedIndex != -1) {
                return TabMeasureOverride(availableSize);
            }
            return LayoutMeasureOverride(availableSize);
        }

        #region private Size TabMeasureOverride(Size availableSize)
        private Size TabMeasureOverride(Size availableSize)
        {
            Size size = new Size(0,0);
            for (int i = 0; i < Children.Count; i++)
            {
                UIElement e = Children[i];
                if (i == SelectedIndex)
                {
                    e.Visibility = System.Windows.Visibility.Visible;
                }
                else {
                    e.Visibility = System.Windows.Visibility.Collapsed;
                }
                e.Measure(availableSize);
                size.Width = Math.Max(e.DesiredSize.Width, size.Width);
                size.Height = Math.Max(e.DesiredSize.Height, size.Height);
            }
            if (!double.IsPositiveInfinity(availableSize.Width))
            {
                size.Width = Math.Min(size.Width, availableSize.Width);
            }
            if (!double.IsPositiveInfinity(availableSize.Height))
            {
                size.Height = Math.Min(size.Height, availableSize.Height);
            }
            return size;
        }
        #endregion


        private Size LayoutMeasureOverride(Size availableSize)
        {
            double width = 0.0;
            double height = 0.0;

            double lineWidth = 0.0;

            List<UIElement> row = null;


            List<object> Rows = PrepareRowsViaLayout(RowLayout);

            double rowHeight = 0.0;

            //double maxLabelWidth = 0.0;

            Size cellSize;

            cellSize = availableSize;

            foreach (object obj in Rows)
            {

                row = obj as List<UIElement>;
                if (row != null)
                {
                    // measure row..
                    lineWidth = 0.0;
                    rowHeight = 0.0;

                    int visibleItems = Math.Max(row.Count(x => x.Visibility == System.Windows.Visibility.Visible), 1);

                    if (!Double.IsNaN(availableSize.Width))
                    {
                        cellSize.Width = availableSize.Width - (HorizontalGap * (visibleItems - 1)) / visibleItems;
                    }

                    for (int i = 0; i < row.Count; i++)
                    {
                        UIElement e = row[i];
                        e.Measure(cellSize);
                        if (e.Visibility == System.Windows.Visibility.Collapsed)
                            continue;
                        lineWidth += e.DesiredSize.Width + HorizontalGap;
                        rowHeight = Math.Max(rowHeight, e.DesiredSize.Height);
                    }
                    if (lineWidth > 0)
                        lineWidth -= HorizontalGap;
                }
                else
                {
                    UIElement e = obj as UIElement;
                    e.Measure(availableSize);
                    if (e.Visibility == System.Windows.Visibility.Collapsed)
                        continue;
                    lineWidth = e.DesiredSize.Width;
                    rowHeight = e.DesiredSize.Height;
                }
                width = Math.Max(width, lineWidth);
                height += rowHeight + VerticalGap;
            }
            if (height > 0)
                height -= VerticalGap;

            return new Size(width, height);
        }

        #region Method PrepareRowsViaLayout
        private List<object> PrepareRowsViaLayout(string layout)
        {
            List<object> Rows = new List<object>();

            Queue<int> items = Split(layout);

            int cells = 0;
            List<UIElement> row = null;
            foreach (UIElement element in Children)
            {
                if (cells == 0)
                {

                    if (row != null)
                        Rows.Add(row);

                    if (items.Count > 0)
                    {
                        cells = items.Dequeue();
                        row = new List<UIElement>();
                    }
                    else
                    {
                        row = null;
                    }
                }

                if (row != null)
                {
                    row.Add(element);
                }
                else
                {
                    Rows.Add(element);
                }

                cells--;
            }
            if (row != null)
                Rows.Add(row);
            return Rows;
        } 
        #endregion

        #region Method Split
        private Queue<int> Split(string layout)
        {
            Queue<int> items = new Queue<int>();

            if (string.IsNullOrEmpty(layout))
                return items;

            string[] tokens = layout.Split(',');
            foreach (string token in tokens)
            {
                // 1 item per row by default...
                int count = 1;
                if (token.Length > 0)
                    int.TryParse(token, out count);
                items.Enqueue(count);
            }
            return items;
        } 
        #endregion


        private readonly static Rect emptyRect = new Rect(0,0,0,0);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (SelectedIndex != -1) {
                return TabArrangeOverride(finalSize);
            }
            return LayoutArrangeOverride(finalSize);
        }

        #region private Size TabArrangeOverride(Size finalSize)
        private Size TabArrangeOverride(Size finalSize)
        {
            UIElement e;
            for (int i = 0; i < Children.Count; i++)
            {
                e = Children[i];
                if (i == SelectedIndex)
                {
                    e.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
                }
                else {
                    e.Arrange(emptyRect);
                }
            }
            return finalSize;
        }
        #endregion


        private Size LayoutArrangeOverride(Size finalSize)
        {
            Rect lastRect = new Rect();

            double left = 0;
            double top = 0;
            double width = finalSize.Width;

            List<object> Rows = new List<object>();

            List<UIElement> row = null;

            Rows = PrepareRowsViaLayout(RowLayout);

            List<AtomFormItemContainer> containers = new List<AtomFormItemContainer>();


            double rowHeight = 0.0;

            double extraHeight = finalSize.Height;

            foreach (object item in Rows)
            {
                if (item is List<UIElement>)
                {
                    // this is row..
                    row = item as List<UIElement>;
                    int visibleItems = Math.Max(row.Count(x => x.Visibility == System.Windows.Visibility.Visible), 1);
                    double eWidth = (width - HorizontalGap * (visibleItems)) / visibleItems;
                    left = 0;
                    rowHeight = 0.0;
                    foreach (UIElement e in row)
                    {
                        if (e.Visibility == System.Windows.Visibility.Collapsed)
                        {
                            e.Arrange(emptyRect);
                            continue;
                        }
                        lastRect = new Rect(left, top, eWidth, e.DesiredSize.Height);
                        e.Arrange(lastRect);
                        left += lastRect.Width + HorizontalGap;
                        rowHeight = Math.Max(rowHeight, lastRect.Height);
                    }
                }
                else
                {
                    UIElement e = item as UIElement;
                    if (e.Visibility == System.Windows.Visibility.Collapsed)
                    {
                        e.Arrange(emptyRect);
                        continue;
                    }
                    lastRect = new Rect(0, top, width, e.DesiredSize.Height);
                    e.Arrange(lastRect);
                    rowHeight = lastRect.Height;
                }
                top += rowHeight + VerticalGap;
            }
            return base.ArrangeOverride(finalSize);
        }

        private void SetMaxPadding(UIElement e, double maxPadding)
        {
            AtomFormItemContainer item = e as AtomFormItemContainer;
            if (item == null)
                return;
            item.Label.Margin = new Thickness(maxPadding - item.Label.ActualWidth, 0, 0, 0);
        }

        private double MeasureMaxPadding(double maxPadding, UIElement e)
        {
            AtomFormItemContainer item = e as AtomFormItemContainer;
            if (item == null)
                return maxPadding;
            maxPadding = Math.Max(maxPadding, item.Label.ActualWidth);
            return maxPadding;
        }



    }

#if !SILVERLIGHT

    /// <summary>
    /// 
    /// </summary>
    public static class UIElementCollectionHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static int Count(this UIElementCollection uc, Func<UIElement, bool> filter)
        {
            int i = 0;
            foreach (UIElement item in uc)
            {
                if (filter(item))
                    i++;
            }
            return i;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static UIElement First(this UIElementCollection uc, Func<UIElement, bool> filter)
        {
            foreach (UIElement item in uc)
            {
                if (filter(item))
                    return item;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uc"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static IEnumerable<UIElement> Where(this UIElementCollection uc, Func<UIElement, bool> filter)
        {
            foreach (UIElement item in uc)
            {
                if (filter(item))
                    yield return item;
            }
        }

    }
#endif

}
