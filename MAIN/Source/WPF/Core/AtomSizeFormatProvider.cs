#if NETFX_CORE
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// Provides File Size in Human Readable form upto PB.
    /// </summary>
    public class AtomSizeFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatType"></param>
        /// <returns></returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter)) return this;
            return null;
        }

        private static AtomFileSize[] Sizes = new[] { 
            new AtomFileSize{Symbol="PB", Value=1024L*1024L*1024L*1024L*1024L}
            ,new AtomFileSize{Symbol="TB", Value=1024L*1024L*1024L*1024L}
            ,new AtomFileSize{Symbol="GB", Value=1024L*1024L*1024L}
            ,new AtomFileSize{Symbol="MB", Value=1024L*1024L}
            ,new AtomFileSize{Symbol="KB", Value=1024L}
            ,new AtomFileSize{Symbol="B", Value=0L}
        };        

        private const string fileSizeFormat = "sz";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="arg"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null || !format.StartsWith(fileSizeFormat))
            {
                return defaultFormat(format, arg, formatProvider);
            }

            if (arg is string)
            {
                return defaultFormat(format, arg, formatProvider);
            }

            ulong size = 0;

            try
            {
                size = Convert.ToUInt64(arg);
            }
            catch (InvalidCastException)
            {
                return defaultFormat(format, arg, formatProvider);
            }

            decimal sup = 0;
            string suffix = "";
            foreach (AtomFileSize s in Sizes) {
                if (s.Value <= size) {
                    if (s.Value > 0)
                    {
                        sup = (decimal)((double)size / (double)s.Value);
                    }
                    else {
                        sup = size;
                    }
                    suffix = s.Symbol;
                    break;
                }
            }

            string precision = format.Substring(2);
            if (String.IsNullOrEmpty(precision)) precision = "2";
            return String.Format("{0:N" + precision + "} {1}", sup, suffix);

        }

        private static string defaultFormat(string format, object arg, IFormatProvider formatProvider)
        {
            IFormattable formattableArg = arg as IFormattable;
            if (formattableArg != null)
            {
                return formattableArg.ToString(format, formatProvider);
            }
            return arg.ToString();
        }

    }

    /// <summary>
    /// 
    /// </summary>
    internal class AtomFileSize {

        /// <summary>
        /// 
        /// </summary>
        internal ulong Value;

        /// <summary>
        /// 
        /// </summary>
        internal string Symbol;
    }
}
