#if NETFX_CORE
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Converts 
    /// </summary>
    [AtomDesign(
        DisplayInToolbox=false
        )]
    public class ArrayToCSVConverter : IValueConverter
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
            IEnumerable en = value as IEnumerable;
            List<string> list = new List<string>();
            foreach (object s in en) {
                if (s == null) {
                    list.Add("");
                }
                else if (s is string)
                {
                    list.Add(s as string);
                }
                else
                {
                    list.Add(s.ToString());
                }
            }
            return AtomCSVUtils.ToCSV((IEnumerable<string>)list);
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
            if (value == null)
                return new string[] { };
            return AtomCSVUtils.SplitCSV(value.ToString());
        }

        #endregion
    }
}
