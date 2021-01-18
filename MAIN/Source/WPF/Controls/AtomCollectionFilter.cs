#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class AtomCollectionFilter
    {

#if SILVERLIGHT

        private ItemsControl Control;
        private Predicate<object> Filter = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coll"></param>
        public AtomCollectionFilter(ItemsControl ctrl)
        {
            Control = ctrl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilter(Predicate<object> filter) {
            Filter = filter;
            RefreshItems();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshItems()
        {
            Panel panel = Control.GetItemsHost();
            if (Filter == null)
            {
                foreach (UIElement e in panel.Children) {
                    e.Visibility = Visibility.Visible;
                }
            }
            else {
                foreach (UIElement e in panel.Children)
                {
                    object item = Control.ItemContainerGenerator.ItemFromContainer(e);
                    e.Visibility = Filter(item) ? Visibility.Visible : Visibility.Collapsed;
                }
            }
        }

        private static Dictionary<ItemsControl, AtomCollectionFilter> Filters = new Dictionary<ItemsControl, AtomCollectionFilter>();

#endif


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ic"></param>
        /// <param name="coll"></param>
        public static void RefreshCollection(ItemsControl ic, ItemCollection coll)
        {
#if SILVERLIGHT
            AtomCollectionFilter f = null;
            if (Filters.TryGetValue(ic, out f)) {
                f.RefreshItems();
            }
#else
            ic.Items.Refresh();
#endif
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ic"></param>
        /// <param name="predicate"></param>
        public static void SetFilter(ItemsControl ic, Predicate<object> predicate)
        {
#if SILVERLIGHT

            AtomCollectionFilter f = null;
            if (!Filters.TryGetValue(ic, out f)) {
                if (predicate == null)
                    return;
                f = new AtomCollectionFilter(ic);
                Filters[ic] = f;
            }
            f.SetFilter(predicate);
            if (predicate == null) {
                Filters.Remove(ic);
            }
#else
            ic.Items.Filter = predicate;
#endif
        }
    }
}
