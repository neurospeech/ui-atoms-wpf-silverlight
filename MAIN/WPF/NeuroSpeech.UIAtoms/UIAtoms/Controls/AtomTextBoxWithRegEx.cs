#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NeuroSpeech.UIAtoms.Validation;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// An Extension of AtomTextBox, this contains validation for regular expression functionality.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <listheader>
    /// The Atom TextBox is a control with the following customizable parameters:
    /// </listheader>
    /// 	<item>
    /// 		<term> 
    /// Watermark
    /// </term>
    /// 		<description>displays a watermark within the TextBox, which automatically gets removed once the cursor is brought to the field. 
    /// </description>
    /// 	</item>
    /// 	<item>
    /// 		<term>Formatted Text
    /// </term>
    /// 		<description>
    /// when the cursor is on the text box, a normal text box will be displayed, and when the cursor is outside the text box, the formatted textbox will be displayed.
    /// </description>
    /// 	</item>
    /// 	<item>
    /// In addition, it supports Regular Expressions.
    /// </item>
    /// </list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomTextBoxWithRegEx : AtomTextBox
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomTextBoxWithRegEx()
        {
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomRegExValidationRule>() });
        }


        /// <summary>
        /// ValidationRegEx
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// ValidationRegEx
        /// </listheader>
        /// 		<item>
        /// This property needs to be defined. It will be the string used to validate the input received in the TextBox.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property ValidationRegEx
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]

        public string ValidationRegEx
        {
            get { return (string)GetValue(ValidationRegExProperty); }
            set { SetValue(ValidationRegExProperty, value); }
        }

        ///<summary>
        ///Using a DependencyProperty as the backing store for ValidationRegEx.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT    
        public static readonly DependencyProperty ValidationRegExProperty = AtomRegExValidationRule.ValidationRegExProperty;
#else
        public static readonly DependencyProperty ValidationRegExProperty =
                AtomRegExValidationRule.ValidationRegExProperty.AddOwner(
                typeof(AtomTextBoxWithRegEx));

#endif
        #endregion

    }
}
