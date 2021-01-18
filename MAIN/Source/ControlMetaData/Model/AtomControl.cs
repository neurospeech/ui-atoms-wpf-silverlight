using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMetaData.Model
{
    public class AtomControl : BindableObject
    {

        private AtomPropertyList _Properties = new AtomPropertyList();
        [Browsable(false)]
        public AtomPropertyList Properties {
            get {
                return _Properties;
            }
        }

        private AtomTemplatePartList _Parts = new AtomTemplatePartList();
        public AtomTemplatePartList Parts {
            get {
                return _Parts;
            }
        }

        private AtomAttachedPropertyList _AttachedProperties = new AtomAttachedPropertyList();
        public AtomAttachedPropertyList AttachedProperties
        {
            get
            {
                return _AttachedProperties;
            }
        }

        private string _BaseType = "Control";
        public string BaseType
        {
            get
            {
                return _BaseType;
            }
            set
            {
                _BaseType = value;
                OnPropertyChanged("BaseType");
            }
        }

		private bool _Active = true;
		public bool Active {
			get {
				return _Active;
			}
			set {
				_Active = value;
				OnPropertyChanged("Active");
			}
		}

		#region Property TParams
		private string _TParams = "";
		public string TParams
		{
			get
			{
				return _TParams;
			}
			set
			{
				_TParams = value;
				OnPropertyChanged("TParams");
			}
		}

		#endregion
	

        #region Property DefaultStyle
        private bool _DefaultStyle = false;

        public bool DefaultStyle
        {
            get { return _DefaultStyle; }
            set
            {
                _DefaultStyle = value;
                OnPropertyChanged("DefaultStyle");
            }
        }
        #endregion

		#region internal AtomProperty GetProperty(string name,bool attached)
		internal AtomProperty GetProperty(string name, bool attached)
		{
			if (attached) {
				var ap = AttachedProperties.FirstOrDefault(x => x.Name == name);
				if (ap == null) {
					ap = new AtomAttachedProperty();
					ap.Name = name;
					AttachedProperties.Add(ap);
				}
				return ap;
			}

			var dp = Properties.FirstOrDefault(x => x.Name == name);
			if (dp == null) {
				dp = new AtomProperty();
				dp.Name = name;
				Properties.Add(dp);
			}
			return dp;
		}
		#endregion
}

    public class AtomControlList : ObservableCollection<AtomControl>
    {

        private AtomControlSet owner;

        public AtomControlList(AtomControlSet owner)
        {
            this.owner = owner;
        }
    }

    public class AtomPropertyList : ObservableCollection<AtomProperty>
    {
 
    }

    public class AtomTemplatePart : BindableObject
    {
        #region Property Required
        private bool _Required = false;

        public bool Required
        {
            get { return _Required; }
            set
            {
                _Required = value;
                OnPropertyChanged("Required");
            }
        }
        #endregion

        #region Property ElementName
        private string _ElementName = null;

        public string ElementName
        {
            get { return _ElementName; }
            set
            {
                _ElementName = value;
                OnPropertyChanged("ElementName");
            }
        }
        #endregion

        #region Property Type
        private string _Type = "Control";

        public string Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }
        #endregion

        public string GetElementName()
        {
            return string.IsNullOrWhiteSpace(ElementName) ? Name : ElementName;
        }
    }

    public class AtomTemplatePartList : ObservableCollection<AtomTemplatePart> { 
    }

    public class AtomAttachedProperty : AtomProperty {
        #region Property DisplayAttachedForChildren
        private bool _DisplayAttachedForChildren = false;

        public bool DisplayAttachedForChildren
        {
            get { return _DisplayAttachedForChildren; }
            set
            {
                _DisplayAttachedForChildren = value;
                OnPropertyChanged("DisplayAttachedForChildren");
            }
        }
        #endregion
    }

    public class AtomAttachedPropertyList : ObservableCollection<AtomAttachedProperty> { 
    }

    public class AtomProperty : BindableObject
    {

        public bool RequiresChangeDelegate()
        {
            return GenerateChangeMethod || GenerateEvent;
        }


        public string GetDefaultValue() {
			if(string.IsNullOrWhiteSpace(DefaultValue))
				return "null";
			return DefaultValue;
        }

		#region Property OwnerType
		private string _OwnerType = "";
		public string OwnerType
		{
			get
			{
				return _OwnerType;
			}
			set
			{
				_OwnerType = value;
				OnPropertyChanged("OwnerType");
			}
		}

		#endregion
	

        private string _Type = "Object";
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
                OnPropertyChanged("Type");
            }
        }

        private bool _GenerateEvent = false;
        public bool GenerateEvent
        {
            get
            {
                return _GenerateEvent;
            }
            set
            {
                _GenerateEvent = value;
                OnPropertyChanged("GenerateEvent");
            }
        }

        private bool _GenerateChangeMethod = false;
        public bool GenerateChangeMethod
        {
            get
            {
                return _GenerateChangeMethod;
            }
            set
            {
                _GenerateChangeMethod = value;
                OnPropertyChanged("GenerateChangeMethod");
            }
        }

        #region Property DisplayName
        private string _DisplayName = null;

        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                OnPropertyChanged("DisplayName");
            }
        }
        #endregion

        #region Property Category
        private string _Category = null;

        public string Category
        {
            get { return _Category; }
            set
            {
                _Category = value;
                OnPropertyChanged("Category");
            }
        }
        #endregion

        #region Property Description
        private string _Description = null;

        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }
        #endregion


        #region Property ObjectToStringConverter
        private bool _ObjectToStringConverter = false;

        public bool ObjectToStringConverter
        {
            get { return _ObjectToStringConverter; }
            set
            {
                _ObjectToStringConverter = value;
                OnPropertyChanged("ObjectToStringConverter");
            }
        }
        #endregion

        #region Property Bindable
        private bool _Bindable = false;

        public bool Bindable
        {
            get { return _Bindable; }
            set
            {
                _Bindable = value;
                OnPropertyChanged("Bindable");
            }
        }
        #endregion

        #region Property DefaultValue
        private string _DefaultValue = null;

        public string DefaultValue
        {
            get { return _DefaultValue; }
            set
            {
                _DefaultValue = value;
                OnPropertyChanged("DefaultValue");
            }
        }
        #endregion

        #region Property BrowseMode
        private AtomPropertyBrowseMode _BrowseMode = AtomPropertyBrowseMode.Default;

        public AtomPropertyBrowseMode BrowseMode
        {
            get { return _BrowseMode; }
            set
            {
                _BrowseMode = value;
                OnPropertyChanged("BrowseMode");
            }
        }
        #endregion

    }


    public enum AtomPropertyBrowseMode { 
        Never,
        Default,
        Extended
    }
}
