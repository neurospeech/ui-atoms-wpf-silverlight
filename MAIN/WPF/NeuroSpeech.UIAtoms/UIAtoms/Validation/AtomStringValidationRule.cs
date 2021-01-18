#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Validation
{

    /// <summary>
    /// This class implements Validation rule to validate required text.
    /// </summary>
    /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomTextBox"/> 
    /// control to validate property <see cref="P:System.Windows.Controls.TextElement.Text"/>. 
    /// You can use this rule to validate any string property on the control. It returns 
    /// <see cref="T:NeuroSpeech.UIAtoms.Validations.AtomValidationError"/> if the string is empty.
    /// 
    /// The child classes implement more specific validation by overriding method 
    /// <see cref="M:NeuroSpeech.UIAtoms.Validations.AtomStringValidationRule.IsStringValid"/>
    /// to do specific business logic validation.
    /// </remarks>
    public class AtomStringValidationRule : AtomValidationRule
    {

        /// <summary>
        /// This class implements Validation rule to validate required text.
        /// </summary>
        /// <remarks>This validation is rule used by <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomTextBox"/> 
        /// control to validate property <see cref="P:System.Windows.Controls.TextElement.Text"/>. 
        /// You can use this rule to validate any string property on the control. It returns 
        /// <see cref="T:NeuroSpeech.UIAtoms.Validations.AtomValidationError"/> if the string is empty.
        /// 
        /// The child classes implement more specific validation by overriding method 
        /// <see cref="M:NeuroSpeech.UIAtoms.Validations.AtomStringValidationRule.IsStringValid"/>
        /// to do specific business logic validation.
        /// </remarks>
        /// <param name="e">Control to validate</param>
        /// <param name="property">Dependency Property to validate</param>
        /// <param name="value">Text Value to validate</param>
        /// <returns></returns>
        public override AtomValidationError Validate(UIElement e, DependencyProperty property, object value)
        {

            //AtomTrace.WriteLine("AtomTextBox.Validate called...");

            string text = value as string;
            bool isRequired = AtomForm.GetIsRequired(e);
            if (isRequired && string.IsNullOrEmpty(text))
                return new AtomValidationError { 
                    Property=property,
                    Message = AtomForm.GetMissingValueMessage(e),
                    Source=e
                };

            int min = GetMinimumLength(e);
            if (min != -1 && min != 0) {
                if (text == null || text.Length < min) {
                    return new AtomValidationError { 
                        Property=property,
                        Message = string.Format( AtomStringValidationRule.GetMinimumLengthErrorMessage(e), min),
                        Source=e
                    };
                }
            }

            //int max = GetMaxLengthInternal(e);
            //if (max != -1 && max != 0) {
            //    if (text.Length > max) {
            //        return new AtomValidationError
            //        {
            //            Property = property,
            //            Message = AtomForm.GetInvalidValueMessage(e),
            //            Source = e
            //        };
            //    }
            //}

            return IsStringValid(value as string, property, e);
        }


        #region Attached Dependency Property MinimumLength
        ///<summary>
        ///Get Attached Property MinimumLength for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static int GetMinimumLength(DependencyObject obj)
        {
            return (int)obj.GetValue(MinimumLengthProperty);
        }

        ///<summary>
        ///Set Attached Property MinimumLength for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMinimumLength(DependencyObject obj, int value)
        {
            obj.SetValue(MinimumLengthProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for MinimumLength.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MinimumLengthProperty =
            DependencyProperty.RegisterAttached("MinimumLength", typeof(int), typeof(AtomStringValidationRule), new PropertyMetadata(0));
#else
        public static readonly DependencyProperty MinimumLengthProperty =
            DependencyProperty.RegisterAttached("MinimumLength", typeof(int), typeof(AtomStringValidationRule), new UIPropertyMetadata(0));
#endif
        #endregion


        #region Attached Dependency Property MinimumLengthErrorMessage
        ///<summary>
        ///Get Attached Property MinimumLengthErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static string GetMinimumLengthErrorMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(MinimumLengthErrorMessageProperty);
        }

        ///<summary>
        ///Set Attached Property MinimumLengthErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMinimumLengthErrorMessage(DependencyObject obj, string value)
        {
            obj.SetValue(MinimumLengthErrorMessageProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for MinimumLengthErrorMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		public static readonly DependencyProperty MinimumLengthErrorMessageProperty =
            DependencyProperty.RegisterAttached("MinimumLengthErrorMessage", typeof(string), typeof(AtomStringValidationRule), new PropertyMetadata("Text should have more then {0} characters"));
 
#else
        public static readonly DependencyProperty MinimumLengthErrorMessageProperty =
            DependencyProperty.RegisterAttached("MinimumLengthErrorMessage", typeof(string), typeof(AtomStringValidationRule), new UIPropertyMetadata("Text should have more then {0} characters"));
#endif
        #endregion



        //private int GetMaxLengthInternal(UIElement e)
        //{
        //    TextBox tb = e as TextBox;
        //    if (tb != null)
        //        return tb.MaxLength == 0 ? -1 : tb.MaxLength;
        //    return GetMaxLength(e);
        //}

        /// <summary>
        /// The child classes must implement this method and return validation error 
        /// respective to the business logic applied.
        /// </summary>
        /// <param name="p">Text Value to validate</param>
        /// <param name="property">Dependency Property to validate</param>
        /// <param name="e">Control to validate</param>
        /// <returns></returns>
        protected virtual AtomValidationError IsStringValid(string p, DependencyProperty property, UIElement e)
        {
            return null;
        }



//        #region Attached Dependency Property MaxLength
//        ///<summary>
//        ///Get Attached Property MaxLength for DependencyObject
//        ///</summary>
//        /// <param name="obj"></param>
//        /// <returns></returns>
//        [System.ComponentModel.Category("Atoms")]
//        public static int GetMaxLength(DependencyObject obj)
//        {
//            return (int)obj.GetValue(MaxLengthProperty);
//        }

//        ///<summary>
//        ///Set Attached Property MaxLength for DependencyObject
//        ///</summary>
//        /// <param name="obj"></param>
//        /// <param name="value"></param>
//        /// <returns></returns>
//        public static void SetMaxLength(DependencyObject obj, int value)
//        {
//            obj.SetValue(MaxLengthProperty, value);
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for MaxLength.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty MaxLengthProperty =
//            DependencyProperty.RegisterAttached("MaxLength", typeof(int), typeof(AtomStringValidationRule), new PropertyMetadata(-1));
//#else
//        public static readonly DependencyProperty MaxLengthProperty =
//            DependencyProperty.RegisterAttached("MaxLength", typeof(int), typeof(AtomStringValidationRule), new FrameworkPropertyMetadata(-1));
//#endif
//        #endregion



    }
}
