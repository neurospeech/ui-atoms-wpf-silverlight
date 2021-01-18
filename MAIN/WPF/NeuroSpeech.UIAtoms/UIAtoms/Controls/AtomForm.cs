#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Threading;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NeuroSpeech.UIAtoms.Core;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections;
#if !SILVERLIGHT
#if !NET4
using Microsoft.Windows.Controls;
#endif
#endif

namespace NeuroSpeech.UIAtoms.Controls
{


    /// <summary>
    /// State of art, Line of Business Form Container.
    /// </summary>
    /// <remarks>
    ///     
    /// <list type="bullet">
    /// 	<item>It provides "Label" attached property to all child elements that gets displayed on the left side.</item>
    /// 	<item>It provides "Title" attached property to all child elements that gets displayed above the content element.</item>
    /// 	<item>It provides "Description" attached property to all child elements that gets displayed below the content element.</item>
    /// 	<item>It has AtomFormPanel, which allows multiple editable controls to be layed out horizontally in one line just by specifying Follow attached property to true.</item>
    ///	</list>
    ///	
    ///	</remarks>
    ///	<seealso cref="NeuroSpeech.UIAtoms.Controls.AtomFlexibleGrid"/>
    [StyleTypedProperty(Property="ItemContainerStyle",StyleTargetType=typeof(AtomFormItemContainer))]
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms",
        DesignTimeProviders = "NeuroSpeech.UIAtoms.Design.Form.AtomFormMenuProvider"
        )]

#if SILVERLIGHT
    [TemplateVisualState(GroupName = "Normal", Name = "Normal")]
    [TemplateVisualState(GroupName = "Normal", Name = "HasErrors")]
#endif

    public class AtomForm : AtomFormContainer
    {
#if SILVERLIGHT

        ///<summary>
        ///
        ///</summary>
        public AtomForm()
        {
            DefaultStyleKey = typeof(AtomForm);

            //Tabs = new ObservableCollection<object>();

            this.BindingValidationError += new EventHandler<ValidationErrorEventArgs>(AtomForm_BindingValidationError);


            // Silverlight hack for DataContextChanged..
            Binding b = new Binding();
            b.Mode = BindingMode.OneWay;
            this.SetBinding(FormDataContextProperty, b);

            //SetDataContext();
            
        }

        void AtomForm_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            //ManageBindingErrors(sender as UIElement, e.Action, e.Error);
        }


        #region Dependency Property FormDataContext
        ///<summary>
        ///
        ///</summary>
        [AtomDesign( Bindable=false, BrowseMode=AtomPropertyBrowseMode.Never)]
        public object FormDataContext
        {
            get { return (object)GetValue(FormDataContextProperty); }
            set { SetValue(FormDataContextProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
        public static readonly DependencyProperty FormDataContextProperty =
            DependencyProperty.Register("FormDataContext", typeof(object), typeof(AtomForm), new PropertyMetadata(null, new PropertyChangedCallback(FormDataContextChangedCallback)));

        public event DependencyPropertyChangedEventHandler FormDataContextChanged;

        protected void OnFormDataContextChanged(DependencyPropertyChangedEventArgs e)
        {
            SetDataContext();
            if (this.FormDataContextChanged != null)
            {
                this.FormDataContextChanged(this, e);
            }
        }

        private bool IsDataContextSet = false;

        private void SetDataContext()
        {
            this.BuildFields();
            
            //object dc = this.DataContext;
            //foreach (UIElement ui in this.Items)
            //{
            //    ApplyDataContext(ui, dc);
            //}
            //IsDataContextSet = true;
        }


        #region protected override void  OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        /*protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            foreach (object item in this.Items) {
                FrameworkElement fe = item as FrameworkElement;
                if (fe == null)
                    continue;

                AtomTrace.WriteLine("Setting DC Binding");

                Binding b = new Binding("DataContext");
                b.Mode = BindingMode.OneWay;
                b.Source = this;
                fe.SetBinding(FrameworkElement.DataContextProperty, b);
            }

        }*/
        #endregion


        

        private void ApplyDataContext(UIElement ui, object val)
        {
            if (ui == null)
                return;

            FrameworkElement fe = ui as FrameworkElement;
            if (fe != null)
            {

                // work around as first time datacontext set does not make any difference
                if (!IsDataContextSet)
                {
                    fe.SetValue(FrameworkElement.DataContextProperty, null);
                }
                fe.SetValue(FrameworkElement.DataContextProperty, val);
            }
        }

        private static void FormDataContextChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            AtomForm obj = sender as AtomForm;
            obj.OnFormDataContextChanged(e);
        }

        #endregion




#else
        static AtomForm(){

            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomForm), new FrameworkPropertyMetadata(typeof(AtomForm)));

            EventManager.RegisterClassHandler(typeof(AtomForm), System.Windows.Controls.Validation.ErrorEvent, new EventHandler<ValidationErrorEventArgs>(OnValidationErrorEvent), false);
        }

        private static void OnValidationErrorEvent(object sender, ValidationErrorEventArgs e) {
            AtomForm af = e.Source as AtomForm;
            if (af != null) {
                af.ManageBindingErrors(e.OriginalSource as UIElement, e.Action, e.Error);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public AtomForm()
        {
            this.DataContextChanged += new DependencyPropertyChangedEventHandler(AtomForm_DataContextChanged);
            //Tabs = new ObservableCollection<object>();
        }

        void AtomForm_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.BuildFields();
        }

#endif

        private Type LastType = null;




        #region Method BuildFields
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

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnBuildFields(Type dataType)
        {
            List<AtomFormItemGroup> groups; 
            groups = CreateFieldGroups();

            if (groups.Count == 1)
            {
                foreach (AtomFormItem item in groups[0].Items)
                {
                    Items.Add(item.Control);
                    SetItemProperties(item.Control, item);
                }
            }
            else
            {
                foreach (var group in groups)
                {
                    AtomFormGroup form = new AtomFormGroup();
                    form.RowLayout = group.RowLayout;

                    foreach (var item in group.Items)
                    {
                        form.Items.Add(item);
                        SetItemProperties(item.Control, item);
                    }

                    this.Items.Add(form);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual List<AtomFormItemGroup> CreateFieldGroups()
        {
            List<AtomFormItem> formItems = new List<AtomFormItem>();


            // recreate...
            foreach (PropertyInfo p in LastType.GetProperties(BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {

                AtomFormItem formItem = new AtomFormItem();

                formItem.PropertyName = p.Name;
                formItem.Label = p.Name;
                formItem.MissingValueError = null;
                formItem.Description = "";
                formItem.Watermark = "";
                formItem.Order = null;
                formItem.IsRequired = false;
                formItem.ControlType = typeof(AtomTextBox);
                formItem.DependencyProperty = AtomTextBox.TextProperty;
                formItem.Property = p;

                formItem.ValidationAttributes = (ValidationAttribute[])p.GetCustomAttributes(typeof(ValidationAttribute), true);
                if (formItem.ValidationAttributes != null)
                {
#if DA
                    ValidationAttribute[] vas = formItem.ValidationAttributes;
                    if (vas.All(x =>
                        ((x is RequiredAttribute) && (((RequiredAttribute)x).AllowEmptyStrings)) ||
                        (x is StringLengthAttribute)
                        ))
                    {
                        formItem.ValidationAttributes = null;
                    }
#endif
                }

                formItems.Add(formItem);

                // has any data annotations???
            }

            List<AtomFormItem> finalItems = new List<AtomFormItem>();
            foreach (var item in formItems)
            {
                FrameworkElement fe = CreateItemAndBinding(item);
                if (fe != null)
                {
                    item.Control = fe;
                    finalItems.Add(item);
                }
            }

            return AtomFormItemGroup.Create(finalItems);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="item"></param>
        #region private void SetItemProperties(FrameworkElement e1,AtomFormItem item)
        protected virtual void SetItemProperties(FrameworkElement e, AtomFormItem item)
        {
            // let Validator do the validation...
            if (item.ValidationRule != null)
            {
                AtomPropertyValidator.SetRule(e, item.ValidationRule);
            }
            else
            {
                if (item.ValidationAttributes != null && item.ValidationAttributes.Length > 0)
                {
                    AtomPropertyValidator.SetRule(e, AtomUtils.GetDefaultInstance<AtomDataAnnotationValidationRule>());
                }
            }

            SetLabel(e, item.Label);

            e.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            e.Width = double.NaN;

            if (!string.IsNullOrEmpty(item.Description))
                SetDescription(e, item.Description);

            SetIsRequired(e, item.IsRequired);

            if (e is AtomTextBox)
            {
                // set watermark..
                //AtomTextBox att = e as AtomTextBox;
                
                ((AtomTextBox)e).WatermarkText = item.Watermark;
            }

            if (!string.IsNullOrEmpty(item.MissingValueError))
            {
                SetMissingValueMessage(e, item.MissingValueError);
            }

            if (item.Binding != null) {
                e.SetBinding(item.DependencyProperty, item.Binding);
            }
            
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        #region private FrameworkElement CreateItem(AtomFormItem item)
        protected virtual FrameworkElement CreateItemAndBinding(AtomFormItem item)
        {
            FrameworkElement e = Activator.CreateInstance(item.ControlType) as FrameworkElement;

            // bind..
            CreateItemBinding(item);
            return e;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        protected virtual void CreateItemBinding(AtomFormItem item)
        {
            if (item.DependencyProperty != null)
            {
                Binding b = new Binding(item.PropertyName);
                b.Mode = BindingMode.TwoWay;
                b.ValidatesOnExceptions = true;
                b.NotifyOnValidationError = true;
                item.Binding = b;
            }
        }
        #endregion

 

        private void ManageBindingErrors(
            UIElement element, 
            ValidationErrorEventAction action, 
            ValidationError error)
        {
            
            DependencyProperty p = null;

            if (action == ValidationErrorEventAction.Added)
            {
                AddError(new AtomValidationError { 
                    Source = element,
                    Property = p,
                    IsBindingError=true,
                    Message = error.ErrorContent.ToString()
                });    
            }
            else
            {
                ClearError(element, p);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        private void AddError(AtomValidationError error) 
        {
            error.SetError();
            error.IsBindingError = true;
            lock (Errors)
            {
                if (Errors.Any(t => t.Source == error.Source && t.Property == error.Property))
                    return;

                Errors.Add(error);
                this.HasErrors = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="property"></param>
        public void ClearError(UIElement control, DependencyProperty property) 
        {
            AtomValidationError lastError = null;
            lock (Errors)
            {
                foreach (AtomValidationError err in Errors)
                {
                    if (err.Source == control && !err.IsFormError)
                    {
                        if (property != null)
                        {
                            if (err.Property != property)
                                continue;
                        }

                        Errors.Remove(err);
                        lastError = err;
                        break;
                    }
                }
                this.HasErrors = Errors.Count > 0;
            }

            if (lastError != null)
                lastError.ClearError();

        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearAllErrors()
        {
            lock (Errors)
            {
                Errors.Clear();
                this.HasErrors = false;
            }
        }


        #region Attached Dependency Property Label
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable=true,
            BrowseMode=AtomPropertyBrowseMode.Default,
            Category="Atoms.Form",
            DisplayName="Label",
            DisplayAttachedForChildren=true,
            ObjectToStringConverter=true
            )]
        public static object GetLabel(DependencyObject obj)
        {
            return (string)obj.GetValue(LabelProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetLabel(DependencyObject obj, object value)
        {
            obj.SetValue(LabelProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT 
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached("Label", typeof(object), typeof(AtomForm), new PropertyMetadata("", OnLabelChanged));

        private static void OnLabelChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement ui = sender as UIElement;
            AtomUtils.InvalidateParent(ui);
        }
#else
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached("Label", typeof(object), typeof(AtomForm),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));
#endif
        #endregion

		#region Attached Dependency Property ShowLabel
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		[AtomDesign(
			Bindable = true,
			BrowseMode = AtomPropertyBrowseMode.Default,
			Category = "Atoms.Form",
			DisplayName = "ShowLabel",
			DisplayAttachedForChildren = true,
			ObjectToStringConverter = true
			)]
		public static bool GetShowLabel(DependencyObject obj)
		{
			return (bool)obj.GetValue(ShowLabelProperty);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="value"></param>
		public static void SetShowLabel(DependencyObject obj, bool value)
		{
			obj.SetValue(ShowLabelProperty, value);
		}

		///<summary> Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT 
        public static readonly DependencyProperty ShowLabelProperty =
            DependencyProperty.RegisterAttached("ShowLabel", typeof(bool), typeof(AtomForm), new PropertyMetadata(true, OnLabelChanged));

        private static void OnShowLabelChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement ui = sender as UIElement;
            AtomUtils.InvalidateParent(ui);
        }
#else
		public static readonly DependencyProperty ShowLabelProperty =
			DependencyProperty.RegisterAttached("ShowLabel", typeof(bool), typeof(AtomForm),
			new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));
#endif
		#endregion
        

        #region Attached Dependency Property Title
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Form",
            DisplayName="Title",
            DisplayAttachedForChildren = true
            )]
        public static string GetTitle(DependencyObject obj)
        {
            return (string)obj.GetValue(TitleProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetTitle(DependencyObject obj, string value)
        {
            obj.SetValue(TitleProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title", typeof(string), typeof(AtomForm), new PropertyMetadata(null, OnTitleChanged));

        private static void OnTitleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomUtils.InvalidateParent(sender as UIElement);
        }
#else
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.RegisterAttached("Title", typeof(string), typeof(AtomForm),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));
#endif
        #endregion

        #region Attached Dependency Property Description
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Form",
            DisplayName="Description",
            DisplayAttachedForChildren = true,
            ObjectToStringConverter=true
        )]
        public static object GetDescription(DependencyObject obj)
        {
            return (object)obj.GetValue(DescriptionProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetDescription(DependencyObject obj, object value)
        {
            obj.SetValue(DescriptionProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(object), typeof(AtomForm), new PropertyMetadata(null, OnDescriptionChanged));

        private static void OnDescriptionChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomUtils.InvalidateParent(sender as UIElement);
        }
#else
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(object), typeof(AtomForm),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange));
#endif
        #endregion

        #region Attached Dependency Property CommandBox
        ///<summary>
        ///Get Attached Property CommandBox for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Form",
            DisplayName = "CommandBox",
            DisplayAttachedForChildren = true
            )]
        public static object GetCommandBox(DependencyObject obj)
        {
            return (object)obj.GetValue(CommandBoxProperty);
        }

        ///<summary>
        ///Set Attached Property CommandBox for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetCommandBox(DependencyObject obj, object value)
        {
            obj.SetValue(CommandBoxProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for CommandBox.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty CommandBoxProperty =
            DependencyProperty.RegisterAttached("CommandBox", typeof(object), typeof(AtomForm), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty CommandBoxProperty =
            DependencyProperty.RegisterAttached("CommandBox", typeof(object), typeof(AtomForm), new FrameworkPropertyMetadata(null));
#endif
        #endregion

        #region Attached Dependency Property IsRequired
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Form",
            DisplayName="Is Required",
            DisplayAttachedForChildren = true
            )]
        public static bool GetIsRequired(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsRequiredProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetIsRequired(DependencyObject obj, bool value)
        {
            obj.SetValue(IsRequiredProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for IsRequired.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.RegisterAttached("IsRequired", typeof(bool), typeof(AtomForm), new PropertyMetadata(false, OnIsRequiredChanged));

        private static void OnIsRequiredChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
#else
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.RegisterAttached("IsRequired", typeof(bool), typeof(AtomForm), new UIPropertyMetadata(false));
#endif
        #endregion

        #region Attached Dependency Property HasError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            BrowseMode = AtomPropertyBrowseMode.Never
            )]
        public static bool GetHasError(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasErrorProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetHasError(DependencyObject obj, bool value)
        {
            obj.SetValue(HasErrorProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for HasError.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached("HasError", typeof(bool), typeof(AtomForm), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached("HasError", typeof(bool), typeof(AtomForm), new UIPropertyMetadata(false));
#endif
        #endregion

        #region Attached Dependency Property ErrorMessage
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            BrowseMode = AtomPropertyBrowseMode.Never
           )]
        public static string GetErrorMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(ErrorMessageProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        internal static void SetErrorMessage(DependencyObject obj, string value)
        {
            obj.SetValue(ErrorMessageProperty, value);
        }

        ///<summary> Using a DependencyProperty as the backing store for ErrorMessage.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.RegisterAttached("ErrorMessage", typeof(string), typeof(AtomForm), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ErrorMessageProperty =
            DependencyProperty.RegisterAttached("ErrorMessage", typeof(string), typeof(AtomForm), new UIPropertyMetadata(null));
#endif
        #endregion

        #region Attached Dependency Property RequiredErrorMessage
        ///<summary>
        ///Get Attached Property RequiredErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Validation",
            DisplayName="Missing Value Message",
            DisplayAttachedForChildren = true
           )]
        public static string GetMissingValueMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(MissingValueMessageProperty);
        }

        ///<summary>
        ///Set Attached Property RequiredErrorMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetMissingValueMessage(DependencyObject obj, string value)
        {
            obj.SetValue(MissingValueMessageProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for RequiredErrorMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty MissingValueMessageProperty =
            DependencyProperty.RegisterAttached("MissingValueMessage", typeof(string), typeof(AtomForm), new PropertyMetadata("Field is required", OnRequiredErrorMessageChanged));

        private static void OnRequiredErrorMessageChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
#else
        public static readonly DependencyProperty MissingValueMessageProperty =
            DependencyProperty.RegisterAttached("MissingValueMessage", typeof(string), typeof(AtomForm), new UIPropertyMetadata("Field is required"));
#endif
        #endregion

        #region Attached Dependency Property InvalidValueMessage
        ///<summary>
        ///Get Attached Property InvalidValueMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms.Validation",
            DisplayName="Invalid Value Message",
            DisplayAttachedForChildren = true
           )]
        public static string GetInvalidValueMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(InvalidValueMessageProperty);
        }

        ///<summary>
        ///Set Attached Property InvalidValueMessage for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetInvalidValueMessage(DependencyObject obj, string value)
        {
            obj.SetValue(InvalidValueMessageProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for InvalidValueMessage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty InvalidValueMessageProperty =
            DependencyProperty.RegisterAttached("InvalidValueMessage", typeof(string), typeof(AtomForm), new PropertyMetadata("Invalid Value"));
#else
        public static readonly DependencyProperty InvalidValueMessageProperty =
            DependencyProperty.RegisterAttached("InvalidValueMessage", typeof(string), typeof(AtomForm), new UIPropertyMetadata("Value is Invalid"));
#endif
        #endregion

        #region Attached Dependency Property ValidationError
        ///<summary>
        ///Get Attached Property ValidationError for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static AtomValidationError GetValidationError(DependencyObject obj)
        {
            return (AtomValidationError)obj.GetValue(ValidationErrorProperty);
        }

        ///<summary>
        ///Set Attached Property ValidationError for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetValidationError(DependencyObject obj, AtomValidationError value)
        {
            obj.SetValue(ValidationErrorProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ValidationError.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValidationErrorProperty =
            DependencyProperty.RegisterAttached("ValidationError", typeof(AtomValidationError), typeof(AtomForm), new PropertyMetadata(null, OnValidationErrorChanged));
#else
        public static readonly DependencyProperty ValidationErrorProperty =
            DependencyProperty.RegisterAttached("ValidationError", typeof(AtomValidationError), typeof(AtomForm), new FrameworkPropertyMetadata(null, OnValidationErrorChanged));
#endif
        private static void OnValidationErrorChanged(object sender, DependencyPropertyChangedEventArgs e) 
        {

            UIElement element = sender as UIElement;

            if (element == null)
                return;

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(element))
                return;

            AtomValidationError error = e.NewValue as AtomValidationError;

            AtomForm parentForm = AtomTreeWalker.FindParent<AtomForm>(element, x=>true);
            
            // not found..
            if (parentForm == null)
                return;

            if (error != null)
            {
                parentForm.SetError(element, error);
            }
            else
            {
                parentForm.ClearError(element, null);
            }
        }

        private void SetError(UIElement e, AtomValidationError error)
        {
            error.SetError();

            lock (Errors)
            {
                AtomValidationError existing = Errors.FirstOrDefault(t => t.Source == e);
                if (existing != null)
                {
                    existing.Message = error.Message;
                    return;
                }

                Errors.Add(error);
                HasErrors = true;
            }
        }

        #endregion


        #region Attached Dependency Property AtomValidator
        ///<summary>
        ///Get Attached Property AtomValidator for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static AtomPropertyValidator GetAtomValidator(DependencyObject obj)
        {
            return (AtomPropertyValidator)obj.GetValue(AtomValidatorProperty);
        }

        ///<summary>
        ///Set Attached Property AtomValidator for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetAtomValidator(DependencyObject obj, AtomPropertyValidator value)
        {
            obj.SetValue(AtomValidatorProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for AtomValidator.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty AtomValidatorProperty =
            DependencyProperty.RegisterAttached("AtomValidator", typeof(AtomPropertyValidator), typeof(AtomForm), new PropertyMetadata(null, OnAtomValidatorChangedCallback));
#else
        public static readonly DependencyProperty AtomValidatorProperty =
            DependencyProperty.RegisterAttached("AtomValidator", typeof(AtomPropertyValidator), typeof(AtomForm), new FrameworkPropertyMetadata(null, OnAtomValidatorChangedCallback));
#endif

        private static void OnAtomValidatorChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        { 
            FrameworkElement fe = sender as FrameworkElement;
            fe.LostFocus += new RoutedEventHandler(fe_LostFocus);
        }

        #region static void  fe_LostFocus(object sender, RoutedEventArgs e)
        static void fe_LostFocus(object sender, RoutedEventArgs e)
        {
            AtomValidationRule.ValidateRecursive(sender as UIElement, null);
        }
        #endregion


        #endregion




        /// <summary>
        /// Dependency Property HasErrors is for internal use only
        /// </summary>
        #region Dependency Property HasErrors
        [AtomDesign(
            BrowseMode=AtomPropertyBrowseMode.Never
            )]
        public bool HasErrors
        {
            get { return (bool)GetValue(HasErrorsProperty); }
            set { SetValue(HasErrorsProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for HasErrors.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty HasErrorsProperty =
            DependencyProperty.Register("HasErrors", typeof(bool), typeof(AtomForm), new PropertyMetadata(false, OnHasErrorsPropertyChanged));

#else
        public static readonly DependencyProperty HasErrorsProperty = 
            DependencyProperty.Register("HasErrors", typeof(bool), typeof(AtomForm), new UIPropertyMetadata(false, OnHasErrorsPropertyChanged));
#endif

        private static void OnHasErrorsPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AtomForm af = sender as AtomForm;
            if (af != null)
            {
                af.OnHasErrorsChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnHasErrorsChanged(DependencyPropertyChangedEventArgs e)
        {
#if SILVERLIGHT
            bool errors = (bool)e.NewValue;
            if (errors)
            {
                VisualStateManager.GoToState(this, "HasErrors", true);
            }
            else
            {
                VisualStateManager.GoToState(this, "Normal", true);
            }
#endif
        }

        #endregion




        ///<summary>
        ///DependencyProperty AutoGenerateFields
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
    DependencyProperty.Register("AutoGenerateFields", typeof(bool), typeof(AtomForm), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty AutoGenerateFieldsProperty =
            DependencyProperty.Register("AutoGenerateFields", typeof(bool), typeof(AtomForm), new FrameworkPropertyMetadata(false));
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
		DependencyProperty.Register("ErrorTitle", typeof(string), typeof(AtomForm), new PropertyMetadata("Errors", OnErrorTitleChangedCallback));

		private static void OnErrorTitleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		AtomForm obj = d as AtomForm;
		}

		#else
		public static readonly DependencyProperty ErrorTitleProperty = 
		DependencyProperty.Register("ErrorTitle", typeof(string), typeof(AtomForm), new FrameworkPropertyMetadata("Errors"));
		#endif

		#endregion




        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            ItemsControl errorItems = this.GetTemplateChild("PART_Errors") as ItemsControl;
            if (errorItems != null)
            {
                errorItems.ItemsSource = Errors;
                //errorItems.BindVisibility(() => Errors.Count > 0);
				errorItems.SafeBindVisibility(() => Errors.Count > 0, new Binding("Count") { Source = Errors });
            }

#if DEMO
            if(!DesignerProperties.GetIsInDesignMode(this))
                NeuroSpeech.UIAtoms.Dialogs.AtomDemoWindow.ShowDemo(false);
#endif

        }


        

        /// <summary>
        /// Property Errors is for internal use only
        /// </summary>
        #region Property Errors
        public ObservableCollection<AtomValidationError> Errors
        {
            get
            {
                return _Errors;
            }
        }
        private ObservableCollection<AtomValidationError> _Errors = new ObservableCollection<AtomValidationError>();

        #endregion






        /// <summary>
        /// Called before any validation begins
        /// </summary>
        public event EventHandler<CancelEventArgs> BeforeValidate;

        /// <summary>
        /// Called after all validation executed
        /// </summary>
        public event ValidationEventHandler AfterValidate;

        

        /// <summary>
        /// Internal Usage.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            AtomFormItemContainer container = new AtomFormItemContainer();

            return container;
        }

        ///// <summary>
        ///// Internal Usage.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //protected override bool IsItemItsOwnContainerOverride(object item)
        //{
        //    return (item is AtomFormItemContainer || item is AtomFormGroup || item is AtomTabContent);
        //}



#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        protected override void AddChild(object value)
        {
            if (!(value is UIElement))
                throw new Exception("Invalid Element, Child element must be of type UIElement only");
            base.AddChild(value);
        }
#endif


        private List<AtomValidationError> FormErrors = new List<AtomValidationError>();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ValidateForm() {

            

            CancelEventArgs ce = new CancelEventArgs();
            OnBeforeValidate(ce);
            if (ce.Cancel)
                return true;

            AtomValidationRule.ValidateRecursive(this, null);
            //foreach (TabItem tab in Tabs)
            //{
            //    if(tab.Tag != this)
            //        continue;
            //    AtomForm af = tab.Content as AtomForm;
            //    af.ValidateForm();
            //}

            foreach (UIElement item in Items)
            {
                AtomValidationRule.ValidateRecursive(item, null);
            }

            AtomValidationEventArgs ae = new AtomValidationEventArgs();
            OnAfterValidate(ae);

            if (ae.Errors.Count > 0) {
                lock (Errors)
                {
                    foreach (AtomValidationError error in ae.Errors)
                    {
                        if (Errors.Any(t => t.IsFormError && t.Source == error.Source && t.Property == error.Property))
                            continue;
                        error.SetError();
                        error.IsFormError = true;
                        Errors.Add(error);
                    }

                    
                }
            }

            if (Errors.Any(t => t.IsFormError)) { 
                // start timer..
                if (PollTimer == null) {
                    PollTimer = new DispatcherTimer();
                    PollTimer.Interval = new TimeSpan(0, 0, 1);
                    PollTimer.Tick += new EventHandler(PollTimer_Tick);
                    PollTimer.Start();
                }
            }

            lock (Errors)
            {
                HasErrors = Errors.Count > 0;
            }

            

//#if !SILVERLIGHT
//#if DEMO
//            NeuroSpeech.UIAtoms.Dialogs.AtomDemoWindow.ShowDemo(true);
//#endif
//#endif

            if (AtomTreeWalker.AnyChild<UIElement>(this, t => AtomForm.GetHasError(t)))
                return false;

            return !HasErrors;
        }

        void PollTimer_Tick(object sender, EventArgs e)
        {
            PollTimer.Stop();

            AtomValidationEventArgs ae = new AtomValidationEventArgs();
            OnAfterValidate(ae);


            lock (Errors)
            {
                AtomValidationError[] errorsToRemove = Errors.Where(t => t.IsFormError).ToArray();

                foreach (AtomValidationError error in errorsToRemove)
                {
                    AtomValidationError newError = ae.Errors.FirstOrDefault(t => t.Source == error.Source);
                    if (newError != null)
                    {
                        error.Message = newError.Message;
                        continue;
                    }

                    error.ClearError();
                    Errors.Remove(error);
                }

                foreach (AtomValidationError error in ae.Errors)
                {
                    if (errorsToRemove.Any(t => t.Source == error.Source))
                    {
                        continue;
                    }
                    error.SetError();
                    error.IsFormError = true;
                    Errors.Add(error);
                }

                HasErrors = Errors.Count > 0;
            }

            if (Errors.Any(t => t.IsFormError))
            {
                PollTimer.Start();
            }
            else
            {
                PollTimer.Tick -= new EventHandler(PollTimer_Tick);
                PollTimer = null;
            }
        }

        private DispatcherTimer PollTimer = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ve"></param>
        protected virtual void OnAfterValidate(AtomValidationEventArgs ve)
        {
            if (AfterValidate != null)
                AfterValidate(this, ve);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ve"></param>
        protected virtual void OnBeforeValidate(CancelEventArgs ve)
        {
            if (BeforeValidate != null)
                BeforeValidate(this, ve);
        }

}



    /// <summary>
    /// Validation Event Argument.
    /// </summary>
    public class AtomValidationEventArgs : EventArgs
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomValidationEventArgs()
        {

        }

        #region Property Result
        private List<AtomValidationError> _Errors = new List<AtomValidationError>();
        /// <summary>
        /// 
        /// </summary>
        public List<AtomValidationError> Errors
        {
            get
            {
                return _Errors;
            }
            internal set {
                _Errors = value;
            }
        }
        #endregion
	

    }

    /// <summary>
    /// Validation Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ValidationEventHandler(object sender, AtomValidationEventArgs e);


    /// <summary>
    /// 
    /// </summary>
    public enum AtomFormValidationMode { 

        /// <summary>
        /// This will inherit behaviour from the parent Form, will be removed in future when 
        /// property inheritance will be supported by Silverlight
        /// </summary>
        Inherit,
        
        /// <summary>
        /// Validation will be called manually only.
        /// </summary>
        Manual,

        /// <summary>
        /// Validation will be triggered by LostFocus event of the data field
        /// </summary>
        OnLostFocus,

        /// <summary>
        /// Validatoin will be triggered by PropertyChanged event
        /// </summary>
        OnPropertyChanged
    }


    /// <summary>
    /// 
    /// </summary>
    public class AtomFormItemGroup {

        /// <summary>
        /// 
        /// </summary>
        public AtomFormItemGroup()
        {
            Items = new List<AtomFormItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        public AtomFormItemGroup(string name, IEnumerable<AtomFormItem> items) {
            GroupName = string.IsNullOrEmpty(name) ? "Default" : name;
            try
            {
                items = items.OrderBy(x => x.Order).ThenBy(x => x.Label);
            }
            catch { }

            Items = new List<AtomFormItem>(items);
        }

        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RowLayout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<AtomFormItem> Items { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public FrameworkElement ChildContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<AtomFormItemGroup> Create(List<AtomFormItem> items) {
            List<AtomFormItemGroup> groups = new List<AtomFormItemGroup>();

            bool hasGroups = items.Any(x => !string.IsNullOrEmpty(x.GroupName));
            if (hasGroups)
            {
                // set "" to "Default"
                foreach (var item in items)
                {
                    if (string.IsNullOrEmpty(item.GroupName))
                        item.GroupName = "Default";
                }

                foreach (var item in items.GroupBy(x=>x.GroupName))
                {
                    AtomFormItemGroup g = new AtomFormItemGroup (item.Key,item);
                    groups.Add(g);
                }
            }
            else {
                groups.Add(new AtomFormItemGroup("",items));
            }

            return groups;
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public class AtomFormItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Binding Binding {get;set;} 

        /// <summary>
        /// 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string MissingValueError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Watermark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Type ControlType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FrameworkElement Control { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DependencyProperty DependencyProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AtomValidationRule ValidationRule { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ValidationAttribute[] ValidationAttributes { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo Property { get {
            return _Property;
        }
            set {
                _Property = value;
                SetProperty(value);
            }
        }
        private PropertyInfo _Property = null;

        #region private void SetProperty(PropertyInfo value)
        private void SetProperty(PropertyInfo p)
        {
#if DA
            DisplayAttribute a = (DisplayAttribute)p.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
            if (a != null)
            {
                string l = a.GetShortName();
                Label = string.IsNullOrWhiteSpace(l) ? p.Name : l;
                Watermark = a.GetPrompt();
                Description = a.GetDescription();
                Order = a.GetOrder();
                GroupName = a.GetGroupName();
            }
#endif

            RequiredAttribute r = (RequiredAttribute)p.GetCustomAttributes(typeof(RequiredAttribute), true).FirstOrDefault();
            if (r != null)
            {
#if DA
                if(!r.AllowEmptyStrings)
                    IsRequired = true;
#else
                IsRequired = true;
#endif
                //missingValueError = r.ErrorMessage;
            }

            DataTypeAttribute dat = (DataTypeAttribute)p.GetCustomAttributes(typeof(DataTypeAttribute), true).FirstOrDefault();
            if (dat != null)
            {
                switch (dat.DataType)
                {
                    case DataType.Currency:
                        ControlType = typeof(AtomCurrencyTextBox);
                        DependencyProperty = AtomCurrencyTextBox.ValueProperty;
                        break;
                    case DataType.Custom:
                        break;
                    case DataType.Date:
                        ControlType = typeof(DatePicker);
                        DependencyProperty = DatePicker.SelectedDateProperty;
                        break;
                    case DataType.DateTime:
                        break;
                    case DataType.Duration:
                        break;
                    case DataType.EmailAddress:
                        ControlType = typeof(AtomEmailTextBox);
                        DependencyProperty = AtomEmailTextBox.TextProperty;
                        // let there be default validator...
                        // as Data Annotation does not validate email address correctly..
                        ValidationAttributes = null;
                        break;
                    case DataType.Html:
                        break;
#if DA
                    case DataType.ImageUrl:
                        break;
#endif
                    case DataType.MultilineText:
                        break;
                    case DataType.Password:
                        ControlType = typeof(AtomPasswordBox);
                        DependencyProperty = AtomPasswordBox.PasswordProperty;
                        ValidationAttributes = null;
                        break;
                    case DataType.PhoneNumber:
                        break;
                    case DataType.Text:
                        break;
                    case DataType.Time:
                        break;
                    case DataType.Url:
                        break;
                    default:
                        break;
                }
            }

            if (ControlType == null) {
                ControlType = typeof(AtomTextBox);
                DependencyProperty = AtomTextBox.TextProperty;
            }

            if (ControlType == typeof(AtomTextBox))
            {
                ControlMap map = null;
                if (TypeMapper.TryGetValue(p.PropertyType, out map)) {
                    ControlType = map.ControlType;
                    DependencyProperty = map.Property;
                }
            }

        }

        private static Dictionary<Type, ControlMap> TypeMapper = new Dictionary<Type, ControlMap>() { 
            { 
                typeof(decimal) , 
                    new ControlMap{ 
                        ControlType =typeof(AtomCurrencyTextBox), 
                        Property=AtomCurrencyTextBox.ValueProperty 
                    }
                },
            { 
                typeof(int) , 
                    new ControlMap{ 
                        ControlType =typeof(AtomIntegerTextBox), 
                        Property=AtomIntegerTextBox.ValueProperty 
                    }
                },
            { 
                typeof(double) , 
                    new ControlMap{ 
                        ControlType =typeof(AtomDoubleTextBox), 
                        Property=AtomDoubleTextBox.ValueProperty 
                    }
                },
            { 
                typeof(DateTime) , 
                    new ControlMap{ 
                        ControlType =typeof(DatePicker), 
                        Property=DatePicker.SelectedDateProperty 
                    }
                },
            { 
                typeof(DateTime?) , 
                    new ControlMap{ 
                        ControlType =typeof(DatePicker), 
                        Property=DatePicker.SelectedDateProperty 
                    }
                },
            { 
                typeof(bool) , 
                    new ControlMap{ 
                        ControlType =typeof(CheckBox), 
                        Property=CheckBox.IsCheckedProperty
                    }
                },
            { 
                typeof(bool?) , 
                    new ControlMap{ 
                        ControlType =typeof(CheckBox), 
                        Property=CheckBox.IsCheckedProperty
                    }
                },
        };

        #endregion

    }

    internal class ControlMap {
        internal Type ControlType;
        internal DependencyProperty Property;
    }

    #region Old
    //    public class AtomBinder {



    //        #region Attached Dependency Property Bind
    //        ///<summary>
    //        ///Get Attached Property Bind for DependencyObject
    //        ///</summary>
    //        /// <param name="obj"></param>
    //        /// <returns></returns>
    //        [System.ComponentModel.Category("Atoms")]
    //        public static AtomMultiBinding GetBind(DependencyObject obj)
    //        {
    //            return (AtomMultiBinding)obj.GetValue(BindProperty);
    //        }

    //        ///<summary>
    //        ///Set Attached Property Bind for DependencyObject
    //        ///</summary>
    //        /// <param name="obj"></param>
    //        /// <param name="value"></param>
    //        /// <returns></returns>
    //        public static void SetBind(DependencyObject obj, AtomMultiBinding value)
    //        {
    //            obj.SetValue(BindProperty, value);
    //        }

    //        ///<summary>
    //        /// Using a DependencyProperty as the backing store for Bind.  This enables animation, styling, binding, etc...
    //        ///</summary>
    //#if SILVERLIGHT
    //        public static readonly DependencyProperty BindProperty =
    //            DependencyProperty.RegisterAttached("Bind", typeof(AtomMultiBinding), typeof(AtomBinder), new PropertyMetadata(OnBindPropertyChanged));
    //#else
    //        public static readonly DependencyProperty BindProperty =
    //            DependencyProperty.RegisterAttached("Bind", typeof(AtomMultiBinding), typeof(AtomBinder), new UIPropertyMetadata(OnBindPropertyChanged));
    //#endif

    //        private static void OnBindPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    //        {
    //            AtomMultiBinding b = e.OldValue as AtomMultiBinding;
    //            if (b != null)
    //            {
    //                DependencyProperty dp = GetProperty(sender, b.Path);
    //                sender.ClearValue(dp);
    //            }
    //            b = e.NewValue as AtomMultiBinding;
    //            if (b != null) {
    //                DependencyProperty dp = GetProperty(sender, b.Path);
    //                b.SetOneWayBinding(FrameworkElement.DataContextProperty, sender, "DataContext");
    //                sender.SetOneWayBinding(dp, b, "Value");
    //            }
    //        }

    //        private static DependencyProperty GetProperty(object value, string path) {
    //            Type type = value.GetType();
    //            FieldInfo field = type.GetField(path + "Property");
    //            return field.GetValue(null) as DependencyProperty;
    //        }

    //        #endregion




    //    } 
    #endregion

}
