#if NETFX_CORE
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
    /// To request designtime value.
    /// </summary>
    public static class AtomHelper
    {

        /// <summary>
        /// Identifies if the code is running in design mode or not.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsInDesignMode(this DependencyObject obj) {
            return System.ComponentModel.DesignerProperties.GetIsInDesignMode(obj);
        }

    }
}
