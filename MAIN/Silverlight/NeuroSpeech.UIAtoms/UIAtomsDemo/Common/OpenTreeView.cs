using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UIAtomsDemo.Common
{
    public class OpenTreeView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new OpenTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is OpenTreeViewItem;
        }
    }

    public class OpenTreeViewItem : TreeViewItem
    {
        public OpenTreeViewItem()
        {
            this.IsExpanded = true;
        }

        
    }
}
