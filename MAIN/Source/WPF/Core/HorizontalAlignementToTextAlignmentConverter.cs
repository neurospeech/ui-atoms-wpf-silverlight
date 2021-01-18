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
    /// 
    /// </summary>
    public class HorizontalAlignmentToTextAlignmentConverter : IValueConverter
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
            HorizontalAlignment hr = (HorizontalAlignment)value;
            switch (hr)
            {
                case HorizontalAlignment.Center:
                    return TextAlignment.Center;
                case HorizontalAlignment.Left:
                    return TextAlignment.Left;
                case HorizontalAlignment.Right:
                    return TextAlignment.Right;
                case HorizontalAlignment.Stretch:
                    return TextAlignment.Justify;
                default:
                    break;
            }
            return TextAlignment.Left;
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
