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
using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Validation;

namespace UIAtoms.WPFSamples.FormSamples.Validations
{
    /// <summary>
    /// Interaction logic for CodeBehindValidation.xaml
    /// </summary>
    public partial class CodeBehindValidation : Page
    {
        public CodeBehindValidation()
        {
            InitializeComponent();
        }

        private void theForm_AfterValidate(object sender, AtomValidationEventArgs e)
        {

            // Validate Username

            if (txtUsername.Text.Length == 0) {
                e.Errors.Add(
                    new AtomValidationError {
                        Message = AtomForm.GetMissingValueMessage(txtUsername),
                        Property = TextBox.TextProperty,
                        Source = txtUsername
                    }
                );
            }


            // Validate Gender

            if (cbGender.SelectedIndex == -1) {
                e.Errors.Add(
                    new AtomValidationError { 
                        Message = AtomForm.GetMissingValueMessage(cbGender),
                        Property = ComboBox.SelectedIndexProperty,
                        Source = cbGender
                    }
                );
            }

            // Validate Check Box

            if (!cbAgree.IsChecked.HasValue || cbAgree.IsChecked == false) {
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
