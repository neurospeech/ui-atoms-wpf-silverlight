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
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.MathControls
{

    /// <summary>
    /// 
    /// </summary>
#if SILVERLIGHT
    public class AtomMathPanel : Panel
#else
    public class AtomMathPanel : Panel , System.Windows.Markup.IAddChild
#endif
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomMathPanel()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            Size size = new Size();
            double left = 0;
            double height = finalSize.Height;
            size.Height = height;
            foreach (UIElement item in Children)
            {
                double top = 0;
                Size dsize = item.DesiredSize;

                if (dsize.Height < height) {
                    top = height - dsize.Height;
                    top /= 2;
                }

                Rect lastRect = new Rect(left, top, dsize.Width, height);
                item.Arrange(lastRect);
                left += lastRect.Width;
                size.Width += lastRect.Width;
            }
            return size;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = new Size();
            foreach (UIElement item in Children)
            {
                item.Measure(availableSize);
                Size dsize = item.DesiredSize;
                size.Height = Math.Max(size.Height, dsize.Height);
                size.Width += dsize.Width;
            }
            return size;
        }

    }
}
