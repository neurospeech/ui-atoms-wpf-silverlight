#if WINRT
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
    public class AtomCheckBoxListItem : ListBoxItem
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
    public class AtomRadioButtonListItem : ListBoxItem
    {


#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        public AtomRadioButtonListItem()
        {
            DefaultStyleKey = typeof(AtomRadioButtonListItem);
        }
#else
        static AtomRadioButtonListItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomRadioButtonListItem), new FrameworkPropertyMetadata(typeof(AtomRadioButtonListItem)));
        }

#endif



        ///<summary>
        /// Dependency Property GroupName
        ///</summary>
        #region Dependency Property GroupName
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for GroupName.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(AtomRadioButtonListItem), new PropertyMetadata(null));
#else
public static readonly DependencyProperty GroupNameProperty = 
    DependencyProperty.Register("GroupName", typeof(string), typeof(AtomRadioButtonListItem), new FrameworkPropertyMetadata(null));
#endif

        #endregion



    }
}
