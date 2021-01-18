#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Media;
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
    /// AtomValidationRule is base class for Advanced Validation Rules used in UIAtoms Validation Framework.
    /// </summary>
    /// <remarks>
    /// AtomValidationRule provides an abstract method 
    /// <see cref="M:NeuroSpeech.UIAtoms.Validation.AtomValidationRule.Validate"/>
    /// that must be implemented by the child class that provides the validation logic. In case of no error, 
    /// the method returns null as return value, otherwise it returns 
    /// <see cref="T:NeuroSpeech.UIAtoms.Validation.AtomValidationError"/> object
    /// which contains the details of the Control, the error message and the dependency property that was
    /// validated.
    /// </remarks>
    public abstract class AtomValidationRule
    {

        /// <summary>
        /// The implementation must override this method and implement the validation logic.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract AtomValidationError Validate(
            UIElement e,
            DependencyProperty property,
            object value
            );


#if SILVERLIGHT
        /// <summary>
        /// In sliverlight attached properties do not validate.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="ownerType"></param>
        /// <returns></returns>
        internal static DependencyProperty LookupCorePropertyInType(string propertyName, Type ownerType)
        {
            DependencyProperty property = null;
            string name = propertyName + "Property";
            System.Reflection.FieldInfo field = ownerType.GetField(name, System.Reflection.BindingFlags.FlattenHierarchy | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            if (field != null)
            {
                property = field.GetValue(null) as DependencyProperty;
            }
            return property;
        }
#endif




        /// <summary>
        /// Called internally from Validator Control to Validate the Property
        /// </summary>
        internal AtomValidationError Validate(UIElement e, string p)
        {
#if SILVERLIGHT
            DependencyProperty dp = LookupCorePropertyInType(p, e.GetType());
            object val = e.GetValue(dp);
            return Validate(e, dp, val);
#else            
            DependencyPropertyDescriptor dpd =
                DependencyPropertyDescriptor.FromName(p, e.GetType(), e.GetType());
            object val = e.GetValue(dpd.DependencyProperty);
            return Validate(e, dpd.DependencyProperty, val);
#endif
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static AtomValidationError Validate(UIElement e)
        {
            if (e == null)
                return null;

            Control c = e as Control;
            if (c != null) {
                if (!c.IsEnabled)
                    return null;
            }

            AtomPropertyValidator pv = AtomForm.GetAtomValidator(e);
            if (pv == null)
                return null;
            return pv.ValidationRule.Validate(e, pv.Property);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool DoValidationReportError(DependencyObject e)
        {
            AtomForm form = e as AtomForm;
            if (form != null) {
                return form.ValidateForm();
            }

            List<AtomValidationError> errors = new List<AtomValidationError>();

            StringBuilder sb = new StringBuilder();

            AtomTreeWalker.ForEachChildren<UIElement>(e,
                (element) => {
                    AtomValidationError error = Validate(element);
                    if (error != null) {
                        errors.Add(error);
                        sb.AppendLine(error.Message);
                    }
                });

            /*ValidateRecursive(e as UIElement, errors);
            if (errors.Count> 0) {
                StringBuilder sb = new StringBuilder();
                foreach (AtomValidationError error in errors)
                    sb.AppendLine(error.Message);
                MessageBox.Show(sb.ToString(), "Validation Error", MessageBoxButton.OK);
                return false;
            }*/
            return errors.Count>0;
        }

        internal static void ValidateRecursive(UIElement rootElement, List<AtomValidationError> errors)
        {

            AtomTreeWalker.ForEachChildren<UIElement>(rootElement,
                (e) =>
                {
                    //AtomTrace.WriteLine("Validating {0} {1}",e.GetType().Name, AtomForm.GetValidationRule(e));
                    AtomValidationError error= Validate(e);
                    AtomForm.SetValidationError(e, error);
                    if (error != null && errors != null)
                    {
                        errors.Add(error);
                    }
                });

        }
    }
}
