#if NETFX_CORE
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
    public partial class AtomEmailTextBox : AtomTextBox
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
            AtomForm.SetMissingValueMessage(this, "Email is required");
            AtomForm.SetInvalidValueMessage(this, "Invalid Email Address");
			AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomEmailValidationRule>() });
		}
		#endregion


    }
}
