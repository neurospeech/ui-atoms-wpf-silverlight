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
using System.Collections;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ListToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IList v = value as IList;
            bool isListFilled = v != null && v.Count > 0;
#if SILVERLIGHT
            AtomTrace.WriteLine("{0}", isListFilled);
#endif
            if (parameter != null && parameter.ToString()=="opposite") {
                return isListFilled ? Visibility.Collapsed : Visibility.Visible;
            }
            return isListFilled ? Visibility.Visible: Visibility.Collapsed;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    public class IntToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isListFilled = false;

            if (value is int?)
            {
                int? v = value as int?;
                isListFilled = v.HasValue && v.Value > 0;
            }
            else {
                int v = (int)System.Convert.ChangeType(value, typeof(int), null);
                isListFilled = v > 0;
            }

            if (parameter != null && parameter.ToString() == "opposite")
            {
                return isListFilled ? Visibility.Collapsed : Visibility.Visible;
            }
            return isListFilled ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    public class ContentToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool isContentAvailable = false;
            if (value != null) {
                if (value is string && string.IsNullOrEmpty(value.ToString()))
                    isContentAvailable = false;
                else
                    isContentAvailable = true;
            }

            if (parameter != null && parameter.ToString() == "opposite")
            {
                return isContentAvailable ? Visibility.Collapsed : Visibility.Visible;
            }
            return isContentAvailable ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
