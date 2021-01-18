using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMetaData.Model
{
    public class AtomControlSet : BindableObject
    {

        public AtomControlSet()
        {
            _Controls = new AtomControlList(this);
        }

        private AtomControlList _Controls;

        public AtomControlList Controls {
            get {
                return this._Controls;
            }
        }

        #region Property Namespace
        private string _Namespace = "";

        public string Namespace
        {
            get { return _Namespace; }
            set
            {
                _Namespace = value;
                OnPropertyChanged("Namespace");
            }
        }
        #endregion


		#region internal AtomControl GetControl(string name)
		internal AtomControl GetControl(string name)
		{
			var ctrl = Controls.FirstOrDefault(x => x.Name == name);
			if (ctrl == null) {
				ctrl = new AtomControl();
				ctrl.Name = name;
				Controls.Add(ctrl);
			}
			return ctrl;
		}
		#endregion
}
}
