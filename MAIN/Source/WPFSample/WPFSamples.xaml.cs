using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Diagnostics;

namespace UIAtoms.WPFSamples
{
    /// <summary>
    /// Interaction logic for WPFSamples.xaml
    /// </summary>
    public partial class WPFSamples : Page
    {
        public WPFSamples()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(WPFSamples_Loaded);
        }

        void WPFSamples_Loaded(object sender, RoutedEventArgs e)
        {
            PageNode[] pages = PageNode.RootPages;
            pageTree.ItemsSource = pages;

            this.Dispatcher.BeginInvoke(
                (Action)delegate() {
                    SelectFirstPage();
                });
        }

        private void SelectFirstPage()
        {
            TreeViewItem item = (TreeViewItem)pageTree.ItemContainerGenerator.ContainerFromIndex(0);
            item = (TreeViewItem)item.ItemContainerGenerator.ContainerFromIndex(0);
            item.IsSelected = true;
        }

        private void pageTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            PageNode node = pageTree.SelectedItem as PageNode;
            if (node == null)
                return;
            if (node.HasChildren) {
                TreeViewItem item = (TreeViewItem)pageTree.ItemContainerGenerator.ContainerFromItem(node);
                item = (TreeViewItem)item.ItemContainerGenerator.ContainerFromIndex(0);
                item.IsSelected = true;
            }
        }

        private void Border_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Process.Start("http://uiatoms.neurospeech.com");
        }
    }
}
