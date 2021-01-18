#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;


namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Password box, supports validation and two way binding of password.
    /// </summary>
     [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]


#if SILVERLIGHT
    public class AtomPasswordBox : ContentControl
    {
        /// <summary>
        /// 
        /// </summary>
        public AtomPasswordBox()
        {
            this.IsTabStop = false;
            //AtomForm.SetValidationRule(this, AtomUtils.GetDefaultInstance<AtomStringValidationRule>());
            //AtomForm.SetValidationProperty(this, "Password");

            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Password", ValidationRule = AtomUtils.GetDefaultInstance<AtomStringValidationRule>() });

            AtomStringValidationRule.SetMinimumLength(this, 5);
            AtomStringValidationRule.SetMinimumLengthErrorMessage(this, "Password too small");
            this.Content = InternalPassword;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
            //this.Width = 100;
            //InternalPassword.Width = double.NaN;
            InternalPassword.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            InternalPassword.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Stretch;
            InternalPassword.PasswordChanged += new RoutedEventHandler(InternalPassword_PasswordChanged);
        }
#else
    public partial class AtomPasswordBox: Border 
    {

		 #region partial void  OnCreate()
		 partial void OnCreate()
		 {
			 AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Password", ValidationRule = AtomUtils.GetDefaultInstance<AtomStringValidationRule>() });
		 }
		 #endregion

		 #region static partial void  OnCreateStatic()
		 static partial void OnCreateStatic()
		 {
			 AtomForm.MissingValueMessageProperty.OverrideMetadata(
				 typeof(AtomPasswordBox),
				 new FrameworkPropertyMetadata("Password is required"));


			 MinimumLengthProperty.OverrideMetadata(typeof(AtomPasswordBox), new FrameworkPropertyMetadata(5));

			 MinimumLengthErrorMessageProperty.OverrideMetadata(typeof(AtomPasswordBox), new FrameworkPropertyMetadata("Password too small"));
		 }
		 #endregion
#endif

        private PasswordBox InternalPassword = new PasswordBox();

#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            this.Child = InternalPassword;

            InternalPassword.PasswordChanged += new RoutedEventHandler(InternalPassword_PasswordChanged);
        }
#endif

         /// <summary>
         /// 
         /// </summary>
         /// <param name="e"></param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            InternalPassword.Focus();
        }


        private AtomLogicContext passwordContext = new AtomLogicContext();

        void InternalPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            passwordContext.PreventRecursive(() =>
                {
                    this.Password = InternalPassword.Password;
                });
        }



		#region partial void  OnAfterPasswordChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterPasswordChanged(DependencyPropertyChangedEventArgs e)
		{
			passwordContext.PreventRecursive(() =>
			{
				this.InternalPassword.Password = this.Password ?? String.Empty;
			});
		}
		#endregion








        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        protected virtual AtomValidationError IsTextDataValid(string text)
        {
            return null;
        }

         /// <summary>
         /// 
         /// </summary>
        public void FocusPasswordBox()
        {
            InternalPassword.Focus();
        }
    }
}
