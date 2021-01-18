using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace NeuroSpeech.UIAtoms.Core
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool invert = parameter != null && parameter.ToString() == "invert";

            if (value == null)
                return invert ? Visibility.Visible : Visibility.Collapsed;
            if (value is bool)
            {
                if ((bool)value)
                    return invert ? Visibility.Collapsed : Visibility.Visible;
            }
            if (value is bool?) 
            {
                bool? v = (bool?)value;
                if (v == true)
                    return invert ? Visibility.Collapsed : Visibility.Visible;
            }
            return invert ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
