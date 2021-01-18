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
    public class BaseAtomImageButton : NeuroSpeech.UIAtoms.Controls.AtomValueDialogButton
    {

        /// <summary>
        /// 
        /// </summary>
        internal protected BaseAtomImageButton()
        {
            object val = GetValue(ImageSourceProperty);
            if (val == null || val == DependencyProperty.UnsetValue)
            {
#if SILVERLIGHT
                ImageSource = new BitmapImage(
                            new Uri(
                                "/NeuroSpeech.UIAtoms.Silverlight;component/Buttons/Icons/" + this.GetType().Name + ".Icon.png",
                                UriKind.RelativeOrAbsolute)
                        );
#else
                ImageSource = new BitmapImage(
                            new Uri(
                                "/NeuroSpeech.UIAtoms;component/Buttons/Icons/" + this.GetType().Name + ".Icon.png",
                                UriKind.RelativeOrAbsolute)
                        );
#endif
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }

    }
}
