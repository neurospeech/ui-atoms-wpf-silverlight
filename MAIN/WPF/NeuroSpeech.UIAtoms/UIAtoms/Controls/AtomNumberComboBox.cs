#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Controls;
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
    /// AtomNumberComboBox is an intelligent ComboBox that generates its numeric data.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomNumberComboBox
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// The AtomNumberComboBox is essentially an AtomComboBox with all the features of the ComboBox.
    /// </para>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// It has one added functionality wherein the data items are self-generated.
    /// </para>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// The StartNumber defines the starting point, EndNumber defines the ending point, and the IncrementBy defines the increment value. 
    /// </para>
    /// 		</item>
    /// 		<item>
    /// 			<para>
    /// Once set, the ComboBox will populate its entries by starting at the defined StartNumber, and incrementing itself to the next item by the IncrementBy parameter, and will stop once it reaches the EndNumber.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomNumberComboBox : AtomComboBox
    {

#if SILVERLIGHT
#else
        static AtomNumberComboBox()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ReArrangeNumbers();
        }
#endif

        private void ReArrangeNumbers()
        {
            object item = null;

            if (SelectedIndex != -1)
                item = this.SelectedItem;

            List<Decimal> newList = new List<decimal>();

            if (NumberStep == 0)
            {
                newList.Add(StartNumber);
                newList.Add(EndNumber);
            }
            else
            {
                decimal start = StartNumber;
                while (start <= EndNumber)
                {
                    newList.Add(start);
                    start += NumberStep;
                }
            }

            this.ItemsSource = newList;
            if (item != null)
            {
                decimal oldItem = (decimal)item;
                for (int i = 0; i < newList.Count; i++)
                {
                    if (newList[i] == oldItem) {
                        this.SelectedIndex = i;
                        return;
                    }
                }
            }
        }




        /// <summary>
        /// StartNumber defines the starting number of the NumberComboBox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// StartNumber
        /// </listheader>
        /// 		<item>
        /// StartNumber defines the starting value of the range of numbers from which to populate the items of the ComboBox.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property StartNumber
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public decimal StartNumber
        {
            get { return (decimal)GetValue(StartNumberProperty); }
            set { SetValue(StartNumberProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for StartNumber.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty StartNumberProperty =
            DependencyProperty.Register("StartNumber", typeof(decimal), typeof(AtomNumberComboBox), new PropertyMetadata(0M, OnStartNumberChangedCallback));
#else
        public static readonly DependencyProperty StartNumberProperty =
            DependencyProperty.Register("StartNumber", typeof(decimal), typeof(AtomNumberComboBox), new UIPropertyMetadata(0M, OnStartNumberChangedCallback));
#endif
        private static void OnStartNumberChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomNumberComboBox obj = d as AtomNumberComboBox;
            if (obj != null)
            {
                obj.OnStartNumberChanged(e);
            }
        }

        /// <summary>
        /// Fires StartNumberChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStartNumberChanged(DependencyPropertyChangedEventArgs e)
        {
            ReArrangeNumbers();
            if (StartNumberChanged != null)
            {
                StartNumberChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler StartNumberChanged;

        #endregion


        /// <summary>
        /// EndNumber defines the ending number of the NumberComboBox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// EndNumber
        /// </listheader>
        /// 		<item>
        /// EndNumber defines the ending value of the range of numbers from which to populate the items of the ComboBox.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property EndNumber
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public decimal EndNumber
        {
            get { return (decimal)GetValue(EndNumberProperty); }
            set { SetValue(EndNumberProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for EndNumber.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty EndNumberProperty =
            DependencyProperty.Register("EndNumber", typeof(decimal), typeof(AtomNumberComboBox), new PropertyMetadata(10.0M, OnEndNumberChangedCallback));
#else
        public static readonly DependencyProperty EndNumberProperty =
            DependencyProperty.Register("EndNumber", typeof(decimal), typeof(AtomNumberComboBox), new UIPropertyMetadata(10.0M, OnEndNumberChangedCallback));
#endif
        private static void OnEndNumberChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomNumberComboBox obj = d as AtomNumberComboBox;
            if (obj != null)
            {
                obj.OnEndNumberChanged(e);
            }
        }

        /// <summary>
        /// Fires EndNumberChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEndNumberChanged(DependencyPropertyChangedEventArgs e)
        {
            ReArrangeNumbers();
            if (EndNumberChanged != null)
            {
                EndNumberChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler EndNumberChanged;

        #endregion





        /// <summary>
        /// NumberStep defines the increment value for the items in the AtomNumberComboBox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// NumberStep
        /// </listheader>
        /// 		<item>
        /// This property defines the increment value from the StartNumber. 
        /// </item>
        /// 		<item>
        /// The AtomNumberComboBox will populate itself starting from the StartNumber, incrementing itself by the NumberStep, until it reaches the EndNumber.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property NumberStep
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public decimal NumberStep
        {
            get { return (decimal)GetValue(NumberStepProperty); }
            set { SetValue(NumberStepProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for NumberStep.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty NumberStepProperty =
            DependencyProperty.Register("NumberStep", typeof(decimal), typeof(AtomNumberComboBox), new PropertyMetadata(1.0M, OnNumberStepChangedCallback));
#else
        public static readonly DependencyProperty NumberStepProperty =
            DependencyProperty.Register("NumberStep", typeof(decimal), typeof(AtomNumberComboBox), new UIPropertyMetadata(1.0M, OnNumberStepChangedCallback));
#endif
        private static void OnNumberStepChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomNumberComboBox obj = d as AtomNumberComboBox;
            if (obj != null)
            {
                obj.OnNumberStepChanged(e);
            }
        }

        /// <summary>
        /// Fires NumberStepChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnNumberStepChanged(DependencyPropertyChangedEventArgs e)
        {
            ReArrangeNumbers();
            if (NumberStepChanged != null)
            {
                NumberStepChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler NumberStepChanged;

        #endregion



    }
}
