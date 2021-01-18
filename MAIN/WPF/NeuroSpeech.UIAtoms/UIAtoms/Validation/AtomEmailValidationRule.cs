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
    /// This class implements Validation rule to validate email address.
    /// </summary>
    /// <remarks>
    /// This rule is default validation rule in 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomEmailTextBox"/> to 
    /// validate the input email address. The property
    /// <see cref="P:NeuroSpeech.UIAtoms.Controls.AtomEmailTextBox.AllowMultiple"/>
    /// turns on multiple email address seperated by comma, so that individual 
    /// email addresses are also validated and comma is accepted as email seperating 
    /// character.
    /// </remarks>
    public class AtomEmailValidationRule : AtomStringValidationRule
    {

        #region Attached Dependency Property AllowMultiple
        ///<summary>
        ///Get Attached Property AllowMultiple for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetAllowMultiple(DependencyObject obj)
        {
            return (bool)obj.GetValue(AllowMultipleProperty);
        }

        ///<summary>
        ///Set Attached Property AllowMultiple for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetAllowMultiple(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowMultipleProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for AllowMultiple.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty AllowMultipleProperty =
            DependencyProperty.RegisterAttached("AllowMultiple", typeof(bool), typeof(AtomEmailValidationRule), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty AllowMultipleProperty =
            DependencyProperty.RegisterAttached("AllowMultiple", typeof(bool), typeof(AtomEmailValidationRule), new UIPropertyMetadata(false));
#endif
        #endregion

        /// <summary>
        /// Validates the specified string against email address format.
        /// </summary>
        /// <param name="text">Text to validate</param>
        /// <param name="property">Dependency Property of Control to validate</param>
        /// <param name="e">Control to validate</param>
        /// <returns></returns>
        protected override AtomValidationError IsStringValid(string text, DependencyProperty property, UIElement e)
        {
            AtomValidationError err = base.IsStringValid(text, property, e);
            if (err == null && !string.IsNullOrEmpty(text)) {
                if (GetAllowMultiple(e))
                {
                    string[] emails = text.Split(',', ';');
                    foreach (string eml in emails)
                    {
                        string email = eml.Trim();
                        if (!IsValidEmailAddress(email))
                        {
                            return new AtomValidationError
                            {
                                Property = property,
                                Source = e,
                                Message = AtomForm.GetInvalidValueMessage(e)
                            };
                        }
                    }
                    return null;
                }

                if (IsValidEmailAddress(text))
                {
                    return null;
                }
                return new AtomValidationError
                {
                    Message = AtomForm.GetInvalidValueMessage(e),
                    Property = property,
                    Source = e
                };
            }
            return err;
        }

        private bool IsValidEmailAddress(string text)
        {
            string[] tokens = text.Split('@');
            if (tokens == null || tokens.Length != 2)
                return false;
            if (tokens[0].Length == 0)
                return false;
            if (tokens[1].Length == 0)
                return false;
            foreach (char ch in tokens[0])
            {
                if (Char.IsLetterOrDigit(ch))
                    continue;
                if (ch == '.' || ch == '_' || ch == '-')
                    continue;
                return false;
            }
            foreach (char ch in tokens[1])
            {
                if (Char.IsLetterOrDigit(ch))
                    continue;
                if (ch == '.' || ch == '_' || ch == '-')
                    continue;
                return false;
            }
            return true;
        }

    }
}
