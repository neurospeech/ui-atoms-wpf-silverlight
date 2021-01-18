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
using System.Diagnostics;
using System.ComponentModel;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Default ItemContainer for AtomAccordion
    /// </summary>
    [TemplatePart(Name="PART_Content",Type=typeof(ContentPresenter))]
    [TemplatePart(Name = "PART_Header", Type = typeof(ToggleButton))]
    [AtomDesign(
        DisplayInToolbox = false
        )]
    public class AtomAccordionItem : ListBoxItem
    {
        static AtomAccordionItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomAccordionItem), new FrameworkPropertyMetadata(typeof(AtomAccordionItem)));
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Binding b = new Binding();
            b.Path = new PropertyPath(AtomAccordion.HeaderProperty);
            b.Source = Content;
            this.SetBinding(HeaderProperty, b);

            contentPresenter = GetTemplateChild("PART_Content") as ContentPresenter;
            if (contentPresenter == null)
                throw new InvalidOperationException("Template must contain PART_Content");
            headerButton = GetTemplateChild("PART_Header") as ToggleButton;
            if (headerButton == null)
                throw new InvalidOperationException("Template must containt PART_Header");

            b = new Binding();
            b.Path = new PropertyPath(ListBoxItem.IsSelectedProperty);
            b.Source = this;
            b.Converter = new BooleanToVisibilityConverter();
            contentPresenter.SetBinding(ContentPresenter.VisibilityProperty, b);

            b = new Binding("IsSelected");
            b.Source = this;
            b.Mode = BindingMode.TwoWay;
            headerButton.SetBinding(ToggleButton.IsCheckedProperty, b);

            b = new Binding("Header");
            b.Source = this;
            headerButton.SetBinding(ToggleButton.ContentProperty, b);

            if (this.Content is HeaderedContentControl || this.Content is HeaderedItemsControl) {
                b = new Binding("Content");
                b.Source = this.Content;
                contentPresenter.SetBinding(ContentPresenter.ContentProperty, b);
            }

        }

        //protected override Size MeasureOverride(Size constraint)
        //{
        //    if (this.IsSelected) {
        //        Trace.WriteLine(string.Format("{0},{1}",constraint.Width,constraint.Height));
        //        return new Size(double.PositiveInfinity, double.PositiveInfinity);
        //    }
        //    return base.MeasureOverride(constraint);
        //}

        //protected override Size ArrangeOverride(Size arrangeBounds)
        //{
        //    Trace.WriteLine(string.Format("{0},{1}", arrangeBounds.Width, arrangeBounds.Height));
        //    return base.ArrangeOverride(arrangeBounds);
        //}

        private ContentPresenter contentPresenter;
        private ToggleButton headerButton;


        ///<summary>
        /// Dependency Property Header
        ///</summary>
        #region Dependency Property Header
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Description("Header")]
        [System.ComponentModel.Browsable(true)]
        public object Header
        {
            get { return (object)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Header.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty HeaderProperty =
            HeaderedContentControl.HeaderProperty.AddOwner(typeof(AtomAccordionItem), new FrameworkPropertyMetadata(0));


        #endregion




    }
}
