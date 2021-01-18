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
    /// Interaction logic for AccordionPanelSample.xaml
    /// </summary>
    public partial class AccordionPanelSample : Page
    {
        public AccordionPanelSample()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cartyperadio.ItemsSource = new CarType[] {
                new CarType{
                    Description = "Petrol - Vehicles fitted with petrol engines"
                },
            
                    
                new CarType{
                    Description = "Diesel - Vehicles fitted with diesel engines"
                },
                    
                    new CarType{
                    Description = "Hybrid - Vehicles fitted with elecrtric motors\n"+
                    "combined with petrol engines"
                    }
            };

            entertainmentRadio.ItemsSource = new EnterTainmentType[]{
                new EnterTainmentType{
                     TypeofEntertainment="HD Radio"
                },
                new EnterTainmentType{
                     TypeofEntertainment="iPod and USB adapter"
                },
                new EnterTainmentType{
                     TypeofEntertainment="Premium hi-fi system"
                }

            };
            seatcheckbox.ItemsSource = new CarOption[]{
                        new CarOption{
                            Label = "Leather Seats",
                            Description = "Optional"
                        },
                        new CarOption{
                            Label = "Heated Seats",
                            Description = "Optional"
                        },
                        new CarOption{
                            Label = "Sunroof",
                            Description = "Optional"
                        },
                        new CarOption{
                            Label = "Integrated Stereo",
                            Description = "Optional"
                        },
                        new CarOption{
                            Label = "Traction Control System",
                            Description = "Optional"
                        },
                        new CarOption{
                            Label = "Automatic Xenon Headlamps",
                            Description = "Optional"
                        }
                    };
            
        }


        class CarType
        {
            public string TypeName { get; set; }

            public string Description { get; set; }

        }

        class EnterTainmentType
        {
            public string TypeofEntertainment { get; set; }
        }

        class CarOption
        {
            public string Label { get; set; }

            public string Description { get; set; }
        }

    }
}
