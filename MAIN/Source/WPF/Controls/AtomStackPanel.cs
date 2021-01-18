#if NETFX_CORE
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
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Similar to stackpanel of WPF, but it provides ability to specify Gaps between controls.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomStackPanel : Panel
    {


		#region partial void  OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
		#endregion

		#region partial void  OnAfterOrientationChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterOrientationChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
		#endregion

		#region partial void  OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
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
