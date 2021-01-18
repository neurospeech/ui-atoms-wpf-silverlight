#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls.Primitives;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !SILVERLIGHT
#endif
using System.Diagnostics;
using System.ComponentModel;
using System.Xml;
using System.Reflection;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// This control adds filtering capability to connected Item Collection.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomFilterTextBox : AtomTextBox
    {

#if SILVERLIGHT
        public AtomFilterTextBox()
        {
            DefaultStyleKey = typeof(AtomFilterTextBox);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnTextPropertyChanged(this, EventArgs.Empty);
            this.Focus();
        }
#else
        static AtomFilterTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(typeof(AtomFilterTextBox)));


            CommandManager.RegisterClassCommandBinding(
                typeof(AtomFilterTextBox),
                new CommandBinding(
                    EditingCommands.Delete,
                    OnDeleteExecuted,
                    OnCanDeleteExecute));

        }
#endif

        /// <summary>
        /// 
        /// </summary>
        protected Button PART_DeleteButton;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_DeleteButton = GetTemplateChild("PART_DeleteButton") as Button;
#if SILVERLIGHT
            PART_DeleteButton.Click += new RoutedEventHandler(PART_DeleteButton_Click);

#endif
        }

        void PART_DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Text = "";
        }

#if SILVERLIGHT
        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);
        }
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(
                TextProperty,
                this.GetType());
            dpd.AddValueChanged(this, OnTextPropertyChanged);
        }
#endif

        private string textToFilter = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnTextPropertyChanged(object sender, EventArgs e)
        {

            string t = this.Text;

            if (string.IsNullOrEmpty(t))
            {
                textToFilter = null;
            }
            else {
                textToFilter = t;
            }

            ItemsControl ic = ItemsControl;
            if (ic != null) {
                InstallFilter(ic);
            }

        }

        /// <summary>
        /// The Control which is bound to the AtomFilterTextBox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// ItemsControl
        /// </listheader>
        /// 		<item>
        /// Controls like ComboBox, ListBox, etc. are types of ItemControls.
        /// </item>
        /// 		<item>
        /// These controls can be bound with AtomFilterTextBox.
        /// </item>
        /// 		<item>
        /// The AtomFilterTextBox will filter the input text from the data available in the ItemsControl that is bound to the AtomFilterTextBox.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property ItemsControl
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public ItemsControl ItemsControl
        {
            get { return (ItemsControl)GetValue(ItemsControlProperty); }
            set { SetValue(ItemsControlProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ItemsControl.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ItemsControlProperty =
            DependencyProperty.Register("ItemsControl", typeof(ItemsControl), typeof(AtomFilterTextBox), new PropertyMetadata(null, OnItemsControlChangedCallback));
#else
        public static readonly DependencyProperty ItemsControlProperty =
            DependencyProperty.Register("ItemsControl", typeof(ItemsControl), typeof(AtomFilterTextBox), new UIPropertyMetadata(null, OnItemsControlChangedCallback));
#endif
        private static void OnItemsControlChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFilterTextBox obj = d as AtomFilterTextBox;
            if (obj != null)
            {
                obj.OnItemsControlChanged(e);
            }
        }

        /// <summary>
        /// Fires ItemsControlChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnItemsControlChanged(DependencyPropertyChangedEventArgs e)
        {
            ItemsControl ic = e.OldValue as ItemsControl;
            if (ic != null)
            {
                UninstallFilter(ic);
            }

            ic = e.NewValue as ItemsControl;
            if (ic != null) {
                InstallFilter(ic);
            }

            if (ItemsControlChanged != null)
            {
                ItemsControlChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler ItemsControlChanged;

        #endregion


        /// <summary>
        /// This property describes how the filter should compare strings.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FilterMode
        /// </listheader>
        /// 		<item>
        /// is an enumerator for type AtomTextFilterMode.
        /// </item>
        /// 		<item>
        /// It identifies how the string search should be done. For example, StartsWith will return all the items based on your own logic.
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
            DependencyProperty.Register("FilterMode", typeof(AtomTextFilterMode), typeof(AtomFilterTextBox), new PropertyMetadata(AtomTextFilterMode.StartsWith, OnFilterModeChangedCallback));
#else
        public static readonly DependencyProperty FilterModeProperty =
            DependencyProperty.Register("FilterMode", typeof(AtomTextFilterMode), typeof(AtomFilterTextBox), new UIPropertyMetadata(AtomTextFilterMode.StartsWith, OnFilterModeChangedCallback));
#endif
        private static void OnFilterModeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFilterTextBox obj = d as AtomFilterTextBox;
            if (obj != null)
            {
                obj.OnFilterModeChanged(e);
            }
        }

        /// <summary>
        /// Fires FilterModeChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFilterModeChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshItems();
            if (FilterModeChanged != null)
            {
                FilterModeChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FilterModeChanged;

        #endregion


        /// <summary>
        /// Refresh the ItemsControl
        /// </summary>
        public void RefreshItems() {
            ItemsControl ic = ItemsControl;
            if (ic != null) {
                FilterItemEventArgs.FilterText = textToFilter;
                FilterItemEventArgs.FilterComparison = this.FilterComparison;
                AtomCollectionFilter.RefreshCollection(ic, ic.Items);
            }
        }

        private void InstallFilter(ItemsControl ic)
        {
            AtomCollectionFilter.SetFilter(ic, string.IsNullOrEmpty(textToFilter) ? null : new Predicate<object>(OnFilterItem));
            RefreshItems();
        }


        /// <summary>
        /// FilterComparison property is a StringComparison which is used to compare strings.
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FilterComparison
        /// </listheader>
        /// 		<item>
        /// is a StringComparison which is used to compare strings. 
        /// </item>
        /// 		<item>
        /// The default value is CurrentCultureIgnoreCase.
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
            DependencyProperty.Register("FilterComparison", typeof(StringComparison), typeof(AtomFilterTextBox), new PropertyMetadata(StringComparison.CurrentCultureIgnoreCase, OnFilterComparisonChangedCallback));
#else
        public static readonly DependencyProperty FilterComparisonProperty =
            DependencyProperty.Register("FilterComparison", typeof(StringComparison), typeof(AtomFilterTextBox), new UIPropertyMetadata(StringComparison.CurrentCultureIgnoreCase, OnFilterComparisonChangedCallback));
#endif
        private static void OnFilterComparisonChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFilterTextBox obj = d as AtomFilterTextBox;
            if (obj != null)
            {
                obj.OnFilterComparisonChanged(e);
            }
        }

        /// <summary>
        /// Fires FilterComparisonChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFilterComparisonChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshItems();
            if (FilterComparisonChanged != null)
            {
                FilterComparisonChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FilterComparisonChanged;

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
    DependencyProperty.Register("FilterProvider", typeof(IAtomItemsFilter), typeof(AtomFilterTextBox), new PropertyMetadata(null, OnFilterProviderChangedCallback));
    
private static void OnFilterProviderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomFilterTextBox obj = d as AtomFilterTextBox;
}
    
#else
        public static readonly DependencyProperty FilterProviderProperty =
            DependencyProperty.Register("FilterProvider", typeof(IAtomItemsFilter), typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(null));
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
            DependencyProperty.Register("FilterProviderParameter", typeof(object), typeof(AtomFilterTextBox), new PropertyMetadata(null, OnFilterProviderParameterChangedCallback));

        private static void OnFilterProviderParameterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFilterTextBox obj = d as AtomFilterTextBox;
        }

        #else
        public static readonly DependencyProperty FilterProviderParameterProperty = 
            DependencyProperty.Register("FilterProviderParameter", typeof(object), typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(null));
        #endif

        #endregion




        /// <summary>
        /// FilterItem event is fired only when FilterMode is set to Custom.
        /// </summary>
        public event EventHandler<AtomFilterItemEventArgs> FilterItem;

        private AtomFilterItemEventArgs FilterItemEventArgs = new AtomFilterItemEventArgs();

#if SILVERLIGHT

        #region Attached Dependency Property TextPath
        ///<summary>
        ///Get Attached Property TextPath for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public static string GetTextPath(DependencyObject obj)
        {
            return (string)obj.GetValue(TextPathProperty);
        }

        ///<summary>
        ///Set Attached Property TextPath for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetTextPath(DependencyObject obj, string value)
        {
            obj.SetValue(TextPathProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for TextPath.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty TextPathProperty =
            DependencyProperty.RegisterAttached("TextPath", typeof(string), typeof(AtomFilterTextBox), new PropertyMetadata(null));
        #endregion


#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
#if SILVERLIGHT
        protected virtual bool OnFilterItem(object obj)
        {

            if (string.IsNullOrEmpty(textToFilter))
                return true;

            if (ItemsControl is ListBox)
            {
                if ((ItemsControl as ListBox).SelectedItems.Contains(obj))
                    return true;
            }
            else if (ItemsControl is Selector)
            {
                if ((ItemsControl as Selector).SelectedItem == obj)
                    return true;
            }


            if (FilterMode == AtomTextFilterMode.Custom)
            {
                if (FilterProvider != null)
                    return FilterProvider.FilterItem(this, obj, textToFilter, FilterProviderParameter, FilterMode, FilterComparison);

                if (FilterItem != null)
                {
                    FilterItemEventArgs.Item = obj;
                    FilterItemEventArgs.IncludeInList = false;
                    FilterItem(this, FilterItemEventArgs);
                    return FilterItemEventArgs.IncludeInList;
                }
                return false;
            }

            string txt = "";

            if (obj is string)
            {
                txt = obj as string;
            }
            else if (obj is FrameworkElement)
            {
                // forget it..
                return true;
            }
            else
            {
                string path = GetTextPath(ItemsControl);
                if (path == null)
                {
                    txt = obj.ToString();
                }
                else
                {
                    Type type = obj.GetType();

                    PropertyInfo pinfo = type.GetProperty(path);
                    if (pinfo != null)
                    {
                        obj = pinfo.GetValue(obj, null);
                        if (obj != null)
                            txt = obj.ToString();
                        else
                            return false;
                    }
                    FieldInfo finfo = type.GetField(path);
                    if (finfo != null)
                    {
                        obj = finfo.GetValue(obj);
                        if (obj != null)
                        {
                            txt = obj.ToString();
                        }
                        else return false;
                    }
                }
            }

            switch (FilterMode)
            {
                case AtomTextFilterMode.StartsWith:
                    if (txt.StartsWith(textToFilter, FilterComparison))
                        return true;
                    break;
                case AtomTextFilterMode.Contains:
                    if (txt.IndexOf(textToFilter, FilterComparison) != -1)
                        return true;
                    break;
                case AtomTextFilterMode.EndsWith:
                    if (txt.EndsWith(textToFilter, FilterComparison))
                        return true;
                    break;
                case AtomTextFilterMode.Exact:
                    if (string.Compare(txt, textToFilter, FilterComparison) == 0)
                        return true;
                    break;
                default:
                    break;
            }

            return false;
        }
#else
        protected virtual bool OnFilterItem(object obj)
        {

            if (string.IsNullOrEmpty(textToFilter))
                return true;

            if (ItemsControl is ListBox)
            {
                if ((ItemsControl as ListBox).SelectedItems.Contains(obj))
                    return true;
            }
            else if (ItemsControl is Selector) {
                if ((ItemsControl as Selector).SelectedItem == obj)
                    return true;
            }

            
            if (FilterMode == AtomTextFilterMode.Custom) {

                if (FilterProvider != null)
                    return FilterProvider.FilterItem(this, obj, textToFilter,FilterProviderParameter, FilterMode, FilterComparison);

                if (FilterItem != null)
                {
                    FilterItemEventArgs.Item = obj;
                    FilterItemEventArgs.IncludeInList = false;
                    FilterItem(this, FilterItemEventArgs);
                    return FilterItemEventArgs.IncludeInList;
                }

                return false;
            }

            string txt = "";

            if (obj is string)
            {
                txt = obj as string;
            }
            else if (obj is FrameworkElement)
            {
                // forget it..
                return true;
            }
            else if (obj is XmlNode)
            {
                // not supported yet..
                XmlNode node = obj as XmlNode;
                string path = TextSearch.GetTextPath(ItemsControl);
                node = node.SelectSingleNode(path);
                if (node != null)
                {
                    txt = node.InnerText;
                }
            }
            else { 
                string path = TextSearch.GetTextPath(ItemsControl);
                if(path==null){
                    txt = obj.ToString();
                }else{
                    Type type = obj.GetType();

                    PropertyInfo pinfo = type.GetProperty(path);
                    if(pinfo!=null)
                    {
                        obj = pinfo.GetValue(obj, null);
                        if (obj != null)
                            txt = obj.ToString();
                        else
                            return false;
                    }
                    FieldInfo finfo = type.GetField(path);
                    if (finfo != null) {
                        obj = finfo.GetValue(obj);
                        if (obj != null)
                        {
                            txt = obj.ToString();
                        }
                        else return false;
                    }
                }
            }

            switch (FilterMode)
            {
                case AtomTextFilterMode.StartsWith:
                    if (txt.StartsWith(textToFilter, FilterComparison))
                        return true;
                    break;
                case AtomTextFilterMode.Contains:
                    if (txt.IndexOf(textToFilter, FilterComparison) != -1)
                        return true;
                    break;
                case AtomTextFilterMode.EndsWith:
                    if (txt.EndsWith(textToFilter, FilterComparison))
                        return true;
                    break;
                case AtomTextFilterMode.Exact:
                    if (string.Compare(txt, textToFilter, FilterComparison) == 0)
                        return true;
                    break;
                default:
                    break;
            }

            return false;
        }
#endif

        private void UninstallFilter(ItemsControl ic)
        {
            AtomCollectionFilter.SetFilter(ic, null);
        }

#if SILVERLIGHT
#else
        private static void OnDeleteExecuted(object sender, ExecutedRoutedEventArgs e) {
            AtomFilterTextBox tb = sender as AtomFilterTextBox;
            if (tb != null) {
                tb.OnDeleteExecuted(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDeleteExecuted(ExecutedRoutedEventArgs e)
        {
            this.Text = "";
        }

        private static void OnCanDeleteExecute(object sender, CanExecuteRoutedEventArgs e){
            AtomFilterTextBox tb = sender as AtomFilterTextBox;
            if (tb != null) {
                tb.OnCanDeleteExecute(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCanDeleteExecute(CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(Text);
            if (PART_DeleteButton != null)
                PART_DeleteButton.Visibility = e.CanExecute ? Visibility.Visible : Visibility.Hidden;
        }
#endif
    }

    /// <summary>
    /// Event arguement supplied for FilterItem event of AtomFilterTextBox
    /// </summary>
    public class AtomFilterItemEventArgs : EventArgs {

        ///<summary>
        /// Item to be search
        ///</summary>
        #region Property Item
        public object Item
        {
            get
            {
                return _Item;
            }
            internal set {
                _Item = value;
            }
        }
        private object _Item = null;

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
        #region Property FilterText
        public string FilterText
        {
            get
            {
                return _FilterText;
            }
            internal set {
                _FilterText = value;
            }
        }
        private string _FilterText = "";

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

        #region Property FilterComparison
        public StringComparison FilterComparison
        {
            get
            {
                return _FilterComparison;
            }
            internal set
            {
                _FilterComparison = value;
            }
        }
        private StringComparison _FilterComparison = StringComparison.CurrentCultureIgnoreCase;

        #endregion
	

        /// <summary>
        /// Set true to include in the filtered result
        /// </summary>
        public bool IncludeInList { get; set; }

    }

    /// <summary>
    /// The filter mode of AtomFilterTextBox, which specifies how the string search should be done.
    /// </summary>
    public enum AtomTextFilterMode
    {
        /// <summary>
        /// Item's text should start with the filter text
        /// </summary>
        StartsWith,

        /// <summary>
        /// Item's text should contain the filter text
        /// </summary>
        Contains,

        /// <summary>
        /// Item's text should end with the filter text
        /// </summary>
        EndsWith,

        /// <summary>
        /// Item's text should match exactly to the filter text
        /// </summary>
        Exact, 


        /// <summary>
        /// FilterItem event is fired on AtomFilterTextBox
        /// </summary>
        Custom
    }

}
