#if NETFX_CORE
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
    public partial class AtomFlexibleGrid :  Panel
    {


		#region partial void  OnAfterRowLayoutChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterRowLayoutChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateVisual();
		}
		#endregion

		#region partial void  OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateVisual();
		}
		#endregion

		#region partial void  OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateVisual();
		}
		#endregion

		#region partial void  OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
		{
			InvalidateMeasure();
			InvalidateArrange();
		}
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
