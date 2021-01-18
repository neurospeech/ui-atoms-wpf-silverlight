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
    /// This class is one master attribute which specifies the design mode metadata, 
    /// which is then processed by design assembly for the WPF designer.
    /// </summary>
    public class AtomDesignAttribute : Attribute
    {
        /// <summary>
        /// Displays or Hides the class on the Toolbox.
        /// </summary>
        public bool DisplayInToolbox { get; set; }

        /// <summary>
        /// Name of Toolbox Tab Name
        /// </summary>
        public string ToolboxTabName { get; set; }

        /// <summary>
        /// Display Name Attribute Value for Properties
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Categorizes the property in Property Browser.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Displays the description of property in Property Browser.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Enables/disables attached properties for children.
        /// </summary>
        public bool DisplayAttachedForChildren { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ObjectToStringConverter { get; set; }

        /// <summary>
        /// If non null, then it enables attached properties for specified type.
        /// </summary>
        public Type DisplayAttachedForType { get; set; }

        /// <summary>
        /// Marks the property as bindable.
        /// </summary>
        public bool Bindable { get; set; }

        /// <summary>
        /// Specifies the default value for the property.
        /// </summary>
        public object DefaultValue { get; set; }

        private AtomPropertyBrowseMode _BrowseMode = AtomPropertyBrowseMode.Never;

        /// <summary>
        /// Browse mode for the property in Property Browsable.
        /// </summary>
        public AtomPropertyBrowseMode BrowseMode { get {
            return _BrowseMode;
        }
            set {
                _BrowseMode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool RegisterUnitControl { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string DesignTimeProviders { get; set; }

    }

    /// <summary>
    /// Browse mode for the property in Property Browsable.
    /// </summary>
    public enum AtomPropertyBrowseMode { 

        /// <summary>
        /// Hides property from Property Browser.
        /// </summary>
        Never, 

        /// <summary>
        /// Displays property in Property Browser.
        /// </summary>
        Default, 

        /// <summary>
        /// Displays property in Property Browser only in Advanced Category.
        /// </summary>
        Extended
        //    ,
        //Appearance, 
        //AppearanceExtended,
        //Layout, 
        //LayoutExtended
    }
}
