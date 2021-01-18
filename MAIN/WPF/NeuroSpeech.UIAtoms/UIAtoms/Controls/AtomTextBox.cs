#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Input;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;


namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// TextBox is a control that is used to display or edit unformatted text. It contains validation functionalities in addition to other parameters.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// The Atom TextBox is a control with the following customizable parameters:
    /// </listheader>
    /// 		<item>
    /// 			<term>Watermark
    /// </term>
    /// 			<description>displays a watermark within the TextBox, which automatically gets removed once the cursor is brought to the field.
    /// </description>
    /// 		</item>
    /// 		<item>
    /// 			<term>Formatted Text
    /// </term>
    /// 			<description>when the cursor is on the text box, a normal text box will be displayed, and when the cursor is outside the text box, the formatted textbox will be displayed.
    /// </description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomTextBox : TextBox 
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomTextBox()
        {

#if SILVERLIGHT
            DefaultStyleKey = typeof(AtomTextBox);
            //Width = 150;
            //HorizontalAlignment = System.Windows.HorizontalAlignment.Left;



            this.SetOneWayBinding(HasTextProperty,this,"Text",AtomUtils.GetDefaultInstance<StringToBooleanConverter>());

            this.TextChanged += new TextChangedEventHandler(AtomTextBox_TextChanged);
#endif
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomStringValidationRule>() });
        }

#if SILVERLIGHT
        void AtomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e);
        }

        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            string t = Text;
            HasText = !string.IsNullOrEmpty(t);

            // update binding...
            BindingExpression be = GetBindingExpression(TextBox.TextProperty);
            if (be != null)
                be.UpdateSource();
        }
#else
        static AtomTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomTextBox), new FrameworkPropertyMetadata(typeof(AtomTextBox)));




        }
#endif


#if SILVERLIGHT

        private TextBlock FormattedTB;
        private TextBlock WatermarkTB;
        private ScrollViewer ContentElement;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            FormattedTB = GetTemplateChild("PART_Formatted") as TextBlock;
            WatermarkTB = GetTemplateChild("PART_Watermark") as TextBlock;
            ContentElement = GetTemplateChild("ContentElement") as ScrollViewer;
            

            // install visibility..
            if (WatermarkTB != null)
            {
                WatermarkTB.SetOneWayBinding(TextBlock.VisibilityProperty,this,"HasText",AtomUtils.GetDefaultInstance<OppositeBooleanToVisibilityConverter>());
            }

            this.MouseLeftButtonDown += new MouseButtonEventHandler(AtomTextBox_MouseLeftButtonDown);

            SetupFormattedTextBinding();

        }

        void AtomTextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RemoveFormattedTextBinding();
            e.Handled = true;
            //this.Focus();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            RemoveFormattedTextBinding();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            SetupFormattedTextBinding();
        }

        private void SetupFormattedTextBinding()
        {
            if (ContentElement != null) 
            {
                ContentElement.SetOneWayBinding(Control.VisibilityProperty,this,"HasFormattedText",AtomUtils.GetDefaultInstance<OppositeBooleanToVisibilityConverter>());
            }
            if (FormattedTB != null) 
            {
                FormattedTB.SetOneWayBinding(Control.VisibilityProperty,this,"HasFormattedText",AtomUtils.GetDefaultInstance<BooleanToVisibilityConverter>());
            }
        }

        private void RemoveFormattedTextBinding() 
        {
            if (ContentElement != null) 
            {
                ContentElement.ClearValue(Control.VisibilityProperty);
                ContentElement.Visibility = System.Windows.Visibility.Visible;
            }
            if (FormattedTB != null)
            {
                FormattedTB.ClearValue(Control.VisibilityProperty);
                FormattedTB.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            Binding b = new Binding();
            b.Source = this;
            b.Path = new PropertyPath(TextProperty);
            b.Converter = AtomUtils.GetDefaultInstance<StringToBooleanConverter>();
            this.SetBinding(HasTextProperty, b);

        }
#endif



        /// <summary>
        /// This is used internally.
        /// </summary>
        #region Dependency Property HasText

        [AtomDesign(
            BrowseMode = AtomPropertyBrowseMode.Never
            )]
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            set { SetValue(HasTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for HasText.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.Register("HasText", typeof(bool), typeof(AtomTextBox), new PropertyMetadata(false));

#else        
        public static readonly DependencyProperty HasTextProperty = 
            DependencyProperty.Register("HasText", typeof(bool), typeof(AtomTextBox), new FrameworkPropertyMetadata(false));
#endif

        #endregion



        /// <summary>
        /// Displays watermark on the textbox when text is empty.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// TextBox Watermark Property
        /// </listheader>
        /// 		<item>
        /// This property places predefined text in an empty text box field as a watermark.
        /// </item>
        /// 		<item>
        /// The color of the text to be displayed can be changed. The default is gray.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property WatermarkText
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]

        public string WatermarkText
        {
            get { return (string)GetValue(WatermarkTextProperty); }
            set { SetValue(WatermarkTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(AtomTextBox), new PropertyMetadata(null, OnWatermarkChangedCallback));
#else
        public static readonly DependencyProperty WatermarkTextProperty =
            DependencyProperty.Register("WatermarkText", typeof(string), typeof(AtomTextBox), new UIPropertyMetadata(null, OnWatermarkChangedCallback));
#endif
        private static void OnWatermarkChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomTextBox obj = d as AtomTextBox;
            if (obj != null)
            {
                obj.OnWatermarkChanged(e);
            }
        }

        /// <summary>
        /// Fires WatermarkChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWatermarkChanged(DependencyPropertyChangedEventArgs e)
        {
            if (WatermarkChanged != null)
            {
                WatermarkChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler WatermarkChanged;

        #endregion



        /// <summary>
        /// This property defines the color of the displayed Watermark.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// WatermarkColor
        /// </listheader>
        /// 		<item>
        /// The color of the watermark can be altered using this property.
        /// </item>
        /// 		<item>
        /// The default value of the color is light gray.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property WatermarkColor
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]

        public Brush WatermarkColor
        {
            get { return (Brush)GetValue(WatermarkColorProperty); }
            set { SetValue(WatermarkColorProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for WatermarkColor.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty WatermarkColorProperty =
            DependencyProperty.Register("WatermarkColor", typeof(Brush), typeof(AtomTextBox), new PropertyMetadata(new SolidColorBrush(Colors.LightGray)));
#else
        public static readonly DependencyProperty WatermarkColorProperty =
            DependencyProperty.Register("WatermarkColor", typeof(Brush), typeof(AtomTextBox), new UIPropertyMetadata(Brushes.LightGray));
#endif

        #endregion




        /// <summary>
        /// Controls Alignment of the Watermark inside Textbox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// WatermarkAlign
        /// </listheader>
        /// 		<item>
        /// This property defines the alignment and position of the watermark text.
        /// </item>
        /// 		<item>
        /// The watermark can be aligned to be displayed at the beginning of the TextBox, middle of the TextBox, or the end of the TextBox.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property WatermarkAlign
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]

        public HorizontalAlignment WatermarkAlign
        {
            get { return (HorizontalAlignment)GetValue(WatermarkAlignProperty); }
            set { SetValue(WatermarkAlignProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for WatermarkAlign.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty WatermarkAlignProperty =
            DependencyProperty.Register("WatermarkAlign", typeof(HorizontalAlignment), typeof(AtomTextBox), new PropertyMetadata(HorizontalAlignment.Left));
#else
        public static readonly DependencyProperty WatermarkAlignProperty =
            DependencyProperty.Register("WatermarkAlign", typeof(HorizontalAlignment), typeof(AtomTextBox), new UIPropertyMetadata(HorizontalAlignment.Left));
#endif

        #endregion




        /// <summary>
        /// This property should be used by the class that will extend the functionality of the AtomTextBox.
        /// </summary>
        #region Dependency Property FormattedText
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string FormattedText
        {
            get { return (string)GetValue(FormattedTextProperty); }
            set { SetValue(FormattedTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FormattedText.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.Register("FormattedText", typeof(string), typeof(AtomTextBox), new PropertyMetadata(null, OnFormattedTextChangedCallback));
#else
        public static readonly DependencyProperty FormattedTextProperty =
            DependencyProperty.Register("FormattedText", typeof(string), typeof(AtomTextBox), new UIPropertyMetadata(null, OnFormattedTextChangedCallback));
#endif
        private static void OnFormattedTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomTextBox obj = d as AtomTextBox;
            if (obj != null)
            {
                obj.OnFormattedTextChanged(e);
            }
        }

        /// <summary>
        /// Fires FormattedTextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFormattedTextChanged(DependencyPropertyChangedEventArgs e)
        {
            this.HasFormattedText = !string.IsNullOrEmpty(e.NewValue as string);
            if (FormattedTextChanged != null)
            {
                FormattedTextChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FormattedTextChanged;

        #endregion





        /// <summary>
        /// This is used internally.
        /// </summary>
        #region Dependency Property HasFormattedText
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Never
            )]
        public bool HasFormattedText
        {
            get { return (bool)GetValue(HasFormattedTextProperty); }
            set { SetValue(HasFormattedTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for HasFormattedText.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HasFormattedTextProperty =
            DependencyProperty.Register("HasFormattedText", typeof(bool), typeof(AtomTextBox), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty HasFormattedTextProperty =
            DependencyProperty.Register("HasFormattedText", typeof(bool), typeof(AtomTextBox), new UIPropertyMetadata(false));
#endif

        #endregion



        ///<summary>
        /// Dependency Property MinimumLength
        ///</summary>
        #region Dependency Property MinimumLength
        [AtomDesign(
          Category = "Atoms.Validation",
          Description="0 or -1 means no limit",
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
            AtomStringValidationRule.MinimumLengthProperty.AddOwner(typeof(AtomTextBox));
#endif

        #endregion


        ///<summary>
        /// Dependency Property MinimumLengthErrorMessage
        ///</summary>
        #region Dependency Property MinimumLengthErrorMessage
        [AtomDesign(
          Category = "Atoms.Validation",
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
            AtomStringValidationRule.MinimumLengthErrorMessageProperty.AddOwner(typeof(AtomTextBox));
#endif

        #endregion



    }
}
