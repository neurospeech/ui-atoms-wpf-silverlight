#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Validation;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
#if SILVERLIGHT
    [TemplateVisualState(Name = "Focused")]
    [TemplateVisualState(Name = "Pressed")]
    [TemplateVisualState(Name = "Normal")]
#endif
    public class AtomErrorDisplay : Control
    {

#if SILVERLIGHT
        public AtomErrorDisplay()
        {
            DefaultStyleKey = typeof(AtomErrorDisplay);
        }
#else
        static AtomErrorDisplay()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomErrorDisplay), new FrameworkPropertyMetadata(typeof(AtomErrorDisplay)));
        }
#endif


        ///<summary>
        /// Dependency Property ValidationError
        ///</summary>
        #region Dependency Property ValidationError
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public AtomValidationError ValidationError
        {
            get { return (AtomValidationError)GetValue(ValidationErrorProperty); }
            set { SetValue(ValidationErrorProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ValidationError.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValidationErrorProperty = 
            DependencyProperty.Register("ValidationError", typeof(AtomValidationError), typeof(AtomErrorDisplay), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ValidationErrorProperty =
            DependencyProperty.Register("ValidationError", typeof(AtomValidationError), typeof(AtomErrorDisplay), new FrameworkPropertyMetadata(null));
#endif

        #endregion



        ///<summary>
        /// Dependency Property IsPressed
        ///</summary>
        #region Dependency Property IsPressed
        [AtomDesign(
          Category = "Atoms",
          Bindable = false,
          BrowseMode = AtomPropertyBrowseMode.Never
        )]
        public bool IsPressed
        {
            get { return (bool)GetValue(IsPressedProperty); }
            set { SetValue(IsPressedProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for IsPressed.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty IsPressedProperty = 
            DependencyProperty.Register("IsPressed", typeof(bool), typeof(AtomErrorDisplay), new PropertyMetadata(false, OnIsPressedPropertyChanged));

        private static void OnIsPressedPropertyChanged(object sender, DependencyPropertyChangedEventArgs e) 
        {
            AtomErrorDisplay error = sender as AtomErrorDisplay;
            if (error != null) 
            {
                error.OnIsPressedChanged(e);
            }
        }

        private void OnIsPressedChanged(DependencyPropertyChangedEventArgs e)
        {
            bool val = (bool)e.NewValue;
            if (val)
            {
                VisualStateManager.GoToState(this,"Pressed",true);
            }
            else 
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
        }
#else
        public static readonly DependencyProperty IsPressedProperty =
            DependencyProperty.Register("IsPressed", typeof(bool), typeof(AtomErrorDisplay), new FrameworkPropertyMetadata(false));
#endif

        #endregion

#if SILVERLIGHT

        private TextBlock innerTB;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            innerTB = GetTemplateChild("textBlock") as TextBlock;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            VisualStateManager.GoToState(this, "Focused", true);

            if (innerTB != null) {
                innerTB.TextDecorations = TextDecorations.Underline;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            VisualStateManager.GoToState(this, "Normal", true);
            if (innerTB != null) {
                innerTB.TextDecorations = null;
            }
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            IsPressed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            IsPressed = false;

            AtomPasswordBox ap = ValidationError.Source as AtomPasswordBox;
            if (ap != null) {
                ap.FocusPasswordBox();
                return;
            }

#if !SILVERLIGHT
            // set focus to error source...
            IInputElement ie = ValidationError.Source as IInputElement;
            if (ie != null)
            {
                Keyboard.Focus(ie);
                return;
            }
#endif

            Control c = ValidationError.Source as Control;
            if (c != null) 
            {
                c.Focus();
            }
        }

    }
}
