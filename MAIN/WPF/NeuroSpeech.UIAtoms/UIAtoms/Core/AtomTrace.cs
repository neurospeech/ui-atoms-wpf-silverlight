#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// Trace API Provider class.
    /// </summary>
    public class AtomTrace
    {

#if SILVERLIGHT
        public static List<TraceListener> Listeners = new List<TraceListener>();

        private static List<String> History = new List<string>();

        public static void Write(string p)
        {
            lock (Listeners)
            {
                History.Add(p);
                foreach (TraceListener listener in Listeners)
                {
                    listener.WriteLine(p);
                }
            }
        }

        public static void WriteLine(string p)
        {
            lock (Listeners) {
                History.Add(p+"\r\n");
                foreach (TraceListener listener in Listeners) {
                    listener.WriteLine(p);
                }                
            }
        }

        public static void WriteLine(string format, params object[] args) 
        {
            WriteLine(string.Format(format, args));
        }

        #region internal static void LoadHistory(AtomTraceListener Listener)
        internal static void LoadHistory(AtomTraceListener Listener)
        {
            lock (Listeners)
            {
                foreach (string item in History)
                {
                    Listener.Write(item);
                }
            }
        }
        #endregion


#else

        /// <summary>
        /// 
        /// </summary>
        public static TraceListenerCollection Listeners {
            get {
                return Trace.Listeners;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        public static void WriteLine(string line)
        {
            Trace.WriteLine(line);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void Write(string text)
        {
            Trace.Write(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }



#endif
    }
}
