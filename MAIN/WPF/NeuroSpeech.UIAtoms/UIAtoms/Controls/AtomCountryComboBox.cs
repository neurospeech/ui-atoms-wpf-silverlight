#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !SILVERLIGHT
#endif
using System.Xml;
using System.Threading;
using System.IO;
using NeuroSpeech.UIAtoms.Core;
using System.Collections.ObjectModel;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// AtomCountryComboBox is extends the AtomComboBox with preconfigured country data.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomCountryComboBox includes the following:
    /// </listheader>
    /// 		<item>
    /// 			<term>
    /// Country name
    /// </term>
    /// 		</item>
    /// 		<item>
    /// 			<term>
    /// Country Flag
    /// </term>
    /// 		</item>
    /// 		<item>
    /// 			<term>
    /// Country Currency Symbol
    /// </term>
    /// 		</item>
    /// 		<item>
    /// 			<term>
    /// Two Letter Country Code 
    /// </term>
    /// 		</item>
    /// 		<item>
    /// 			<term>
    /// International Country Phone Code
    /// </term>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomCountryComboBox : AtomComboBox
    {
#if SILVERLIGHT
        public AtomCountryComboBox()
        {
            DefaultStyleKey = typeof(AtomCountryComboBox);
            InvalidIndices = new int[] { 0 , -1 };
            this.SelectedValuePath = "CountryCode";
            AtomFilterTextBox.SetTextPath(this, "CountryName");
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
            IsFilterVisible = true;
            LoadCountries();
        }
#else
        static AtomCountryComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomCountryComboBox), new FrameworkPropertyMetadata(typeof(AtomCountryComboBox)));
            AtomComboBox.InvalidIndicesProperty.OverrideMetadata(typeof(AtomCountryComboBox), new FrameworkPropertyMetadata(new int[] { 0, -1 }));
            AtomComboBox.SelectedValuePathProperty.OverrideMetadata(typeof(AtomCountryComboBox), new FrameworkPropertyMetadata("CountryCode"));
            //NSComboBox.DisabledIndicesProperty.OverrideMetadata(typeof(NSCountryComboBox), new FrameworkPropertyMetadata(new int[] { 0, -1}));
            IsFilterVisibleProperty.OverrideMetadata(
                typeof(AtomCountryComboBox),
                new FrameworkPropertyMetadata(true));
        }
#endif


#if SILVERLIGHT
        
#else
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            if (AtomHelper.IsInDesignMode(this))
                return;

            TextSearch.SetTextPath(this, "CountryName");

            LoadCountries();
        }
#endif

        private void LoadCountries() {

            ThreadPool.QueueUserWorkItem((state) =>
            {

                List<AtomCountryItem> countries = LoadCountries(null);

#if SILVERLIGHT
                countries.Insert(0,new AtomCountryItem { CountryName = "Select", CountryCode = "", ImageUri = "/NeuroSpeech.UIAtoms.Silverlight;component/CountryIcons/-flag.png" });
#else
                countries.Insert(0, new AtomCountryItem { CountryName = "Select", CountryCode = "", ImageUri = "/NeuroSpeech.UIAtoms;component/CountryIcons/-flag.gif" });
#endif
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    this.ItemsSource = countries;
                    if (this.GetValue(SelectedValueProperty) == DependencyProperty.UnsetValue)
                    {
                        this.SelectedIndex = 0;
                    }
                });
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cxml"></param>
        /// <returns></returns>
        public static List<AtomCountryItem> LoadCountries(string cxml)
        {

            // load countries...
            if(cxml==null)
                cxml = NeuroSpeech.UIAtoms.Properties.Resources.Countries;

            List<AtomCountryItem> countries = new List<AtomCountryItem>();

            XmlReader xr = XmlReader.Create(new StringReader(cxml));
            xr.Read();

            while (xr.Read())
            {
                if (xr.NodeType == XmlNodeType.Element)
                    countries.Add(new AtomCountryItem(xr));
            }
            xr.Close();
            return countries;
        }


    }


    /// <summary>
    /// Used in Country Combobox.
    /// </summary>
    public class AtomCountryItem
    {
        /// <summary>
        /// CountryCode is a string value that holds the Country Code of the country.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// CountryName is a string that holds the name of the country.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ISDCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LocalCode { get; set; }

        /// <summary>
        /// IDDCode is the string value that holds the International Dialing Code of the country.
        /// </summary>
        public string IDDCode { get; set; }

        /// <summary>
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AtomCountryItem()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        internal AtomCountryItem(XmlReader r)
        {
            if (r.MoveToFirstAttribute()) 
                LoadNode(r);
            
            while (r.MoveToNextAttribute())
                LoadNode(r);

#if SILVERLIGHT
            ImageUri = "/NeuroSpeech.UIAtoms.Silverlight;component/CountryIcons/" + CountryCode + "-flag.png";
#else
            ImageUri = "/NeuroSpeech.UIAtoms;component/CountryIcons/" + CountryCode + "-flag.gif";
#endif
        }

        private void LoadNode(XmlReader r)
        {
            switch (r.Name)
            {
                case "CountryName":
                    CountryName = r.Value;
                    break;
                case "CountryCode":
                    CountryCode = r.Value;
                    break;
                case "ISDCode":
                    ISDCode = r.Value;
                    break;
                case "LocalCode":
                    LocalCode = r.Value;
                    break;
                case "IDDCode":
                    IDDCode = r.Value;
                    break;
                default:
                    break;
            }
        }

    }
}
