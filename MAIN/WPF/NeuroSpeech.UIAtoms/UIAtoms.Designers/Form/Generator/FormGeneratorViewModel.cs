using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Designers.Form.Designer;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Model;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;


namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    public class FormGeneratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private GenericCommand[] Commands = null;

        public string Prefix { get; set; }

        public FormGeneratorViewModel(string prefix = "AtomForm.")
        {
            Prefix = prefix;

            this.OpenTypeCommand = new DelegateCommand<object>(OnOpenTypeCommand);
            this.MoveUpCommand = new DelegateCommand<FormItemModel>(OnMoveUpCommand,CanMoveUpCommand);
            this.MoveDownCommand = new DelegateCommand<FormItemModel>(OnMoveDownCommand,CanMoveDownCommand);
            this.DeleteCommand = new DelegateCommand<FormItemModel>(OnDeleteCommand);
            this.ChangeTypeCommand = new DelegateCommand<FormItemModel>(OnChangeTypeCommand);
            this.ChangeDefaultTypeCommand = new DelegateCommand<object>(OnChangeDefaultTypeCommand);
            this.AddNewItemCommand = new DelegateCommand<object>(OnAddNewItemCommand);

            Commands = new GenericCommand [] { OpenTypeCommand,MoveUpCommand,MoveDownCommand,DeleteCommand, ChangeTypeCommand };
        }

        #region Command OnAddNewItemCommand
        private void OnAddNewItemCommand(object p) {
            ModelItem modelItem = ModelFactory.CreateItem(Context, DefaultType);
            Items.InternalCollection.Add(modelItem);
            Items.Reset();
        }
        #endregion

        #region Command OnChangeDefaultTypeCommand
        private void OnChangeDefaultTypeCommand(object p) {
            TypeChooserWindow tcw = new TypeChooserWindow();
            TypeChooserWindowViewModel vm = tcw.DataContext as TypeChooserWindowViewModel;
            vm.Context = this.Context;
            vm.BaseType = GetControlType(Context);
            tcw.ShowDialog();
            if (vm.SelectedType == null)
                return;
            DefaultType = vm.SelectedType as Type;
        }
        #endregion

        #region Command ChangeTypeCommand
        private void OnChangeTypeCommand(FormItemModel item) {

            string bindingTarget = item.Binding.TargetName;

            TypeChooserWindow tcw = new TypeChooserWindow();
            TypeChooserWindowViewModel vm = tcw.DataContext as TypeChooserWindowViewModel;
            vm.Context = this.Context;
            vm.BaseType = GetControlType(Context);
            tcw.ShowDialog();
            if (vm.SelectedType == null)
                return;
            Type type = vm.SelectedType as Type;

            string label = item.Label;
            bool isRequired = item.IsRequired;
            

            int index = Items.InternalCollection.IndexOf(item.Item);
            Items.InternalCollection.Remove(item.Item);

            ModelItem modelItem = ModelFactory.CreateItem(Context, type);
            Items.InternalCollection.Insert(index, modelItem);

            Items.Reset();

            item = Items.FirstOrDefault(x => x.Item == modelItem);
            item.Label = label;
            item.IsRequired = isRequired;

            if (!string.IsNullOrWhiteSpace(bindingTarget)) {
                item.Binding.SelectDefaultProperty();
                item.Binding.TargetName = bindingTarget;
                item.Binding.TwoWay = true;
            }

        }
        #endregion

        #region Command MoveUpCommand
        private void OnMoveUpCommand(FormItemModel item)
        {
            int index = Items.InternalCollection.IndexOf(item.Item);
            Items.InternalCollection.RemoveAt(index);
            index--;
            Items.InternalCollection.Insert(index, item.Item);
            Items.Reset();

        }
        private bool CanMoveUpCommand(FormItemModel item)
        {
            if (Items == null || item == null)
                return false;
            return Items.IndexOf(item) > 0;
        } 
        #endregion

        #region Command MoveDownCommand
        private void OnMoveDownCommand(FormItemModel item)
        {
            int index = Items.InternalCollection.IndexOf(item.Item);
            Items.InternalCollection.RemoveAt(index);
            index++;
            Items.InternalCollection.Insert(index, item.Item);
            Items.Reset();
        }

        private bool CanMoveDownCommand(FormItemModel item)
        {
            if (Items == null || item == null)
                return false;
            return Items.IndexOf(item) < Items.Count - 1;
        } 
        #endregion

        #region Command DeleteCommand
        private void OnDeleteCommand(FormItemModel item)
        {
            if (
                MessageBox.Show("Are you sure you want to delete this item?", "Delete Item", MessageBoxButton.YesNo, MessageBoxImage.Question)
                != MessageBoxResult.Yes)
                return;
            Items.InternalCollection.Remove(item.Item);
        } 
        #endregion

        #region Command OpenTypeCommand
        private void OnOpenTypeCommand(object p)
        {
            // open new type opener window...

            TypeChooserWindow tcw = new TypeChooserWindow();
            TypeChooserWindowViewModel vm = tcw.DataContext as TypeChooserWindowViewModel;
            vm.Context = this.Context;
            if (tcw.ShowDialog() != true)
                return;

            if (vm.SelectedType != null)
            {
                // regenerate items...
                Type type = vm.SelectedType as Type;
                RegenerateForm(type);
            }

            ResetCommands();

        } 
        #endregion

        private void ResetCommands()
        {
            // reset commands...
            foreach (GenericCommand cmd in Commands)
            {
                cmd.FireCanExecuteChanged(this);
            }
        }



        #region private void RegenerateForm(Type type)
        private void RegenerateForm(Type type)
        {
            // delete all items...
            Items.InternalCollection.Clear();

            Dictionary<ModelItem, string> names = new Dictionary<ModelItem, string>();

            foreach (PropertyInfo item in 
                type.GetProperties(BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.DeclaredOnly)
                )
            {
                Type uiType = GetUIType(item);
                ModelItem modelItem = ModelFactory.CreateItem(Context, uiType);

                names[modelItem] = item.Name;
                Items.InternalCollection.Add(modelItem);

                FormItemModel formItem = new FormItemModel(modelItem,Prefix);
                formItem.Label = item.Name;
                formItem.Binding.TargetName = item.Name;
                formItem.Binding.TwoWay = true;
                formItem.Binding.SaveBindingsWithSelectedProperty();
                formItem.Item = null;
            }

            Items.Reset();
        }

        #region Property TypeCollection
        private TypeCollection _TypeCollection = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public TypeCollection TypeCollection
        {
            get
            {
                if (_TypeCollection == null) {
                    _TypeCollection = new TypeCollection(Context, GetControlType(Context));
                }
                return _TypeCollection;
            }
        }

        #region private Type GetControlType()
        public static Type GetControlType(EditingContext Context,string defaultControlType = "System.Windows.Controls.Control")
        {
            AssemblyReferences ars = Context.Items.FirstOrDefault(x => x is AssemblyReferences) as AssemblyReferences;
            try
            {
                foreach (Type type in ars.GetTypes(typeof(object)))
                {
                    if (type.FullName == defaultControlType)
                        return type;
                }
            }
            catch (ReflectionTypeLoadException re)
            {
                string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                StringBuilder sb = new StringBuilder();
                StringBuilder sbh = new StringBuilder();
                sb.AppendLine(re.ToString());
                foreach (var item in re.LoaderExceptions) {
                    sbh.AppendLine(item.Message);
                    sb.AppendLine(item.ToString());
                }
                //System.IO.File.WriteAllText(folder + "\\UIAtoms.Designer.Log.txt", sb.ToString());
                throw new InvalidOperationException(sbh.ToString() + sb.ToString());
            }
            return null;
        }
        #endregion


        #endregion
	

        #region private Type GetUIType(PropertyInfo item)
        private Type GetUIType(PropertyInfo property)
        {
            if (Prefix == "AtomDataForm.")
                return TypeCollection.SearchType("TextBox", "System.Windows.Controls");
            return TypeCollection.SearchType("AtomTextBox", "NeuroSpeech.UIAtoms.Controls");
        }
        #endregion

        #endregion


        public DelegateCommand<object> OpenTypeCommand { get; set; }

        public DelegateCommand<FormItemModel> MoveUpCommand { get; set; }

        public DelegateCommand<FormItemModel> MoveDownCommand { get; set; }

        public DelegateCommand<FormItemModel> DeleteCommand { get; set; }

        public DelegateCommand<FormItemModel> ChangeTypeCommand { get; set; }

        public DelegateCommand<object> ChangeDefaultTypeCommand { get; set; }

        public DelegateCommand<object> AddNewItemCommand { get; set; }

        #region Property FormModel
        private FormModel _FormModel = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(0)]
        [System.ComponentModel.Category("FormModel")]
        public FormModel FormModel
        {
            get
            {
                return _FormModel;
            }
            set
            {
                _FormModel = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("FormModel"));
                GenerateItems();
                ResetCommands();
            }
        }

        #region Property Items
        private LinkedCollection<FormItemModel, ModelItem> _Items = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public LinkedCollection<FormItemModel, ModelItem> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Items"));
            }
        }

        #endregion
	

        #region private void GenerateItems()
        private void GenerateItems()
        {
            if (FormModel != null)
            {
                ModelItemCollection mc = FormModel.Item.Properties["Items"].Value as ModelItemCollection;

                Items = new LinkedCollection<FormItemModel, ModelItem>(mc, x => new FormItemModel(x, Prefix));
            }
        }
        #endregion


        #endregion

        #region Property Context
        private EditingContext _Context = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public EditingContext Context
        {
            get
            {
                return _Context;
            }
            set
            {
                _Context = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Context"));
            }
        }

        #endregion

        #region Property DefaultType
        private Type _DefaultType = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public Type DefaultType
        {
            get
            {
                return _DefaultType;
            }
            set
            {
                _DefaultType = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("DefaultType"));
            }
        }

        #endregion




        #region internal void SetDefaultType()
        internal void SetDefaultType()
        {
            if(Prefix == "AtomDataForm.")
                DefaultType = GetControlType(Context, "System.Windows.Controls.TextBox");
            else
                DefaultType = GetControlType(Context,"NeuroSpeech.UIAtoms.Controls.AtomTextBox");
        }
        #endregion
    }
}
