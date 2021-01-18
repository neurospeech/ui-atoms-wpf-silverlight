#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{
    public abstract class TraceListener
    {

        public abstract void Write(string message);
        public abstract void WriteLine(string message);

    }
}
