using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.OLE.Interop;

namespace NeuroSpeech.UIAtoms.Designers.OleServices
{
internal static class OleServiceProvider
{


    [DllImport("ole32.dll", ExactSpelling = true)]
    internal static extern int CoRegisterMessageFilter(HandleRef newFilter, ref IntPtr oldMsgFilter);
 

 



    // Fields
    [ThreadStatic]
    private static Microsoft.VisualStudio.OLE.Interop.IServiceProvider globalProvider;
    private static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

    // Methods
    private static Microsoft.VisualStudio.OLE.Interop.IServiceProvider GetGlobalProviderFromMessageFilter()
    {
        object oleMessageFilterForCallingThread = GetOleMessageFilterForCallingThread();
        if (oleMessageFilterForCallingThread == null)
        {
            return null;
        }
        return (oleMessageFilterForCallingThread as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
    }

    private static object GetOleMessageFilterForCallingThread()
    {
        if (Thread.CurrentThread.GetApartmentState() == ApartmentState.MTA)
        {
            return null;
        }
        IntPtr zero = IntPtr.Zero;
        if (OleServiceProvider.Failed(CoRegisterMessageFilter(NullHandleRef, ref zero)))
        {
            return null;
        }
        if (zero == IntPtr.Zero)
        {
            return null;
        }
        IntPtr oldMsgFilter = IntPtr.Zero;
        int num = CoRegisterMessageFilter(new HandleRef(null, zero), ref oldMsgFilter);
        object objectForIUnknown = Marshal.GetObjectForIUnknown(zero);
        Marshal.Release(zero);
        return objectForIUnknown;
    }

    private static bool Failed(int hr)
    {
        return (hr < 0);
    }

 

    // Properties
    public static Microsoft.VisualStudio.OLE.Interop.IServiceProvider GlobalProvider
    {
        get
        {
            if (OleServiceProvider.globalProvider == null)
            {
                Microsoft.VisualStudio.OLE.Interop.IServiceProvider globalProvider = OleServiceProvider.globalProvider;
            }
            return (OleServiceProvider.globalProvider = GetGlobalProviderFromMessageFilter());
        }
        set
        {
            globalProvider = value;
        }
    }
}

 
 
}
