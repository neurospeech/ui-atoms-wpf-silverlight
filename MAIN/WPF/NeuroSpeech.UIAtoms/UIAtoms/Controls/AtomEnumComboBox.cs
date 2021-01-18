#if WINRT
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
    public class AtomEnumComboBox : AtomComboBox
    {

        static AtomEnumComboBox()
        {
            SelectedValuePathProperty.OverrideMetadata(
                typeof(AtomEnumComboBox),
                new FrameworkPropertyMetadata("Data"));
            DisplayMemberPathProperty.OverrideMetadata(
                typeof(AtomEnumComboBox),
                new FrameworkPropertyMetadata("Label"));
        }

        /// <summary>
        /// Type of enumerator to load values from.
        /// </summary>
        #region Dependency Property EnumType
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public Type EnumType
        {
            get { return (Type)GetValue(EnumTypeProperty); }
            set { SetValue(EnumTypeProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for EnumType.  This enables animation, styling, binding, etc...
        /// </summary> 
        public static readonly DependencyProperty EnumTypeProperty =
            DependencyProperty.Register("EnumType", typeof(Type), typeof(AtomEnumComboBox), new UIPropertyMetadata(null, OnEnumTypeChangedCallback));

        private static void OnEnumTypeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomEnumComboBox obj = d as AtomEnumComboBox;
            if (obj != null)
            {
                obj.OnEnumTypeChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEnumTypeChanged(DependencyPropertyChangedEventArgs e)
        {
            CreateEnumSource();
            if (EnumTypeChanged != null)
            {
                EnumTypeChanged(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler EnumTypeChanged;

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
