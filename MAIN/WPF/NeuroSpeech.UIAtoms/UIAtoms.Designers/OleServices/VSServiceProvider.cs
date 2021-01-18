using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Shell;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Designers.OleServices
{
    public class VSServiceProvider
    {

        private ServiceProvider sp;

        public VSServiceProvider()
        {
            sp = ServiceProvider.GlobalProvider;
        }

        public T GetService<T>()
            where T:class
        {
            T obj = sp.GetService(typeof(T)) as T;
            if (obj == null) {
                Trace.WriteLine("Could not create type of "+typeof(T).FullName);
            }
            Debug.Assert(obj != null, "Could not create type of " + typeof(T).FullName);
            return obj;
        }

    }
}
