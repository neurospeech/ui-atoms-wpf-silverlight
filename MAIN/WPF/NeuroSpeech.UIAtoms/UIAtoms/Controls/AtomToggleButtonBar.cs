#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// AtomToggleButtonBar is a simple toggle button bar that can deliver the selected value.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomToggleButtonBar
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// displays a toggle button bar. When making a selection, the selectedIndex parameter returns the selected value triggering the display of controls like "AtomViewStack" or any other control. 
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    [StyleTypedProperty(
        Property="ItemContainerStyle",
        StyleTargetType=typeof(AtomToggleButtonBarItem)
        )]
    public class AtomToggleButtonBar : AtomListBox
    {
#if SILVERLIGHT
        public AtomToggleButtonBar()
        {
            DefaultStyleKey = typeof(AtomToggleButtonBar);

        }

#else
        static AtomToggleButtonBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomToggleButtonBar),
                new FrameworkPropertyMetadata(typeof(AtomToggleButtonBar)));

            HorizontalAlignmentProperty.OverrideMetadata(
                typeof(AtomToggleButtonBar),
                new FrameworkPropertyMetadata(HorizontalAlignment.Left));
        }
#endif



        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            BindingExpression be = this.GetBindingExpression(SelectedItemProperty);
            if (be == null)
                be = this.GetBindingExpression(SelectedValueProperty);

            if (be != null)
                return;
            
            if (this.SelectedIndex == -1 && this.Items.Count > 0)
                this.SelectedIndex = 0;
            
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AtomToggleButtonBarItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is AtomToggleButtonBarItem;
        }

    }

    /// <summary>
    /// ItemContainer of AtomToggleButtonBar class.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public class AtomToggleButtonBarItem : ListBoxItem
    {

#if SILVERLIGHT
        public AtomToggleButtonBarItem()
        {
            DefaultStyleKey = typeof(AtomToggleButtonBarItem);

        }
#else
        static AtomToggleButtonBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomToggleButtonBarItem),
                new FrameworkPropertyMetadata(typeof(AtomToggleButtonBarItem)));
        }
#endif

#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Trace.WriteLine(this.Content.GetType().ToString());
            Object content = this.Content;
            FrameworkElement e = content as FrameworkElement;
            if (e == null)
                return;

            // let the container items retain text properties...
            AtomUtils.BindTextProperties(this, e);


        }
#endif



        #region protected override void  OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.IsSelected)
            {
                e.Handled = true;
            }
            base.OnMouseLeftButtonDown(e);
        }
        #endregion



        #region protected override void  OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.IsSelected)
            {
                e.Handled = true;
            }
            base.OnMouseLeftButtonUp(e);
        }
        #endregion

        

    }
}
