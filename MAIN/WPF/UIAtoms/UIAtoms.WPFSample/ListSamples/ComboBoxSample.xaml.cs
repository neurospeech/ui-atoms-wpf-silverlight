using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIAtoms.WPFSamples.ListSamples
{
    /// <summary>
    /// Interaction logic for ComboBoxSample.xaml
    /// </summary>
    public partial class ComboBoxSample : Page
    {
        public ComboBoxSample()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //comboText.Text = "•	The Select Color ComboBox is a required field for this sample form. Clicking the Submit button will fire the customized error stating Please select color" +
            //                 "•	Making a selection will instantaneously return the selected value to the form, which is displayed for demonstration purposes in the Selected Value field. Making the selection will also automatically remove the validation error that was fired."
        }

    }
}
