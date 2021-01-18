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
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;

namespace UIAtoms.WPFSamples.TraceSample
{
    /// <summary>
    /// Interaction logic for TraceSample.xaml
    /// </summary>
    public partial class TraceSample : Page
    {
        public TraceSample()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            AtomTrace.WriteLine(b.Content + " Clicked.");
        }

        private void eventsCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            AtomTrace.WriteLine("Mouse Entered the Canvas.");
        }

        private void eventsCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            AtomTrace.WriteLine("Mouse Left the Canvas");
        }

        private void eventsCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AtomTrace.WriteLine("Left Button down in the Canvas");
        }

        private void eventsCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AtomTrace.WriteLine("Left Button up in the Canvas");
        }

        private void eventsCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(eventsCanvas);
            AtomTrace.WriteLine(string.Format("Mouse moved in the Canvas to {0:000},{1:000}", p.X, p.Y));
        }

        private void eventsCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            AtomTrace.WriteLine(string.Format("Mouse wheeel changed to {0}", e.Delta));
        }

    }
}
