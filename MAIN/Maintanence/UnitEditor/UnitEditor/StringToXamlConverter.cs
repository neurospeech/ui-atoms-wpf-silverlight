using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;
using System.Windows.Markup;
using System.Diagnostics;
using System.Windows.Documents;

namespace UnitEditor
{
    public class StringToXamlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(value.ToString()));
                return XamlReader.Load(ms);
            }
            catch {
                //Trace.WriteLine(ex.ToString());
            }
            Paragraph p;
            //FlowDocument fd = new FlowDocument();
            //Paragraph p = fd.Blocks.FirstBlock as Paragraph;
            //if (p == null) {
                p = new Paragraph();
                //fd.Blocks.Add(p);
                p.FontFamily = new System.Windows.Media.FontFamily("Palatino Linotype");
            //}
            if(value!=null)
                p.Inlines.Add(value.ToString());
            //return fd;
            return p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return XamlWriter.Save(value);
        }
    }
}
