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

namespace UIAtomsDemo.Views.FormSamples
{
    public partial class FormLabelAlignmentSample : Page
    {
        public FormLabelAlignmentSample()
        {
            InitializeComponent();

            halign.Items.Add(HorizontalAlignment.Left);
            halign.Items.Add(HorizontalAlignment.Right);
            halign.Items.Add(HorizontalAlignment.Center);
            halign.Items.Add(HorizontalAlignment.Stretch);

            valign.Items.Add(VerticalAlignment.Top);
            valign.Items.Add(VerticalAlignment.Bottom);
            valign.Items.Add(VerticalAlignment.Center);
            valign.Items.Add(VerticalAlignment.Stretch);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
