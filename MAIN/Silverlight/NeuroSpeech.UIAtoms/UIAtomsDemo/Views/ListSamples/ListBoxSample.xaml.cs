﻿using System;
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

namespace UIAtomsDemo.Views.ListSamples
{
    public partial class ListBoxSample : Page
    {
        public ListBoxSample()
        {
            InitializeComponent();

            // Set 0 and 3 as Invalid Indices
            invalidItemsList.InvalidIndices = new[] { 0, 3 };
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}
