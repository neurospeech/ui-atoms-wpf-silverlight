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
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Dialogs
{
    public partial class AtomCalculatorDialog : ChildWindow, IAtomValueProvider
    {
        public AtomCalculatorDialog()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(AtomCalculatorDialog_Loaded);
        }

        void AtomCalculatorDialog_Loaded(object sender, RoutedEventArgs e)
        {
            calculator.Value = Value;
        }

        public decimal Value { get; set; }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Value = calculator.Value;
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        object IAtomValueProvider.Value
        {
            get
            {
                return this.Value;
            }
            set
            {
                if (value != null) {
                    decimal v = 0;
                    if (decimal.TryParse(value.ToString(), out v)) {
                        this.Value = v;
                    }
                }
            }
        }
    }
}

