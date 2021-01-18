#if NETFX_CORE
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

namespace NeuroSpeech.UIAtoms.Controls
{


    /// <summary>
    /// AtomDoubleTextBox is a numeric text box for double type text. It will only accept floating point number.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomDoubleTextBox
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// AtomDoubleTextBox is designed to accept only numeric inputs and will accept the value as a floating point number. 
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomDoubleTextBox : AtomRangeBase<double, double>
    {
		#region partial void  OnCreate()
		partial void OnCreate()
		{
			Minimum = double.MinValue;
			Maximum = double.MaxValue;
			Step = (double)1;
		}
		#endregion


		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
			TB.TextChanged += new TextChangedEventHandler(TB_TextChanged);
			TB.Text = Value.ToString();

			string format = StringFormat;
			if (!string.IsNullOrEmpty(format))
			{
				SetFormat(format);
			}
		}
		#endregion


        private AtomLogicContext valueContext = new AtomLogicContext();

        void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            double d = this.Value;
            valueContext.PreventRecursive(() =>
            {
                if (TB.Text.Length == 0)
                {
                    d = 0;
                }
                else if (!double.TryParse(TB.Text, out d))
                {
                    if (d == 0)
                    {
                        TB.Text = "";
                    }
                    else
                    {
                        TB.Text = d.ToString();
                    }
                    AtomUtils.Beep();
                    return;
                }
                this.Value = d;
                double nd = this.Value;
                if (nd != d)
                {
                    if (nd == 0)
                        TB.Text = "";
                    else
                        TB.Text = nd.ToString();
                    AtomUtils.Beep();
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnValueChanged(e);
            valueContext.PreventRecursive(() =>
            {
                if(TB!=null)
                    TB.Text = this.Value.ToString();
            });
        }


		#region partial void  OnAfterStringFormatChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterStringFormatChanged(DependencyPropertyChangedEventArgs e)
		{
			if (TB == null)
				return;

			string format = e.OldValue as string;
			if (!string.IsNullOrEmpty(format))
			{
				TB.SetBinding(AtomTextBox.FormattedTextProperty, (Binding)null);
			}
			format = e.NewValue as string;
			SetFormat(format);
		}

		private void SetFormat(string format)
		{
#if SILVERLIGHT
            TB.SetOneWayBinding(AtomTextBox.FormattedTextProperty,this,"Value",new StringFormatConverter(format));
#else
			Binding b = new Binding();
			b.Source = this;
			b.StringFormat = format;
			b.Path = new PropertyPath(ValueProperty);
			TB.SetBinding(AtomTextBox.FormattedTextProperty, b);
#endif
		}

		#endregion



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool OnCanDecrease()
        {
            return Value > Minimum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool OnCanIncrease()
        {
            return Value < Maximum;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnIncrease()
        {
            Value += Step;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnDecrease()
        {
            Value -= Step;
        }
    }
}


/*
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Controls
{


    /// <summary>
    /// AtomDoubleTextBox is a numeric text box for double type text. It will only accept floating point number.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomDoubleTextBox
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// AtomDoubleTextBox is designed to accept only numeric inputs and will accept the value as a floating point number. 
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox=true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomDoubleTextBox : AtomNumberContainerControl
    {
#if SILVERLIGHT
        public AtomDoubleTextBox()
        {
            Minimum = double.MinValue;
            Maximum = double.MaxValue;
            Step = (double)1;
        }
#else
        static AtomDoubleTextBox()
        {

            MinimumProperty.OverrideMetadata(
                typeof(AtomDoubleTextBox),
                new FrameworkPropertyMetadata(double.MinValue));
            MaximumProperty.OverrideMetadata(
                typeof(AtomDoubleTextBox),
                new FrameworkPropertyMetadata(double.MaxValue));
            StepProperty.OverrideMetadata(
                typeof(AtomDoubleTextBox),
                new FrameworkPropertyMetadata((double)1));
        }
#endif


        ///<summary>
        /// Dependency Property Minimum
        ///</summary>
        #region Dependency Property Minimum
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(AtomDoubleTextBox), new PropertyMetadata(Double.MinValue, OnMinimumChangedCallback));

        private static void OnMinimumChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDoubleTextBox obj = d as AtomDoubleTextBox;
        }

#else
public static readonly DependencyProperty MinimumProperty = 
    DependencyProperty.Register("Minimum", typeof(double), typeof(AtomDoubleTextBox), new FrameworkPropertyMetadata(Double.MinValue));
#endif

        #endregion



        ///<summary>
        /// Dependency Property Maximum
        ///</summary>
        #region Dependency Property Maximum
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(AtomDoubleTextBox), new PropertyMetadata(Double.MaxValue, OnMaximumChangedCallback));

        private static void OnMaximumChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDoubleTextBox obj = d as AtomDoubleTextBox;
        }

#else
public static readonly DependencyProperty MaximumProperty = 
    DependencyProperty.Register("Maximum", typeof(double), typeof(AtomDoubleTextBox), new FrameworkPropertyMetadata(Double.MaxValue));
#endif

        #endregion



        ///<summary>
        /// Dependency Property Step
        ///</summary>
        #region Dependency Property Step
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Step.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(AtomDoubleTextBox), new PropertyMetadata((double)1, OnStepChangedCallback));

        private static void OnStepChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDoubleTextBox obj = d as AtomDoubleTextBox;
        }

#else
public static readonly DependencyProperty StepProperty = 
    DependencyProperty.Register("Step", typeof(double), typeof(AtomDoubleTextBox), new FrameworkPropertyMetadata((double)1));
#endif

        #endregion




        ///<summary>
        ///DependencyProperty Value
        ///</summary>
        #region Dependency Property Value
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(AtomDoubleTextBox), new PropertyMetadata((double)0, OnValueChangedCallback));
#else
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(AtomDoubleTextBox), 
            new FrameworkPropertyMetadata((double)0, OnValueChangedCallback, OnValueCoerced));

        private static object OnValueCoerced(object sender, object value) { 
            AtomDoubleTextBox obj = sender as AtomDoubleTextBox;
            if(obj!=null){
                return obj.OnValueCoerced(value);
            }
            return value;
        }

        private object OnValueCoerced(T value)
        {
            if (value.CompareTo(Minimum)<0) {
                this.Value = Minimum;
                return Minimum;
            }
            if (value.CompareTo(Maximum)>0) {
                this.Value = Maximum;
                return Maximum;
            }
            return value;
        }

#endif

        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDoubleTextBox obj = d as AtomDoubleTextBox;
            if (obj != null)
            {
                obj.OnValueChanged(e);
            }
        }

        /// <summary>
        /// Fires ValueChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {

#if SILVERLIGHT
            double val = (double)e.NewValue;
            if (val.CompareTo(Minimum) < 0)
            {
                this.Value = Minimum;
            }

            if (val.CompareTo(Maximum) > 0)
            {
                this.Value = Maximum;
            }

            // set buttons..
            EnableButtons();

            // update text..
            AtomUtils.ProcessOneTime(ref isValueChanging, () => {
                TB.Text = val.ToString();
            });

            Trace.WriteLine(string.Format("Value changed to .. " + e.NewValue.ToString()));
#endif

            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler ValueChanged;

        #endregion




        protected Button UpButton;
        protected Button DownButton;
        private AtomTextBox TB;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            TB = GetNamedChild<AtomTextBox>("PART_TextBox");

            TB.TextChanged += new TextChangedEventHandler(TB_TextChanged);
            //base.BindAttachedProperties(TB, TextBox.TextProperty, "Value");

            string format = StringFormat;
            if (!string.IsNullOrEmpty(format)) {
                SetFormat(format);
            }
            UpButton = GetNamedChild<Button>("PART_UP");
            DownButton = GetNamedChild<Button>("PART_DOWN");

            UpButton.Click += new RoutedEventHandler(UpButton_Click);
            DownButton.Click += new RoutedEventHandler(DownButton_Click);
            EnableButtons();
        }

        void DownButton_Click(object sender, RoutedEventArgs e)
        {
            OnDecrease();
        }

        void UpButton_Click(object sender, RoutedEventArgs e)
        {
            OnIncrease();
        }

        private void EnableButtons()
        {
            if (UpButton != null)
                UpButton.IsEnabled = OnCanIncrease();
            if (DownButton != null)
                DownButton.IsEnabled = OnCanDecrease();
        }

        private bool isValueChanging = false;

        void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            double d = this.Value;
            AtomUtils.ProcessOneTime(ref isValueChanging, () =>
            {
                if (TB.Text.Length == 0)
                {
                    d = 0;
                }
                else if (!double.TryParse(TB.Text, out d))
                {
                    if (d == 0)
                    {
                        TB.Text = "";
                    }
                    else
                    {
                        TB.Text = d.ToString();
                    }
                    AtomUtils.Beep();
                    return;
                }
                this.Value = d;
                // Update Bindings...
                this.UpdateValueBindings();
                Trace.WriteLine("Value set to " + d.ToString());
                double nd = this.Value;
                if (nd != d)
                {
                    if (nd == 0)
                        TB.Text = "";
                    else
                        TB.Text = nd.ToString();
                    AtomUtils.Beep();
                }
            });
        }

        private void UpdateValueBindings()
        {
#if SILVERLIGHT
            BindingExpression b = GetBindingExpression(ValueProperty);
            if (b != null)
                b.UpdateSource();
#endif
        }

        ///<summary>
        ///DependencyProperty StringFormat
        ///</summary>
        #region Dependency Property StringFormat
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string StringFormat
        {
            get { return (string)GetValue(StringFormatProperty); }
            set { SetValue(StringFormatProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for StringFormat.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty StringFormatProperty =
            DependencyProperty.Register("StringFormat", typeof(string), typeof(AtomDoubleTextBox), new PropertyMetadata("{0:N2}", OnStringFormatChangedCallback));

#else
        public static readonly DependencyProperty StringFormatProperty =
            DependencyProperty.Register("StringFormat", typeof(string), typeof(AtomDoubleTextBox), new UIPropertyMetadata("{0:N2}", OnStringFormatChangedCallback));
#endif
        private static void OnStringFormatChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDoubleTextBox obj = d as AtomDoubleTextBox;
            if (obj != null)
            {
                obj.OnStringFormatChanged(e);
            }
        }

        /// <summary>
        /// Fires StringFormatChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStringFormatChanged(DependencyPropertyChangedEventArgs e)
        {

            if (TB == null)
                return;

            string format = e.OldValue as string;
            if (!string.IsNullOrEmpty(format)) {
                TB.SetBinding(AtomTextBox.FormattedTextProperty, (Binding)null);
            }
            format = e.NewValue as string;
            SetFormat(format);

            if (StringFormatChanged != null)
            {
                StringFormatChanged(this, EventArgs.Empty);
            }
        }

        private void SetFormat(string format)
        {
#if SILVERLIGHT
            AtomUtils.BindControls(
                this,
                ValueProperty,
                TB,
                AtomTextBox.FormattedTextProperty,
                new StringFormatConverter(format));
#else
            Binding b = new Binding();
            b.Source = this;
            b.StringFormat = format;
            b.Path = new PropertyPath(ValueProperty);
            TB.SetBinding(AtomTextBox.FormattedTextProperty, b);
#endif
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler StringFormatChanged;

        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool OnCanDecrease()
        {
            return Value > Minimum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected bool OnCanIncrease()
        {
            return Value < Maximum;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void OnIncrease()
        {
            Value += Step;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void OnDecrease()
        {
            Value -= Step;
        }
    }
}

 */
