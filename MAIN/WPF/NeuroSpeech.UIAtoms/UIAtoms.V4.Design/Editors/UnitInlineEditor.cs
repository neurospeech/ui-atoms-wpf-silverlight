using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.PropertyEditing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.IO;
using Microsoft.Windows.Design.Model;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Design.Editors
{
    public class UnitInlineEditor : PropertyValueEditor
    {

        public UnitInlineEditor()
        {
            this.InlineEditorTemplate = CreateTemplate();
        }

        private DataTemplate CreateTemplate()
        {
            DataTemplate result = new DataTemplate();

            FrameworkElementFactory root = new FrameworkElementFactory(typeof(ComboBox));
            result.VisualTree = root;
            Binding b = new Binding("StringValue");
            b.Mode = BindingMode.TwoWay;
            root.SetBinding(ComboBox.SelectedItemProperty, b);
            b = new Binding("ParentProperty.ModelProperties");
            b.Converter = new UnitToTypeConverter();
            root.SetBinding(ComboBox.ItemsSourceProperty, b);
            return result;
        }

        public class UnitToTypeConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                try
                {
                    IEnumerable<ModelProperty> props = value as IEnumerable<ModelProperty>;
                    object siteObject = props.First().Parent.GetCurrentValue();
                    PropertyDescriptor pd = TypeDescriptor.GetProperties(siteObject)["AvailableUnitNames"];
                    return pd.GetValue(siteObject);
                }
                catch (Exception ex) {
                    Log(ex.ToString());
                }
                return value;
            }

            private void Log(string p)
            {
                File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Designer.txt", p + "\r\n");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

    }
}
