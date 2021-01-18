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


// Add this namespace...
using NeuroSpeech.UIAtoms;

namespace UIAtomsDemo.Views.FormSamples
{
    public partial class LambdaBindingSample : Page
    {
        public LambdaBindingSample()
        {
            InitializeComponent();

            // this is how we set the binding...
            // Make sure you add NeuroSpeech.UIAtoms namespace...
            this.fullName.Bind(TextBlock.TextProperty, 
                () => string.Format(
                    "{0} {1}",
                        firstName.Text,
                        lastName.Text));

            // Bind is an extension method for any dependency object
            // in which the first parameter has to be the target dependency property
            // and second parameter has to be the Lambda Expression involving other
            // dependency object and its properties





            // this is how we set Visibility Binding
            // visibility binding will expect boolean expression
            socialSecurity.BindVisibility(() => showDetails.IsChecked == true);
            passportNumber.BindVisibility(() => showDetails.IsChecked == true);
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
