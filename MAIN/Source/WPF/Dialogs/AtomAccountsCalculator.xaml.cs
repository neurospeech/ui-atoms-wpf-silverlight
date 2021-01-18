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
using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Dialogs
{
    /// <summary>
    /// Interaction logic for AtomAccountsCalculator.xaml
    /// </summary>
    
    [AtomDesign(
        DisplayInToolbox=false
        )]

    public partial class AtomAccountsCalculator : Window, IAtomValueProvider
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomAccountsCalculator()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(AtomAccountsCalculator_Loaded);
        }

        void AtomAccountsCalculator_Loaded(object sender, RoutedEventArgs e)
        {
            calculator.Value = this.Value;
            calculator.Focus();
        }


        /// <summary>
        /// 
        /// </summary>
        public decimal Value { get; set; }


        #region IAtomValueProvider Members

        object IAtomValueProvider.Value
        {
            get
            {
                return this.Value;
            }
            set
            {
                if (value is decimal)
                {
                    this.Value = (decimal)value;
                }
                else {
                    if (value != null) {
                        string v = value.ToString();
                        decimal dv = (decimal)0;
                        if (decimal.TryParse(v, out dv))
                        {
                            this.Value = dv;
                        }
                    }
                }
            }
        }

        #endregion

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Value = calculator.Value;
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
