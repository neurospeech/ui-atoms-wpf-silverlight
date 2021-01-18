#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
#else
using System.Windows;
using System.Windows.Media;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// AtomImageButton is a collection of advanced buttons with images and commonly used functionalities preset.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomImageButton
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// Commonly used buttons like delete, submit, cancel, play, stop, etc.. with their universally accepted symbols or images are preset on these buttons. Their functionalities are standard, and their error messages can be customized as per the application's needs.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomImageButton : AtomButton
    {

#if SILVERLIGHT
        public AtomImageButton()
        {
            DefaultStyleKey = typeof(AtomImageButton);
        }
#else
#endif



    }
}
