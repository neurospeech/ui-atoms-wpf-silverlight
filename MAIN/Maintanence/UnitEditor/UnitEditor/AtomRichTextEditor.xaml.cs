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
using System.Windows.Shapes;
using System.Windows.Markup;
using System.IO;
using NeuroSpeech.UIAtoms.Core;

namespace UnitEditor
{
    /// <summary>
    /// Interaction logic for AtomRichTextEditor.xaml
    /// </summary>
    public partial class AtomRichTextEditor : Window , NeuroSpeech.UIAtoms.Controls.IAtomValueProvider
    {
        public AtomRichTextEditor()
        {
            InitializeComponent();
        }

        public object Value
        {
            get
            {
                return rtb.Xaml;
            }
            set
            {
                if (value != null)
                {
                    rtb.Xaml = value.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Toggle_Subscript(object sender, RoutedEventArgs e)
        {
            //rtb.Selection.ApplyPropertyValue(Run.BaselineAlignmentProperty, BaselineAlignment.Subscript);
            double val = (double)rtb.Selection.GetPropertyValue(Run.FontSizeProperty);
            if (val == 7)
            {
                rtb.Selection.ClearAllProperties();
            }else{
                rtb.Selection.ApplyPropertyValue(Run.FontSizeProperty, (double)7);
            }
        }


        private void Toggle_Superscript(object sender, RoutedEventArgs e)
        {
            //rtb.Selection.ApplyPropertyValue(Run.BaselineAlignmentProperty, BaselineAlignment.Superscript);
        }
    }
}
