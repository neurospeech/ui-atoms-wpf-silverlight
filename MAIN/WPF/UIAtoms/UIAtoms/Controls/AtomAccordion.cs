#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomAccordion allows for multiple sections of data, either in a form or report, to be displayed upon expanding the relevant heading for that group of data items.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomAccordion
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// Allows multiple views to be collapsed and stacked together. When one "heading" is expanded, the others collapse, and only the content of the selected heading is displayed. 
    /// </para>
    /// 			<para>
    /// This display can be used for form building as well as for reporting, and all types of controls (ranging from image displays, to radio buttons, check box lists, etc.) can be embedded within the accordion.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName="Atoms"
        )]
    public partial class AtomAccordion : AtomListBox
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
			SelectionMode = System.Windows.Controls.SelectionMode.Single;
			ItemsPanel = GetDefaultItemsPanel();
			IsFilterVisible = false;
		}
		#endregion


        private static ItemsPanelTemplate GetDefaultItemsPanel() {
            
            FrameworkElementFactory panelFactory = new FrameworkElementFactory(typeof(AtomAccordionPanel));
            panelFactory.SetValue(Panel.IsItemsHostProperty, true);
            ItemsPanelTemplate t = new ItemsPanelTemplate(panelFactory);
            return t;
        }

        private static void OnItemsPanelPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) { 
        }

        private static object OnItemsPanelCoerced(object sender, object value) {
            if (value is AtomAccordionPanel)
                return value;
            return new AtomAccordionPanel();
        }

        private static void OnSelectionModePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e) { 
        }

        private static object OnSelectionModeCoerced(object sender, object value) {
            return SelectionMode.Single;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
            this.InvalidateMeasure();
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new AtomAccordionItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is AtomAccordionItem;
        }




    }
}
