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
using System.Collections.ObjectModel;

namespace UIAtoms.WPFSamples.EditorSamples
{
    /// <summary>
    /// Interaction logic for FileSizeSample.xaml
    /// </summary>
    public partial class FileSizeSample : Page
    {
        public ulong converttype;
        public string sizetype;

        public FileSizeSample()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            tv1.ItemsSource = new[] { new FileObject("C:\\"), new FileObject("D:\\") };
        }

    }
}
