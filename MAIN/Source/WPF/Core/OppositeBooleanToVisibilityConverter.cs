#if NETFX_CORE
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml;
#else
using System.Windows.Data;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// Converts opposite of boolean to Visibility, Collapsed if value is true.
    /// </summary>
    public class OppositeBooleanToVisibilityConverter : IValueConverter
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
            if (value is bool) {
                return ((bool)value) ? Visibility.Collapsed : Visibility.Visible;
            }
            if (value is bool?) {
                return ((bool?)value) == true ? Visibility.Collapsed : Visibility.Visible;
            }
            if (value is string) {
                string val = value as string;
                if (!string.IsNullOrEmpty(val)) {
                    val = val.ToUpper();
                    if (val == "FALSE" || val == "NO")
                        return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
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
            throw new NotImplementedException();
        }

        #endregion

    }
}
