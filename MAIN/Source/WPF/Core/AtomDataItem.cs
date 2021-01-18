#if NETFX_CORE
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// This serves as a Data object, which has properties for Label, IsSelected, Data and GroupName
    /// typically used for binding List based controls.
    /// </summary>
    public class AtomDataItem : System.ComponentModel.INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Reports change in property value
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property Label
        private string _Label = "";

        /// <summary>
        /// Label to display text for the object.
        /// </summary>
        [AtomDesign( Bindable=true)]
        public string Label
        {
            get
            {
                return _Label;
            }
            set
            {
                _Label = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Label"));
            }
        }

        #endregion

        #region Property Data
        private object _Data = null;

        /// <summary>
        /// Used for bindable data.
        /// </summary>
        [AtomDesign(Bindable = true)]
        public object Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Data"));
            }
        }

        #endregion

        #region Property IsSelected
        private bool? _IsSelected = false;
        /// <summary>
        /// Usually bound to ToggleButton.IsChecked property.
        /// </summary>
        [AtomDesign(Bindable = true)]
        public bool? IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("IsSelected"));
            }
        }

        #endregion

        #region Property GroupName
        private string _GroupName = null;
        /// <summary>
        /// Used for Radio Button Grouping.
        /// </summary>
        [AtomDesign(Bindable = true)]
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("GroupName"));
            }
        }

        #endregion

        /// <summary>
        /// Returns label of the item.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _Label;
        }
	
    }
}
