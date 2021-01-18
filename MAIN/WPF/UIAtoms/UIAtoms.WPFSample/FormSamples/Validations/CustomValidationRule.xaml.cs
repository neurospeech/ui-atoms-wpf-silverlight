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
using NeuroSpeech.UIAtoms.Validation;
using Microsoft.Windows.Controls;
using NeuroSpeech.UIAtoms.Controls;

namespace UIAtoms.WPFSamples.FormSamples.Validations
{
    /// <summary>
    /// Interaction logic for CustomValidationRule.xaml
    /// </summary>
    public partial class CustomValidationRule : Page
    {
        public CustomValidationRule()
        {
            InitializeComponent();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class CustomDateValidationRule : AtomValidationRule 
    {

        /// <summary>
        /// Returns null if validation was successful or returns error in case 
        /// the date was empty
        /// </summary>
        /// <param name="e"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override AtomValidationError Validate(UIElement e, DependencyProperty property, object value)
        {
            Microsoft.Windows.Controls.DatePicker d = e as Microsoft.Windows.Controls.DatePicker;
            if (!d.SelectedDate.HasValue || d.SelectedDate.Value == DateTime.MinValue) {
                return new AtomValidationError
                {
                    Source = d,
                    Property = Microsoft.Windows.Controls.DatePicker.SelectedDateProperty,
                    Message = AtomForm.GetMissingValueMessage(d)
                };
            }
            return null;
        }
    }

}
