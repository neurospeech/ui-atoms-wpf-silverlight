using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using ControlMetaData.Model;
using Microsoft.Win32;
using NeuroSpeech.UIAtoms.Controls;
using System.Reflection;
using NeuroSpeech.UIAtoms.Core;

namespace ControlMetaData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (App.Args != null && App.Args.Length > 0)
            {
                FilePath = App.Args[0];
                try
                {
                    LoadDocument();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    DataContext = new AtomControlSet();
                }
            }
            else {
                AtomControlSet cset = new AtomControlSet();
                cset.Controls.Add(new AtomControl());
                cset.Controls.First().Properties.Add(new AtomProperty { });
                this.DataContext = cset;
            }
        }

        public string FilePath = null;

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All xamlc files (*.xamlc)|*.xamlc|All files (*.*)|*.*";
            if (ofd.ShowDialog(this) == true) {
                FilePath = ofd.FileName;

                LoadDocument();
            }
        }

        private void LoadDocument()
        {
            this.DataContext = XamlServices.Load(FilePath);
        }


		#region protected override void  OnClosing(System.ComponentModel.CancelEventArgs e)
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			SaveFile();
			base.OnClosing(e);
		}
		#endregion


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
			SaveFile();
        }

		private void SaveFile()
		{
			if (FilePath == null)
			{
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "All xamlc files (*.xamlc)|*.xamlc|All files (*.*)|*.*";
				if (sfd.ShowDialog(this) == true)
				{
					FilePath = sfd.FileName;

				}
			}
			if (FilePath != null)
			{
				XamlServices.Save(FilePath, this.DataContext);
			}
		}

		private void refreshButton_Click(object sender, RoutedEventArgs e)
		{
			// load controls...
			Assembly asm = typeof(AtomForm).Assembly;

			foreach (Type type in asm.GetTypes().Where(x=>x.IsSubclassOf(typeof(FrameworkElement))))
			{
				SyncProperties(type);
			}

		}

		#region private void SyncProperties(Type type)
		private void SyncProperties(Type type)
		{
			var fields = type.GetFields();
			var q = fields.Where(x=>x.FieldType == typeof(DependencyProperty) && x.DeclaringType == type);
			if (!q.Any())
				return;

			string typeName = type.Name;

			string baseType = type.BaseType.Name;

			AtomControlSet controls = this.DataContext as AtomControlSet;

			AtomControl ctrl = controls.GetControl(typeName);
			if(string.IsNullOrWhiteSpace(ctrl.BaseType))
				ctrl.BaseType = baseType;


			// create properties...
			foreach (var field in fields)
			{
				string name = field.Name.Substring(0, field.Name.Length - "Property".Length);

				// check if it is attached??

				PropertyInfo p = type.GetProperty(name);

				bool attached = p == null;

				string propertyType = "";

				if (p == null)
				{
					MethodInfo gm = type.GetMethod("Get" + name);
					propertyType = gm.ReturnType.Name;
				}
				else
				{
					propertyType = p.PropertyType.Name;
				}

				AtomProperty property = ctrl.GetProperty(name, attached);
				if(string.IsNullOrWhiteSpace(property.Type))
					property.Type = propertyType;

				if (type.IsAbstract)
					continue;

				DependencyProperty dp = GetDependencyProperty(field);
				if (dp == null)
					continue;

				PropertyMetadata metadata = dp.GetMetadata(type);

				string defaultValue = metadata.DefaultValue == null ? "null" : LiteralValue(dp.PropertyType, metadata.DefaultValue);
				if(string.IsNullOrWhiteSpace(property.DefaultValue) || dp.PropertyType.IsEnum)
					property.DefaultValue = defaultValue;

				AtomDesignAttribute design = null;

				if (attached)
				{
					// get GetMethod...
					MethodInfo info = type.GetMethod("Get" + name);
					object[] attrs = info.GetCustomAttributes(typeof(AtomDesignAttribute), false);
					if (attrs != null && attrs.Length > 0)
					{
						design = attrs[0] as AtomDesignAttribute;
					}
				}
				else {
					PropertyInfo info = type.GetProperty(name);
					object[] attrs = info.GetCustomAttributes(typeof(AtomDesignAttribute), false);
					if (attrs != null && attrs.Length > 0)
					{
						design = attrs[0] as AtomDesignAttribute;
					}
				}


				if (design != null) {
					property.Category = design.Category;
					property.Bindable = design.Bindable;
					property.BrowseMode = (Model.AtomPropertyBrowseMode)Enum.Parse(typeof(Model.AtomPropertyBrowseMode),design.BrowseMode.ToString());
				}

				EventInfo eventInfo = type.GetEvent(name + "Changed");
				if (eventInfo != null) {
					property.GenerateEvent = true;
				}

				MethodInfo minfo = type.GetMethod("On" + name + "Changed");
				if (minfo != null) {
					property.GenerateChangeMethod = true;
				}

			}
		}

		private static DependencyProperty GetDependencyProperty(FieldInfo field)
		{
			try
			{
				return field.GetValue(null) as DependencyProperty;
			}
			catch {
				return null;
			}
		}
		#endregion

		#region private string LiteralValue(Type type,object p)
		private string LiteralValue(Type type, object p)
		{
			if (type == typeof(string))
			{
				string val = p.ToString();
				val = val.Replace("\r", "\\r");
				val = val.Replace("\n", "\\n");
				val = val.Replace("\"", "\\\"");
				return string.Format("\"{0}\"",val);
			}
			if (type == typeof(bool))
				return "(bool)" + p.ToString().ToLower();
			if (type == typeof(int))
				return "(int)" + p.ToString();
			if (type == typeof(decimal))
				return "(decimal)" + p.ToString();
			if (type == typeof(double))
				return "(double)" + p.ToString();
			if (type == typeof(long))
				return "(long)" + p.ToString();
			if (type == typeof(ulong))
				return "(ulong)" + p.ToString();
			if (type == typeof(float))
				return "(float)" + p.ToString();
			if (type.IsEnum)
				return "(" + type.Name + ")" + type.Name + "." + p.ToString();
			return "(" + type.Name + ")" + p.ToString();
		}
		#endregion



    }
}
