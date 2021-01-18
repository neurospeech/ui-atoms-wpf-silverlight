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

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// AtomListBox extends the functionality of a ListBox with several customizable parameters.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomListBox Parameters
    /// </listheader>
    /// 		<item>
    /// 			<term>
    /// Filter:
    /// </term>
    /// 			<description>
    ///  displays a "search" field in the list box, enabling the user to type and filter through the listed options and search for the characters entered.
    /// <para>
    /// This search is intelligent, wherein it can be customized to search for text in the beginning of the string, end of the string, or anywhere in the string. 
    /// </para>
    /// 				<para>
    /// It uses the "String Comparison" to make a match of the text entered in the filter field. 
    /// </para>
    /// 			</description>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomListBox : ListBox 
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomListBox()
        {
#if SILVERLIGHT
            DefaultStyleKey = typeof(AtomListBox);
            AtomForm.SetMissingValueMessage(this, "Please select the item");
            AtomForm.SetInvalidValueMessage(this, "Invalid Selection");
#endif
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "SelectedIndex", ValidationRule = AtomUtils.GetDefaultInstance<AtomSelectionValidationRule>() });
        }

#if SILVERLIGHT

        private AtomFilterTextBox FilterTB;
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FilterTB = GetTemplateChild("PART_Filter") as AtomFilterTextBox;
            if (FilterTB != null) {
                FilterTB.SetOneWayBinding(AtomFilterTextBox.VisibilityProperty,this,"IsFilterVisible",AtomUtils.GetDefaultInstance<BooleanToVisibilityConverter>());
            }
        }
#else
        static AtomListBox()
        {

            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomListBox),
                new FrameworkPropertyMetadata(typeof(AtomListBox)));

            InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty.AddOwner(typeof(AtomListBox));

            AtomForm.MissingValueMessageProperty.OverrideMetadata(
                typeof(AtomListBox),
                new FrameworkPropertyMetadata("Please select the item"));

            AtomForm.InvalidValueMessageProperty.OverrideMetadata(
                typeof(AtomListBox),
                new FrameworkPropertyMetadata("Invalid Selection"));

        }
#endif

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
            DependencyProperty.Register("IsFilterVisible", typeof(bool), typeof(AtomListBox), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty IsFilterVisibleProperty =
            DependencyProperty.Register("IsFilterVisible", typeof(bool), typeof(AtomListBox), new UIPropertyMetadata(false));
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
            DependencyProperty.Register("FilterText", typeof(string), typeof(AtomListBox), new PropertyMetadata(""));
#else        
        public static readonly DependencyProperty FilterTextProperty =
            DependencyProperty.Register("FilterText", typeof(string), typeof(AtomListBox), new UIPropertyMetadata(""));
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
            DependencyProperty.Register("FilterMode", typeof(AtomTextFilterMode), typeof(AtomListBox), new PropertyMetadata(AtomTextFilterMode.StartsWith));
#else
        public static readonly DependencyProperty FilterModeProperty =
            AtomFilterTextBox.FilterModeProperty.AddOwner(typeof(AtomListBox), new UIPropertyMetadata(AtomTextFilterMode.StartsWith));
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
            DependencyProperty.Register("FilterComparison", typeof(StringComparison), typeof(AtomListBox), new PropertyMetadata(StringComparison.CurrentCultureIgnoreCase));

#else
        public static readonly DependencyProperty FilterComparisonProperty = 
            DependencyProperty.Register("FilterComparison", typeof(StringComparison), typeof(AtomListBox), new UIPropertyMetadata(StringComparison.CurrentCultureIgnoreCase));
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
    DependencyProperty.Register("FilterProvider", typeof(IAtomItemsFilter), typeof(AtomListBox), new PropertyMetadata(null, OnFilterProviderChangedCallback));
    
private static void OnFilterProviderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomListBox obj = d as AtomListBox;
}
    
#else
        public static readonly DependencyProperty FilterProviderProperty =
            AtomFilterTextBox.FilterProviderProperty.AddOwner(typeof(AtomListBox));
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
            DependencyProperty.Register("FilterProviderParameter", typeof(object), typeof(AtomListBox), new PropertyMetadata(null, OnFilterProviderParameterChangedCallback));

        private static void OnFilterProviderParameterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomListBox obj = d as AtomListBox;
        }

        #else
        public static readonly DependencyProperty FilterProviderParameterProperty = 
            AtomFilterTextBox.FilterProviderParameterProperty.AddOwner(typeof(AtomListBox));
        #endif

        #endregion





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
        public int[] InvalidIndices
        {
            get { return (int[])GetValue(InvalidIndicesProperty); }
            set { SetValue(InvalidIndicesProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for InvalidIndices.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty InvalidIndicesProperty =
            AtomSelectionValidationRule.InvalidIndicesProperty;
#else        
        public static readonly DependencyProperty InvalidIndicesProperty;
#endif

        #endregion


#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            BindingExpression be = GetBindingExpression(SelectedItemsProperty);
            if (be != null)
            {
                be.UpdateSource();
            }
        }
#endif

    }

    /// <summary>
    /// Converter for Commpa seperator values to string array and vice verse.
    /// </summary>
    public class CSVToArrayTypeConverter : TypeConverter
    {


        ///<summary>
        ///Override CanConvertFrom to return true for String-to-Complex conversions.
        ///</summary>
        public override bool CanConvertFrom(
            ITypeDescriptorContext context,
            Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        /// Override CanConvertTo to return true for Complex-to-String conversions.
        /// </summary>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        ///<summary>
        ///Override ConvertFrom to convert from a string to an instance of Complex.
        ///</summary>
        public override object ConvertFrom(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value)
        {
            string text = value as string;

            if (text != null)
            {
                try
                {
                    List<int> list = new List<int>();
                    string[] tokens = text.Split(',');
                    foreach (string item in tokens)
                    {
                        int n = 0;
                        if (int.TryParse(item, out n))
                            list.Add(n);
                    }
                    return list.ToArray();
                }
                catch (Exception e)
                {
                    throw new Exception(
                        String.Format("Cannot convert '{0}' ({1}) because {2}",
                                        value,
                                        value.GetType(),
                                        e.Message), e);
                }
            }

            return base.ConvertFrom(context, culture, value);
        }

        ///<summary>
        ///Override ConvertTo to convert from an instance of Complex to string.
        ///</summary>
        public override object ConvertTo(
            ITypeDescriptorContext context,
            System.Globalization.CultureInfo culture,
            object value,
            Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            //Convert Complex to a string in a standard format.
            int[] c = value as int[];

            if (c != null && this.CanConvertTo(context, destinationType))
            {
                StringBuilder sb = new StringBuilder();
                foreach (int item in c)
                {
                    sb.Append(',');
                    sb.Append(item);
                }
                if(sb.Length > 0)
                    return sb.ToString().Substring(1);
                return "";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }




    }

}
