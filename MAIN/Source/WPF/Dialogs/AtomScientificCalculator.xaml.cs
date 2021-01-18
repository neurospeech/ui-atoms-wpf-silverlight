#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Dialogs
{
    /// <summary>
    /// Interaction logic for AtomScientificCalculator.xaml
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomScientificCalculator : Window
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomScientificCalculator()
        {
            InitializeComponent();
        }
    }
}
