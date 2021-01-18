#if WINRT
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
        public class AtomComboBox : ComboBox 
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomComboBox()
        {
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "SelectedIndex", ValidationRule = AtomUtils.GetDefaultInstance<AtomSelectionValidationRule>() });

#if SILVERLIGHT
            DefaultStyleKey = typeof(AtomComboBox);
            AtomForm.SetMissingValueMessage(this, "Please select the item");
            AtomForm.SetInvalidValueMessage(this, "Invalid Selection");


            this.SetOneWayBinding(SelectedValueCache, this, "SelectedValue");
#endif


        }

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
        static AtomComboBox()
        {

            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomComboBox), new FrameworkPropertyMetadata(typeof(AtomComboBox)));

            InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty.AddOwner(typeof(AtomComboBox));

            AtomForm.MissingValueMessageProperty.OverrideMetadata(
                typeof(AtomComboBox),
                new FrameworkPropertyMetadata("Please select the item"));

            AtomForm.InvalidValueMessageProperty.OverrideMetadata(
                typeof(AtomComboBox),
                new FrameworkPropertyMetadata("Invalid Selection"));

            
        
        }

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
        /// This property determines which selection is triggered as invalid
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// InvalidIndices
        /// </listheader>
        /// 		<item>
        /// This property determines which index is invalid.
        /// </item>
        /// 		<item>
        /// The default value is set to -1.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property InvalidIndices
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        [TypeConverter(typeof(CSVToArrayTypeConverter))]
        public int[] InvalidIndices
        {
            get { return (int[])GetValue(InvalidIndicesProperty); }
            set { SetValue(InvalidIndicesProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for InvalidIndices.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty InvalidIndicesProperty;
        #endregion        

        /// <summary>
        /// This property decides whether or not the Filter is used for the particular ItemsControl
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// IsFilterVisible
        /// </listheader>
        /// 		<item>
        /// This property, when set true, displays a Filter Box on top of the bound ItemsControl and filters the items displayed in the list based on the text input provided.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property IsFilterVisible
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public bool IsFilterVisible
        {
            get { return (bool)GetValue(IsFilterVisibleProperty); }
            set { SetValue(IsFilterVisibleProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for IsFilterVisible.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty IsFilterVisibleProperty =
            DependencyProperty.Register("IsFilterVisible", typeof(bool), typeof(AtomComboBox), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty IsFilterVisibleProperty =
            DependencyProperty.Register("IsFilterVisible", typeof(bool), typeof(AtomComboBox), new FrameworkPropertyMetadata(false));
#endif

        #endregion



        /// <summary>
        /// FilterText accepts the text input from the user
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FilterText
        /// </listheader>
        /// 		<item>
        /// is the text that is in the text box, as entered by the user.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property FilterText
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string FilterText
        {
            get { return (string)GetValue(FilterTextProperty); }
            set { SetValue(FilterTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AtomComboBox), new PropertyMetadata(""));
#else
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AtomComboBox), new UIPropertyMetadata(""));
#endif

        #endregion



        /// <summary>
        /// FilterMode sets the mode with which to filter the text.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FilterMode
        /// </listheader>
        /// 		<item>
        /// is an enumerator of type AtomTextFilterMode.
        /// </item>
        /// 		<item>
        /// It identifies how the string search should be done. For example, StartsWith will return all the items starting with specified FilterText.
        /// </item>
        /// 		<item>
        /// The FilterMode can be customizes to filter the items based on your own logic.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property FilterMode
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public AtomTextFilterMode FilterMode
        {
            get { return (AtomTextFilterMode)GetValue(FilterModeProperty); }
            set { SetValue(FilterModeProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FilterMode.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FilterModeProperty =
            DependencyProperty.Register("FilterMode", typeof(AtomTextFilterMode), typeof(AtomComboBox), new PropertyMetadata(AtomTextFilterMode.StartsWith));
#else
        public static readonly DependencyProperty FilterModeProperty =
            AtomFilterTextBox.FilterModeProperty.AddOwner(typeof(AtomComboBox), new UIPropertyMetadata(AtomTextFilterMode.StartsWith));
#endif

        #endregion



        /// <summary>
        /// FilterComparison - A String Comparison
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FilterComparison
        /// </listheader>
        /// 		<item>
        /// Filter Comparison is a StringComparison which is used to compare strings.
        /// </item>
        /// 		<item>
        /// The default is CurrentCultureIgnoreCase.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property FilterComparison
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public StringComparison FilterComparison
        {
            get { return (StringComparison)GetValue(FilterComparisonProperty); }
            set { SetValue(FilterComparisonProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FilterComparison.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FilterComparisonProperty =
            DependencyProperty.Register("FilterComparison", typeof(StringComparison), typeof(AtomComboBox), new PropertyMetadata(StringComparison.CurrentCultureIgnoreCase));
#else
        public static readonly DependencyProperty FilterComparisonProperty =
            AtomFilterTextBox.FilterComparisonProperty.AddOwner(typeof(AtomComboBox), new UIPropertyMetadata(StringComparison.CurrentCultureIgnoreCase));
#endif

        #endregion



        ///<summary>
        /// Dependency Property FilterProvider
        ///</summary>
        #region Dependency Property FilterProvider
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public IAtomItemsFilter FilterProvider
        {
            get { return (IAtomItemsFilter)GetValue(FilterProviderProperty); }
            set { SetValue(FilterProviderProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FilterProvider.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FilterProviderProperty =
            DependencyProperty.Register("FilterProvider", typeof(IAtomItemsFilter), typeof(AtomComboBox), new PropertyMetadata(null, OnFilterProviderChangedCallback));

        private static void OnFilterProviderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomComboBox obj = d as AtomComboBox;
        }

#else
public static readonly DependencyProperty FilterProviderProperty = 
    AtomFilterTextBox.FilterProviderProperty.AddOwner(typeof(AtomComboBox));
#endif

        #endregion




        ///<summary>
        /// Dependency Property FilterProviderParameter
        ///</summary>
        #region Dependency Property FilterProviderParameter
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object FilterProviderParameter
        {
            get { return (object)GetValue(FilterProviderParameterProperty); }
            set { SetValue(FilterProviderParameterProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FilterProviderParameter.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FilterProviderParameterProperty =
            DependencyProperty.Register("FilterProviderParameter", typeof(object), typeof(AtomComboBox), new PropertyMetadata(null, OnFilterProviderParameterChangedCallback));

        private static void OnFilterProviderParameterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomComboBox obj = d as AtomComboBox;
        }

#else
public static readonly DependencyProperty FilterProviderParameterProperty = 
    AtomFilterTextBox.FilterProviderParameterProperty.AddOwner(typeof(AtomComboBox));
#endif

        #endregion




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

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

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
    public class AtomComboBoxItemWithFilter : ComboBoxItem
    {

#if SILVERLIGHT
        public AtomComboBoxItemWithFilter()
        {
                        
        }
#else
        static AtomComboBoxItemWithFilter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomComboBoxItemWithFilter),
                new FrameworkPropertyMetadata(typeof(AtomComboBoxItemWithFilter)));
        }
#endif

    }

}
