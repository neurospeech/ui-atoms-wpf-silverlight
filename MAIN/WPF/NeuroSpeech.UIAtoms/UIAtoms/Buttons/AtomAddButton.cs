#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
#else
using System.Windows;
using System.Windows.Media.Imaging;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Controls.Buttons
{
    /// <summary>
    /// 
    /// </summary>
    [NeuroSpeech.UIAtoms.Core.AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atom Buttons"
        )]
    public class AtomAddButton : BaseAtomImageButton
    {


    }
}
