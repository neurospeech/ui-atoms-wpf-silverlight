#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
#else
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
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
    public class AtomTreeWalker
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static bool AnyChild<T>(DependencyObject obj, Func<T, bool> action)
            where T:class
        {
            if (obj == null)
                return false;

            T item = obj as T;
            if (item != null) {
                if (action(item))
                    return true;
            }

            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (AnyChild<T>(child, action))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        public static void ForEachChildren<T>(DependencyObject obj, MethodHandler<T> action)
            where T:class
        {
            if (obj == null)
                return;

            T item = obj as T;
            if (item != null)
            {
                action(item);
            }

            TabControl tc = item as TabControl;
            if (tc != null) {
                // do for each items...
                foreach (TabItem tabItem in tc.Items)
                {
                    UIElement e = tabItem.Content as UIElement;
                    if (e != null)
                    {
                        //AtomTrace.WriteLine("Validating Tab Item Content");
                        ForEachChildren<T>(e, action);
                    }
                    else
                    {
                        //AtomTrace.WriteLine("Validating Tab Item");
                        ForEachChildren<T>(tabItem, action);
                    }
                }
            }

            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                ForEachChildren<T>(child, action);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <param name="depth"></param>
        public static void ForEachChildren<T>(DependencyObject obj, int depth,  MethodHandler<T> action)
            where T : class
        {
            if (obj == null)
                return;

            T item = obj as T;
            if (item != null)
            {
                action(item);
                depth = depth - 1;
            }

            if (depth == 0)
                return;

            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                ForEachChildren<T>(child , depth, action);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T FindParent<T>(DependencyObject obj, Func<T, bool> action)
            where T:class
        {
            if (obj == null)
                return null;

            T item = obj as T;
            if (item != null) {
                if (action(item))
                    return item;
            }

            TabItem tab = item as TabItem;
            if (tab != null) {
                return FindParent<T>(tab.Parent,action);
            }

            obj = VisualTreeHelper.GetParent(obj);
            return FindParent<T>(obj, action);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindFirstChild<T>(DependencyObject obj) 
            where T:class
        {
            if (obj == null)
                return null;

            T titem = obj as T;
            if (titem != null)
                return titem;

            int count = VisualTreeHelper.GetChildrenCount(obj);
            for (int i = 0; i < count; i++)
            {
                T item = FindFirstChild<T>(VisualTreeHelper.GetChild(obj, i));
                if (item != null)
                    return item;
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public delegate void MethodHandler<T>(T item);

    }
}
