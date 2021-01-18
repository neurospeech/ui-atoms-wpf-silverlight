#if NETFX_CORE
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
    public partial class AtomNumberComboBox : AtomComboBox
    {

#if SILVERLIGHT
#else

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



		#region partial void  OnAfterEndNumberChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterEndNumberChanged(DependencyPropertyChangedEventArgs e)
		{
			ReArrangeNumbers();
		}
		#endregion

		#region partial void  OnAfterNumberStepChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterNumberStepChanged(DependencyPropertyChangedEventArgs e)
		{
			ReArrangeNumbers();
		}
		#endregion

		#region partial void  OnAfterStartNumberChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterStartNumberChanged(DependencyPropertyChangedEventArgs e)
		{
			ReArrangeNumbers();
		}
		#endregion





    }
}
