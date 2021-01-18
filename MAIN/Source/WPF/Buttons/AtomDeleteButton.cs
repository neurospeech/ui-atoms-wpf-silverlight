#if WINRT
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;
#else
using System.Windows.Media.Imaging;
using System.Windows;
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
    public class AtomDeleteButton : BaseAtomImageButton
    {
#if SILVERLIGHT
        public AtomDeleteButton()
        {
            Verify = true;
            VerificationMessage = "Are you sure you want to delete this?";
        }
#else
        static AtomDeleteButton()
        {
            VerifyProperty.OverrideMetadata(
                typeof(AtomDeleteButton),
                new FrameworkPropertyMetadata(true));

            VerificationMessageProperty.OverrideMetadata(
                typeof(AtomDeleteButton),
                new FrameworkPropertyMetadata("Are you sure you want to delete this?"));
        }
#endif
    }
}
