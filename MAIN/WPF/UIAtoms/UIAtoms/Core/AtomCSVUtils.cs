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
    /// Class provides CSV functionality
    /// </summary>
    public static class AtomCSVUtils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string ToCSV(IEnumerable<string> items) {
            string quote = "\"";
            return ToCSV(items, quote);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        private static string ToCSV(IEnumerable<string> items, string quote)
        {
            string dquote = quote + quote;
            StringBuilder sb = new StringBuilder();
            foreach (string item in items) {
                sb.Append(',');
                sb.Append(item.Replace(quote, dquote));
            }
            string val = sb.ToString();
            if (val.Length > 0)
                val = val.Substring(1);
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string[] SplitCSV(this string text) {
            List<String> list = new List<string>();
            char curChar = ' ';
            char lastQuote = ' ';
            StringBuilder lastWord = new StringBuilder();

            int n = text.Length;
            for (int i = 0; i < n; i++)
            {
                curChar = text[i];

                if (lastQuote != ' ') {

                    // end of quote...
                    if (lastQuote == curChar) { 
                        
                        // check next...
                        if (i + 1 < n && text[i + 1] == lastQuote)
                        {
                            lastWord.Append(curChar);
                            i += 1;
                            continue;
                        }
                        lastQuote = ' ';
                        continue;
                    }
                    lastWord.Append(curChar);
                    continue;
                }

                if (curChar == '\'' || curChar == '"') {
                    lastQuote = curChar;
                    continue;
                }

                if (curChar == ',') {
                    list.Add(lastWord.ToString().Trim());
                    lastWord = new StringBuilder();
                    continue;
                }

                lastWord.Append(curChar);
            }

            list.Add(lastWord.ToString().Trim());

            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iList"></param>
        /// <returns></returns>
        public static string ToCSV(System.Collections.IList iList) {
            return ToCSV(iList, "\"");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="quote"></param>
        /// <returns></returns>
        public static string ToCSV(System.Collections.IList items, string quote)
        {
            string dquote = quote + quote;
            StringBuilder sb = new StringBuilder();
            foreach (object item in items)
            {
                sb.Append(',');
                sb.Append(item.ToString().Replace(quote, dquote));
            }
            string val = sb.ToString();
            if (val.Length > 0)
                val = val.Substring(1);
            return val;
        }
    }
}
