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
using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Validation;

namespace WpfTester
{
    /// <summary>
    /// Interaction logic for AsyncErrorTest.xaml
    /// </summary>
    public partial class AsyncErrorTest : Page
    {
        public AsyncErrorTest()
        {
            InitializeComponent();

            rootForm.DataContext = new Customer();
        }

        private void reportButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(cur.DataContext.ToString() + ":" + cur.DataContext.GetType().FullName);

            AtomForm.SetValidationError(cur, new AtomValidationError { Message="Error 1", Property= AtomCurrencyTextBox.ValueProperty, Source=cur });
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            rootForm.ClearError(cur, AtomCurrencyTextBox.ValueProperty);
        }
    }
}
