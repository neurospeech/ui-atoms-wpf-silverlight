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
using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Validation;

namespace UIAtomsDemo.Views.FormSamples.Validations
{
    public partial class CodeBehindValidation : Page
    {
        public CodeBehindValidation()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void theForm_AfterValidate(object sender, AtomValidationEventArgs e)
        {

            // Validate Username

            if (txtUsername.Text.Length == 0)
            {
                e.Errors.Add(
                    new AtomValidationError
                    {
                        Message = AtomForm.GetMissingValueMessage(txtUsername),
                        Property = TextBox.TextProperty,
                        Source = txtUsername
                    }
                );
            }


            // Validate Gender

            if (cbGender.SelectedIndex == -1)
            {
                e.Errors.Add(
                    new AtomValidationError
                    {
                        Message = AtomForm.GetMissingValueMessage(cbGender),
                        Property = ComboBox.SelectedIndexProperty,
                        Source = cbGender
                    }
                );
            }

            // Validate Check Box

            if (!cbAgree.IsChecked.HasValue || cbAgree.IsChecked == false)
            {
                e.Errors.Add(
                    new AtomValidationError
                    {
                        Message = AtomForm.GetMissingValueMessage(cbAgree),
                        Property = CheckBox.IsCheckedProperty,
                        Source = cbAgree
                    }
                );
            }

        }

    }
}
