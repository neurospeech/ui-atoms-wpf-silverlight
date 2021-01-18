#if WINRT
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
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomIntegerTextBox is an extension of the AtomTextBox designed only to accept numeric whole number inputs.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomIntegerTextBox
    /// </listheader>
    /// 		<item>
    /// This control is designed to accept only numeric whole number inputs. 
    /// </item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomIntegerTextBox : AtomRangeBase<int, int>
    {
#if SILVERLIGHT
        public AtomIntegerTextBox()
        {
            this.Maximum = int.MaxValue;
            this.Minimum = int.MinValue;
            Step = (int)1;
        }
#else
        static AtomIntegerTextBox()
        {

            MinimumProperty.OverrideMetadata(
                typeof(AtomIntegerTextBox),
                new FrameworkPropertyMetadata(int.MinValue));
            MaximumProperty.OverrideMetadata(
                typeof(AtomIntegerTextBox),
                new FrameworkPropertyMetadata(int.MaxValue));
            StepProperty.OverrideMetadata(
                typeof(AtomIntegerTextBox),
                new FrameworkPropertyMetadata((int)1));
        }
#endif

        private AtomTextBox TB;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            TB = GetNamedChild<AtomTextBox>("PART_TextBox");

            TB.TextChanged += new TextChangedEventHandler(TB_TextChanged);
            TB.Text = Value.ToString();
            string format = StringFormat;
            if (!string.IsNullOrEmpty(format))
            {
                SetFormat(format);
            }
        }

        private AtomLogicContext valueContext = new AtomLogicContext();

        void TB_TextChanged(object sender, TextChangedEventArgs e)
        {
            valueContext.PreventRecursive(() =>
            {
                int d = this.Value;
                if (TB.Text.Length == 0)
                {
                    d = 0;
                }
                else if (!int.TryParse(TB.Text, out d))
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
                int nd = this.Value;
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
        /// StringFormat defines the format in which the integers will appear in an AtomIntegerTextBox
        /// </summary>
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
            DependencyProperty.Register("StringFormat", typeof(string), typeof(AtomIntegerTextBox), new PropertyMetadata("{0:#,###,##0}", OnStringFormatChangedCallback));

#else
        public static readonly DependencyProperty StringFormatProperty =
            DependencyProperty.Register("StringFormat", typeof(string), typeof(AtomIntegerTextBox), new UIPropertyMetadata("{0:#,###,##0}", OnStringFormatChangedCallback));
#endif
        private static void OnStringFormatChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomIntegerTextBox obj = d as AtomIntegerTextBox;
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
            if (!string.IsNullOrEmpty(format))
            {
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
            TB.SetOneWayBinding(AtomTextBox.FormattedTextProperty,this,"Value",new StringFormatConverter(format));
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
    ///// Textbox that accepts only integer as valid input.
    ///// </summary>
    //[ToolboxItem(false)]
    //public class AtomIntegerTextBox : AtomNumberTextBox
    //{

    //    static AtomIntegerTextBox(){

    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public AtomIntegerTextBox()
    //    {

    //    }

    //} 
    #endregion
}
