using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public partial class FormItemModel
    {

        partial void OnItemSet()
        {
            if (this.Item != null)
            {
                Type type = this.Item.ItemType;
            }

            // try getting default property...

        }

        private static string[] DefaultProperties = new[] { 
            "SelectedItem",
            "SelectedValue",
            "Value",
            "Text",
            "IsChecked"
        };

        //private string propertyName = "Text";


        partial void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (e.PropertyName == "Width" || e.PropertyName == "HorizontalAlignment") {
                if (PropertyChanged != null) {
                    PropertyChanged(this,new PropertyChangedEventArgs("ItemWidth"));
                }
            }
            if(e.PropertyName == "AtomForm.Label"){
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
                }
            }
        }

        #region Property DisplayName
        public string DisplayName
        {
            get
            {
                string label = this.Label;
                return this.Item.ItemType.Name + (label==null ? "" : (" (" + label+ ")"));
            }
        }

        #endregion

        #region Property ItemWidth
        //private double _ItemWidth = 0D;
        public double ItemWidth
        {
            get
            {
                return this.Width;
            }
            set
            {
                this.Width = value;
                if (double.IsNaN(value))
                {
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                }
                else {
                    this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                }
            }
        }

        #endregion

        #region Property Binding
        private BindingModel _Binding = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public BindingModel Binding
        {
            get
            {
                if (_Binding == null) {
                    _Binding = new BindingModel(this);
                }
                return _Binding;
            }
        }
        #endregion
	


    }
}
