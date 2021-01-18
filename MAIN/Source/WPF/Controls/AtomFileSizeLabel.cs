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
    /// Displays file size in Human readable format.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomFileSizeLabel : BaseAtomTextBlock
    {


		#region partial void  OnAfterFileSizeTextChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterFileSizeTextChanged(DependencyPropertyChangedEventArgs e)
		{
			ulong n = 0;
			if (ulong.TryParse(FileSizeText, out n))
			{
				FileSize = n;
			}
		}
		#endregion


		#region partial void  OnAfterFileSizeChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterFileSizeChanged(DependencyPropertyChangedEventArgs e)
		{
			Text = string.Format(new AtomSizeFormatProvider(), "{0:sz}", FileSize);
		}
		#endregion


    }
}
