#if NETFX_CORE
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Validation
{

    /// <summary>
    /// This class implements Validation rule to match two passwords in different controls.
    /// </summary>
    /// <remarks>
    /// Validates the password for 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomPasswordBoxAgain"/> with password of
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomPasswordBox"/>. In order to make it work 
    /// correctly the property 
    /// <see cref="P:NeuroSpeech.UIAtoms.Controls.AtomPasswordBox.FirstPassworBoxName"/> should
    /// be set to Element Name of <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomPasswordBox"/>.
    /// </remarks>
    public class AtomPasswordMatchValidationRule : AtomStringValidationRule
    {

        /// <summary>
        /// Validates the password for 
        /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomPasswordBoxAgain"/> with password of
        /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomPasswordBox"/>.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="property"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override AtomValidationError IsStringValid(string p, System.Windows.DependencyProperty property, System.Windows.UIElement e)
        {

            AtomPasswordBoxAgain apb = e as AtomPasswordBoxAgain;
            if (apb == null) {
                throw new InvalidOperationException("AtomPasswordMatchValidationRule can only be applied on AtomPasswordBoxAgain");
            }

            AtomPasswordBox a = apb.FirstPasswordBox;

            if (a.Password == apb.Password)
                return null;

            return new AtomValidationError { 
                Message= AtomForm.GetInvalidValueMessage(e),
                Property=property,
                Source=e
            };
        }

    }
}
