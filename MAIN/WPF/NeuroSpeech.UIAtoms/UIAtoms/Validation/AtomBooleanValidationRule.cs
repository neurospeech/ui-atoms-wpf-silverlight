#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Validation
{
    /// <summary>
    /// This class implements Validation rule to validate boolean property.
    /// </summary>
    /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomCheckBox"/> 
    /// control to validate property <see cref="P:System.Windows.Controls.Primitives.ToggleButton.IsChecked"/>. 
    /// You can use this rule to validate any boolean property on the control.
    /// </remarks>
    public class AtomBooleanValidationRule : AtomValidationRule
    {

        /// <summary>
        /// Validates boolean property
        /// </summary>
        /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomCheckBox"/> 
        /// control to validate property <see cref="P:System.Windows.Controls.Primitives.ToggleButton.IsChecked"/>. 
        /// You can use this rule to validate any boolean property on the control.</remarks>
        /// <param name="e">Control whose property is validated</param>
        /// <param name="property">Property of the control to validate</param>
        /// <param name="value">Value of property to validate</param>
        /// <returns>Null if the property value is true otherwise it returns 
        /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomValidationError"/></returns>
        public override AtomValidationError Validate(System.Windows.UIElement e, System.Windows.DependencyProperty property, object value)
        {
            if (value != null) {
                if (value is Boolean?)
                {
                    Boolean? v = value as Boolean?;
                    if (v == true)
                        return null;
                }
                else {
                    bool v = (bool)value;
                    if (v)
                        return null;
                }
            }
            return new AtomValidationError { 
                Source=e,
                Property=property,
                Message= AtomForm.GetMissingValueMessage(e)
            };
        }
    }
}
