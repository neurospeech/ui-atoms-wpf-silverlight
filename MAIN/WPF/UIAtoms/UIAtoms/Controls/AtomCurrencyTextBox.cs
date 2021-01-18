#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Data;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Validation;
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Dialogs;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomCurrencyTextBox is an intelligent numeric TextBox designed and configured to accept currency values.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomCurrencyTextBox
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// This control accepts only numerical inputs into the text box field in whole numbers. Once the period is pressed, it will accept decimal values as well. 
    /// </para>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// Additionally, an up and down arrow appears to the right of the text box, and clicking the up arrow will increment the value by one whole number, and likewise, clicking the down arrow will reduce the value by one whole number. 
    /// </para>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// The currency symbol can be customized as a string, and set to appear as a prefix to the numeric value displayed in the text box.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox=true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomCurrencyTextBox : AtomRangeBase<decimal, decimal>
    {
		#region partial void  OnCreate()
		partial void OnCreate()
		{
			Minimum = decimal.MinValue;
			Maximum = decimal.MaxValue;
			Step = 1;
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


        void PART_CALC_Click(object sender, RoutedEventArgs e)
        {
#if SILVERLIGHT
            AtomCalculatorDialog calc = new AtomCalculatorDialog();
            calc.Value = this.Value;
            calc.Closed += (s, e1) => {
                if (calc.DialogResult == true) {
                    this.Value = calc.Value;
                }
            };
            calc.Show();
#else
#endif
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


        private AtomLogicContext valueContext = new AtomLogicContext();

        void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            valueContext.PreventRecursive(() =>
            {
                decimal d = this.Value;
                if (TB.Text.Length == 0)
                {
                    d = 0;
                }
                else if (!decimal.TryParse(TB.Text, out d))
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
                decimal nd = this.Value;
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


    #region Old
    ///// <summary>
    ///// Currency with 2 decimal point editing.
    ///// </summary>
    ///// <remarks>Always starts editing before decimal point and by pressing tab key, it moves to next control.</remarks>
    //[TemplatePart(Name = "PART_Number", Type=typeof(AtomIntegerField))]
    //[TemplatePart(Name = "PART_Decimal", Type = typeof(AtomIntegerField))]
    //public class AtomCurrencyTextBox : AtomRangeBase<Decimal,Decimal>
    //{

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    static AtomCurrencyTextBox()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomCurrencyTextBox), new FrameworkPropertyMetadata(typeof(AtomCurrencyTextBox)));
    //        IsTabStopProperty.OverrideMetadata(typeof(AtomCurrencyTextBox), new FrameworkPropertyMetadata(false));
    //     }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public AtomCurrencyTextBox()
    //    {
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnInitialized(EventArgs e)
    //    {
    //        base.OnInitialized(e);
    //        CreateDefaultClipboardBinding();
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <returns></returns>
    //    protected override string GetValueForClipboard()
    //    {
    //        return Value.ToString();
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="p"></param>
    //    protected override void SetValueFromClipboard(string p)
    //    {
    //        decimal v = 0;
    //        if (Decimal.TryParse(p, out v))
    //            Value = v;
    //    }


    //    /// <summary>
    //    /// Currency Symbol
    //    /// <value>default "$"</value>
    //    /// </summary>
    //    #region Dependency Property CurrencySymbol
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("Currency Symbol")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string CurrencySymbol
    //    {
    //        get { return (string)GetValue(CurrencySymbolProperty); }
    //        set { SetValue(CurrencySymbolProperty, value); }
    //    }

    //    ///<summary> Using a DependencyProperty as the backing store for CurrencySymbol.  This enables animation, styling, binding, etc...</summary>
    //    public static readonly DependencyProperty CurrencySymbolProperty =
    //        DependencyProperty.Register("CurrencySymbol", typeof(string), typeof(AtomCurrencyTextBox), new UIPropertyMetadata("$"));


    //    #endregion

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    #region Dependency Property GroupNumbers
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("Not Avaliable in this Edition")]
    //    [System.ComponentModel.Browsable(true)]
    //    public bool GroupNumbers
    //    {
    //        get { return (bool)GetValue(GroupNumbersProperty); }
    //        set { SetValue(GroupNumbersProperty, value); }
    //    }

    //    ///<summary> Using a DependencyProperty as the backing store for GroupNumbers.  This enables animation, styling, binding, etc...</summary>
    //    public static readonly DependencyProperty GroupNumbersProperty =
    //        DependencyProperty.Register("GroupNumbers", typeof(bool), typeof(AtomCurrencyTextBox), new UIPropertyMetadata(false));


    //    #endregion


    //    private AtomTextField NumberTB;
    //    private AtomTextField DecimalTB;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public override void OnApplyTemplate()
    //    {
    //        base.OnApplyTemplate();

    //        NumberTB = GetNamedChild<AtomIntegerField>("PART_Number");
    //        DecimalTB = GetNamedChild<AtomIntegerField>("PART_Decimal");

    //        NumberTB.NextField = DecimalTB;
    //        NumberTB.OnDotMoveNext = true;
    //        NumberTB.OnDotMoveNextIfEmpty = true;
    //        DecimalTB.PrevField = NumberTB;
    //        DecimalTB.MaxLength = 2;

    //        NumberTB.TextChanged += new TextChangedEventHandler(NumberTB_TextChanged);
    //        DecimalTB.TextChanged += new TextChangedEventHandler(DecimalTB_TextChanged);

    //        ResetClipboardCommandBindings(NumberTB);
    //        ResetClipboardCommandBindings(DecimalTB);
    //    }



    //    private bool IsValueChanging = false;

    //    void DecimalTB_TextChanged(object sender, TextChangedEventArgs e)
    //    {
    //        AtomUtils.ProcessOneTime(ref IsValueChanging,
    //            () => {
    //                Value = Decimal.Parse(NumberTB.Text + "." + (string.IsNullOrEmpty(DecimalTB.Text) ? "0" : DecimalTB.Text));
    //            });
    //    }

    //    void NumberTB_TextChanged(object sender, TextChangedEventArgs e)
    //    {
    //        AtomUtils.ProcessOneTime(ref IsValueChanging,
    //            () =>
    //            {
    //                Value = Decimal.Parse(NumberTB.Text + "." + (string.IsNullOrEmpty(DecimalTB.Text) ? "0" : DecimalTB.Text));
    //            });
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnValueChanged(DependencyPropertyChangedEventArgs e)
    //    {

    //        AtomUtils.ProcessOneTime(ref IsValueChanging, () => {

    //            decimal v = Value;
    //            int n = (int)v;
    //            v = v - (decimal)n;
    //            v = v * 100;

    //            NumberTB.Text = n==0 ? "" : n.ToString();
    //            n = (int)v;
    //            DecimalTB.Text = n==0 ? "" : n.ToString();

    //        });

    //        base.OnValueChanged(e);



    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnCanDecrease(CanExecuteRoutedEventArgs e)
    //    {
    //        e.CanExecute = Value > Minimum;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnCanIncrease(CanExecuteRoutedEventArgs e)
    //    {
    //        e.CanExecute = Value < Maximum;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnIncrease(ExecutedRoutedEventArgs e)
    //    {
    //        Value += Step;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected override void OnDecrease(ExecutedRoutedEventArgs e)
    //    {
    //        Value -= Step;
    //    }
    //} 
    #endregion
}
