#if WINRT
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

namespace NeuroSpeech.UIAtoms.Core
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
    public class AtomNumberContainerControl : AtomContainerControl
    {
#if SILVERLIGHT
        public AtomNumberContainerControl()
        {
            DefaultStyleKey = typeof(AtomNumberContainerControl);
        }


#else
        static AtomNumberContainerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomNumberContainerControl),
                new FrameworkPropertyMetadata(typeof(AtomNumberContainerControl)));
        }
#endif
    }

    /// <summary>
    /// Range class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="StepT"></typeparam>
    public abstract class AtomRangeBase<T, StepT> : AtomNumberContainerControl
        where T:System.IComparable
    {

#if SILVERLIGHT
        public AtomRangeBase()
        {

        }
#else

        static AtomRangeBase()
        {


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


        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Minimum
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("Minimum")]
#if SILVERLIGHT
        [EditorBrowsable(EditorBrowsableState.Always)]
#else
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
        public T Minimum
        {
            get { return (T)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(T), typeof(AtomRangeBase<T, StepT>), new PropertyMetadata(default(T)));
#else
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(T), typeof(AtomRangeBase<T,StepT>), new UIPropertyMetadata(default(T)));
#endif

        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Maximum
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("Maximum")]
#if !SILVERLIGHT
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
        public T Maximum
        {
            get { return (T)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(T), typeof(AtomRangeBase<T,StepT>), new PropertyMetadata(default(T)));
#else
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(T), typeof(AtomRangeBase<T,StepT>), new UIPropertyMetadata(default(T)));
#endif


        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Value
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("Value")]
#if !SILVERLIGHT
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
        public T Value
        {
            get { return (T)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(T), typeof(AtomRangeBase<T, StepT>),
            new PropertyMetadata(default(T), OnValueChangedCallback));
#else
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(T), typeof(AtomRangeBase<T,StepT>), 
            new FrameworkPropertyMetadata(default(T), OnValueChangedCallback, OnValueCoerced));

        private static object OnValueCoerced(object sender, object value) { 
            AtomRangeBase<T,StepT> obj = sender as AtomRangeBase<T,StepT>;
            if(obj!=null){
                return obj.OnValueCoerced((T)value);
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
            AtomRangeBase<T,StepT> obj = d as AtomRangeBase<T,StepT>;
            if (obj != null)
            {
                obj.OnValueChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {
#if SILVERLIGHT
            T val = (T)e.NewValue;
            if (val.CompareTo(Minimum)<0) {
                this.Value = Minimum;
            }
            
            if (val.CompareTo(Maximum) > 0) {
                this.Value = Maximum;
            }

            // set buttons..
            EnableButtons();

#endif
            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion





        ///<summary>
        /// Increment or Decrement Step
        ///</summary>
        #region Dependency Property Step
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Description("Step")]
#if !SILVERLIGHT
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Browsable(true)]
#endif
        public StepT Step
        {
            get { return (StepT)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Step.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(StepT), typeof(AtomRangeBase<T, StepT>), new PropertyMetadata(default(T)));
#else
        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(StepT), typeof(AtomRangeBase<T,StepT>), new UIPropertyMetadata(default(T)));
#endif

        #endregion




    }
}
