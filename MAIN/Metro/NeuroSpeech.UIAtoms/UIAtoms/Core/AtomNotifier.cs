using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Core
{
    public class AtomNotifier : INotifyPropertyChanged
    {

        #region Property Value
        private object _Value = null;
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public object Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Value"));
            }
        }

        #endregion


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
