#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Threading;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Shapes;
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

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(AtomFormItemContainer))]
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public partial class AtomFormLayout : HeaderedItemsControl
    {


		#region partial void  OnCreate()
		partial void OnCreate()
		{
			TabItems = new ObservableCollection<object>();
			this.IsTabStop = false;

			//this.Bind(AtomFormLayout.TabItemsProperty, () => ToTabItems(this.Items));

#if SILVERLIGHT
            this.DefaultStyleKey = typeof(AtomFormLayout);
#endif
		}
		#endregion


        ObservableCollection<object> TabItems = new ObservableCollection<object>();

        #region protected override void  OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            ToTabItems(this.Items);

        }

        #region private ObservableCollection<object> ToTabItems(ItemCollection itemCollection)
        private void ToTabItems(ItemCollection itemCollection)
        {
            TabItems.Clear();
            foreach (object item in itemCollection)
            {
                AtomFormTab tab = item as AtomFormTab;
                if (tab != null)
                {
                    TabItems.Add(tab.Header);
                }
                AtomTabContent ti = item as AtomTabContent;
                if (ti != null)
                {
                    TabItems.Add(ti.Header);
                }
            }
        }
        #endregion

        #endregion




#if SILVERLIGHT
#else
#endif


//        ///<summary>
//        /// Dependency Property Tabs
//        ///</summary>
//        #region Dependency Property Tabs
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public ObservableCollection<TabItem> Tabs
//        {
//            get { return (ObservableCollection<TabItem>)GetValue(TabsProperty); }
//            private set { SetValue(TabsProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Tabs.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty TabsProperty =
//            DependencyProperty.Register("Tabs", typeof(ObservableCollection<TabItem>), typeof(AtomFormLayout), new PropertyMetadata(null, OnTabsChangedCallback));
		    
//        private static void OnTabsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
//          AtomFormLayout obj = d as AtomFormLayout;
//        }
		    
//#else
//        public static readonly DependencyProperty TabsProperty =
//            DependencyProperty.Register("Tabs", typeof(ObservableCollection<TabItem>), typeof(AtomFormLayout), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion







        #region protected override bool  IsItemItsOwnContainerOverride(object item)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            /*if (item is TabItem)
                throw new InvalidOperationException("AtomFormTab can only be added in Tabs Items Group");*/
            return item is AtomFormItemContainer || item is AtomFormLayout || item is AtomFormTab || item is AtomTabContent;
        }
        #endregion


        #region protected override DependencyObject  GetContainerForItemOverride()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new AtomFormItemContainer();
        }
        #endregion


		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
			Border header = this.GetTemplateChild("PART_HeaderBorder") as Border;
			if (header != null)
			{
				header.SafeBindVisibility(() => IsHeaderVisible(this.Header) && this.ShowHeader,
					new Binding("Header") { Source = this },
					new Binding("ShowHeader") { Source = this }
					);
			}

			Rectangle rect = this.GetTemplateChild("PART_Box") as Rectangle;
			if (rect != null)
			{
				rect.SafeBindVisibility(() => IsHeaderVisible(this.Header) && this.ShowHeader,
					new Binding("Header") { Source = this },
					new Binding("ShowHeader") { Source = this }
					);
			}

			Control footerPresenter = this.GetTemplateChild("PART_Footer") as Control;
			if (footerPresenter != null)
			{
				footerPresenter.SafeBindVisibility(() => this.IsHeaderVisible(this.Footer),
					new Binding("Footer") { Source = this });
			}

			/*TabControl tabControl = this.GetTemplateChild("PART_Tabs") as TabControl;
			if (tabControl != null)
			{
				//tabControl.ItemsSource = this.Tabs;
				//tabControl.BindVisibility(() => this.Tabs.Count > 0);
				//tabControl.Bind(TabControl.ItemsSourceProperty, () => this.Items.OfType<TabItem>());
				//tabControl.BindVisibility(() => this.Items.OfType<TabItem>().Any());
				//tabControl.Bind(TabControl.ItemsSourceProperty, () => this.TabItems);
				//tabControl.BindVisibility(() => this.TabItems.Count > 0);
			}*/

			selector = this.GetTemplateChild("PART_Selector") as AtomToggleButtonBar;
			if (selector != null)
			{
				selector.ItemsSource = this.TabItems;
				selector.SafeBindVisibility(() => this.TabItems.Count > 0,
					new Binding("Count") { Source = TabItems });
			}

			ItemsPresenter ip = GetTemplateChild("PART_Items") as ItemsPresenter;
			if (ip != null)
			{
				ip.SafeBind(ItemsPresenter.MarginProperty,
					() => IsHeaderVisible(this.Header) && this.ShowHeader ? new Thickness(5) : new Thickness(0),
					new Binding("Header") { Source = this },
					new Binding("ShowHeader") { Source = this });
			}

			this.Loaded += new RoutedEventHandler(AtomFormLayout_Loaded);
		}

		AtomToggleButtonBar selector;

		#region private bool IsHeaderVisible(object p)
		private bool IsHeaderVisible(object p)
		{
			return p != null && !string.IsNullOrEmpty(p.ToString());
		}
		#endregion


		#region void  AtomFormLayout_Loaded(object sender, RoutedEventArgs e)
		void AtomFormLayout_Loaded(object sender, RoutedEventArgs e)
		{
			AtomFlexibleGrid grid = this.GetItemsHost() as AtomFlexibleGrid;

			if (grid != null)
			{
				grid.SetOneWayBinding(AtomFlexibleGrid.RowLayoutProperty, this, "RowLayout");
				grid.SetOneWayBinding(AtomFlexibleGrid.HorizontalGapProperty, this, "HorizontalGap");
				grid.SetOneWayBinding(AtomFlexibleGrid.VerticalGapProperty, this, "VerticalGap");
				if (selector != null)
				{
					//grid.Bind(AtomFlexibleGrid.SelectedIndexProperty, () => this.TabItems.Count > 0 ? selector.SelectedIndex : -1);

					grid.SafeBind(
						AtomFlexibleGrid.SelectedIndexProperty,
						() => this.TabItems.Count > 0 ? selector.SelectedIndex : -1,
						new Binding("Count") { Source = TabItems },
						new Binding("SelectedIndex") { Source = selector }
						);

					/*AtomMultiBinding b = new AtomMultiBinding();
					Binding b1 = new Binding("TabItems.Count");
					b1.Source = this;
					b.Bindings.Add(b1);
					b1 = new Binding("SelectedIndex");
					b1.Source = selector;
					b.Bindings.Add(b1);
					b.Converter = new MultiDelegateConverter<int>(GetTabSelectedIndex);
					grid.SetBinding(AtomFlexibleGrid.SelectedIndexProperty, b);*/
				}
				//grid.BindVisibility(() => this.Tabs.Count == 0);
				//grid.BindVisibility(() => this.TabItems.Count == 0);
				OnLayoutGridAvailable(grid);
			}
		}

		private int GetTabSelectedIndex()
		{
			return this.TabItems.Count > 0 ? selector.SelectedIndex : -1;
		}

		#region private void OnLayoutGridAvailable(AtomFlexibleGrid grid)
		/// <summary>
		/// 
		/// </summary>
		/// <param name="grid"></param>
		protected virtual void OnLayoutGridAvailable(AtomFlexibleGrid grid)
		{

		}
		#endregion

		#endregion

		#endregion


        #region internal void SetLabelWidth(double desiredWidth)
        private double lastWidth = 0;
        internal void SetLabelWidth(double p)
        {
            lastWidth = Math.Max(lastWidth, p);
            if (this.LabelWidth < lastWidth)
                LabelWidth = lastWidth;
        }
        #endregion


		#region partial void  OnAfterLabelWidthChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterLabelWidthChanged(DependencyPropertyChangedEventArgs e)
		{
			// might need parent invalidation...
			this.InvalidateVisual();
		}
		#endregion


    }
}
