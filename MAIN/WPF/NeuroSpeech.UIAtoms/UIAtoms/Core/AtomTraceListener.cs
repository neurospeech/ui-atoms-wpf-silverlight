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
    /// 
    /// </summary>
    public class AtomTraceMessageEventArgs : EventArgs {

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomTraceListener : TraceListener
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<AtomTraceMessageEventArgs> Traced;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void Write(string message)
        {
            if (Traced != null) {
                Traced(this, new AtomTraceMessageEventArgs { Message = message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public override void WriteLine(string message)
        {
            if (Traced != null) {
                Traced(this, new AtomTraceMessageEventArgs { Message = message + "\r\n" });
            }
        }
    }
}
