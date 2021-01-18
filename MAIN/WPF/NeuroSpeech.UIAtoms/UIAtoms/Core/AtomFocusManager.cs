#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// Helps in solving Focus related issues.
    /// </summary>
    public class AtomFocusManager
    {

        /// <summary>
        /// Allows a type to be registered to ignore focus, typically composite control's root must ignore itself from FocusManager.
        /// </summary>
        /// <param name="control"></param>
        public static void IgnoreFocus(Type control) { 
            System.Windows.Controls.Control.IsTabStopProperty.OverrideMetadata(control,new FrameworkPropertyMetadata(false,
                OnIsTabStopChanged,OnIsTabStopCoerced));
        }

        private static void OnIsTabStopChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
        }

        private static object OnIsTabStopCoerced(object sender, object newValue)
        {
            return false;
        }


    }
}
