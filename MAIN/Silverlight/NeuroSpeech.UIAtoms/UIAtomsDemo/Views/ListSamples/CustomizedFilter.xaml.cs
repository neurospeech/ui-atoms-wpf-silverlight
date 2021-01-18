using System;
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
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Controls;

namespace UIAtomsDemo.Views.ListSamples
{
    public partial class CustomizedFilter : Page
    {
        public CustomizedFilter()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }




    public class CountryViewModel {


        // load countries
        public AtomCountryItem[] Countries {
            get {
                return AtomCountryComboBox.LoadCountries(null).ToArray();
            }
        }

        // provide filter...
        public IAtomItemsFilter FilterProvider{
            get {
                return new CountryFilter();
            }
        }

        public class CountryFilter : IAtomItemsFilter
        {

            public bool FilterItem(
                object itemsControl, 
                object item, 
                string filterText, 
                object filterParameter,
                AtomTextFilterMode mode, 
                StringComparison comparison)
            {
                AtomCountryItem country = item as AtomCountryItem;

                if (country.CountryName.ToLower().StartsWith(filterText.ToLower()))
                    return true;

                return false;
            }

        }

    }


}
