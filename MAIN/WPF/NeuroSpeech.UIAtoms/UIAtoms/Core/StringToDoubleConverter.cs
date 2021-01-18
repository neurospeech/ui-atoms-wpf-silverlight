#if WINRT
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class StringToDoubleConverter : IValueConverter
    {
        #region IValueConverter Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string val = value as string;
            if (string.IsNullOrEmpty(val))
                return (double)0;
            double d = (double)0;
            if (double.TryParse(val, out d)) {
                return d;
            }
#if !SILVERLIGHT
            Console.Beep();
#endif
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d = 0;
            if (value is double) {
                d = (double)value;
                return d.ToString();
            }
            return "";
        }

        #endregion

    }
}
