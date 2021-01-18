#if WINRT
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
    public class AtomFormLayout : HeaderedItemsControl
    {



        /// <summary>
        /// 
        /// </summary>
        public AtomFormLayout()
        {
            TabItems = new ObservableCollection<object>();
            this.IsTabStop = false;

            //this.Bind(AtomFormLayout.TabItemsProperty, () => ToTabItems(this.Items));

#if SILVERLIGHT
            this.DefaultStyleKey = typeof(AtomFormLayout);
#endif
        }

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


        ///<summary>
        /// Dependency Property ShowHeader
        ///</summary>
        #region Dependency Property ShowHeader
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public bool ShowHeader
        {
            get { return (bool)GetValue(ShowHeaderProperty); }
            set { SetValue(ShowHeaderProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ShowHeader.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ShowHeaderProperty =
            DependencyProperty.Register("ShowHeader", typeof(bool), typeof(AtomFormLayout), new PropertyMetadata(true, OnShowHeaderChangedCallback));

        private static void OnShowHeaderChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFormLayout obj = d as AtomFormLayout;
        }

#else
public static readonly DependencyProperty ShowHeaderProperty = 
    DependencyProperty.Register("ShowHeader", typeof(bool), typeof(AtomFormLayout), new FrameworkPropertyMetadata(true));
#endif

        #endregion




#if SILVERLIGHT
#else
        static AtomFormLayout()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomFormLayout), new FrameworkPropertyMetadata(typeof(AtomFormLayout)));
        }
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


        /// <summary>
        /// 
        /// </summary>
        #region public override void  OnApplyTemplate()
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();


            Border header = this.GetTemplateChild("PART_HeaderBorder") as Border;
            if (header != null)
            {
				header.SafeBindVisibility(() => IsHeaderVisible(this.Header) && this.ShowHeader,
					new Binding("Header") { Source = this },
					new Binding("ShowHeader") { Source = this }
					);
            }

            Rectangle rect = this.GetTemplateChild("PART_Box") as Rectangle;
            if (rect != null) {
				rect.SafeBindVisibility(() => IsHeaderVisible(this.Header) && this.ShowHeader,
					new Binding("Header") { Source = this },
					new Binding("ShowHeader") { Source = this }
					);
            }

            Control footerPresenter = this.GetTemplateChild("PART_Footer") as Control;
            if (footerPresenter != null) {
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
            if (selector != null) {
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
					new Binding("ShowHeader") { Source=this });
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
						new Binding("SelectedIndex") { Source = selector}
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
			return this.TabItems.Count > 0 ?selector.SelectedIndex : -1;
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


        /// <summary>
        /// LabelWidth defines the pixel width of the labels in an AtomFormLayout
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// LabelWidth
        /// </listheader>
        /// 		<item>
        /// This property, set once, defines the width of all the labels in the AtomFormLayout.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property LabelWidth
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms"
            )]
        public double LabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		        public static readonly DependencyProperty LabelWidthProperty =
		            DependencyProperty.Register("LabelWidth", typeof(double), typeof(AtomFormLayout), new PropertyMetadata((double)75,OnLabelWidthPropertyChanged));

		        private static void OnLabelWidthPropertyChanged(object sender, DependencyPropertyChangedEventArgs e) {
		            //AtomFormLayout form = sender as AtomFormLayout;
		            //if (form != null)
		            //    form.OnLabelWidthChanged(e);
		        }

		        //#region private void OnLabelWidthChanged(DependencyPropertyChangedEventArgs e)
		        //protected void OnLabelWidthChanged(DependencyPropertyChangedEventArgs e)
		        //{
		        //    //AtomUtils.Invalidate(this);
		        //    foreach (var item in Items)
		        //    {
		        //        var x = ItemContainerGenerator.ContainerFromItem(item);
		        //        AtomFormLayoutItemContainer fe = x as AtomFormLayoutItemContainer;
		        //        if (fe != null)
		        //            fe.InvalidateLabel((double)e.NewValue);
		        //    }
		        //}
		        //#endregion

#else
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.RegisterAttached("LabelWidth", typeof(double), typeof(AtomFormLayout),
            new FrameworkPropertyMetadata((double)75.0,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.Inherits
                ));
#endif

        #endregion


        ///<summary>
        /// Dependency Property LabelHorizontalAlignment
        ///</summary>
        #region Dependency Property LabelHorizontalAlignment
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public HorizontalAlignment LabelHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(LabelHorizontalAlignmentProperty); }
            set { SetValue(LabelHorizontalAlignmentProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for LabelHorizontalAlignment.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		public static readonly DependencyProperty LabelHorizontalAlignmentProperty = 
		                                DependencyProperty.Register("LabelHorizontalAlignment", typeof(HorizontalAlignment), typeof(AtomFormLayout), new PropertyMetadata(HorizontalAlignment.Right, OnLabelHorizontalAlignmentChangedCallback));
		    
		        private static void OnLabelHorizontalAlignmentChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
		            AtomFormLayout obj = d as AtomFormLayout;
		            if (obj != null) {
		                obj.OnLabelHorizontalAlignmentChanged(e);
		            }
		        }

        #region private void OnLabelHorizontalAlignmentChanged(DependencyPropertyChangedEventArgs e)
		        private void OnLabelHorizontalAlignmentChanged(DependencyPropertyChangedEventArgs e)
		        {
		            foreach (var item in Items)
		            {
		                var x = ItemContainerGenerator.ContainerFromItem(item);
		                AtomFormItemContainer fe = x as AtomFormItemContainer;
		                if (fe != null)
		                    fe.InvalidateLabel();
		            }
		        }
                #endregion

		    
#else
        public static readonly DependencyProperty LabelHorizontalAlignmentProperty =
            DependencyProperty.Register("LabelHorizontalAlignment", typeof(HorizontalAlignment), typeof(AtomFormLayout), new FrameworkPropertyMetadata(HorizontalAlignment.Right));
#endif

        #endregion


        ///<summary>
        /// Dependency Property LabelVerticalAlignment
        ///</summary>
        #region Dependency Property LabelVerticalAlignment
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public VerticalAlignment LabelVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty); }
            set { SetValue(LabelVerticalAlignmentProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for LabelVerticalAlignment.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		public static readonly DependencyProperty LabelVerticalAlignmentProperty = 
		    DependencyProperty.Register("LabelVerticalAlignment", typeof(VerticalAlignment), typeof(AtomFormLayout), new PropertyMetadata(VerticalAlignment.Center, OnLabelVerticalAlignmentChangedCallback));
		    
		private static void OnLabelVerticalAlignmentChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
		  AtomFormLayout obj = d as AtomFormLayout;
		}
		    
#else
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register("LabelVerticalAlignment", typeof(VerticalAlignment), typeof(AtomFormLayout), new FrameworkPropertyMetadata(VerticalAlignment.Center));
#endif

        #endregion



        ///<summary>
        /// Dependency Property RowLayout
        ///</summary>
        #region Dependency Property RowLayout
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string RowLayout
        {
            get { return (string)GetValue(RowLayoutProperty); }
            set { SetValue(RowLayoutProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for RowLayout.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		public static readonly DependencyProperty RowLayoutProperty = 
		    DependencyProperty.Register("RowLayout", typeof(string), typeof(AtomFormLayout), new PropertyMetadata("", OnRowLayoutChangedCallback));
		    
		private static void OnRowLayoutChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
		  AtomFormLayout obj = d as AtomFormLayout;
		}
		    
#else
        public static readonly DependencyProperty RowLayoutProperty =
            DependencyProperty.Register("RowLayout", typeof(string), typeof(AtomFormLayout), new FrameworkPropertyMetadata(""));
#endif

        #endregion




        /// <summary>
        /// Horizontal Gap defines the horizontal gap between items on an AtomFormLayout
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// Horizontal Gap
        /// </listheader>
        /// 		<item>
        /// This property defines the horizontal gap between items on an AtomFormLayout. It is used uniformly across all items in the AtomFormLayout.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property HorizontalGap
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms"
            )]
        public double HorizontalGap
        {
            get { return (double)GetValue(HorizontalGapProperty); }
            set { SetValue(HorizontalGapProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for HorizontalGap.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		        public static readonly DependencyProperty HorizontalGapProperty =
		            DependencyProperty.Register("HorizontalGap", typeof(double), typeof(AtomFormLayout), new PropertyMetadata((double)2));
#else
        public static readonly DependencyProperty HorizontalGapProperty =
            AtomFlexibleGrid.HorizontalGapProperty.AddOwner(typeof(AtomFormLayout), new FrameworkPropertyMetadata((double)2));
#endif

        #endregion


        /// <summary>
        /// Vertical Gap defines the vertical gap between items in an AtomFormLayout
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// Vertical Gap
        /// </listheader>
        /// 		<item>
        /// This property, set once, defines the Vertical Gap between items in an AtomFormLayout. 
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property VerticalGap
        [AtomDesign(
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default,
            Category = "Atoms"
            )]
        public double VerticalGap
        {
            get { return (double)GetValue(VerticalGapProperty); }
            set { SetValue(VerticalGapProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for VerticalGap.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		        public static readonly DependencyProperty VerticalGapProperty =
		            DependencyProperty.Register("VerticalGap", typeof(double), typeof(AtomFormLayout), new PropertyMetadata((double)2));
#else
        public static readonly DependencyProperty VerticalGapProperty =
            AtomFlexibleGrid.VerticalGapProperty.AddOwner(typeof(AtomFormLayout), new FrameworkPropertyMetadata((double)2));
#endif
        #endregion




        ///<summary>
        ///HeaderBackground is brush for applying background to the Header Border, if there is any Header specified.
        ///</summary>
        #region Dependency Property HeaderBackground
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for HeaderBackground.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		        public static readonly DependencyProperty HeaderBackgroundProperty = 
		            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(AtomFormLayout), new PropertyMetadata(null, OnHeaderBackgroundChangedCallback));
		            
		        private static void OnHeaderBackgroundChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
		          AtomFormLayout obj = d as AtomFormLayout;
		        }
		    
#else
        public static readonly DependencyProperty HeaderBackgroundProperty =
            DependencyProperty.Register("HeaderBackground", typeof(Brush), typeof(AtomFormLayout), new FrameworkPropertyMetadata(null));
#endif

        #endregion





        ///<summary>
        ///You can use footer to display buttons in the form, 
        ///it is very useful when you are generating fields of the form automatically.
        ///</summary>
        #region Dependency Property Footer
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public object Footer
        {
            get { return (object)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Footer.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
		        public static readonly DependencyProperty FooterProperty = 
		            DependencyProperty.Register("Footer", typeof(object), typeof(AtomFormLayout), new PropertyMetadata(null, OnFooterChangedCallback));
		            
		        private static void OnFooterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
		          AtomFormLayout obj = d as AtomFormLayout;
		        }
#else
        public static readonly DependencyProperty FooterProperty =
            DependencyProperty.Register("Footer", typeof(object), typeof(AtomFormLayout), new FrameworkPropertyMetadata(null));
#endif

        #endregion



    }
}
