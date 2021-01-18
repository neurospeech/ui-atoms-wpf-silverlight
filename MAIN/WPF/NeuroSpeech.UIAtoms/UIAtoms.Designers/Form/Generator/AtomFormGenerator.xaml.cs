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
using Microsoft.Windows.Design.Model;

namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    /// <summary>
    /// Interaction logic for AtomFormGenerator.xaml
    /// </summary>
    public partial class AtomFormGenerator : Window
    {
        public AtomFormGenerator(string prefix)
        {
            this.DataContext = new FormGeneratorViewModel(prefix);

            InitializeComponent();

            if (prefix == "AtomDataForm.")
            {
                itemListView.Columns.Remove(invalidColumn);
                itemListView.Columns.Remove(missingColumn);
            }

            this.Loaded += new RoutedEventHandler(AtomFormGenerator_Loaded);
        }


        #region void  AtomFormGenerator_Loaded(object sender, RoutedEventArgs e)
        void AtomFormGenerator_Loaded(object sender, RoutedEventArgs e)
        {
            FormGeneratorViewModel vm = DataContext as FormGeneratorViewModel;
            if(vm.Items.Count==0)
                vm.OpenTypeCommand.Execute(null);
            vm.SetDefaultType();
        }
        #endregion



        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            FormGeneratorViewModel vm = DataContext as FormGeneratorViewModel;
            foreach (var item in vm.Items)
            {
                item.Binding.SaveBindings();
            }
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

    }
}
