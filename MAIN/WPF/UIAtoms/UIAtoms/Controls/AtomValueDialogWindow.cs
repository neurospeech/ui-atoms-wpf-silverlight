#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAtomValueProvider
    {

        /// <summary>
        /// 
        /// </summary>
        object Value { get; set; }

    }
}
