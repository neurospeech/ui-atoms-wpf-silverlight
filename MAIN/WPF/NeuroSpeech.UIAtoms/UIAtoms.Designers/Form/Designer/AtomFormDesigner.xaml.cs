using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Design.Model;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;
using Microsoft.Windows.Design;
using System.Diagnostics;
using VSLangProj;
using System.Runtime.InteropServices;
using NeuroSpeech.UIAtoms.Designers.OleServices;


namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    /// <summary>
    /// Interaction logic for AtomFormDesigner.xaml
    /// </summary>
    public partial class AtomFormDesigner : Window
    {

        private FormItemType[] Types = null;

        public string Prefix { get; set; }

        public AtomFormDesigner(FormItemType[] types, EditingContext context)
        {
            InitializeComponent();
            //this.Types = types.Union(GetTypes(context)).ToArray();
            this.Types = types;

            this.Loaded += new RoutedEventHandler(AtomFormDesigner_Loaded);   
        }

        #region private IEnumerable<FormItemType> GetTypes()
        private FormItemType[] GetTypes(EditingContext context)
        {

            foreach (Type item in context.Services)
            {
                Trace.WriteLine(item.FullName);
            }

            /*Microsoft.VisualStudio.Shell.ServiceProvider sp = Microsoft.VisualStudio.Shell.ServiceProvider.GlobalProvider;

            Debug.Assert(sp!=null,"sp is null");

            Microsoft.VisualStudio.OLE.Interop.IServiceProvider sp2 =
                sp.GetService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider)) as Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

            Debug.Assert(sp2 != null, "sp2 is null");

            sp = new Microsoft.VisualStudio.Shell.ServiceProvider(sp2);

            EnvDTE.DTE dte = sp.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
            object obj = dte.ActiveDocument.ProjectItem.ContainingProject.Object;
            VSProject p = (VSProject)(obj);
            foreach (Reference r in p.References) {
                Trace.WriteLine(r.Identity);
            }*/

            // enuerate all types...


            return new FormItemType[] { };
        }
        #endregion


        #region void  AtomFormDesigner_Loaded(object sender, RoutedEventArgs e)
        void AtomFormDesigner_Loaded(object sender, RoutedEventArgs e)
        {
            SetupItemTypes();
            
            //EnumerateTypes(GetParent(FormModel.Item).ItemType);

            ModelItemCollection mc = FormModel.Item.Properties["Items"].Value as ModelItemCollection;

            Items = new LinkedCollection<FormItemModel, ModelItem>(mc, x=> new FormItemModel(x,Prefix));
            grid.ItemsSource = Items;
        }

        private ModelItem GetParent(ModelItem item)
        {
            Trace.WriteLine(item.ItemType.FullName);
            if (item.Parent != null)
                return GetParent(item.Parent);
            return item;
        }

        //private void EnumerateTypes(Type type)
        //{
        //    try
        //    {
        //        VSServiceProvider sp = new VSServiceProvider();
        //        EnvDTE.DTE dte = sp.GetService<EnvDTE.DTE>();
        //        EnvDTE.Project p = dte.ActiveDocument.ProjectItem.ContainingProject;
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex.ToString());
        //    }
        //}

        private EnvDTE.DTE GetDTE(params string[] ids) {
            foreach (string item in ids)
            {
                try {
                    return Marshal.GetActiveObject(item) as EnvDTE.DTE;
                }
                catch(Exception ex) {
                    Trace.WriteLine(ex.ToString());
                }
            }
            return null;
        }

        #region private void SetupItemTypes()
        private void SetupItemTypes()
        {
            itemTypes.ItemsSource = Types;
            itemTypes.SelectedIndex = 0;
        }
        #endregion


        LinkedCollection<FormItemModel, ModelItem> Items;
        

        #endregion




        ///<summary>
        ///DependencyProperty FormModel
        ///</summary>
        #region Dependency Property FormModel
        public FormModel FormModel
        {
            get { return (FormModel)GetValue(FormModelProperty); }
            set { SetValue(FormModelProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FormModel.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty FormModelProperty =
            DependencyProperty.Register("FormModel", typeof(FormModel), typeof(AtomFormDesigner), new FrameworkPropertyMetadata(null, OnFormModelChangedCallback));

        private static void OnFormModelChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFormDesigner obj = d as AtomFormDesigner;
            if (obj != null)
            {
                obj.OnFormModelChanged(e);
            }
        }

        /// <summary>
        /// Fires FormModelChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFormModelChanged(DependencyPropertyChangedEventArgs e)
        {
            if (FormModelChanged != null)
            {
                FormModelChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FormModelChanged;

        #endregion

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Type type = itemTypes.SelectedValue as Type;
            if (type == null) {
                return;
            }
            
            Items.InternalCollection.Add(ModelFactory.CreateItem(this.FormModel.Item.Context,type));

            grid.SelectedIndex = Items.InternalCollection.Count - 1;

        }

        #region private Microsoft.Windows.Design.Metadata.TypeIdentifier LoadType(Type type)
        private Type LoadType(string typeName)
        {
            Assembly asm = Assembly.GetAssembly(typeof(AtomFormDesigner));
            
            foreach (AssemblyName name in asm.GetReferencedAssemblies()) {
                Assembly a = Assembly.ReflectionOnlyLoad(name.FullName);
                Type t = a.GetType(typeName, false);
                if (t != null)
                    return t;
            }
            return null;
        }
        #endregion



    }

    public class FormItemType {
        public string Label { get; set; }

        public Type Type { get; set; }

        public string ControlProperty { get; set; }

        
    }
}
