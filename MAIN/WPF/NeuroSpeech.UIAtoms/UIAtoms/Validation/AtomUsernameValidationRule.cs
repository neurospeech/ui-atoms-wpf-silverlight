#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Validation
{

    /// <summary>
    /// Validation rule to validate "Username" text.
    /// </summary>
    public class AtomUsernameValidationRule : AtomStringValidationRule
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="property"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override NeuroSpeech.UIAtoms.Validation.AtomValidationError IsStringValid(string p, DependencyProperty property, UIElement e)
        {

            if (!Char.IsLetter(p[0]))
            {
                return new AtomValidationError
                {
                    Property = property,
                    Source = e,
                    Message = GetInvalidUsernameErrorMessage(e)
                };
            }

            foreach (char ch in p) {
                if (!Char.IsLetterOrDigit(ch)) {
                    return new AtomValidationError
                    {
                        Property = property,
                        Source = e,
                        Message = GetInvalidUsernameErrorMessage(e)
                    };
                }
            }

            return base.IsStringValid(p, property, e);
        }



        #region Attached Dependency Property InvalidUsernameErrorMessage
        ///<summary>
        ///Get Attached Property InvalidUsernameErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static string GetInvalidUsernameErrorMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(InvalidUsernameErrorMessageProperty);
        }

        ///<summary>
        ///Set Attached Property InvalidUsernameErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetInvalidUsernameErrorMessage(DependencyObject obj, string value)
        {
            obj.SetValue(InvalidUsernameErrorMessageProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for InvalidUsernameErrorMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty InvalidUsernameErrorMessageProperty =
            DependencyProperty.RegisterAttached("InvalidUsernameErrorMessage", typeof(string), typeof(AtomUsernameValidationRule), new PropertyMetadata("Invalid Username, should only be alpha numeric and must start with an alphabet"));
#else
        public static readonly DependencyProperty InvalidUsernameErrorMessageProperty =
            DependencyProperty.RegisterAttached("InvalidUsernameErrorMessage", typeof(string), typeof(AtomUsernameValidationRule), new UIPropertyMetadata("Invalid Username, should only be alpha numeric and must start with an alphabet"));
#endif
        #endregion


        

    }
}
