using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace NeuroSpeech.UIAtoms.Core
{
    public class StringFormatConverter : IValueConverter
    {

        private string format;

        public StringFormatConverter()
        {

        }

        public StringFormatConverter(string f)
        {
            format = f;
        }

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return string.Format(format ?? parameter as string, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        //public static StringFormatConverter Default = new StringFormatConverter();
    }
}
