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
using NeuroSpeech.UIAtoms.UnitControls.Units;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Xml;
using System.Collections.ObjectModel;

namespace UnitEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Conversions.AllowEdit = true;
            //Conversions.AllowNew = true;
            //Conversions.AllowRemove = true;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BaseUnit = new AtomMeasurementUnit();
            conversionItems.ItemsSource = Conversions;
            Binding b = new Binding("BaseUnit");
            b.Source = this;
            this.SetBinding(DataContextProperty, b);
        }



        ///<summary>
        ///DependencyProperty BaseUnit
        ///</summary>
        #region Dependency Property BaseUnit
        public AtomMeasurementUnit BaseUnit
        {
            get { return (AtomMeasurementUnit)GetValue(BaseUnitProperty); }
            set { SetValue(BaseUnitProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for BaseUnit.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty BaseUnitProperty =
            DependencyProperty.Register("BaseUnit", typeof(AtomMeasurementUnit), typeof(MainWindow), new FrameworkPropertyMetadata(null, OnBaseUnitChangedCallback));

        private static void OnBaseUnitChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MainWindow obj = d as MainWindow;
            if (obj != null)
            {
                obj.OnBaseUnitChanged(e);
            }
        }

        /// <summary>
        /// Fires BaseUnitChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnBaseUnitChanged(DependencyPropertyChangedEventArgs e)
        {
            if (BaseUnitChanged != null)
            {
                BaseUnitChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler BaseUnitChanged;

        #endregion

        //public BindingList<AtomDerivedUnit> Conversions = new BindingList<AtomDerivedUnit>();
        public ObservableCollection<AtomDerivedUnit> Conversions = new ObservableCollection<AtomDerivedUnit>();

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog()== true) {
                // load manually...
                LoadXML(ofd.FileName);
            }

        }

        private string FileName = "";

        private void LoadXML(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            FileName = fileName;


            LoadElement(BaseUnit, doc.DocumentElement);

            /*if (BaseUnit.Version > 0)
            {
                // load via serializer
                BaseUnit = AtomSerializer.Load<AtomMeasurementUnit>(fileName);
                Conversions.Clear();
                //Conversions.RaiseListChangedEvents = false;
                foreach (AtomDerivedUnit du in BaseUnit.Conversions) {
                    Conversions.Add(du);
                }
                //Conversions.RaiseListChangedEvents = true;
                //Conversions.ResetBindings();
            }
            else*/
            {
                //Conversions.RaiseListChangedEvents = false;
                Conversions.Clear();
                XmlNodeList list = doc.DocumentElement.GetElementsByTagName("Conversions");
                list = list[0].ChildNodes;
                foreach (XmlNode node in list) {
                    XmlElement e = node as XmlElement;
                    if (e == null)
                        continue;
                    AtomDerivedUnit du = new AtomDerivedUnit();
                    LoadElement(du, e);
                    Conversions.Add(du);
                }
                //Conversions.RaiseListChangedEvents = true;
                //Conversions.ResetBindings();
            }

        }

        private void LoadElement(Object obj, XmlElement e)
        {
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(obj);
            foreach (PropertyDescriptor item in pdc)
            {
                string val = "";
                if (e.HasAttribute(item.Name)) {
                    val = e.GetAttribute(item.Name);
                }
                XmlNodeList list = e.GetElementsByTagName(item.Name);
                if (list.Count > 0) {
                    XmlNode node = list[0];
                    val = node.Value;
                }
                if (!string.IsNullOrEmpty(val))
                {
                    //if (item.PropertyType != typeof(Paragraph))
                    {
                        item.SetValue(obj, Convert.ChangeType(val, item.PropertyType));
                    }
                    /*else
                    {
                        Section s = new Section();
                        Paragraph p = new Paragraph();
                        p.FontFamily = new System.Windows.Media.FontFamily("Palatino Linotype");
                        s.Blocks.Add(p);
                        p.Inlines.Add(val);
                        item.SetValue(obj, p);
                    }*/
                }
            }
        }

        private void SaveAsMenu_Click(object sender, RoutedEventArgs e)
        {
            //BaseUnit.Version = 1.1;

            BaseUnit.Conversions = Conversions.ToArray();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xml|*.xml";
            if (sfd.ShowDialog() != true)
                return;
            FileName = sfd.FileName;

            AtomSerializer.Save(BaseUnit, FileName);
        }


        private void SaveMenu_Click(object sender, RoutedEventArgs e)
        {
            //BaseUnit.Version = 1.1;

            BaseUnit.Conversions = Conversions.ToArray();

            if (string.IsNullOrEmpty(FileName))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.xml|*.xml";
                if (sfd.ShowDialog() != true)
                    return;
                FileName = sfd.FileName;
            }

            AtomSerializer.Save(BaseUnit, FileName);
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Conversions.Add(new AtomDerivedUnit { });
            conversionItems.SelectedIndex = Conversions.Count - 1;
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Conversions.Remove(conversionItems.SelectedItem as AtomDerivedUnit);
        }

    }
}
