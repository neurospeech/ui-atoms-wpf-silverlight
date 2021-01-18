#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

#if NET4
using VR = System.ComponentModel.DataAnnotations;
#else
#if SILVERLIGHT
using VR = System.ComponentModel.DataAnnotations;
#else
using VR = System.Windows.Controls;
#endif
#endif


namespace NeuroSpeech.UIAtoms.Validation
{

    /// <summary>
    /// This rule can be used on the property that is bound to an object which supports in built "DataAnnotations"
    /// </summary>
    public class AtomDataAnnotationValidationRule : AtomValidationRule
    {


        /// <summary>
        /// 
        /// </summary>
        public AtomDataAnnotationValidationRule()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override AtomValidationError Validate(System.Windows.UIElement e, System.Windows.DependencyProperty property, object value)
        {

            FrameworkElement fe = e as FrameworkElement;
            BindingExpression be = fe.GetBindingExpression(property);

            // not bound...
            if (be == null)
                return null;

            
            Binding b = be.ParentBinding;


            ValidationAttribute[] ValidationAttributes = null;
            string name = b.Path.Path;

            Type type = be.DataItem.GetType();
            PropertyInfo p = type.GetProperty(name);
            ValidationAttributes = (ValidationAttribute[])p.GetCustomAttributes(typeof(ValidationAttribute), true);
            if (ValidationAttributes == null || ValidationAttributes.Length == 0)
                return null;

            List<VR.ValidationResult> results = new List<VR.ValidationResult>();

#if DA
            if (!Validator.TryValidateValue(value, new ValidationContext(fe.DataContext, null, null), results, ValidationAttributes))
            {
                if (results.Count > 0) {
                    VR.ValidationResult vr = results[0];
                    return new AtomValidationError { 
                        Message= vr.ErrorMessage,
                        Property=property,
                        Source=e
                    };
                }
            }
#else
            // bring required first...

            RequiredAttribute ra = (RequiredAttribute)ValidationAttributes.FirstOrDefault((t) => t is RequiredAttribute);
            if (ra != null) {
                ValidationAttributes = ValidationAttributes.Where(t => !(t is RequiredAttribute)).ToArray();
            }

            if (!ra.IsValid(value)) {
                return new AtomValidationError { 
                    Message = ra.ErrorMessage,
                    Property=property,
                    Source=e
                };
            }

            foreach (ValidationAttribute va in ValidationAttributes) {
                if (!va.IsValid(value)) {
                    return new AtomValidationError { 
                        Message = va.ErrorMessage,
                        Property = property,
                        Source = e
                    };
                }
            }
#endif

            return null;
        }
    }
}
