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
    public class AtomViewPanel : Panel
    {

        /// <summary>
        /// SelectedIndex defines the selected value in the AtomViewPanel.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// SelectedIndex
        /// </listheader>
        /// 		<item>
        /// This property is an int value that holds the selected item in the AtomViewPanel.
        /// </item>
        /// 	</list>
        /// </remarks>
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

        ///<summary> Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(AtomViewPanel), new PropertyMetadata(-1,
                OnSelectedIndexChangedCallback));
#else
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(AtomViewPanel), new FrameworkPropertyMetadata(
                -1, 
                FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
                OnSelectedIndexChangedCallback
                ));

#endif
        private static void OnSelectedIndexChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomViewPanel obj = d as AtomViewPanel;
            if (obj != null)
            {
#if SILVERLIGHT
                AtomUtils.Invalidate(obj);
#endif
                obj.OnSelectedIndexChanged(e);
            }
        }

        private int LastVisible = -1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnSelectedIndexChanged(DependencyPropertyChangedEventArgs e)
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
                foreach (UIElement e1 in Children) {
                    if (e1.Visibility == System.Windows.Visibility.Visible) {
                        e1.Visibility = System.Windows.Visibility.Collapsed;
                        break;
                    }
                    n++;
                }
                LastVisible = n;
            }

            int i = (int)e.OldValue;
            if (i != -1) {
                Children[i].Visibility = Visibility.Collapsed;
            }
            i = (int)e.NewValue;
            if (i != -1) {
                Children[i].Visibility = Visibility.Visible;
            }
            if (SelectedIndexChanged != null)
            {
                SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler SelectedIndexChanged;

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
