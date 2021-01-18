#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.DataAnnotations;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections;
using System.Reflection;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(AtomFormItemContainer))]
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms",
        DesignTimeProviders = "NeuroSpeech.UIAtoms.Design.Form.AtomFormMenuProvider"
        )]
    public class AtomDataForm : AtomFormContainer
    {
#if SILVERLIGHT
#else
        static AtomDataForm()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomDataForm), new FrameworkPropertyMetadata(typeof(AtomDataForm)));
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        public AtomDataForm()
        {
#if SILVERLIGHT
            this.DefaultStyleKey = typeof(AtomDataForm);
            this.SetOneWayBinding(FormDataContextProperty, this, "DataContext");
#else
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(AtomDataForm_DataContextChanged);
#endif

#if DA
            Errors = new ObservableCollection<System.ComponentModel.DataAnnotations.ValidationResult>();
#else
            Errors = new ObservableCollection<object>();
#endif
            EditCommand = new AtomDelegateCommand<object>(OnEditCommand, x => x != null);
            SaveCommand = new AtomDelegateCommand<object>(OnSaveCommand);
            CancelCommand = new AtomDelegateCommand<object>(OnCancelCommand);

        }

#if SILVERLIGHT
#else
        void AtomDataForm_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.BuildFields();
        }
#endif


#if SILVERLIGHT
        #region Dependency Property FormDataContext
        ///<summary>
        ///
        ///</summary>
        [AtomDesign(Bindable = false, BrowseMode = AtomPropertyBrowseMode.Never)]
        public object FormDataContext
        {
            get { return (object)GetValue(FormDataContextProperty); }
            set { SetValue(FormDataContextProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
        public static readonly DependencyProperty FormDataContextProperty =
            DependencyProperty.Register("FormDataContext", typeof(object), typeof(AtomDataForm), new PropertyMetadata(null, new PropertyChangedCallback(FormDataContextChangedCallback)));

        private static void FormDataContextChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomDataForm adf = sender as AtomDataForm;
            if (adf != null) {
                adf.OnFormDataContextChanged(e);
            }
        }

        public event DependencyPropertyChangedEventHandler FormDataContextChanged;

        protected void OnFormDataContextChanged(DependencyPropertyChangedEventArgs e)
        {
            BuildFields();
            if (this.FormDataContextChanged != null)
            {
                this.FormDataContextChanged(this, e);
            }
        }
        #endregion
#endif

        private Type LastType;

        private void BuildFields()
        {

            if (!AutoGenerateFields)
                return;

            object data = DataContext;

            // dont do anything if data is null...
            if (data == null)
                return;

            // dont do anything if type of last data and this is same 
            // and fields are there...
            if (data.GetType() == LastType && Items.Count > 0)
                return;

            LastType = data.GetType();


            OnBuildFields(LastType);
        }


        #region private void OnBuildFields(Type LastType)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LastType"></param>
        protected virtual void OnBuildFields(Type LastType)
        {
            
        }
        #endregion



        #region protected override void  BindField(AtomFormContainer container, Control field)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="field"></param>
        protected override void BindField(AtomFormItemContainer container, Control field)
        {
            if (container == null || field == null)
                return;
            Type t = field.GetType();
            PropertyInfo p = t.GetProperty("IsReadOnly");
            if (p != null)
            {
                FieldInfo f = p.DeclaringType.GetField("IsReadOnlyProperty");
                DependencyProperty dp = f.GetValue(null) as DependencyProperty;
                if (dp != null) {
					field.SafeBind(dp, () => this.IsReadOnly, new Binding("IsReadOnly") { Source=this });
                    return;
                }
            }

			container.SafeBind(Control.IsEnabledProperty, () => !this.IsReadOnly, new Binding("IsReadOnly") { Source=this });
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public void BeginEdit() {
            IEditableObject obj = this.DataContext as IEditableObject;
            obj.BeginEdit();
            IsReadOnly = false;
            if (OnBeginEdit != null)
            {
                OnBeginEdit(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected virtual void OnEditCommand(object p)
        {
            BeginEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool ValidateForm() {
#if DA
            ValidationContext vc = new ValidationContext(this.DataContext, null, null);
            Errors.Clear();
            Validator.TryValidateObject(this.DataContext, vc, (ICollection<System.ComponentModel.DataAnnotations.ValidationResult>)Errors, true);
            if (Errors.Count > 0)
                return false;
#endif
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void EndEdit() {

            if (!ValidateForm())
                return;

            IEditableObject obj = this.DataContext as IEditableObject;
            obj.EndEdit();
            IsReadOnly = true;
            if (OnEndEdit != null)
            {
                OnEndEdit(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected virtual void OnSaveCommand(object p)
        {
            EndEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CancelEdit() {
            Errors.Clear();

            IEditableObject obj = this.DataContext as IEditableObject;
            obj.CancelEdit();
            IsReadOnly = true;
            if (OnCancelEdit != null)
            {
                OnCancelEdit(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected virtual void OnCancelCommand(object p) 
        {
            CancelEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnBeginEdit;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnEndEdit;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OnCancelEdit;

        ///<summary>
        /// Dependency Property Errors
        ///</summary>
        #region Dependency Property Errors
        [AtomDesign(
          Category = "Atoms",
          Bindable = false,
          BrowseMode = AtomPropertyBrowseMode.Never
        )]
        public IList Errors
        {
            get { return (IList)GetValue(ErrorsProperty); }
            private set { SetValue(ErrorsProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Errors.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ErrorsProperty =
            DependencyProperty.Register("Errors", typeof(IList), typeof(AtomDataForm), new PropertyMetadata(null, OnErrorsChangedCallback));

        private static void OnErrorsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDataForm obj = d as AtomDataForm;
        }

#else
        public static readonly DependencyProperty ErrorsProperty =
    DependencyProperty.Register("Errors", typeof(IList), typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        ///<summary>
        /// Dependency Property AutoGenerateFields
        ///</summary>
        #region Dependency Property AutoGenerateFields
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public bool AutoGenerateFields
        {
            get { return (bool)GetValue(AutoGenerateFieldsProperty); }
            set { SetValue(AutoGenerateFieldsProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for AutoGenerateFields.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty AutoGenerateFieldsProperty =
            DependencyProperty.Register("AutoGenerateFields", typeof(bool), typeof(AtomDataForm), new PropertyMetadata(false, OnAutoGenerateFieldsChangedCallback));

        private static void OnAutoGenerateFieldsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDataForm obj = d as AtomDataForm;
        }

#else
public static readonly DependencyProperty AutoGenerateFieldsProperty = 
    DependencyProperty.Register("AutoGenerateFields", typeof(bool), typeof(AtomDataForm), new FrameworkPropertyMetadata(false));
#endif

        #endregion



        ///<summary>
        /// Dependency Property SaveCommand
        ///</summary>
        #region Dependency Property SaveCommand
        [AtomDesign(
          Category = "Atoms",
          Bindable = false,
          BrowseMode = AtomPropertyBrowseMode.Never
        )]
        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            private set { SetValue(SaveCommandProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for SaveCommand.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty SaveCommandProperty = 
    DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(AtomDataForm), new PropertyMetadata(null, OnSaveCommandChangedCallback));
    
private static void OnSaveCommandChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomDataForm obj = d as AtomDataForm;
}
    
#else
        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
#endif

        #endregion


        ///<summary>
        /// Dependency Property EditCommand
        ///</summary>
        #region Dependency Property EditCommand
        [AtomDesign(
          Category = "Atoms",
          Bindable = false,
          BrowseMode = AtomPropertyBrowseMode.Never
        )]
        public ICommand EditCommand
        {
            get { return (ICommand)GetValue(EditCommandProperty); }
            private set { SetValue(EditCommandProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for EditCommand.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty EditCommandProperty = 
    DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(AtomDataForm), new PropertyMetadata(null, OnEditCommandChangedCallback));
    
private static void OnEditCommandChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomDataForm obj = d as AtomDataForm;
}
    
#else
        public static readonly DependencyProperty EditCommandProperty =
            DependencyProperty.Register("EditCommand", typeof(ICommand), typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
#endif

        #endregion



        ///<summary>
        /// Dependency Property CancelCommand
        ///</summary>
        #region Dependency Property CancelCommand
        [AtomDesign(
          Category = "Atoms",
          Bindable = false,
          BrowseMode = AtomPropertyBrowseMode.Never
        )]
        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            private set { SetValue(CancelCommandProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for CancelCommand.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty CancelCommandProperty = 
    DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(AtomDataForm), new PropertyMetadata(null, OnCancelCommandChangedCallback));
    
private static void OnCancelCommandChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
  AtomDataForm obj = d as AtomDataForm;
}
    
#else
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
#endif

        #endregion



        ///<summary>
        /// Dependency Property IsReadOnly
        ///</summary>
        #region Dependency Property IsReadOnly
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for IsReadOnly.  This enables animation, styling, binding, etc...
        ///</summary>
        #if SILVERLIGHT
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(AtomDataForm), new PropertyMetadata(true, OnIsReadOnlyChangedCallback));

        private static void OnIsReadOnlyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomDataForm obj = d as AtomDataForm;
        }

        #else
        public static readonly DependencyProperty IsReadOnlyProperty = 
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(AtomDataForm), new FrameworkPropertyMetadata(true));
        #endif

        #endregion




		///<summary>
		/// Dependency Property ErrorTitle
		///</summary>
		#region Dependency Property ErrorTitle
		[AtomDesign(
		  Category = "Atoms",
		  Bindable = true,
		  BrowseMode = AtomPropertyBrowseMode.Default
		)]
		public string ErrorTitle
		{
			get { return (string)GetValue(ErrorTitleProperty); }
			set { SetValue(ErrorTitleProperty, value); }
		}

		///<summary>
		/// Using a DependencyProperty as the backing store for ErrorTitle.  This enables animation, styling, binding, etc...
		///</summary>
#if SILVERLIGHT
		public static readonly DependencyProperty ErrorTitleProperty =
			DependencyProperty.Register("ErrorTitle", typeof(string), typeof(AtomDataForm), new PropertyMetadata("Errors", OnErrorTitleChangedCallback));

		private static void OnErrorTitleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			AtomDataForm obj = d as AtomDataForm;
		}

#else
public static readonly DependencyProperty ErrorTitleProperty = 
    DependencyProperty.Register("ErrorTitle", typeof(string), typeof(AtomDataForm), new FrameworkPropertyMetadata("Errors"));
#endif

		#endregion



        private T GetTemplateChild<T>(string name)
            where T : UIElement
        {
            T val = GetTemplateChild(name) as T;
            if (val == null)
            {
                throw new InvalidOperationException(name + " is of type " + typeof(T).FullName + " not defined in template of AtomDataFormItem");
            }
            return val;
        }

        

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            ItemsControl errorItems = this.GetTemplateChild<ItemsControl>("PART_Errors");
            if (errorItems != null)
            {
                errorItems.SetOneWayBinding(ItemsControl.VisibilityProperty, this, "Errors.Count", AtomUtils.GetDefaultInstance<IntToVisibilityConverter>());
                errorItems.ItemsSource = Errors;
            }


            Button btn = GetTemplateChild<Button>("PART_Edit");
            btn.Command = this.EditCommand;
            btn.SetOneWayBinding(Button.CommandParameterProperty, this, "DataContext");
			btn.SafeBindVisibility(() => this.IsReadOnly, new Binding("IsReadOnly") { Source=this });

            btn = GetTemplateChild<Button>("PART_Save");
            btn.Command = this.SaveCommand;
			btn.SafeBindVisibility(() => !this.IsReadOnly, new Binding("IsReadOnly") { Source = this });

            btn = GetTemplateChild<Button>("PART_Cancel");
            btn.Command = this.CancelCommand;
			btn.SafeBindVisibility(() => !this.IsReadOnly, new Binding("IsReadOnly") { Source = this });


#if DEMO
            if(!DesignerProperties.GetIsInDesignMode(this))
                NeuroSpeech.UIAtoms.Dialogs.AtomDemoWindow.ShowDemo(false);
#endif
        }


    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AtomDelegateCommand<T> : ICommand
    {

        Action<T> executeAction;
        Func<T, bool> canExecute;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        public AtomDelegateCommand(Action<T> action)
        {
            executeAction = action;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExec"></param>
        public AtomDelegateCommand(Action<T> action, Func<T, bool> canExec)
        {
            executeAction = action;
            canExecute = canExec;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute((T)parameter);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (executeAction != null)
                executeAction((T)parameter);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }

}
