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
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public class AtomAccordionPanel : Panel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override Size ArrangeOverride(Size finalSize)
        {

            double allHeight = 0;

            double lastTop = 0;

            Rect rect;

            foreach (AtomAccordionItem e in InternalChildren)
            {
                //e.Measure(finalSize);
                if (!e.IsSelected)
                {
                    allHeight += e.DesiredSize.Height;
                }
            }

            foreach (AtomAccordionItem e in InternalChildren) {
                if (e.IsSelected)
                {
                    rect = new Rect(0,lastTop,finalSize.Width, finalSize.Height-allHeight);
                }
                else {
                    rect = new Rect(0, lastTop,  finalSize.Width,e.DesiredSize.Height);
                }
                e.Arrange(rect);
                lastTop += rect.Height;
            }

            return base.ArrangeOverride(finalSize);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            double width = 0;
            double height = 0;
            foreach (UIElement e in this.InternalChildren)
            {
                e.Measure(availableSize);
                Size s = e.DesiredSize;
                if (width < s.Width)
                    width = s.Width;
                height += s.Height;
            }
            return new Size(width,height);
        }
    }
}
