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

namespace UIAtoms.WPFSamples.ListSamples
{
    /// <summary>
    /// Interaction logic for RadioButtonList.xaml
    /// </summary>
    public partial class RadioButtonList : Page
    {
        public RadioButtonList()
        {
            InitializeComponent();
        }

        class Gender
        {
            public string GenderType { get; set; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            radiogender.ItemsSource = new Gender[]{
                new Gender{ 
                    GenderType = "Male"
                },
                new Gender{
                    GenderType = "Female"
                }
            };
                    
        }
    }
}
