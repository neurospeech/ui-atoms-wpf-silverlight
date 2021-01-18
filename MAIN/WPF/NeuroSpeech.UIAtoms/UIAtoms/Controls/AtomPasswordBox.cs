#if WINRT
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
    public class AtomPasswordBox: Border 
    {
         /// <summary>
         /// 
         /// </summary>
         public AtomPasswordBox()
         {
             AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Password", ValidationRule = AtomUtils.GetDefaultInstance<AtomStringValidationRule>() });
         }

        static AtomPasswordBox()
        {

            AtomForm.MissingValueMessageProperty.OverrideMetadata(
                typeof(AtomPasswordBox),
                new FrameworkPropertyMetadata("Password is required"));


            MinimumLengthProperty.OverrideMetadata(typeof(AtomPasswordBox), new FrameworkPropertyMetadata(5));

            MinimumLengthErrorMessageProperty.OverrideMetadata(typeof(AtomPasswordBox), new FrameworkPropertyMetadata("Password too small"));

        }
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




        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Password
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(AtomPasswordBox), new PropertyMetadata(null, OnPasswordChangedCallback));
#else
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(AtomPasswordBox), new UIPropertyMetadata(null, OnPasswordChangedCallback));
#endif
        private static void OnPasswordChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomPasswordBox obj = d as AtomPasswordBox;
            if (obj != null)
            {
                obj.OnPasswordChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPasswordChanged(DependencyPropertyChangedEventArgs e)
        {

            passwordContext.PreventRecursive(() => {
                this.InternalPassword.Password = this.Password ?? String.Empty;
            });

            if (PasswordChanged != null)
            {
                PasswordChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler PasswordChanged;

        #endregion



        ///<summary>
        /// Dependency Property MinimumLength
        ///</summary>
        #region Dependency Property MinimumLength
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public int MinimumLength
        {
            get { return (int)GetValue(MinimumLengthProperty); }
            set { SetValue(MinimumLengthProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for MinimumLength.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MinimumLengthProperty = 
            AtomStringValidationRule.MinimumLengthProperty;
#else
        public static readonly DependencyProperty MinimumLengthProperty =
            AtomStringValidationRule.MinimumLengthProperty.AddOwner(typeof(AtomPasswordBox));
#endif

        #endregion



        ///<summary>
        /// Dependency Property MinimumLengthErrorMessage
        ///</summary>
        #region Dependency Property MinimumLengthErrorMessage
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string MinimumLengthErrorMessage
        {
            get { return (string)GetValue(MinimumLengthErrorMessageProperty); }
            set { SetValue(MinimumLengthErrorMessageProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for MinimumLengthErrorMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty MinimumLengthErrorMessageProperty = 
    AtomStringValidationRule.MinimumLengthErrorMessageProperty;
    
#else
        public static readonly DependencyProperty MinimumLengthErrorMessageProperty =
            AtomStringValidationRule.MinimumLengthErrorMessageProperty.AddOwner(typeof(AtomPasswordBox));
#endif

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
