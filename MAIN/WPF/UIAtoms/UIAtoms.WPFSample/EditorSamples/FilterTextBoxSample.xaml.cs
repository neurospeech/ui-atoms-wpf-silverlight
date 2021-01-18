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
using UIAtoms.WPFSamples.Data.NwindDataSetTableAdapters;
using UIAtoms.WPFSamples.Data;

namespace UIAtoms.WPFSamples.EditorSamples
{
    /// <summary>
    /// Interaction logic for FilterTextBoxSample.xaml
    /// </summary>
    public partial class FilterTextBoxSample : Page
    {
        public FilterTextBoxSample()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CustomersTableAdapter customersTableAdapter =
            new CustomersTableAdapter();
            NwindDataSet.CustomersDataTable customers =
               customersTableAdapter.GetData();
            this.DataContext = customers;

        }
    }
}
