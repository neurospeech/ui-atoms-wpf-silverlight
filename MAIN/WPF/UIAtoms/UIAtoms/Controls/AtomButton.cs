#if NETFX_CORE
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomButton comes preconfigured with validation pop-up alert message buttons, validation rules, and customizable error messages.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// 			<para>AtomButton
    /// </para>
    /// 			<para>
    /// Displays a simple button which triggers the validation and submission of a form.
    /// </para>
    /// 			<para>
    /// It provides the functionalities of the following:
    /// </para>
    /// 		</listheader>
    /// 		<item>
    /// 			<term>
    /// Pop-Up Message Box:
    /// </term>
    /// 			<description>
    /// This appears once the button is pressed. It has a customizable title and a message and provides two options, yes or proceed, and no or don't proceed. 
    /// </description>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// It also has customizable error messages that can be displayed for validation purposes. 
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomButton : Button
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
			this.Width = 75;
			this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
		}
		#endregion


        /// <summary>
        /// IsValidationSuccessful is a property that is used internally
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// IsValidationSuccessful
        /// </listheader>
        /// 		<item>
        /// This property is used internally.
        /// </item>
        /// 		<item>
        /// This property checks the form on submission and is set to true if no validation errors are triggered.
        /// </item>
        /// 	</list>
        /// </remarks>

        #region Property IsDataValid
        protected bool IsValidationSuccessful
        {
            get
            {
                return _IsValidationSuccessful;
            }
        }
        private bool _IsValidationSuccessful = false;

        #endregion



        /// <summary>
        /// Internal Usage.
        /// </summary>
        protected override void OnClick()
        {
            _IsValidationSuccessful = false;
            if (Verify)
            {
#if SILVERLIGHT
                MessageBoxResult r = MessageBox.Show(VerificationMessage, VerificationTitle, MessageBoxButton.OKCancel);
                if (r != MessageBoxResult.OK && r != MessageBoxResult.Yes)
                    return;
#else
                if (MessageBox.Show(VerificationMessage, VerificationTitle, MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No) != MessageBoxResult.Yes)
                    return;
#endif
            }

            object rootElement = ValidationRootElement;
            if (rootElement is string)
            {
                string e = ValidationRootElement as string;
                if (e != null)
                {
                    object obj = FindName(e);
                    if (obj == null)
                    {
                        DependencyObject p = VisualTreeHelper.GetParent(this);
                        while (p != null)
                        {
                            string name = (string)p.GetValue(FrameworkElement.NameProperty);
                            if (name == e)
                            {
                                obj = p;
                                break;
                            }
                            p = VisualTreeHelper.GetParent(p);
                        }
                    }

                    if (!AtomValidationRule.DoValidationReportError((DependencyObject)obj))
                        return;

                }
            }
            else {
                UIElement element = ValidationRootElement as UIElement;
                if (element != null) {
                    if (!AtomValidationRule.DoValidationReportError((DependencyObject)element))
                        return;
                }
            }

            _IsValidationSuccessful = true;
            base.OnClick();


        }

    }
}
