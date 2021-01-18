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

namespace UIAtomsDemo
{
    public class SamplesViewModel : INotifyPropertyChanged
    {

        public SamplesViewModel()
        {


            SelectedPage = RootNodes[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PageNode[] RootNodes {
            get {
                return PageNode.RootPages;
            }
        }

        #region Property SelectedPage
        private PageNode _SelectedPage = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public PageNode SelectedPage
        {
            get
            {
                return _SelectedPage;
            }
            set
            {
                _SelectedPage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SelectedPage"));
            }
        }

        #endregion
	

    }
}
