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
using NeuroSpeech.UIAtoms.Core;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    public partial class AtomFormGroup : AtomFormLayout
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public partial class AtomFormTab : AtomFormLayout
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
    public partial class AtomTabContent : ContentControl
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
			this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
			this.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
			this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
			this.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
			this.Width = double.NaN;
			this.Height = double.NaN;
		}
		#endregion





    }


}
