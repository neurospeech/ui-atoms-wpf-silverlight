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
    /// Coming up in the next release.
    /// </summary>
    public class AtomWrapPanel : Panel
    {

        /// <summary>
        /// Horizontal Gap defines the horizontal gap in the AtomWrapPanel
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// HorizontalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the horizontal gap in between items in an AtomWrapPanel.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property HorizontalGap
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int HorizontalGap
        {
            get { return (int)GetValue(HorizontalGapProperty); }
            set { SetValue(HorizontalGapProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for HorizontalGap.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty HorizontalGapProperty =
            DependencyProperty.Register("HorizontalGap", typeof(int), typeof(AtomWrapPanel), new UIPropertyMetadata(4, OnHorizontalGapChangedCallback));

        private static void OnHorizontalGapChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomWrapPanel obj = d as AtomWrapPanel;
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
            this.InvalidateMeasure();
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
        /// Vertical Gap defines the vertical gap in between items in an AtomWrapPanel.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VerticalGap
        /// </listheader>
        /// 		<item>
        /// This property defines the vertical gap between items in an AtomWrapPanel.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property VerticalGap
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public int VerticalGap
        {
            get { return (int)GetValue(VerticalGapProperty); }
            set { SetValue(VerticalGapProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for VerticalGap.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty VerticalGapProperty =
            DependencyProperty.Register("VerticalGap", typeof(int), typeof(AtomWrapPanel), new UIPropertyMetadata(4, OnVerticalGapChangedCallback));

        private static void OnVerticalGapChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomWrapPanel obj = d as AtomWrapPanel;
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
            InvalidateMeasure();
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size availableSize)
        {

            //double maxWidth = 0;
            //double maxHeight = 0;



            return base.MeasureOverride(availableSize);
        }
    }
}
