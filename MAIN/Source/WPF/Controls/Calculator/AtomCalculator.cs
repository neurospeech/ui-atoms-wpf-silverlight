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
using NeuroSpeech.UIAtoms.Expressions;

namespace NeuroSpeech.UIAtoms.Controls
{


    /// <summary>
    /// 
    /// </summary>
    public partial class AtomCalculator : Control
    {


		private AtomLogicContext valueContext = new AtomLogicContext();


		#region partial void  OnAfterValueChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterValueChanged(DependencyPropertyChangedEventArgs e)
		{
			valueContext.PreventRecursive(() =>
			{
				// clear everything..
				Clear();

				if (PART_Value != null)
				{
					PART_Value.Text = Value.ToString();
				}
			});

			if (ValueChanged != null)
			{
				ValueChanged(this, e);
			}			
		}
		#endregion



        /// <summary>
        /// 
        /// </summary>
        public void Clear() 
        {
            // resets...
            if (PART_Value != null)
            {
                PART_Value.Text = "";
            }
            AppendMode = true;

            CurrentExpression = null;
            LastEntry = null;
            LastAction = null;
            LastValue = null;
            ExpressionHistory = "";

        }



        #region Buttons and Value
        private TextBox PART_Value;

        private Button PART_BKSP;
        private Button PART_Clear;
        private Button PART_ClearEntry;
        private Button PART_PosNeg;
        private Button PART_Root;

        private Button PART_Seven;
        private Button PART_Eight;
        private Button PART_Nine;
        private Button PART_Division;
        private Button PART_Modulo;

        private Button PART_Four;
        private Button PART_Five;
        private Button PART_Six;
        private Button PART_Mul;
        private Button PART_OnebyX;

        private Button PART_One;
        private Button PART_Two;
        private Button PART_Three;
        private Button PART_Minus;

        private Button PART_Zero;
        private Button PART_Zero2;
        private Button PART_Dot;
        private Button PART_Plus;
        private Button PART_Equal; 
        #endregion


		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
			PART_BKSP = (Button)GetTemplateChild("PART_BackSpace");
			PART_Clear = (Button)GetTemplateChild("PART_Clear");
			PART_ClearEntry = (Button)GetTemplateChild("PART_ClearEntry");
			PART_PosNeg = (Button)GetTemplateChild("PART_PosNeg");
			PART_Root = (Button)GetTemplateChild("PART_Root");

			PART_Seven = (Button)GetTemplateChild("PART_Seven");
			PART_Eight = (Button)GetTemplateChild("PART_Eight");
			PART_Nine = (Button)GetTemplateChild("PART_Nine");
			PART_Division = (Button)GetTemplateChild("PART_Division");
			PART_Modulo = (Button)GetTemplateChild("PART_Modulo");

			PART_Four = (Button)GetTemplateChild("PART_Four");
			PART_Five = (Button)GetTemplateChild("PART_Five");
			PART_Six = (Button)GetTemplateChild("PART_Six");
			PART_Mul = (Button)GetTemplateChild("PART_Mul");
			PART_OnebyX = (Button)GetTemplateChild("PART_OnebyX");

			PART_One = (Button)GetTemplateChild("PART_One");
			PART_Two = (Button)GetTemplateChild("PART_Two");
			PART_Three = (Button)GetTemplateChild("PART_Three");
			PART_Minus = (Button)GetTemplateChild("PART_Minus");

			PART_Zero = (Button)GetTemplateChild("PART_Zero");
			PART_Zero2 = (Button)GetTemplateChild("PART_Zero2");
			PART_Dot = (Button)GetTemplateChild("PART_Dot");
			PART_Plus = (Button)GetTemplateChild("PART_Plus");
			PART_Equal = (Button)GetTemplateChild("PART_Equal");

			PART_Value = (TextBox)GetTemplateChild("PART_Value");

			if (Value != 0)
			{
				PART_Value.Text = Value.ToString();
			}

			SetupEvents();
		}
		#endregion


        /// <summary>
        /// 
        /// </summary>
        #region SetupEvents
        private void SetupEvents()
        {
            PART_Zero.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Zero2.Click += new RoutedEventHandler(ContentButton_Click);
            PART_One.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Two.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Three.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Four.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Five.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Six.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Seven.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Eight.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Nine.Click += new RoutedEventHandler(ContentButton_Click);
            PART_Dot.Click += new RoutedEventHandler(ContentButton_Click);

            PART_Minus.Click += new RoutedEventHandler(PART_Minus_Click);
            PART_Plus.Click += new RoutedEventHandler(PART_Plus_Click);
            PART_Division.Click += new RoutedEventHandler(PART_Division_Click);
            PART_Modulo.Click += new RoutedEventHandler(PART_Modulo_Click);
            PART_Mul.Click += new RoutedEventHandler(PART_Mul_Click);
            PART_Root.Click += new RoutedEventHandler(PART_Root_Click);
            PART_OnebyX.Click += new RoutedEventHandler(PART_OnebyX_Click);
            PART_PosNeg.Click += new RoutedEventHandler(PART_PosNeg_Click);
            PART_Equal.Click += new RoutedEventHandler(PART_Equal_Click);
            PART_BKSP.Click += new RoutedEventHandler(PART_BKSP_Click);
            PART_Clear.Click += new RoutedEventHandler(PART_Clear_Click);
            PART_ClearEntry.Click += new RoutedEventHandler(PART_ClearEntry_Click);

            PART_Value.TextChanged += new TextChangedEventHandler(PART_Value_TextChanged);

        } 
        #endregion

        void PART_Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            //SaveValue();
        }

        void PART_ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            PART_Value.Text = "";
            AppendMode = true;
        }

        void PART_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        void PART_BKSP_Click(object sender, RoutedEventArgs e)
        {
            if (AppendMode)
            {
                string txt = PART_Value.Text;
                if (txt.Length > 0)
                {
                    PART_Value.Text = txt.Substring(0, txt.Length - 1);
                }
                else
                {
                    AtomUtils.Beep();
                }
            }
        }

        void PART_Equal_Click(object sender, RoutedEventArgs e)
        {
            SaveValue();    
        }

        private void SaveValue()
        {
            PerformOperation(false, null);

            valueContext.PreventRecursive(() =>
            {
                this.Value = decimal.Parse(PART_Value.Text);
            });
        }

        void PART_PosNeg_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(true, (x, y) => MathDecimalExpression.Neg(x));
        }

        void PART_OnebyX_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(true, (x, y) => MathDecimalExpression.Reciproc(x));
        }

        void PART_Root_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(true, (x, y) => MathDecimalExpression.Sqrt(x));
        }

        void PART_Mul_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(false, (x, y) => MathDecimalExpression.Mul(x, y));
        }

        void PART_Modulo_Click(object sender, RoutedEventArgs e)
        {
            BeforePerform();

            if (CurrentExpression != null) {

                BinaryMathExpression<decimal> be = CurrentExpression as BinaryMathExpression<decimal>;

                if (be != null)
                {
                    decimal right = LastEntry.Invoke();
                    decimal left = be.Left.Invoke();
                    right = (left * right) / (decimal)100;

                    PART_Value.Text = right.ToString();
                }
            }
        }

        void PART_Division_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(false, (x, y) => MathDecimalExpression.Div(x, y));
        }

        void PART_Plus_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(false, (x, y) => MathDecimalExpression.Add(x, y));
        }

        void PART_Minus_Click(object sender, RoutedEventArgs e)
        {
            PerformOperation(false, (x,y) => MathDecimalExpression.Sub(x,y));
        }

        private BaseMathExpression<decimal> CurrentExpression = null;

        private BaseMathExpression<decimal> LastEntry = null;
        private BaseMathExpression<decimal> LastValue = null;

        private InvokeOperationDelegate LastAction = null;

        private void PerformOperation(bool unary, InvokeOperationDelegate action)
        {
            try
            {
                BeforePerform();

                if (action == null)
                {
                    if (!unary)
                    {
                        PerformCalculation(action);
                        ExpressionHistory = "";
                    }
                }
                else
                {
                    if (unary)
                    {
                        PerformUnary(action);
                    }
                    else
                    {
                        PerformBinary(action);
                    }

                    // update expression history
                    ExpressionHistory = CurrentExpression.ToString();
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButton.OK);
            }
            // enable editing...
            AppendMode = false;
        }

        /// <summary>
        /// Executed when "=" sign is pressed
        /// </summary>
        /// <param name="action"></param>
        private void PerformCalculation(InvokeOperationDelegate action)
        {
            BinaryMathExpression<decimal> be = CurrentExpression as BinaryMathExpression<decimal>;
            if (be == null)
            {
                if (LastValue == null)
                    return;
                BaseMathExpression<decimal> value = LastAction(LastValue, LastEntry);
                LastValue = value.ValueExpression;
            }
            else
            {
                be.Right = LastEntry;
                
                // calculate
                LastValue = be.ValueExpression;
            }

            CurrentExpression = LastValue;
            PART_Value.Text = LastValue.Invoke().ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        private void PerformBinary(InvokeOperationDelegate action)
        {
            BinaryMathExpression<decimal> be = CurrentExpression as BinaryMathExpression<decimal>;

            LastAction = action;

            // nothing was entered, just change the sign..
            if (!AppendMode)
            {
                if (be != null)
                {
                    CurrentExpression = (BinaryMathExpression<decimal>)action(be.Left, null);
                    return;
                }
            }


            if (be == null)
            {
                CurrentExpression = (BinaryMathExpression<decimal>)LastAction(LastValue ?? LastEntry, null);
            }
            else
            {
                be.Right = LastValue ?? LastEntry;
                CurrentExpression = (BinaryMathExpression<decimal>)LastAction(CurrentExpression, null);
                PART_Value.Text = be.Invoke().ToString();
            }


        }

        private void PerformUnary(InvokeOperationDelegate action)
        {
            if (LastValue != null)
            {
                LastValue = action(LastValue, null);
                PART_Value.Text = LastValue.Invoke().ToString();
                CurrentExpression = LastValue;
            }
            else
            {
                LastEntry = action(LastEntry, null);
                PART_Value.Text = LastEntry.Invoke().ToString();
            }
        }

        private void BeforePerform()
        {
            if (AppendMode) { 
                // something was edited...
                LastEntry = new ConstantMathExpression<decimal>(decimal.Parse(PART_Value.Text));
                if (CurrentExpression == null) {
                    CurrentExpression = LastEntry;
                }
                LastValue = null;
            }            
        }


        





        private delegate BaseMathExpression<decimal> InvokeOperationDelegate(BaseMathExpression<decimal> lastExp , BaseMathExpression<decimal> curOp);



        private void ContentButton_Click(object sender, RoutedEventArgs e) 
        {
            Button b = (Button)sender;
            string txt = b.Content as string;

            AppendContent(txt);
        }

        private bool AppendMode = true;

        private void AppendContent(string txt)
        {
            string txtValue = "";
            if (AppendMode)
            {
                txtValue = PART_Value.Text;
            }
            AppendMode = true;
            txtValue += txt;

            decimal val = 0;
            if (decimal.TryParse(txtValue, out val))
            {
                PART_Value.Text = txtValue;
            }
            else
            {
                AtomUtils.Beep();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        #region Keyboard Bindings
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            switch (e.Key)
            {

                case Key.D0:
                case Key.NumPad0:
                    AppendContent("0");
                    break;

                case Key.D1:
                case Key.NumPad1:
                    AppendContent("1");
                    break;

                case Key.D2:
                case Key.NumPad2:
                    AppendContent("2");
                    break;

                case Key.D3:
                case Key.NumPad3:
                    AppendContent("3");
                    break;

                case Key.D4:
                case Key.NumPad4:
                    AppendContent("4");
                    break;

                case Key.D5:
                case Key.NumPad5:
                    AppendContent("5");
                    break;

                case Key.D6:
                case Key.NumPad6:
                    AppendContent("6");
                    break;

                case Key.D7:
                case Key.NumPad7:
                    AppendContent("7");
                    break;

                case Key.D8:
                case Key.NumPad8:
                    AppendContent("8");
                    break;

                case Key.D9:
                case Key.NumPad9:
                    AppendContent("9");
                    break;


                case Key.Delete:
                    PART_ClearEntry_Click(null, null);
                    break;

                case Key.Escape:
                    PART_Clear_Click(null, null);
                    break;

                case Key.Back:
                    PART_BKSP_Click(null, null);
                    break;

                case Key.Multiply:
                    PART_Mul_Click(null, null);
                    break;

                case Key.Enter:
                    PART_Equal_Click(null, null);
                    break;

                case Key.F9:
                    PART_PosNeg_Click(null, null);
                    break;

                case Key.R:
                    PART_OnebyX_Click(null, null);
                    break;

                case Key.D:
                    PART_Modulo_Click(null, null);
                    break;

                case Key.Divide:
                    PART_Division_Click(null, null);
                    break;

                case Key.Add:
                    PART_Plus_Click(null, null);
                    break;

                case Key.Subtract:
                    PART_Minus_Click(null, null);
                    break;
            }
        } 
        #endregion







    }
}
