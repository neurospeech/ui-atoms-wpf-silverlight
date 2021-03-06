#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NeuroSpeech.UIAtoms.MathControls
{
    /// <summary>
    /// </summary>
    [XmlAlias("b")]
    public class AtomMathBrackets : ItemsControl
    {
#if SILVERLIGHT
        public AtomMathBrackets()
        {
            DefaultStyleKey = typeof(AtomMathBrackets);
        } 
#else
		static AtomMathBrackets()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomMathBrackets), new FrameworkPropertyMetadata(typeof(AtomMathBrackets)));
        }
#endif
    }
}
