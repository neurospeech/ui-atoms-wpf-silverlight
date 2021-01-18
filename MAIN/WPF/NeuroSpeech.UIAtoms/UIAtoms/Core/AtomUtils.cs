#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
#else
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Documents;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// Supplies utility functions for framework.
    /// </summary>
    public class AtomUtils
    {


#if SILVERLIGHT

        private static StringBuilder loggedText = new StringBuilder();
        public static string LogData {
            get {
                return loggedText.ToString();
            }
        }

        public static void Log(string txt) 
        {
            loggedText.AppendLine(txt);
        }

#endif

        /// <summary>
        /// Searches control with name to up the heirarchy.
        /// </summary>
        /// <param name="fromControl"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object FindControl(FrameworkElement fromControl, string name) {

            object obj = fromControl.FindName(name);
            if (obj == null)
            {
                DependencyObject p = VisualTreeHelper.GetParent(fromControl);
                while (p != null)
                {
                    string n = (string)p.GetValue(FrameworkElement.NameProperty);
                    if (n == name)
                    {
                        obj = p;
                        break;
                    }
                    p = VisualTreeHelper.GetParent(p);
                }
            }
            return obj;
        }

        ///// <summary>
        ///// Helps in resolving deadlock.
        ///// </summary>
        ///// <param name="isChanging"></param>
        ///// <param name="vh"></param>
        //public static void ProcessOneTime(
        //    ref bool isChanging, 
        //    Action vh) 
        //{
        //    if (isChanging)
        //        return;
        //    isChanging = true;
        //    try {
        //        vh();
        //    }
        //    finally
        //    {
        //        isChanging = false;
        //    }

        //}

        /// <summary>
        /// Copies file into temp and returns temp file location.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string CopyPath(string file)
        {
            if (!File.Exists(file))
                return null;
            string tf = GetTempFile();
            if (File.Exists(tf))
                File.Delete(tf);
            File.Copy(file, tf);
            return tf;
        }

        /// <summary>
        /// Deletes temp files created during one application session.
        /// </summary>
        public static void ClearFiles() {
            foreach (string file in tempFiles) {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex) {
                    AtomTrace.WriteLine(ex.ToString());
                }
            }
        }

        private static List<string> tempFiles = new List<string>();

        /// <summary>
        /// Returns Path.GetTempFileName(), but also stores file into collection to be deleted later on.
        /// </summary>
        /// <returns></returns>
        public static string GetTempFile()
        {
            string p = Path.GetTempFileName();
            tempFiles.Add(p);
            return p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="file"></param>
        public static void SaveStream(Stream input, string file) {
            using (FileStream fs = File.OpenWrite(file)) {
                CopyStreams(input, fs, 51200);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public static void CopyStreams(Stream src, Stream dest) {
            CopyStreams(src, dest, 51200);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        /// <param name="bufSize"></param>
        public static void CopyStreams(Stream src, Stream dest, int bufSize)
        {
            byte[] buf = new byte[bufSize];
            int count = src.Read(buf, 0, bufSize);
            while (count > 0)
            {
                dest.Write(buf, 0, count);
                count = src.Read(buf, 0, bufSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="all"></param>
        /// <param name="ignoreWords"></param>
        /// <returns></returns>
        public static string TitleCapitalize(string text, bool all, string ignoreWords)
        {
            if (all)
                return text.ToUpper();
            StringBuilder retVal = new StringBuilder();
            StringBuilder word = new StringBuilder();
            string w;
            foreach (char ch in text) {
                if (ch == ' ')
                {
                    w = word.ToString();
                    word = new StringBuilder();
                    if (!ignoreWords.Contains(w))
                    {
                        if (w.Length >= 1)
                        {
                            retVal.Append(Char.ToUpper(w[0]));
                            retVal.Append(w.Substring(1).ToLower());
                            retVal.Append(' ');
                            continue;
                        }
                    }
                    retVal.Append(w);
                    retVal.Append(' ');
                }
                else {
                    word.Append(ch);
                }
            }

            w = word.ToString();
            if (w.Length > 0)
            {
                if (!ignoreWords.Contains(w))
                {
                    if (w.Length >= 1)
                    {
                        retVal.Append(Char.ToUpper(w[0]));
                        retVal.Append(w.Substring(1));
                        return retVal.ToString();
                    }
                }
            }

            retVal.Append(w);

            return retVal.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        internal static byte[] GetFileData(string filePath, int p)
        {
            byte[] buf =new byte[p];
            using (FileStream fs = File.OpenRead(filePath)) {
                fs.Read(buf, 0, p);
            }
            return buf;
        }


#if !SILVERLIGHT

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dest"></param>
        public static void BindTextProperties(
            FrameworkElement src,
            FrameworkElement dest) 
        {
            AtomUtils.BindTextProperty(src, TextElement.BackgroundProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.FontFamilyProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.FontSizeProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.FontStretchProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.FontStyleProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.FontWeightProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.ForegroundProperty, dest);
            AtomUtils.BindTextProperty(src, TextElement.TextEffectsProperty, dest);        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="prop"></param>
        /// <param name="dest"></param>
        public static void BindTextProperty(
            FrameworkElement src,
            DependencyProperty prop,
            FrameworkElement dest
            )
        {
            dest.SetOneWayBinding(prop,src, prop.Name);
        }

#endif


#if SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ui"></param>
        public static void InvalidateParent(UIElement ui)
        {
            if (ui != null)
            {
                ui = VisualTreeHelper.GetParent(ui) as UIElement;
                if (ui != null)
                {
                    ui.InvalidateMeasure();
                    ui.InvalidateArrange();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uIElement"></param>
        public static void Invalidate(UIElement ui)
        {
            if (ui != null) {
                ui.InvalidateMeasure();
                ui.InvalidateArrange();
            }
        }



#endif

        /// <summary>
        /// 
        /// </summary>
        public static void Beep() { 
#if SILVERLIGHT
            AtomTrace.WriteLine("Beep...");
#else
            Console.Beep();
#endif
        }


        private static Dictionary<Type, object> DefaultInstances = new Dictionary<Type, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetDefaultInstance<T>()
            where T:class
        {
            lock (DefaultInstances)
            {
                Type type = typeof(T);
                object val;
                if (DefaultInstances.TryGetValue(type, out val))
                    return (T)val;
                val = Activator.CreateInstance<T>();
                DefaultInstances[type] = val;
                return (T)val;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomLogicContext {
        private bool isCalled = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public void PreventRecursive(Action action) {
            if (isCalled)
                return;
            isCalled = true;
            try {
                action();
            }
            finally
            {
                isCalled = false;
            }
        }
    }
}
