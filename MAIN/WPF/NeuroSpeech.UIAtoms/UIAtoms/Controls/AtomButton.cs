#if WINRT
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
    public class AtomButton : Button
    {

#if SILVERLIGHT
        public AtomButton()
        {
            this.Width = 75;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
        }
#else
        static AtomButton()
        {
            WidthProperty.OverrideMetadata(
                typeof(AtomButton),
                new FrameworkPropertyMetadata((double)75));
            HorizontalAlignmentProperty.OverrideMetadata(typeof(AtomButton),
                new FrameworkPropertyMetadata(HorizontalAlignment.Left));
        }
#endif

        /// <summary>
        /// Verify defines whether or not to display the alert box
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// Verify
        /// </listheader>
        /// 		<item>
        /// This property, if set true, will display the Verification Pop-Up Alert.
        /// </item>
        /// 		<item>
        /// If this property is set to false, the button will simply execute its associated function. 
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property Verify
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            Description="Display Verification Message Box",
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public bool Verify
        {
            get { return (bool)GetValue(VerifyProperty); }
            set { SetValue(VerifyProperty, value); }
        }

        /// <summary>Using a DependencyProperty as the backing store for Verify.  This enables animation, styling, binding, etc...</summary> 
#if SILVERLIGHT
        public static readonly DependencyProperty VerifyProperty =
            DependencyProperty.Register("Verify", typeof(bool), typeof(AtomButton), new PropertyMetadata(false));

#else
        public static readonly DependencyProperty VerifyProperty =
            DependencyProperty.Register("Verify", typeof(bool), typeof(AtomButton), new UIPropertyMetadata(false));

  
#endif
        #endregion


        /// <summary>
        /// VerificationMessage is the message that is displayed in the pop-up box to confirm user action
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VerificationMessage
        /// </listheader>
        /// 		<item>
        /// This is the message that is displayed when a pop-up alert appears requesting user-confirmation of the button action.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property VerificationMessage
        [AtomDesign(
            Category = "Atoms",
            Description = "Verification Message displayed in MessageBox",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string VerificationMessage
        {
            get { return (string)GetValue(VerificationMessageProperty); }
            set { SetValue(VerificationMessageProperty, value); }
        }

        ///<summary>Using a DependencyProperty as the backing store for VerificationMessage.  This enables animation, styling, binding, etc...</summary> 
#if SILVERLIGHT
        public static readonly DependencyProperty VerificationMessageProperty =
            DependencyProperty.Register("VerificationMessage", typeof(string), typeof(AtomButton), new PropertyMetadata("Are you sure?"));
#else
        public static readonly DependencyProperty VerificationMessageProperty =
            DependencyProperty.Register("VerificationMessage", typeof(string), typeof(AtomButton), new UIPropertyMetadata("Are you sure?"));
#endif

        #endregion


        /// <summary>
        /// VerificationTitle is the title of the pop-ip alert message box.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VerificationTitle
        /// </listheader>
        /// 		<item>
        /// This property sets the title of the Verification Pop-Up alert box
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property VerificationTitle
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string VerificationTitle
        {
            get { return (string)GetValue(VerificationTitleProperty); }
            set { SetValue(VerificationTitleProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for VerificationTitle.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty VerificationTitleProperty =
            DependencyProperty.Register("VerificationTitle", typeof(string), typeof(AtomButton), new PropertyMetadata("Confirmation"));
#else
        public static readonly DependencyProperty VerificationTitleProperty =
            DependencyProperty.Register("VerificationTitle", typeof(string), typeof(AtomButton), new UIPropertyMetadata("Confirmation"));
#endif

        #endregion




        /// <summary>
        /// ValidationRootElement defines the form which needs to be validated.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// VAlidationRootElement
        /// </listheader>
        /// 		<item>
        /// This property is set to identify the name of the AtomForm which needs to be validated.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property ValidationRootElement
        [AtomDesign(
            Category="Atoms",
            Description = "Root Element of Visual Tree to start Validation From",
            Bindable=true,
            BrowseMode=AtomPropertyBrowseMode.Default
            )]
        public object ValidationRootElement
        {
            get { return GetValue(ValidationRootElementProperty); }
            set { SetValue(ValidationRootElementProperty, value); }
        }

        ///<summary>
        ///Using a DependencyProperty as the backing store for ValidationRootElement.  
        ///This enables animation, styling, binding, etc...
        ///</summary> 
#if SILVERLIGHT
        public static readonly DependencyProperty ValidationRootElementProperty =
            DependencyProperty.Register("ValidationRootElement", typeof(object), typeof(AtomButton), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ValidationRootElementProperty =
            DependencyProperty.Register("ValidationRootElement", typeof(object), typeof(AtomButton), new UIPropertyMetadata(null));

#endif

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
