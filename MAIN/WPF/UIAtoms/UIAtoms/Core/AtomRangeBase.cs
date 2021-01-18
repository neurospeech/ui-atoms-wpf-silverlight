#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Input;
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
    /// Serves as a base class for 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomCurrencyTextBox"/>, 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomDoubleTextBox"/> and 
    /// <see cref="T:NeuroSpeech.UIAtoms.Controls.AtomIntegerTextBox"/> 
    /// which encapsulates property binding and validation.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomNumberContainerControl : AtomContainerControl
    {
    }

    /// <summary>
    /// Range class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="StepT"></typeparam>
    public abstract partial class AtomRangeBase<T, StepT> : AtomNumberContainerControl
        where T:System.IComparable
    {

		#region static partial void  OnCreateStatic()
		static partial void OnCreateStatic()
		{
#if SILVERLIGHT || NETFX_CORE
#else
			CommandManager.RegisterClassCommandBinding(
				typeof(AtomRangeBase<T, StepT>),
				new CommandBinding(
					System.Windows.Controls.Slider.IncreaseLarge,
					IncreaseSmallExecuted,
					CanExecuteIncreaseSmall));

			CommandManager.RegisterClassCommandBinding(
				typeof(AtomRangeBase<T, StepT>),
				new CommandBinding(
					System.Windows.Controls.Slider.DecreaseLarge,
					IncreaseSmallExecuted,
					CanExecuteIncreaseSmall));
#endif
		}
		#endregion


#if SILVERLIGHT
        public AtomRangeBase()
        {

        }

#endif

#if SILVERLIGHT

        protected Button UpButton;
        protected Button DownButton;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

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

        private void EnableButtons() {
            if (UpButton != null)
                UpButton.IsEnabled = OnCanIncrease();
            if (DownButton != null)
                DownButton.IsEnabled = OnCanDecrease();
        }
#else
        private static void IncreaseSmallExecuted(object sender, ExecutedRoutedEventArgs e) {
            AtomRangeBase<T, StepT> rb = sender as AtomRangeBase<T, StepT>;
            if (rb != null) {
                ICommand cmd = e.Command;
                if (cmd == System.Windows.Controls.Slider.IncreaseSmall ||
                    cmd == System.Windows.Controls.Slider.IncreaseLarge)
                {
                    e.Handled = true;
                    rb.OnIncrease();
                }
                else if (cmd == System.Windows.Controls.Slider.DecreaseSmall ||
                    cmd == System.Windows.Controls.Slider.DecreaseLarge)
                {
                    e.Handled = true;
                    rb.OnDecrease();
                }
            }
        }

        private static void CanExecuteIncreaseSmall(object sender, CanExecuteRoutedEventArgs e)
        {
            AtomRangeBase<T, StepT> rb = sender as AtomRangeBase<T, StepT>;
            if (rb != null)
            {
                ICommand cmd = e.Command;
                if (cmd == System.Windows.Controls.Slider.IncreaseSmall ||
                    cmd == System.Windows.Controls.Slider.IncreaseLarge)
                {
                    e.Handled = true;
                    e.CanExecute = rb.OnCanIncrease();
                }
                else if (cmd == System.Windows.Controls.Slider.DecreaseSmall ||
                    cmd == System.Windows.Controls.Slider.DecreaseLarge)
                {
                    e.Handled = true;
                    e.CanExecute = rb.OnCanDecrease();
                }
            }
        }


#endif

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnDecrease()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnIncrease()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnCanDecrease()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool OnCanIncrease()
        {
            return false;
        }

		#region partial void  OnAfterValueChanged(DependencyPropertyChangedEventArgs e)
		partial void  OnAfterValueChanged(DependencyPropertyChangedEventArgs e)
		{
 	
            T val = (T)e.NewValue;
            if (val.CompareTo(Minimum)<0) {
                this.Value = Minimum;
            }
            
            if (val.CompareTo(Maximum) > 0) {
                this.Value = Maximum;
            }

#if SILVERLIGHT
            // set buttons..
            EnableButtons();

#endif
		}
		#endregion

    }
}
