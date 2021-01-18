#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Item Container for AtomCheckBoxList class
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomCheckBoxListItem : ListBoxItem
    {

#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public AtomCheckBoxListItem()
        {
            DefaultStyleKey = typeof(AtomCheckBoxListItem);
        }
#else
        static AtomCheckBoxListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomCheckBoxListItem), new FrameworkPropertyMetadata(typeof(AtomCheckBoxListItem)));
        }
#endif

    }

    /// <summary>
    /// Item Container of AtomRadioButtonList class.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomRadioButtonListItem : ListBoxItem
    {


#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public AtomRadioButtonListItem()
        {
            DefaultStyleKey = typeof(AtomRadioButtonListItem);
        }
#endif


    }
}
