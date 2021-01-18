using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.Windows.Design.Model;
using NeuroSpeech.UIAtoms.Designers.Form.Generator;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class BindingModel : INotifyPropertyChanged
    {
        private FormItemModel formItem;

        public BindingModel(FormItemModel formItem)
        {
            this.formItem = formItem;
            formItem.PropertyChanged += new PropertyChangedEventHandler(formItem_PropertyChanged);
            PropertyCollection = new ObservableCollection<string>();
            VerifyItemType();
        }


        #region void  formItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        void formItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            VerifyItemType();
        }


        #endregion

        Type lastType = null;

        #region private void VerifyItemType()
        private void VerifyItemType()
        {
            if (formItem.Item != null) {
                if (formItem.Item.ItemType != lastType) {
                    lastType = formItem.Item.ItemType;

                    ResetPropertiesCollection();
                }
            }
        }
        #endregion

        #region private void ResetPropertiesCollection()
        private void ResetPropertiesCollection()
        {
            PropertyCollection.Clear();
            if (lastType == null)
                return;
            foreach (PropertyInfo p in 
                lastType.GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.FlattenHierarchy)
                .OrderBy(x=>x.Name)
                ) {
                PropertyCollection.Add(p.Name);
            }

            // binding exits???

            SelectDefault();

        }

        private void SelectDefault()
        {
            string suggestedProperty = SelectedProperty;

            // choose default...
            string[] properties = new string[] { 
                "SelectedValue",
                "SelectedItem",
                "Value",
                "Password",
                "Text"
            };
            string val = null;
            foreach (string item in PropertyCollection)
            {
                ModelItem binding = formItem.Item.Properties[item].Value;
                if (binding != null && binding.ItemType.FullName == "System.Windows.Data.Binding") {
                    if (properties.Contains(item)) {
                        SelectedProperty = item;
                        return;
                    }
                    val = item;
                }
            }
            foreach (string item in properties)
            {
                if(PropertyCollection.Contains(item))
                {
                    SelectedProperty = item;
                    return;
                }
            }
            if (val!=null)
                SelectedProperty = val;
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<string> PropertyCollection { get; private set; }

        #region Property SelectedProperty
        private string _SelectedProperty = "Text";
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue("Text")]
        [System.ComponentModel.Category("Category")]
        public string SelectedProperty
        {
            get
            {
                return _SelectedProperty;
            }
            set
            {
                _SelectedProperty = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SelectedProperty"));

                // verify and load TargetName...
                LoadTargetName();
            }
        }

        #region private void LoadTargetName()
        private void LoadTargetName()
        {
            ModelItem binding = formItem.Item.Properties[SelectedProperty].Value;
            if (binding == null)
                return;
            if (binding.ItemType.FullName != "System.Windows.Data.Binding")
                return;
            TargetName = binding.Properties["Path"].Value.Properties["Path"].Value.GetCurrentValue().ToString();
            TwoWay = binding.Properties["Mode"].Value.GetCurrentValue().ToString() == "TwoWay";
        }
        #endregion


        #endregion

        #region Property TargetName
        private string _TargetName = "";
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Category("Category")]
        public string TargetName
        {
            get
            {
                return _TargetName;
            }
            set
            {
                _TargetName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("TargetName"));
            }
        }

        #endregion

        #region Property TwoWay
        private bool _TwoWay = false;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Category("Category")]
        public bool TwoWay
        {
            get
            {
                return _TwoWay;
            }
            set
            {
                _TwoWay = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("TwoWay"));
            }
        }

        #endregion
	

        public void SaveBindingsWithSelectedProperty() {
            VerifyItemType();
            if (string.IsNullOrWhiteSpace(SelectedProperty))
                return;
            SaveBindings();
        }

        public void SaveBindings() {

            if (string.IsNullOrWhiteSpace(TargetName))
                return;

            ModelItem item = formItem.Item;
            ModelItem binding = null;
            ModelProperty p = formItem.Item.Properties[SelectedProperty];
            if (!p.IsSet)
            {
                // create binding...
                Type type = FormGeneratorViewModel.GetControlType(item.Context, "System.Windows.Data.Binding");
                binding = ModelFactory.CreateItem(item.Context, type);
                p.SetValue(binding);
            }
            else { 
                // check if it is binding or not...
                // otherwise destroy it..
                ModelItem val = p.Value;
                if (val.ItemType.FullName != "System.Windows.Data.Binding")
                {
                    p.ClearValue();
                    Type type = FormGeneratorViewModel.GetControlType(item.Context, "System.Windows.Data.Binding");
                    binding = ModelFactory.CreateItem(item.Context, type);
                    p.SetValue(binding);
                }
                else {
                    binding = p.Value;
                }
            }

            // set bindings...

            binding.Properties["Path"].SetValue(TargetName);

            if (TwoWay) {
                ModelProperty mp = binding.Properties["Mode"];
                Type enType = mp.PropertyType;
                object val = Enum.Parse(enType, "TwoWay");
                mp.SetValue(val);
            }
        }


        #region internal void SelectDefaultProperty()
        internal void SelectDefaultProperty()
        {
            VerifyItemType();
        }
        #endregion
}
}
