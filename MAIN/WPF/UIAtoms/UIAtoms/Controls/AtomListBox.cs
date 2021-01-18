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
    public partial class AtomListBox : ListBox 
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
#if SILVERLIGHT
            DefaultStyleKey = typeof(AtomListBox);
            AtomForm.SetMissingValueMessage(this, "Please select the item");
            AtomForm.SetInvalidValueMessage(this, "Invalid Selection");
#endif
			AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "SelectedIndex", ValidationRule = AtomUtils.GetDefaultInstance<AtomSelectionValidationRule>() });
		}
		#endregion


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
		#region static partial void  OnCreateStatic()
		static partial void OnCreateStatic()
		{
			AtomForm.MissingValueMessageProperty.OverrideMetadata(
				typeof(AtomListBox),
				new FrameworkPropertyMetadata("Please select the item"));

			AtomForm.InvalidValueMessageProperty.OverrideMetadata(
				typeof(AtomListBox),
				new FrameworkPropertyMetadata("Invalid Selection"));
		}
		#endregion

#endif



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
