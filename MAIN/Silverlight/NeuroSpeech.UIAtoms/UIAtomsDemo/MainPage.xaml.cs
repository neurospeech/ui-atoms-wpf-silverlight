using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
//using UIAtomsDemo.Web;
using UIAtomsDemo.Common;
using UIAtomsDemo.DataService;
using System.Xml.Serialization;
using System.Windows.Browser;
using NeuroSpeech.UIAtoms.Validation;

namespace UIAtomsDemo
{
    public partial class MainPage : UserControl
    {
        //private NSDomainContext _nsDomainContext = new NSDomainContext();

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {


            PageNode[] pages = PageNode.RootPages;

            pageList.ItemsSource = pages;


            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            this.Dispatcher.BeginInvoke(() =>
            {
                SelectDefault(pages);
            });

            
        }

        private void SelectDefault(PageNode[] pages)
        {
            string hash = HtmlPage.Document.DocumentUri.OriginalString;
            int i = hash.IndexOf('#');
            if (i != -1) { 
                hash = hash.Substring(i+1);

                PageNode node = FindNode(pages, hash);
                if (node != null) {
                    pageList.SelectItem(node);
                    return;
                }
            }

            pageList.SelectItem(pages[0]);
        }

        private PageNode FindNode(PageNode[] pages, string hash)
        {
            PageNode node = pages.FirstOrDefault(x => x.XAMLName == hash);
            if (node != null)
                return node;
            foreach (PageNode n in pages)
            {
                if (!n.HasChildren)
                    continue;
                PageNode child = FindNode(n.Children, hash);
                if (child != null)
                    return child;
            }
            return null;
        }

        private void pageList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            PageNode node = pageList.SelectedItem as PageNode;
            if (node == null)
                return;

            if (node.HasChildren) {
                pageList.SelectItem(node.Children[0]);
            }
        }

        //private void subscribeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //emailAddress.Text
        //    AtomValidationError error = AtomValidationRule.Validate(emailAddress);
        //    if (error != null) {
        //        MessageBox.Show(error.Message, "Error", MessageBoxButton.OK);
        //        return;
        //    }

        //    LicenseManager.LicenseServiceSoapClient sc = new LicenseManager.LicenseServiceSoapClient();
        //    sc.SubscribeAsync(emailAddress.Text, "com.neurospeech.uiatoms.suite");
        //    sc.SubscribeCompleted += new EventHandler<LicenseManager.SubscribeCompletedEventArgs>(sc_SubscribeCompleted);
        //}

        //void sc_SubscribeCompleted(object sender, LicenseManager.SubscribeCompletedEventArgs e)
        //{
        //    if (e.Error != null) {
        //        MessageBox.Show("There was an error communicating with server, Make sure you are connected to internet", "Error", MessageBoxButton.OK);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Thank you for subscribing.");
        //    }
        //}



    }

    public class PageUrl {
        public string Label { get; set; }
        public string Source { get; set; }
    }
}
