#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
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
    /// Validation Error Details
    /// </summary>
    /// <remarks>
    /// The Method 
    /// <see cref="M:NeuroSpeech.UIAtoms.Validation.AtomValidationRule.Validate"/>
    /// of <see cref="T:NeuroSpeech.UIAtoms.Validation.AtomValidationRule"/>
    /// returns object of type AtomValidationError if there was a validation error. This object
    /// contains Source, Property and Message that gives details of the validation error. That is
    /// used by internal validation framework and 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomForm"/> to validate and display details of
    /// validation errors.
    /// </remarks>
    public class AtomValidationError : System.ComponentModel.INotifyPropertyChanged
    {

        /// <summary>
        /// Error message displayed on Error List.
        /// </summary>
        #region Property Message
        [AtomDesign(
            Bindable=true
            )]
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Message"));
            }
        }
        private string _Message = "";
        #endregion
	

        /// <summary>
        /// The control whose property was validated.
        /// </summary>
        public DependencyObject Source { get; set; }

        /// <summary>
        /// The property of the Control that was validated.
        /// </summary>
        #region Property Property
        [AtomDesign(
            Category="Atoms"
            )]
        public DependencyProperty Property
        {
            get
            {
                return _Property;
            }
            set
            {
                _Property = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Property"));
            }
        }
        private DependencyProperty _Property = null;
        #endregion

        /// <summary>
        /// Ignore...
        /// </summary>
        internal bool IsFormError { get; set; }


        /// <summary>
        /// Ignore...
        /// </summary>
        internal bool IsBindingError { get; set; }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Notifies change in property value.
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion

        internal void SetError()
        {
            UIElement e = Source as UIElement;

            AtomForm.SetErrorMessage(e, Message);
            AtomForm.SetHasError(e, true);
        }

        internal void ClearError() 
        {
            UIElement e = Source as UIElement;

            AtomForm.SetErrorMessage(e, "");
            AtomForm.SetHasError(e, false);
        }

    }
}
