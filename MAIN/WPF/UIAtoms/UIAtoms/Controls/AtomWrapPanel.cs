#if NETFX_CORE
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
    public partial class AtomWrapPanel : Panel
    {

		#region partial void  OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
		#endregion

		#region partial void  OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e)
		{
			this.InvalidateMeasure();
		}
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
