#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Core;
using System.Reflection;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomComboBox extends the functionality of a standard ComboBox with search, filter and validation facilities.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomComboBox
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// extends the functionality of the standard ComboBox.
    /// </para>
    /// 			<para>
    /// A filter can be set to search through the data items in the ComboBox assisting the user to search for a specific data item.
    /// </para>
    /// 			<para>
    /// InvalidIndices can be set to identify which of the selections are invalid selections.
    /// </para>
    /// 			<para>
    /// Validation Errors can be customized and set to display specific errors for invalid selections or for no selection at all.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    //[TemplatePart(Name="",Type=typeof())]
        public partial class AtomComboBox : ComboBox 
    {


		#region partial void  OnCreate()
		partial void OnCreate()
		{
			AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "SelectedIndex", ValidationRule = AtomUtils.GetDefaultInstance<AtomSelectionValidationRule>() });

			AtomForm.SetMissingValueMessage(this, "Please select the item");
			AtomForm.SetInvalidValueMessage(this, "Invalid Selection");

#if SILVERLIGHT


            this.SetOneWayBinding(SelectedValueCache, this, "SelectedValue");
#endif
		}
		#endregion



#if SILVERLIGHT

        static AtomComboBox()
        {
            InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty;
        }

        private static DependencyProperty SelectedValueCache = DependencyProperty.Register("SelectedValueCache",typeof(object),typeof(AtomComboBox),
            new PropertyMetadata(null,OnSelectedValueCacheChanged));

        private static void OnSelectedValueCacheChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomComboBox cb = sender as AtomComboBox;
            if (cb != null)
            {
                cb.OnSelectedValueCacheChanged(e);
            }
        }

        private BindingExpression LastBinding = null;
        private object LastValue = null;

        #region private void OnSelectedValueCacheChanged(DependencyPropertyChangedEventArgs e)
        private void OnSelectedValueCacheChanged(DependencyPropertyChangedEventArgs e)
        {
            if (LastBinding == null)
            {
                LastBinding = this.GetBindingExpression(SelectedValueProperty);
            }
            else
            {
                /*BindingExpression be = this.GetBindingExpression(SelectedValueProperty);
                if (be == null) {
                    SelectLastValue();
                }*/
            }

            if (e.OldValue != null)
            {
                LastValue = e.OldValue;
            }
            else
            {
                if (LastValue == null)
                {
                    LastValue = e.NewValue;
                }
            }

        }
        #endregion

        #region protected override void  OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
            try
            {
                SelectLastValue();
            }
            catch (Exception ex)
            {
                //swallow exception..
                AtomTrace.WriteLine(ex.ToString());
            }
        }

        private AtomLogicContext selectionContext = new AtomLogicContext();
        #endregion

        #region private void SelectLastValue()
        private void SelectLastValue()
        {

            selectionContext.PreventRecursive(() =>
            {

                if (LastBinding != null)
                {
                    BindingExpression be = this.GetBindingExpression(SelectedValueProperty);
                    if (be == null)
                    {
                        SetBinding(SelectedValueProperty, LastBinding.ParentBinding);
                    }
                }

                //object currentValue = this.SelectedValue;
                //if (currentValue == LastValue)
                //    return;

                string valuePath = SelectedValuePath;
                if (string.IsNullOrEmpty(valuePath))
                    return;
                if (LastValue == null)
                    return;
                PropertyInfo pinfo = null;
                int i = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (pinfo == null)
                    {
                        pinfo = item.GetType().GetProperty(valuePath);
                    }
                    if (pinfo == null)
                    {
                        break;
                    }
                    object val = pinfo.GetValue(item, null);
                    if (val!=null && LastValue != null && val.Equals(LastValue))
                    {
                        this.SelectedIndex = i;
                        LastBinding.UpdateSource();
                        return;
                    }
                    i++;
                }

                //this.SelectedIndex = -1;
            });
        }
        #endregion




#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        #region protected override void  OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            try
            {
                BindingExpression be = this.GetBindingExpression(SelectedValueProperty);
                if (be != null)
                {
                    be.UpdateTarget();
                }
                base.OnItemsChanged(e);
            }
            catch (Exception ex)
            {
                //swallow exception..
                AtomTrace.WriteLine(ex.ToString());
            }
        }
        #endregion

#endif


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AtomComboBoxItemWithFilter();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is AtomComboBoxItemWithFilter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDownClosed(EventArgs e)
        {
            base.OnDropDownClosed(e);
            this.FilterText = "";
#if SILVERLIGHT
            WasFilterFocused = false;
#endif
        }


		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
#if SILVERLIGHT
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
            FilterTB = GetTemplateChild("PART_Filter") as AtomFilterTextBox;
            if (FilterTB != null)
            {
                
                FilterTB.GotFocus += new RoutedEventHandler(FilterTB_GotFocus);
                FilterTB.BindVisibility(() => this.IsFilterVisible);
                //FilterTB.SetOneWayBinding(AtomFilterTextBox.VisibilityProperty,this,"IsFilterVisible",AtomUtils.GetDefaultInstance<BooleanToVisibilityConverter>());
            }
#endif
		}
		#endregion


#if SILVERLIGHT

        void FilterTB_GotFocus(object sender, RoutedEventArgs e)
        {
            WasFilterFocused = true;
        }

        private AtomFilterTextBox FilterTB;
        private bool WasFilterFocused = false;

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (WasFilterFocused) {
                if (this.IsDropDownOpen)
                    FilterTB.Focus();
                else
                    WasFilterFocused = false;
            }
        }
#endif

    }

    /// <summary>
    /// Combo Box sometimes lags due to erroneous bindings when filtering, this class helps in removing lag.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public partial class AtomComboBoxItemWithFilter : ComboBoxItem
    {

    }

}
