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
using System.IO;
using System.ServiceModel;
using NeuroSpeech.UIAtoms.Designers.WebLicense;

namespace NeuroSpeech.UIAtoms.Design.License
{
    /// <summary>
    /// Interaction logic for ActivateLicenseWindow.xaml
    /// </summary>
    public partial class ActivateLicenseWindow : Window
    {
        public ActivateLicenseWindow()
        {
            InitializeComponent();
        }

        public string FilePath { get; set; }

        private void activateButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmailAddress.Text;
            string code = txtActivationCode.Text;
            EndpointAddress remoteAddress 
                = new EndpointAddress("http://account.neurospeech.com/Service/LicenseService.asmx");
            System.ServiceModel.Channels.Binding binding = new System.ServiceModel.BasicHttpBinding( BasicHttpSecurityMode.None);
            LicenseServiceSoapClient ls = new LicenseServiceSoapClient(binding, remoteAddress);

            ls.GetLicenseCompleted += new EventHandler<Designers.WebLicense.GetLicenseCompletedEventArgs>(ls_GetLicenseCompleted);
            ls.GetLicenseAsync(email, "", code, System.Environment.MachineName);
            this.activateButton.IsEnabled = false;
        }

        #region void  ls_GetLicenseCompleted(object sender, Designers.WebLicense.GetLicenseCompletedEventArgs e)
        void ls_GetLicenseCompleted(object sender, Designers.WebLicense.GetLicenseCompletedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)delegate()
            {
                var result = e.Result;
                if (result.Successful)
                {
                    File.WriteAllText(FilePath, result.Result);
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show(result.Message, "Operation Unsuccessful");
                    this.activateButton.IsEnabled = true;
                }

            });
        }
        #endregion






    }
}
