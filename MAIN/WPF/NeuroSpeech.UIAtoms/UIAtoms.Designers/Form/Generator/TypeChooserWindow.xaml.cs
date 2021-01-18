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

namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    /// <summary>
    /// Interaction logic for TypeChooserWindow.xaml
    /// </summary>
    public partial class TypeChooserWindow : Window
    {
        public TypeChooserWindow()
        {


            InitializeComponent();
            this.DataContext = new TypeChooserWindowViewModel();
        }

        private void typeTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TypeChooserWindowViewModel vm = this.DataContext as TypeChooserWindowViewModel;
            vm.SelectedType = typeTree.SelectedItem;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
