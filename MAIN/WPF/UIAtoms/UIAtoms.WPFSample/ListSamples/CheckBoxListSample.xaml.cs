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
    /// Interaction logic for CheckBoxListSample.xaml
    /// </summary>
    public partial class CheckBoxListSample : Page
    {
        public CheckBoxListSample()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            seatcheckbox.ItemsSource = new SeatType[]{
                new SeatType {
                    SeatTypeName = "Leather Seats"
                },
                new SeatType{
                    SeatTypeName = "Automatic Wipers"
                },
                new  SeatType{
                    SeatTypeName = "Automatic Xenon Headlamps"
                }
            };

            breakcheckbox.ItemsSource = new BreakType[]{
                new BreakType{
                    BreakTypeName = "ABS Braking System"
                },
                new  BreakType{
                    BreakTypeName = "TCS Tranction Control System"
                },
                new BreakType{
                    BreakTypeName = "ESP - Electronic Stability Program"
                }
          };
        }
        class SeatType
        {
            public string SeatTypeName { get; set; }
        }

        class BreakType
        {
            public string BreakTypeName { get; set; }
        }

    }

}
