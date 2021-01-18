#if DesignSL
extern alias sl;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;
using System.Reflection;
using System.ComponentModel;
using System.Windows;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.PropertyEditing;
using NeuroSpeech.UIAtoms.Design.Editors;
using Microsoft.Windows.Design.Features;

#if DesignSL
using NSU = sl::NeuroSpeech.UIAtoms;
#else
using NSU = NeuroSpeech.UIAtoms;
using NeuroSpeech.UIAtoms.Core;
#endif

namespace NeuroSpeech.UIAtoms.Design
{
    public class MetadataBuilder : AttributeTableBuilder
    {
        public MetadataBuilder()
        {
            try
            {

#if DEMO
                NeuroSpeech.UIAtoms.Design.About.AboutWindow.ShowAboutDialog(true);
#else
                if (!NeuroSpeech.UIAtoms.Design.License.AtomLicenseManager.IsValid())
                    return;
#endif

#if DesignSL
                Type t = typeof(NSU.Controls.AtomForm);
#else
                Type t = typeof(NeuroSpeech.UIAtoms.Controls.AtomForm);
#endif
                RegisterDesignerFeatures(t.Assembly);



            }
            catch (Exception ex)
            {
                LogText(ex.ToString());
            }
        }

        private void RegisterDesignerFeatures(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                AddAttributes(type, type);
                foreach (MemberInfo m in type.GetProperties())
                {
                    AddAttributes(type, m);
                }
                foreach (MemberInfo m in type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static))
                {
                    AddAttributes(type, m);
                }
            }
        }

        private static void LogText(string text)
        {
            System.IO.File.AppendAllText( Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\log.txt", text + "\r\n");
        }

        private static void LogTextFormatted(string text, params object[] args)
        {
            LogText(string.Format(text, args));
        }

        private void AddAttributes(Type type, MemberInfo member)
        {
#if DesignSL
            object[] ads = GetMembers(member.GetCustomAttributes(false));
#else
            object[] ads = member.GetCustomAttributes(typeof(AtomDesignAttribute), false);
#endif

            if (ads == null || ads.Length == 0)
            {
                // hide from toolbox...
                this.AddCustomAttributes(type, new Attribute[] { new ToolboxBrowsableAttribute(false) });
                return;
            }
            foreach (NSU::Core.AtomDesignAttribute a in ads)
            {
                if (member.MemberType == MemberTypes.TypeInfo)
                {
                    //this.AddCallback(type, b => b.AddCustomAttributes(GetAttributes(a)));
                    this.AddCustomAttributes(type, GetAttributes(a));

                    this.AddCustomAttributes(type, new FeatureAttribute(typeof(NeuroSpeech.UIAtoms.Design.Form.AtomAboutMenuProvider)));
                }
                else
                {
                    //this.AddCallback(type, b => b.AddCustomAttributes(member, GetAttributes(a)));
                    this.AddCustomAttributes(type, member.Name, GetAttributes(a));

                    /*if (a.PropertyValueConverter != null) {
                        LogText(string.Format("Editor added for {0} of {1}",member.Name, type.FullName));
                    }*/
                }
            }
        }

#if DesignSL
        private object[] GetMembers(object[] attrs)
        {
            List<NSU::Core.AtomDesignAttribute> list = new List<NSU::Core.AtomDesignAttribute>();
            Type type = null;
            foreach (object at in attrs) {
                type = at.GetType();
                if (type.Name == "AtomDesignAttribute")
                {
                    NSU::Core.AtomDesignAttribute ad = new NSU::Core.AtomDesignAttribute();
                    Copy(at, ad);
                    list.Add(ad);
                }
            }
            return list.ToArray();
        }

        Dictionary<string, PropertyDescriptor> srcProperties = null;
        Dictionary<string, PropertyDescriptor> destProperties = null;

        private void Copy(object src, NSU::Core.AtomDesignAttribute dest)
        {

            if (srcProperties == null) {
                srcProperties = new Dictionary<string, PropertyDescriptor>();
                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(src)) 
                {
                    srcProperties[pd.Name] = pd;
                }                
            }
            if (destProperties == null) {
                destProperties = new Dictionary<string, PropertyDescriptor>();
                foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(dest)) 
                {
                    destProperties[pd.Name] = pd;
                }
            }

            foreach (KeyValuePair<string,PropertyDescriptor> pair in srcProperties) {
                PropertyDescriptor destProperty = destProperties[pair.Key];
                destProperty.SetValue(dest, pair.Value.GetValue(src));
            }
        }
#endif

        private Attribute[] GetAttributes(NSU::Core.AtomDesignAttribute a)
        {
            List<Attribute> list = new List<Attribute>();

            ToolboxBrowsableAttribute tba = new ToolboxBrowsableAttribute(a.DisplayInToolbox);
            list.Add(tba);

#if MPD4
            if (a.DisplayInToolbox) 
            {
                if (!string.IsNullOrEmpty(a.ToolboxTabName))
                {
                    list.Add(new ToolboxTabNameAttribute(a.ToolboxTabName));
                }
            }
#endif

            if (!string.IsNullOrEmpty(a.Category))
            {
                list.Add(new CategoryAttribute(a.Category));
            }

            if (!string.IsNullOrEmpty(a.Description))
            {
                list.Add(new DescriptionAttribute(a.Description));
            }

            if (!string.IsNullOrEmpty(a.DisplayName))
            {
                list.Add(new DisplayNameAttribute(a.DisplayName));
            }

            if (a.Bindable)
            {
                list.Add(new BindableAttribute(a.Bindable));
            }

            switch (a.BrowseMode)
            {
                case NSU::Core.AtomPropertyBrowseMode.Never:
                    list.Add(new BrowsableAttribute(false));
                    break;
                case NSU::Core.AtomPropertyBrowseMode.Default:
                    list.Add(new EditorBrowsableAttribute(EditorBrowsableState.Always));
                    break;
                case NSU::Core.AtomPropertyBrowseMode.Extended:
                    list.Add(new EditorBrowsableAttribute(EditorBrowsableState.Advanced));
                    break;
                default:
                    break;
            }

            if (a.DefaultValue != null)
            {
                list.Add(new DefaultValueAttribute(a.DefaultValue));
            }

            if (a.DisplayAttachedForType != null)
            {
                list.Add(new AttachedPropertyBrowsableForTypeAttribute(a.DisplayAttachedForType));
            }

            if (a.DisplayAttachedForChildren)
            {
				var att = new AttachedPropertyBrowsableForChildrenAttribute();
				att.IncludeDescendants = true;
                list.Add(att);
            }
            if (a.ObjectToStringConverter)
            {
                list.Add(new TypeConverterAttribute(typeof(ObjectToStringConverter)));
            }

            if (a.RegisterUnitControl) {
                list.Add(PropertyValueEditor.CreateEditorAttribute(typeof(UnitInlineEditor)));
            }

            if (a.DesignTimeProviders != null) {
                foreach (string item in a.DesignTimeProviders.Split(';'))
                {
                    AddProvider(item, list);
                }
            }

            return list.ToArray();
        }

        private static void AddProvider(string name, List<Attribute> list)
        {
            Type t = Type.GetType(name);
            if (t != null)
            {
                list.Add(new FeatureAttribute(t));
            }

        }
    }

    public class ObjectToStringConverter : TypeConverter {

        #region public override bool  CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return true;
        }
        #endregion


        #region public override bool  CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return true;
        }
        #endregion


        #region public override object  ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return value;
        }
        #endregion


        #region public override object  ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return value;
        }
        #endregion



    }
}
