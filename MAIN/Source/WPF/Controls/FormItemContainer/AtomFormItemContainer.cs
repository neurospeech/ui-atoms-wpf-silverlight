#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Controls.Primitives;
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
using System.Windows.Controls.Primitives;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !SILVERLIGHT
#endif
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Validation;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Item Container of Form
    /// </summary>
    [TemplatePart(Name = "PART_Description", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_Title", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_IsRequired", Type = typeof(TextBlock))]
    // Optional
    [TemplateVisualState(Name = "Normal", GroupName="General")]
    [TemplateVisualState(Name = "HasError", GroupName = "General")]
    [TemplatePart(Name = "PART_Label", Type = typeof(Label))]
    [AtomDesign(DisplayInToolbox = false)]
    public partial class AtomFormItemContainer : ContentControl
    {


#if SILVERLIGHT

        /// <summary>
        /// 
        /// </summary>
        public AtomFormItemContainer()
        {
            this.IsTabStop = false;
            DefaultStyleKey = typeof(AtomFormItemContainer);
        }

#else
		#region static partial void  OnCreateStatic()
		static partial void OnCreateStatic()
		{
			AtomFocusManager.IgnoreFocus(typeof(AtomFormItemContainer));
		}
		#endregion

#endif


        #region protected override void  OnContentChanged(object oldContent, object newContent)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldContent"></param>
        /// <param name="newContent"></param>
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (newContent != null && newContent is Control && Label != null)
				Label.SafeBind(Label.IsEnabledProperty,
					() => this.Content.Property("IsEnabled"),
					new Binding("Content.IsEnabled") { Source=this });
            BindLayoutProperties(newContent);

        }

        private void BindLayoutProperties(object newContent)
        {
            if (newContent != null && newContent is Control)
            {
                BindAttached(newContent, Grid.RowProperty, "(Grid.Row)");
                BindAttached(newContent, Grid.RowSpanProperty, "(Grid.RowSpan)");
                BindAttached(newContent, Grid.ColumnProperty, "(Grid.Column)");
                BindAttached(newContent, Grid.ColumnSpanProperty, "(Grid.ColumnSpan)");
                BindAttached(newContent, Canvas.LeftProperty, "(Canvas.Left)");
                BindAttached(newContent, Canvas.TopProperty, "(Canvas.Top)");

                IFormContainer c = OwnerForm;
                if (c != null) {
                    c.BindField(this, newContent as Control);
                }
            }
        }
        #endregion


        private void BindAttached(object obj, DependencyProperty p, string path)
        {
            Binding b = new Binding(path);
            BindingOperations.SetBinding(this, p, b);
        }

        /// <summary>
        /// 
        /// </summary>
        internal protected Label Label;

        private ContentControl Description;
        private ContentControl Title;
        private ContentControl CommandBox;
        private ContentControl IsRequired;
        private Border contentBorder;


		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
#if SILVERLIGHT
            
            try {
                SetupControls();
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.ToString());
                AtomUtils.Log(ex.ToString());
            }
#else
			SetupControls();
#endif
		}
		#endregion



        internal IFormContainer OwnerForm {
            get {
                return AtomTreeWalker.FindParent<IFormContainer>(this, x => (x is IFormContainer));
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="availableSize"></param>
        /// <returns></returns>
        #region protected override Size  MeasureOverride(Size availableSize)
        protected override Size MeasureOverride(Size availableSize)
        {
            Size size = base.MeasureOverride(availableSize);
            try
            {
                if (Label != null && OwnerForm != null)
                {
                    double desiredWidth = Label.DesiredSize.Width;
                    desiredWidth += Label.Margin.Right + Label.Margin.Left;
#if SILVERLIGHT
                    Dispatcher.BeginInvoke(() =>
                    {
                        if(OwnerForm!=null)
                            OwnerForm.SetLabelWidth(desiredWidth);
                        //AtomTrace.WriteLine(string.Format("{0}", e.DesiredSize.Width));
                    });
#else
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    OwnerForm.SetLabelWidth(desiredWidth);
                    //AtomTrace.WriteLine(string.Format("{0}", e.DesiredSize.Width));
                });
#endif
                }
            }
            catch { }
            return size;
        }
        #endregion




        private void SetupControls()
        {
            IFormContainer of = OwnerForm;

            Description = GetNamedChild<ContentControl>("PART_Description");
            Title = GetNamedChild<ContentControl>("PART_Title");
            IsRequired = GetNamedChild<ContentControl>("PART_IsRequired");
            CommandBox = GetTemplateChild("PART_CommandBox") as ContentControl;

            contentBorder = GetTemplateChild("contentBorder") as Border;


            // bind everything...

            FrameworkElement c = Content as FrameworkElement;
			if (c == null)
				return;

            BindLayoutProperties(c);

            this.SetOneWayBinding(VisibilityProperty, c, "Visibility");
            c.SetOneWayBinding(FrameworkElement.DataContextProperty, of, "DataContext");
            Label = GetNamedChild<Label>("PART_Label");

            Label.BindAttached(Label.ContentProperty, c, AtomForm.LabelProperty, null);
            Label.Target = c;

            
            if(c!=null && c is Control)
				Label.SafeBind(Label.IsEnabledProperty, () => Content.Property<bool>("IsEnabled"), new Binding("Content.IsEnabled") {  Source=this});

            Label.SetOneWayBinding(Label.MinWidthProperty, of, "LabelWidth");
            Label.SetOneWayBinding(Label.HorizontalContentAlignmentProperty, of, "LabelHorizontalAlignment");
            Label.SetOneWayBinding(Label.VerticalContentAlignmentProperty, of, "LabelVerticalAlignment");

            Description.BindAttached(ContentControl.ContentProperty, c, AtomForm.DescriptionProperty, null);
            
            Title.BindAttached(ContentControl.ContentProperty, c, AtomForm.TitleProperty, null);

            IsRequired.BindAttached(ContentControl.VisibilityProperty, c, AtomForm.IsRequiredProperty, AtomUtils.GetDefaultInstance<BooleanToVisibilityConverter>());

			Label.BindAttached(ContentControl.VisibilityProperty, c, AtomForm.ShowLabelProperty, AtomUtils.GetDefaultInstance<BooleanToVisibilityConverter>());

            if (CommandBox != null) {
                CommandBox.BindAttached(ContentControl.ContentProperty, c, AtomForm.CommandBoxProperty, null);
            }

            this.BindAttached(IsContentInvalidProperty, c, AtomForm.HasErrorProperty, null);
            this.BindAttached(ErrorMessageProperty, c, AtomForm.ErrorMessageProperty, null);


#if SILVERLIGHT

            Label.GotFocus += new RoutedEventHandler(Label_GotFocus);
            Label.MouseLeftButtonUp += new MouseButtonEventHandler(Label_MouseLeftButtonUp);
#else
            //BindAttachedProperties(Label, AtomForm.LabelWidthProperty, Label, Label.MinWidthProperty, null);
            Label.BindAttached(Label.MinWidthProperty, OwnerForm as FrameworkElement, AtomFormLayout.LabelWidthProperty, null);
#endif

            c.GotFocus += new RoutedEventHandler(c_GotFocus);

        }

        #region void  c_GotFocus(object sender, RoutedEventArgs e)
        void c_GotFocus(object sender, RoutedEventArgs e)
        {
            FrameworkElement c = sender as FrameworkElement;
            if (c == null)
                return;
            c.BringIntoView();
        }
        #endregion



#if SILVERLIGHT

        void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Control c = Content as Control;
            if (c != null)
                c.Focus();
        }

        void Label_GotFocus(object sender, RoutedEventArgs e)
        {
            Control c = Content as Control;
            if (c != null)
                c.Focus();
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T GetNamedChild<T>(string name)
    where T : DependencyObject
        {
            T child = GetTemplateChild(name) as T;
            if (child == null)
                throw new Exception("Please define '" + name + "' of type '" + typeof(T).FullName + "'");
            return child;
        }

		#region partial void  OnAfterIsContentInvalidChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterIsContentInvalidChanged(DependencyPropertyChangedEventArgs e)
		{
			bool val = (bool)e.NewValue;
			if (val)
			{
				VisualStateManager.GoToState(this, "HasError", true);
			}
			else
			{
				VisualStateManager.GoToState(this, "Normal", true);
			}
		}
		#endregion



        #region internal void InvalidateLabel()
        internal void InvalidateLabel()
        {
            if (Label != null) {
                Label.InvalidateArrange();
                Label.InvalidateMeasure();
            }    
        }
        #endregion
    }
}
