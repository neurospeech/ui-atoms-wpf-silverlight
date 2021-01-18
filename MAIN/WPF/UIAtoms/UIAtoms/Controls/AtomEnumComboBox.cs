#if NETFX_CORE
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Validation;
using System.Reflection;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Combobox that can load values from the given Enumerator Type
    /// </summary>
    [AtomDesign(
        DisplayInToolbox=true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomEnumComboBox : AtomComboBox
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
			SelectedValuePath = "Data";
			DisplayMemberPath = "Label";
		}
		#endregion


		#region partial void  OnAfterEnumTypeChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterEnumTypeChanged(DependencyPropertyChangedEventArgs e)
		{
			CreateEnumSource();
		}
		#endregion


        private void CreateEnumSource()
        {
            Type type = EnumType;

            if (type.IsEnum)
                this.AttachEnumeratorDataSource(type);
        }

        private void AttachEnumeratorDataSource(Type type)
        {

            List<AtomDataItem> items = new List<AtomDataItem>();

            foreach (FieldInfo m in type.GetFields())
            {
                if ((m.Attributes & FieldAttributes.Literal) > 0)
                {

                    string name = m.Name;

                    string desc = name;

                    object[] atts = m.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (atts != null && atts.Length > 0) {
                        DescriptionAttribute d = atts[0] as DescriptionAttribute;
                        desc = d.Description;
                    }

                    object value = Enum.Parse(type, name);

                    items.Add(new AtomDataItem { Data = value, Label = desc, IsSelected = false });

                }
            }

            this.ItemsSource = items;

        }        

    }
}
