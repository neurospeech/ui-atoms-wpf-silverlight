#if WINRT
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
    /// Converts string to visibility, Collapsed if string is null or empty.
    /// </summary>
    public class StringToVisibiltyConverter : IValueConverter
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
            if (value == null)
                return Visibility.Collapsed;
            string v = value.ToString();
            if (v != null && v.Length > 0)
                return Visibility.Visible;
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


    /// <summary>
    /// Converts string to boolean, false if string is null or empty.
    /// </summary>
    public class StringToBooleanConverter : IValueConverter
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
            if (value == null)
                return false;
            string v = value.ToString();
            if (v != null && v.Length > 0)
                return true;
            return false;
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
