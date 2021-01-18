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
    public partial class AtomAccordionItem : ListBoxItem
    {

		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
			Binding b = new Binding();
			b.Path = new PropertyPath(AtomAccordion.HeaderProperty);
			b.Source = Content;
			this.SetBinding(HeaderProperty, b);

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

			if (this.Content is HeaderedContentControl || this.Content is HeaderedItemsControl)
			{
				b = new Binding("Content");
				b.Source = this.Content;
				contentPresenter.SetBinding(ContentPresenter.ContentProperty, b);
			}

		}
		#endregion



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




    }
}
