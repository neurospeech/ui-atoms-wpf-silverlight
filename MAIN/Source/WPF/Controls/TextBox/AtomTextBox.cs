#if NETFX_CORE
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
    public partial class AtomTextBox : TextBox 
    {

		#region partial void  OnCreate()
		partial void OnCreate()
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
		#endregion




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





		#region partial void  OnAfterFormattedTextChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterFormattedTextChanged(DependencyPropertyChangedEventArgs e)
		{
			this.HasFormattedText = !string.IsNullOrEmpty(e.NewValue as string);
		}
		#endregion



    }
}
