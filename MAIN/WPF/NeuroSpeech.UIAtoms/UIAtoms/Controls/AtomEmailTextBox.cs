#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// EmailTextBox ensures that the text entered into the TextBox is a properly formatted email address. It also supports multiple email address inputs.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <listheader>
    /// The AtomEmailTextBox is an extension of the AtomTextBox and has validation settings to ensure that the text input is a properly formatted email address. It fires a customizable error if this validation fails. It also supports multiple email address inputs. 
    /// </listheader>
    /// 	<item>
    /// 		<term>Error Message
    /// </term>
    /// 		<description>can be customized for both non-null as well as incorrectly formatted input.
    /// </description>
    /// 	</item>
    /// 	<item>
    /// 		<term>Multiple</term>
    /// 		<description>allows for multiple comma separated email addresses to be input into the input field.</description>
    /// 	</item>
    /// </list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomEmailTextBox : AtomTextBox
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomEmailTextBox()
        {
#if SILVERLIGHT
            AtomForm.SetMissingValueMessage(this, "Email is required");
            AtomForm.SetInvalidValueMessage(this, "Invalid Email Address");
#endif
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomEmailValidationRule>() });
        }

#if SILVERLIGHT
#else
        static AtomEmailTextBox()
        {

            AtomForm.MissingValueMessageProperty.OverrideMetadata(
                typeof(AtomEmailTextBox),
                new FrameworkPropertyMetadata("Email is required"));

            AtomForm.InvalidValueMessageProperty.OverrideMetadata(
                typeof(AtomEmailTextBox),
                new FrameworkPropertyMetadata("Invalid Email Address"));


        }
#endif



        /// <summary>
        /// AllowMultiple allows multiple email address inputs into an email address text box
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// AllowMultiple
        /// </listheader>
        /// 		<item>
        /// This property, when set to True, will set the TextBox field to accept multiple email addresses separated by a comma.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property AllowMultiple
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            Description="Allow multiple email addresses seperated by comma",
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public bool AllowMultiple
        {
            get { return (bool)GetValue(AllowMultipleProperty); }
            set { SetValue(AllowMultipleProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for AllowMultiple.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty AllowMultipleProperty =
            AtomEmailValidationRule.AllowMultipleProperty;
#else
        public static readonly DependencyProperty AllowMultipleProperty =
            AtomEmailValidationRule.AllowMultipleProperty.AddOwner(typeof(AtomEmailTextBox));
#endif

        #endregion


    }
}
