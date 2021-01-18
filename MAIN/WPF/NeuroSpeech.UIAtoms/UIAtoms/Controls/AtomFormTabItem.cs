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
using NeuroSpeech.UIAtoms.Core;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    public class AtomFormGroup : AtomFormLayout
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomFormTab : AtomFormLayout
    {
        public AtomFormTab()
        {
            this.ShowHeader = false;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomFormRow : AtomFormGroup { 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        #region protected override void  OnLayoutGridAvailable(AtomFlexibleGrid grid)
        protected override void OnLayoutGridAvailable(AtomFlexibleGrid grid)
        {
            base.OnLayoutGridAvailable(grid);

			grid.SafeBind(AtomFlexibleGrid.RowLayoutProperty,
				() => Items.Count.ToString(),
				new Binding("Count") { Source=Items });
        }
        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomTabContent : ContentControl
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomTabContent()
        {
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
            this.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
            this.Width = double.NaN;
            this.Height = double.NaN;
        }

        ///<summary>
        /// Dependency Property Header
        ///</summary>
        #region Dependency Property Header
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(object), typeof(AtomTabContent), new PropertyMetadata(null, OnHeaderChangedCallback));

        private static void OnHeaderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomTabContent obj = d as AtomTabContent;
        }

#else
public static readonly DependencyProperty HeaderProperty = 
    DependencyProperty.Register("Header", typeof(object), typeof(AtomTabContent), new FrameworkPropertyMetadata(null));
#endif

        #endregion



    }


}
