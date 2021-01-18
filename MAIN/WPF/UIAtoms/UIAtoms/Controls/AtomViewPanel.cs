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
using System.Diagnostics;

using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Implements panel, where only one item is shown at a time, like TabControl.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomViewPanel : Panel
    {

		private int LastVisible = -1;

		#region partial void  OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
		{
			if (this.Children.Count == 0)
			{
				//Trace.WriteLine(string.Format("No Children, Change from {0}-{1}",e.OldValue, e.NewValue));
				return;
			}

			//Trace.WriteLine(string.Format("No Children, Change from {0}-{1}", e.OldValue, e.NewValue));

			if (LastVisible == -1)
			{
				// navigate all...
				int n = 0;
				foreach (UIElement e1 in Children)
				{
					if (e1.Visibility == System.Windows.Visibility.Visible)
					{
						e1.Visibility = System.Windows.Visibility.Collapsed;
						break;
					}
					n++;
				}
				LastVisible = n;
			}

			int i = (int)e.OldValue;
			if (i != -1)
			{
				Children[i].Visibility = Visibility.Collapsed;
			}
			i = (int)e.NewValue;
			if (i != -1)
			{
				Children[i].Visibility = Visibility.Visible;
			}

			this.InvalidateVisual();
		}
		#endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="finalSize"></param>
        /// <returns></returns>
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
        {
            int sn = this.SelectedIndex;
            int i = 0;
            foreach (UIElement child in this.Children) {
                
                //child.Visibility = Visibility.Hidden;
                if (i == sn)
                {
                    child.Visibility = System.Windows.Visibility.Visible;
                    child.Arrange(new Rect(new Point(0,0),finalSize));
                    LastVisible = i;
                }
                else
                {
                    child.Visibility = System.Windows.Visibility.Collapsed;
                }
                i++;
            }
            return finalSize;
        }

#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="layoutSlotSize"></param>
        /// <returns></returns>
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            if (base.ClipToBounds)
            {
                return new RectangleGeometry(new Rect(base.RenderSize));
            }
            return null;
        }
#endif

        
 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size constraint)
        {

            if (this.IsInDesignMode())
                return new Size();

            Size newSize = new Size();
            //Size newSize = new Size(constraint.Width, constraint.Height);

            foreach (UIElement element in base.Children)
            {
                if (element != null)
                {
                    element.Measure(constraint);

                    if (newSize.Width < element.DesiredSize.Width) {
                        newSize.Width = element.DesiredSize.Width;
                    }
                    if (newSize.Height < element.DesiredSize.Height) {
                        newSize.Height = element.DesiredSize.Height;
                    }

                }
            }
            return newSize;
        }

 

    }
}
