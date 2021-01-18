using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using NeuroSpeech.UIAtoms.Validation;
using NeuroSpeech.UIAtoms.Controls;

namespace UIAtomsDemo.Views.FormSamples.Validations
{
    public partial class CustomValidationRule : Page
    {
        public CustomValidationRule()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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
            DatePicker d = e as DatePicker;
            if (!d.SelectedDate.HasValue || d.SelectedDate.Value == DateTime.MinValue)
            {
                return new AtomValidationError
                {
                    Source = d,
                    Property = DatePicker.SelectedDateProperty,
                    Message = AtomForm.GetMissingValueMessage(d)
                };
            }
            return null;
        }
    }


}
