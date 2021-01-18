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
using NeuroSpeech.UIAtoms.Validation;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// </summary>
    public class AtomUsernameTextBox : AtomTextBox
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomUsernameTextBox()
        {
#if SILVERLIGHT
            AtomUsernameValidationRule.SetMinimumLength(this, 5);
            AtomForm.SetMissingValueMessage(this, "Username is required");
            WatermarkText = "Alpha numeric only";
#endif
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomUsernameValidationRule>() });
        }

#if SILVERLIGHT
#else
        static AtomUsernameTextBox()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata(typeof(AtomUsernameTextBox)));

            AtomUsernameValidationRule.MinimumLengthProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata(5));
            AtomForm.MissingValueMessageProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata("Username is required"));

            WatermarkTextProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata("Alpha numeric only"));

            AtomForm.AtomValidatorProperty.OverrideMetadata(
                typeof(AtomUsernameTextBox), 
                new FrameworkPropertyMetadata(new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomUsernameValidationRule>() }));
        }
#endif


        ///<summary>
        /// Dependency Property InvalidUsernameErrorMessage
        ///</summary>
        #region Dependency Property InvalidUsernameErrorMessage
        [AtomDesign(
          Category = "Atoms.Validation",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string InvalidUsernameErrorMessage
        {
            get { return (string)GetValue(InvalidUsernameErrorMessageProperty); }
            set { SetValue(InvalidUsernameErrorMessageProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for InvalidUsernameErrorMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty InvalidUsernameErrorMessageProperty = 
            AtomUsernameValidationRule.InvalidUsernameErrorMessageProperty;
#else
        public static readonly DependencyProperty InvalidUsernameErrorMessageProperty =
            AtomUsernameValidationRule.InvalidUsernameErrorMessageProperty.AddOwner(typeof(AtomUsernameTextBox));
#endif

        #endregion



    }
}
