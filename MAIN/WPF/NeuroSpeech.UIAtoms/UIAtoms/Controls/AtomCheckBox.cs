#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Checkbox with Validation rule to Validate an Empty Checkbox State.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomCheckBox : CheckBox 
    {
        /// <summary>
        /// 
        /// </summary>
        public AtomCheckBox()
        {

#if SILVERLIGHT

            AtomForm.SetMissingValueMessage(this, "Please check the field");
            AtomForm.SetIsRequired(this,true);
#endif

            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "IsChecked", ValidationRule = AtomUtils.GetDefaultInstance<AtomBooleanValidationRule>() });

        }


#if !SILVERLIGHT
        static AtomCheckBox()
        {
            AtomForm.MissingValueMessageProperty.OverrideMetadata(
                typeof(AtomCheckBox),
                new FrameworkPropertyMetadata("Please check the field"));

            AtomForm.IsRequiredProperty.OverrideMetadata(
                typeof(AtomCheckBox),
                new FrameworkPropertyMetadata(true));

        }
        
#endif

    }
}
