#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomCheckBoxList extends the normal, standard CheckBox with validation and search facilities.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <listheader>
    /// AtomCheckBoxList
    /// </listheader>
    /// 	<item>
    /// 		<para>
    /// This control displays the data with their associated check boxes facilitating selections to be made. 
    /// </para>
    /// 	</item>
    /// </list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    [StyleTypedProperty(
        Property = "ItemContainerStyle",
        StyleTargetType = typeof(AtomCheckBoxListItem)
        )]
    public partial class AtomCheckBoxList : AtomListBox
    {

#if SILVERLIGHT
        public AtomCheckBoxList()
        {
            SelectionMode = System.Windows.Controls.SelectionMode.Multiple;
        }
#else
        static AtomCheckBoxList()
        {
            SelectionModeProperty.OverrideMetadata(typeof(AtomCheckBoxList), new FrameworkPropertyMetadata(SelectionMode.Multiple));
        }
#endif


        /// <summary>
        /// 
        /// </summary>
        /// <returns>new instance of AtomCheckBoxListItem</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AtomCheckBoxListItem();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is AtomCheckBoxListItem;
        }

    }

    /// <summary>
    /// AtomRadioButtonList extends the RadioButtonList.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <listheader>
    /// AtomRadioButtonList
    /// </listheader>
    /// 	<item>
    /// 		<para>
    /// displays the data along with a radio button ensuring that only one selection can be made.
    /// </para>
    /// 	</item>
    /// </list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomRadioButtonList : AtomListBox
    {

#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public AtomRadioButtonList()
        {
            SelectionMode = SelectionMode.Single;

            this.GroupName = DateTime.Now.Ticks.ToString();
        }
#endif


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            AtomRadioButtonListItem btn = new AtomRadioButtonListItem();
            btn.SetOneWayBinding(AtomRadioButtonListItem.GroupNameProperty, this, "GroupName");
            return btn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is AtomRadioButtonListItem;
        }
    }
}
