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

namespace UIAtoms.WPFSamples.LayoutSamples
{
    /// <summary>
    /// Interaction logic for AtomStackPanelSample.xaml
    /// </summary>
    public partial class AtomStackPanelSample : Page
    {
        public AtomStackPanelSample()
        {
            InitializeComponent();
        }

        private void radioorientation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (radioorientation.SelectedValue.ToString() == "Vertical")
            {
                stackorient.Visibility = System.Windows.Visibility.Visible;
            }
            else if (radioorientation.SelectedValue.ToString() == "Horizontal")
            {
                stackorient.Visibility = System.Windows.Visibility.Visible;   
            }
        }

    }
}
