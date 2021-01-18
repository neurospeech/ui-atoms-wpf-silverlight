#if WINRT
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

#if SILVERLIGHT
    public abstract class Freezable : DependencyObject
    {
        protected abstract Freezable CreateInstanceCore();
    }
#endif

    /// <summary>
    /// 
    /// </summary>
    public class AtomPropertyValidator : Freezable
    {


        ///<summary>
        /// Dependency Property Property
        ///</summary>
        #region Dependency Property Property
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string Property
        {
            get { return (string)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Property.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.Register("Property", typeof(string), typeof(AtomPropertyValidator), new PropertyMetadata(null, OnPropertyChangedCallback));

        private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomPropertyValidator obj = d as AtomPropertyValidator;
        }

#else
public static readonly DependencyProperty PropertyProperty = 
    DependencyProperty.Register("Property", typeof(string), typeof(AtomPropertyValidator), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        ///<summary>
        /// Dependency Property ValidationRule
        ///</summary>
        #region Dependency Property ValidationRule
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public AtomValidationRule ValidationRule
        {
            get { return (AtomValidationRule)GetValue(ValidationRuleProperty); }
            set { SetValue(ValidationRuleProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ValidationRule.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValidationRuleProperty =
            DependencyProperty.Register("ValidationRule", typeof(AtomValidationRule), typeof(AtomPropertyValidator), new PropertyMetadata(null, OnValidationRuleChangedCallback));

        private static void OnValidationRuleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomPropertyValidator obj = d as AtomPropertyValidator;
        }

#else
public static readonly DependencyProperty ValidationRuleProperty = 
    DependencyProperty.Register("ValidationRule", typeof(AtomValidationRule), typeof(AtomPropertyValidator), new FrameworkPropertyMetadata(null));
#endif

        #endregion




        #region internal static void SetRule(FrameworkElement e,AtomValidationRule atomValidationRule)
        internal static void SetRule(FrameworkElement e, AtomValidationRule atomValidationRule)
        {
            AtomPropertyValidator pv = AtomForm.GetAtomValidator(e);
            if (pv != null) {
                AtomForm.SetAtomValidator(e, new AtomPropertyValidator { Property = pv.Property, ValidationRule = atomValidationRule });
            }
        }
        #endregion

        #region protected override Freezable  CreateInstanceCore()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new AtomPropertyValidator();
        }
        #endregion

    }

}
