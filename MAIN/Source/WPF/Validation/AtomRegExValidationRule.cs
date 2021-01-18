#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Validation
{

    /// <summary>
    /// This class implements Validation rule to validate text against regular expression.
    /// </summary>
    /// <remarks>
    /// This rule is default validation rule in 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomTextBoxWithRegEx"/> to 
    /// validate the input text against specified regular expression. The property
    /// <see cref="P:NeuroSpeech.UIAtoms.Controls.AtomTextBoxWithRegEx.ValidationRegEx"/>
    /// specifies the regular expression to validate against.
    /// </remarks>
    public class AtomRegExValidationRule : AtomStringValidationRule
    {


        #region Attached Dependency Property ValidationRegEx
        ///<summary>
        ///Get Attached Property ValidationRegEx for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetValidationRegEx(DependencyObject obj)
        {
            return (string)obj.GetValue(ValidationRegExProperty);
        }

        ///<summary>
        ///Set Attached Property ValidationRegEx for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetValidationRegEx(DependencyObject obj, string value)
        {
            obj.SetValue(ValidationRegExProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ValidationRegEx.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValidationRegExProperty =
            DependencyProperty.RegisterAttached("ValidationRegEx", typeof(string), typeof(AtomRegExValidationRule), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ValidationRegExProperty =
            DependencyProperty.RegisterAttached("ValidationRegEx", typeof(string), typeof(AtomRegExValidationRule), new UIPropertyMetadata(null));
#endif
        #endregion



        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="property"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override AtomValidationError IsStringValid(string p, DependencyProperty property, UIElement e)
        {
            string regex = GetValidationRegEx(e);
            if (string.IsNullOrEmpty(regex) || Regex.IsMatch(p, regex))
                return null;
            return new AtomValidationError { 
                Source=e,
                Property=property,
                Message=AtomForm.GetInvalidValueMessage(e)
            };
        }

    }
}
