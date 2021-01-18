#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Threading;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NeuroSpeech.UIAtoms.Core;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFormContainer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        void SetLabelWidth(double w);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="field"></param>
        void BindField(AtomFormItemContainer container, Control field);

    }
}
