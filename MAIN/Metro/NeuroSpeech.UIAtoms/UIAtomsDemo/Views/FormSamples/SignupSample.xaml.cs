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
using System.Windows.Navigation;
using UIAtomsDemo.Common;
using UIAtomsDemo.DataService;

namespace UIAtomsDemo.Views.FormSamples
{
    public partial class SignupSample : Page
    {
        public SignupSample()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Utils.Execute<WSResultOfEmployee>(
            //    () =>
            //    {
            //        IAsyncResult r = Utils.WebService.BeginGetEmployees("", null, null);
            //        r.AsyncWaitHandle.WaitOne();
            //        return Utils.WebService.EndGetEmployees(r);
            //    },
            //    (r) =>
            //    {
            //        this.NSdataGrid.ItemsSource = r.Results;
            //    }
            // );

        }


    }
}
