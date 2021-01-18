#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Validation
{
    /// <summary>
    /// This class implements Validation rule to validate SelectedIndex property of List based classes.
    /// </summary>
    /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomListBox"/> 
    /// control to validate property <see cref="P:NeuroSpeech.UIAtoms.Controls.AtomListBox.SelectedIndex"/>. 
    /// If SelectedIndex is -1, its considered as missing value error, and if it matches any of "InvalidIndices"
    /// specified then it is considered as invalid value error.
    /// You can use this rule to validate any SelectedIndex property on the control.
    /// </remarks>
    public class AtomSelectionValidationRule : AtomValidationRule
    {



        #region Attached Dependency Property InvalidIndices
        ///<summary>
        ///Get Attached Property InvalidIndices for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int[] GetInvalidIndices(DependencyObject obj)
        {
            return (int[])obj.GetValue(InvalidIndicesProperty);
        }

        ///<summary>
        ///Set Attached Property InvalidIndices for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetInvalidIndices(DependencyObject obj, int[] value)
        {
            obj.SetValue(InvalidIndicesProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for InvalidIndices.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty InvalidIndicesProperty =
            DependencyProperty.RegisterAttached("InvalidIndices", typeof(int[]), typeof(AtomSelectionValidationRule), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty InvalidIndicesProperty =
            DependencyProperty.RegisterAttached("InvalidIndices", typeof(int[]), typeof(AtomSelectionValidationRule), new UIPropertyMetadata(null));
#endif
        #endregion




        /// <summary>
        /// Validates selected index property
        /// </summary>
        /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomListBox"/> 
        /// control to validate property <see cref="P:NeuroSpeech.UIAtoms.Controls.AtomListBox.SelectedIndex"/>. 
        /// You can use this rule to validate any SelectedIndex property on the control.</remarks>
        /// <param name="e">Control whose property is validated</param>
        /// <param name="property">Property of the control to validate</param>
        /// <param name="value">Value of property to validate</param>
        /// <returns>Null if the property value is not -1 or is one of the invalid indices 
        /// otherwise it returns <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomValidationError"/></returns>
        public override AtomValidationError Validate(UIElement e, DependencyProperty property, object value)
        {
            int val = (int)value;
            if (AtomForm.GetIsRequired(e)) {
                if (val == -1)
                    return new AtomValidationError { 
                        Property=property,
                        Message=AtomForm.GetMissingValueMessage(e),
                        Source=e
                    };
            }
            int[] indices = GetInvalidIndices(e);
            if (indices == null || indices.Length == 0)
                return null;
            if (indices.Contains(val))
                return new AtomValidationError { 
                    Property=property,
                    Message= AtomForm.GetInvalidValueMessage(e),
                    Source=e
                };
            return null;
        }

    }
}
