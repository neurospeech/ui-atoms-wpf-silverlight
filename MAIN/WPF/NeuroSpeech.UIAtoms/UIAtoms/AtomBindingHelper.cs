#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Markup;
#else
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.ObjectModel;

namespace NeuroSpeech.UIAtoms
{



    #region Old
//    public class AtomMultiBinding : FrameworkElement
//    {


//        ///<summary>
//        /// Dependency Property Path
//        ///</summary>
//        #region Dependency Property Path
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public string Path
//        {
//            get { return (string)GetValue(PathProperty); }
//            set { SetValue(PathProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty PathProperty =
//            DependencyProperty.Register("Path", typeof(string), typeof(AtomMultiBinding), new PropertyMetadata("", OnPathChangedCallback));

//        private static void OnPathChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomMultiBinding obj = d as AtomMultiBinding;
//        }

//#else
//public static readonly DependencyProperty PathProperty = 
//    DependencyProperty.Register("Path", typeof(string), typeof(AtomMultiBinding), new FrameworkPropertyMetadata(""));
//#endif

//        #endregion

//        public AtomMultiBinding()
//        {
//            this.Items = new AtomBindingList(this);
//        }


//        ///<summary>
//        /// Dependency Property Items
//        ///</summary>
//        #region Dependency Property Items
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public AtomBindingList Items
//        {
//            get { return (AtomBindingList)GetValue(ItemsProperty); }
//            private set { SetValue(ItemsProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty ItemsProperty =
//            DependencyProperty.Register("Items", typeof(AtomBindingList), typeof(AtomMultiBinding), new PropertyMetadata(null, OnItemsChangedCallback));

//        private static void OnItemsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomMultiBinding obj = d as AtomMultiBinding;
//        }

//#else
//public static readonly DependencyProperty ItemsProperty = 
//    DependencyProperty.Register("Items", typeof(AtomBindingList), typeof(AtomMultiBinding), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion


//        ///<summary>
//        /// Dependency Property Value
//        ///</summary>
//        #region Dependency Property Value
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public object Value
//        {
//            get { return (object)GetValue(ValueProperty); }
//            private set { SetValue(ValueProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty ValueProperty =
//            DependencyProperty.Register("Value", typeof(object), typeof(AtomMultiBinding), new PropertyMetadata(null, OnValueChangedCallback));

//        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomMultiBinding obj = d as AtomMultiBinding;
//        }

//#else
//public static readonly DependencyProperty ValueProperty = 
//    DependencyProperty.Register("Value", typeof(object), typeof(AtomMultiBinding), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion


//        ///<summary>
//        /// Dependency Property Converter
//        ///</summary>
//        #region Dependency Property Converter
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public IValueConverter Converter
//        {
//            get { return (IValueConverter)GetValue(ConverterProperty); }
//            set { SetValue(ConverterProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Converter.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty ConverterProperty =
//            DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(AtomMultiBinding), new PropertyMetadata(null, OnConverterChangedCallback));

//        private static void OnConverterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomMultiBinding obj = d as AtomMultiBinding;
//        }

//#else
//public static readonly DependencyProperty ConverterProperty = 
//    DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(AtomMultiBinding), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion


//        ///<summary>
//        ///DependencyProperty ConverterParameter
//        ///</summary>
//        #region Dependency Property ConverterParameter
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public object ConverterParameter
//        {
//            get { return (object)GetValue(ConverterParameterProperty); }
//            set { SetValue(ConverterParameterProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for ConverterParameter.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty ConverterParameterProperty =
//            DependencyProperty.Register("ConverterParameter", typeof(object), typeof(AtomMultiBinding), new PropertyMetadata(null, OnConverterParameterChangedCallback));
//#else
//public static readonly DependencyProperty ConverterParameterProperty = 
//    DependencyProperty.Register("ConverterParameter", typeof(object), typeof(AtomMultiBinding), new FrameworkPropertyMetadata(null,OnConverterParameterChangedCallback));
//#endif

//        private static void OnConverterParameterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomMultiBinding obj = d as AtomMultiBinding;
//            if (obj != null)
//            {
//                obj.OnConverterParameterChanged(e);
//            }
//        }

//        /// <summary>
//        /// Fires ConverterParameterChanged event.
//        /// </summary>
//        /// <param name="e"></param>
//        protected virtual void OnConverterParameterChanged(DependencyPropertyChangedEventArgs e)
//        {
//            if (ConverterParameterChanged != null)
//            {
//                ConverterParameterChanged(this, EventArgs.Empty);
//            }
//        }

//        ///<summary>
//        ///
//        ///</summary>
//        public event EventHandler ConverterParameterChanged;

//        #endregion


//        #region internal void UpdateValue()
//        internal void UpdateValue()
//        {
//            List<object> values = new List<object>();
//            foreach (var item in Items)
//            {
//                values.Add(item.Value);
//            }
//            object finalValue = values.ToArray();
//            IValueConverter vc = Converter;
//            if (vc != null)
//            {
//                finalValue = vc.Convert(finalValue, null, ConverterParameter, null);
//            }
//            this.Value = finalValue;
//        }
//        #endregion
//    }

//    public class AtomBinding : FrameworkElement
//    {
//        internal AtomMultiBinding Owner { get; set; }



//        ///<summary>
//        ///DependencyProperty Value
//        ///</summary>
//        #region Dependency Property Value
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public object Value
//        {
//            get { return (object)GetValue(ValueProperty); }
//            set { SetValue(ValueProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty ValueProperty =
//            DependencyProperty.Register("Value", typeof(object), typeof(AtomBinding), new PropertyMetadata(null, OnValueChangedCallback));
//#else
//public static readonly DependencyProperty ValueProperty = 
//    DependencyProperty.Register("Value", typeof(object), typeof(AtomBinding), new FrameworkPropertyMetadata(null,OnValueChangedCallback));
//#endif

//        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
//        {
//            AtomBinding obj = d as AtomBinding;
//            if (obj != null)
//            {
//                obj.OnValueChanged(e);
//            }
//        }

//        /// <summary>
//        /// Fires ValueChanged event.
//        /// </summary>
//        /// <param name="e"></param>
//        protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e)
//        {
//            if (ValueChanged != null)
//            {
//                ValueChanged(this, EventArgs.Empty);
//            }
//            if (this.Owner != null)
//            {
//                Owner.UpdateValue();
//            }
//        }

//        ///<summary>
//        ///
//        ///</summary>
//        public event EventHandler ValueChanged;

//        #endregion



//    }

//    public class AtomBindingList : ICollection<AtomBinding>
//    {

//        internal AtomMultiBinding Owner { get; private set; }

//        public AtomBindingList(AtomMultiBinding owner)
//        {
//            this.Owner = owner;
//        }

//        private List<AtomBinding> bindings = new List<AtomBinding>();

//        #region public void  Add(AtomBinding item)
//        public void Add(AtomBinding item)
//        {
//            bindings.Add(item);
//            item.Owner = Owner;
//            item.SetOneWayBinding(FrameworkElement.DataContextProperty, Owner, "DataContext");
//        }
//        #endregion


//        #region public void  Clear()
//        public void Clear()
//        {
//            bindings.Clear();
//        }
//        #endregion


//        #region public bool  Contains(AtomBinding item)
//        public bool Contains(AtomBinding item)
//        {
//            return bindings.Contains(item);
//        }
//        #endregion


//        #region public void  CopyTo(AtomBinding[] array, int arrayIndex)
//        public void CopyTo(AtomBinding[] array, int arrayIndex)
//        {
//            bindings.CopyTo(array, arrayIndex);
//        }
//        #endregion


//        public int Count
//        {
//            get { return bindings.Count; }
//        }

//        public bool IsReadOnly
//        {
//            get { return false; }
//        }

//        #region public bool  Remove(AtomBinding item)
//        public bool Remove(AtomBinding item)
//        {
//            bool retval = bindings.Remove(item);
//            item.Owner = null;
//            return retval;
//        }
//        #endregion


//        #region public IEnumerator<AtomBinding>  GetEnumerator()
//        public IEnumerator<AtomBinding> GetEnumerator()
//        {
//            return bindings.GetEnumerator();
//        }
//        #endregion


//        #region System.Collections.IEnumerator  System.Collections.IEnumerable.GetEnumerator()
//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return bindings.GetEnumerator();
//        }
//        #endregion

//    } 
    #endregion


    public static class AtomDispatcherHelper
    {
        public static void CallLater(this UIElement e, Action a) {
            e.Dispatcher.BeginInvoke(a);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public static class AtomBindingHelper
    {

        private const int ScrollPadding = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameworkElement"></param>
        public static void BringIntoView(this FrameworkElement frameworkElement)
        {
            var parent = VisualTreeHelper.GetParent(frameworkElement);
            while (parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
                var scrollViewer = parent as ScrollViewer;
                if (scrollViewer != null)
                {
                    frameworkElement.BringIntoViewForScrollViewer(scrollViewer);
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameworkElement"></param>
        /// <param name="scrollViewer"></param>
        public static void BringIntoViewForScrollViewer(this FrameworkElement frameworkElement, ScrollViewer scrollViewer)
        {
            try
            {
                var transform = frameworkElement.TransformToVisual(scrollViewer);
                var positionInScrollViewer = transform.Transform(new Point(0, 0));

                if (positionInScrollViewer.Y < 0 || positionInScrollViewer.Y > scrollViewer.ViewportHeight - 20)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + positionInScrollViewer.Y - ScrollPadding);
            }
            catch {
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="dp"></param>
        /// <param name="src"></param>
        /// <param name="srcPath"></param>
        public static void SetOneWayBinding(this DependencyObject fe, DependencyProperty dp, object src, string srcPath)
        {
            SetOneWayBinding(fe, dp, src, srcPath, (IValueConverter)null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="dp"></param>
        /// <param name="src"></param>
        /// <param name="srcPath"></param>
        /// <param name="conv"></param>
        public static void SetOneWayBinding(this DependencyObject fe, DependencyProperty dp, object src, string srcPath, IValueConverter conv)
        {
            Binding b = new Binding(srcPath);
            b.Source = src;
            if (conv != null)
                b.Converter = conv;
            //fe.SetBinding(dp, b);
            BindingOperations.SetBinding(fe, dp, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="dp"></param>
        /// <param name="src"></param>
        /// <param name="srcPath"></param>
        /// <param name="conv"></param>
        public static void SetOneWayBinding<TSrc,TDest>(this FrameworkElement fe, DependencyProperty dp, object src, string srcPath, Func<TSrc,object,TDest> conv)
        {
            Binding b = new Binding(srcPath);
            b.Source = src;
            if (conv != null)
                b.Converter = new DelegateConverter<TSrc,TDest>(conv);
            fe.SetBinding(dp, b);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fe"></param>
        /// <param name="dp"></param>
        /// <param name="src"></param>
        /// <param name="srcPath"></param>
        public static void SetTwoWayBinding(this FrameworkElement fe, DependencyProperty dp, object src, string srcPath)
        {
            Binding b = new Binding(srcPath);
            b.Source = src;
            b.Mode = BindingMode.TwoWay;
            fe.SetBinding(dp, b);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="destProperty"></param>
        /// <param name="src"></param>
        /// <param name="srcProperty"></param>
        /// <param name="conv"></param>
#if SILVERLIGHT
        public static void BindAttached(
            this FrameworkElement dest, DependencyProperty destProperty, 
            FrameworkElement src, DependencyProperty srcProperty,
            IValueConverter conv)
        {
            Binding b = new Binding();
            AtomNotifier am = new AtomNotifier();
            b.Source = am;
            am.Value = src.GetValue(srcProperty);
            b.Path = new PropertyPath("Value");
            b.Mode = BindingMode.TwoWay;
            src.SetBinding(srcProperty, b);
            b = new Binding();
            b.Source = am;
            b.Path = new PropertyPath("Value");
            if (conv != null)
                b.Converter = conv;
            dest.SetBinding(destProperty, b);
        }
#else
        public static void BindAttached(
            this FrameworkElement dest, DependencyProperty destProperty, 
            FrameworkElement src, DependencyProperty srcProperty,
            IValueConverter conv)
        {
            Binding b = new Binding();
            b.Source = src;
            
            b.Path = new PropertyPath(srcProperty);
            if (conv != null)
                b.Converter = conv;
            dest.SetBinding(destProperty, b);
        }

#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static Panel GetItemsHost(this ItemsControl control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }
            // Get the first live container
            DependencyObject container = control.ItemContainerGenerator.ContainerFromIndex(0);
            if (container != null)
            {
                return VisualTreeHelper.GetParent(container) as Panel;
            }

            ItemsPresenter presenter = AtomTreeWalker.FindFirstChild<ItemsPresenter>(control);
            if (presenter != null)
            {
                if(VisualTreeHelper.GetChildrenCount(presenter)>0)
                    return VisualTreeHelper.GetChild(presenter, 0) as Panel;
            }

            /*FrameworkElement rootVisual = control.GetVisualChildren().FirstOrDefault() as FrameworkElement;
            if (rootVisual != null)
            {
                ItemsPresenter presenter = rootVisual.GetLogicalDescendents().OfType<ItemsPresenter>().FirstOrDefault();
                if (presenter != null && VisualTreeHelper.GetChildrenCount(presenter) > 0)
                {
                    return VisualTreeHelper.GetChild(presenter, 0) as Panel;
                }
            }*/



            return null;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class DelegateConverter<TSrc,TDest> : IValueConverter
    {

        Func<TSrc,object, TDest> converter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="converterFunc"></param>
        public DelegateConverter(Func<TSrc,object,TDest> converterFunc)
        {
            converter = converterFunc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return converter((TSrc)value,parameter);
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }


    /// <summary>
    /// 
    /// </summary>
    public static class LambdaBinder
    {

        /// <summary>
        /// Binds Visibility to a boolean expression,
        /// <code>customerName.BindVisibility( () => customer.FirstName.Length>0 || customer.LastName.Length>0)</code>
        /// in case of runtime binding 
        /// <code>customerName.BindVisibility( () => DataContext.Property&lt;int&gt;("FirstName.Length") > 0 || DataContext.Property&lt;int&gt;("LastName.Length") > 0) </code>
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="funcExp"></param>
        public static void BindVisibility(this DependencyObject dest, Expression<Func<bool>> funcExp)
        {
            try
            {
                System.Linq.Expressions.Expression exp = System.Linq.Expressions.Expression.Condition(funcExp.Body,
                    System.Linq.Expressions.Expression.Constant(Visibility.Visible),
                    System.Linq.Expressions.Expression.Constant(Visibility.Collapsed));
                System.Linq.Expressions.Expression<Func<Visibility>> me = System.Linq.Expressions.Expression.Lambda<Func<Visibility>>(exp);
                Bind<Visibility>(dest, System.Windows.Controls.Control.VisibilityProperty, me);
            }
            catch (Exception ex)
            {
                AtomTrace.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Binds property to any expressoin that returns a type of object
        /// </summary>
        /// <param name="dest"></param>
        /// <param name="destProperty"></param>
        /// <param name="func"></param>
        public static void Bind(this DependencyObject dest, DependencyProperty destProperty, Expression<Func<object>> func)
        {
            Bind<object>(dest, destProperty, func);
        }

		public static void SafeBindVisibility(
			this DependencyObject dest,
			Func<bool> f,
			params Binding[] bindings) 
		{
			var nf = f;
			Func<object> vf = () => (nf() ? Visibility.Visible : Visibility.Collapsed);
			SafeBind(dest, FrameworkElement.VisibilityProperty, vf, bindings);
		}

		public static void SafeBind(
			this DependencyObject dest, 
			DependencyProperty destProperty,
			Func<object> f,
			params Binding[] bindings)
		{

#if SILVERLIGHT
			AtomMultiBinding b = new AtomMultiBinding();
			b.Converter = new MultiDelegateConverter<object>(f);
			foreach (var item in bindings)
			{
				b.Bindings.Add(b);
			}
			BindingOperations.SetBinding(dest, destProperty, b);
#else
			MultiBinding mb = new MultiBinding();
			mb.Converter = new MultiDelegateConverter<object>(f);
			foreach (var item in bindings)
			{
				mb.Bindings.Add(item);
			}
			BindingOperations.SetBinding(dest, destProperty, mb);
#endif

		}

        /// <summary>
        /// You can bind lambda expressions like...
        /// <code>customerName.Bind(TextBox.TextProperty, ()=> customer.FirstName + " " + customer.LastName )</code> in case 
        /// of runtime binding you can use
        /// <code>customerName.Bind(TextBox.TextProperty, ()=> string.Format("{0} {1}",DataContext.Property("FirstName"),DataContext.Property("LastName"))</code>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dest"></param>
        /// <param name="destProperty"></param>
        /// <param name="func"></param>
        public static void Bind<T>(
            this DependencyObject dest,
            DependencyProperty destProperty,
            Expression<Func<T>> func)
        {
            LambdaBindingBuilder bb = new LambdaBindingBuilder();
            bb.Visit(func.Body);

            List<Binding> bindings = bb.Bindings;
            if (bindings.Count == 1)
            {
                Binding b = bindings[0];
                b.Converter = new DelegateConverter<T>(func.Compile());
                BindingOperations.SetBinding(dest, destProperty, b);
            }
            else
            {
#if SILVERLIGHT
                AtomMultiBinding b = new AtomMultiBinding();
#else
                MultiBinding b = new MultiBinding();
#endif
                b.Converter = new MultiDelegateConverter<T>(func.Compile());
                foreach (var item in bindings)
                {
                    b.Bindings.Add(item);
                }
                BindingOperations.SetBinding(dest, destProperty, b);
            }

        }

        /// <summary>
        /// Helpful Property Expander in absence of dynamic keyword in Linq Expression.
        /// You can easily use DataContext.Property("FirstName") or DataContext.Property("Broker.FullName")
        /// to evaluate property at runtime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static object Property(this object obj, string property)
        {
            if (obj == null)
                return null;
            if (string.IsNullOrEmpty(property))
                return obj;
            return Property(obj, property.Split('.'));
        }

        /// <summary>
        /// Helpful Property Expander in absence of dynamic keyword in Linq Expression.
        /// You can easily use DataContext.Property("FirstName") or DataContext.Property("Broker.FullName")
        /// to evaluate property at runtime. This method returns object casted to specified type parameter T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public static T Property<T>(this object obj, string property)
        {
            if (obj == null)
                return default(T);
            return (T)Property(obj, property.Split('.'));
        }


        private static object Property(object obj, IEnumerable<string> properties)
        {
            foreach (var token in properties)
            {
                PropertyInfo p = obj.GetType().GetProperty(token);
                if (p == null)
                    return null;
                obj = p.GetValue(obj, null);
            }
            return obj;
        }

    }



    /// <summary>
    /// Lambda Expression Visitor to build List of Bindings
    /// </summary>
    public class LambdaBindingBuilder : ExpressionVisitor
    {
        private List<Binding> _bindings = new List<Binding>();
        /// <summary>
        /// 
        /// </summary>
        public List<Binding> Bindings
        {
            get
            {
                return _bindings;
            }
        }

        private string lastPath = null;

        private void AddBinding(object src, string path)
        {
            if (string.IsNullOrEmpty(path))
                return;

            // add binding only once, as expression may have
            // mutlple expression of same type
            if (_bindings.Any(x => x.Source == src && x.Path.Path == path))
                return;

            //AtomTrace.WriteLine("{0}:{1}",src,path);

            Binding b = new Binding(path);
            b.Source = src;
            b.Mode = BindingMode.OneWay;
            _bindings.Add(b);
            lastPath = null;
        }
#if DA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitMember(MemberExpression node)
        {
            PropertyInfo p = node.Member as PropertyInfo;
            if (p != null)
            {
                if (p.CanRead)
                {
                    MethodInfo m = p.GetGetMethod();
                    if (m.IsStatic)
                        return VisitMember(node);
                }
                if (string.IsNullOrEmpty(lastPath))
                {
                    lastPath = p.Name;
                }
                else
                {
                    lastPath = p.Name + "." + lastPath;
                }
            }
            FieldInfo f = node.Member as FieldInfo;
            if (f != null && !f.IsStatic)
            {
                AddBinding(
                    System.Linq.Expressions.Expression.Lambda<Func<object>>(node).Compile()(),
                    lastPath);
            }
            return base.VisitMember(node);
        }

        #region protected override System.Linq.Expressions.Expression  VisitTypeBinary(TypeBinaryExpression node)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitTypeBinary(TypeBinaryExpression node)
        {
            var x = base.VisitTypeBinary(node);
            if (!string.IsNullOrEmpty(lastPath))
            {
                lastPath = null;
            }
            return x;
        }
        #endregion
#else

        #region internal override System.Linq.Expressions.Expression  VisitMemberAccess(MemberExpression m)
        internal override System.Linq.Expressions.Expression VisitMemberAccess(MemberExpression node)
        {
            PropertyInfo p = node.Member as PropertyInfo;
            if (p != null)
            {
                if (p.CanRead)
                {
                    MethodInfo m = p.GetGetMethod();
                    if (m.IsStatic)
                        return base.VisitMemberAccess(node);
                }
                if (string.IsNullOrEmpty(lastPath))
                {
                    lastPath = p.Name;
                }
                else
                {
                    lastPath = p.Name + "." + lastPath;
                }
            }
            FieldInfo f = node.Member as FieldInfo;
            if (f != null && !f.IsStatic)
            {
                AddBinding(
                    System.Linq.Expressions.Expression.Lambda<Func<object>>(node).Compile()(),
                    lastPath);
            }
            return base.VisitMemberAccess(node);
        }
        #endregion


        #region internal override System.Linq.Expressions.Expression  VisitTypeIs(TypeBinaryExpression b)
        internal override System.Linq.Expressions.Expression VisitTypeIs(TypeBinaryExpression b)
        {
            System.Linq.Expressions.Expression exp = base.VisitTypeIs(b);
            if (!string.IsNullOrEmpty(lastPath))
            {
                lastPath = null;
            }
            return exp;
        }
        #endregion


#endif








        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitConstant(ConstantExpression node)
        {
            object value = node.Value;
            if (value != null)
            {
                Type valueType = value.GetType();
                if (valueType.IsEnum || valueType.IsValueType || valueType == typeof(string))
                    return base.VisitConstant(node);
            }

            if (!string.IsNullOrEmpty(lastPath))
            {
                AddBinding(
                    node.Value,
                    lastPath);
            }

            return base.VisitConstant(node);
        }




        #region protected override System.Linq.Expressions.Expression  VisitMethodCall(MethodCallExpression node)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override System.Linq.Expressions.Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.DeclaringType == typeof(LambdaBinder) && node.Method.Name == "Property")
            {
                ConstantExpression ce = node.Arguments[1] as ConstantExpression;
                if (ce != null)
                {
                    string strValue = ce.Value as string;
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        if (string.IsNullOrEmpty(lastPath))
                        {
                            lastPath = strValue;
                        }
                        else
                        {
                            lastPath = strValue + "." + lastPath;
                        }
                    }
                }

            }
            return base.VisitMethodCall(node);
        }
        #endregion

    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiDelegateConverter<T> : IMultiValueConverter
    {
        private Func<T> func;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        public MultiDelegateConverter(Func<T> func)
        {
            this.func = func;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values,
            Type targetType,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            return func();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value,
            Type[] targetTypes,
            object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Simple replacement for IValueConverter in Lambda style
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateConverter<T> : IValueConverter
    {
        private Func<T> func;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="func"></param>
        public DelegateConverter(Func<T> func)
        {
            this.func = func;
        }

        #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return func();
        }
        #endregion


        #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

#if SILVERLIGHT

    [ContentProperty("Bindings")]
    public class AtomMultiBinding : Binding
    {

        public AtomMultiBinding()
        {

            parentItem = new MultiBindingItem(this);
            this.Bindings = parentItem.Bindings;
            this.Source = parentItem;
            this.Path = new PropertyPath("Value");
        }

        private MultiBindingItem parentItem;

        public new IMultiValueConverter Converter { get; set; }


        public ICollection<Binding> Bindings { get; private set; }

    }

    internal class MultiBindingCollection : Collection<Binding>
    {
        MultiBindingItem parentItem;
        AtomMultiBinding parentBinding;

        private List<MultiBindingItem> bindingItems = new List<MultiBindingItem>();

        internal MultiBindingCollection(MultiBindingItem b, AtomMultiBinding mb)
        {
            this.parentItem = b;
            parentBinding = mb;
        }

        #region protected override void  InsertItem(int index, Binding item)
        protected override void InsertItem(int index, Binding item)
        {
            base.InsertItem(index, item);
            MultiBindingItem bitem = new MultiBindingItem(parentItem, item);
            bindingItems.Add(bitem);
            parentItem.UpdateValue();
        }
        #endregion


        #region protected override void  RemoveItem(int index)
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
            MultiBindingItem item = bindingItems[index];
            item.ClearValue(MultiBindingItem.ValueProperty);
            bindingItems.Remove(item);
            parentItem.UpdateValue();
        }
        #endregion


        #region protected override void  SetItem(int index, Binding item)
        protected override void SetItem(int index, Binding item)
        {
            base.SetItem(index, item);
            MultiBindingItem oldItem = bindingItems[index];
            oldItem.ClearValue(MultiBindingItem.ValueProperty);
            oldItem.SetBinding(item);
            parentItem.UpdateValue();
        }
        #endregion

        internal object ToValue()
        {
            List<object> values = new List<object>();
            foreach (var item in bindingItems)
            {
                values.Add(item.Value);
            }

            object[] val = values.ToArray();

            IMultiValueConverter mvc = parentBinding.Converter;
            if (mvc != null)
            {
                return mvc.Convert(val, null, null, System.Globalization.CultureInfo.CurrentCulture);
            }
            return val;
        }


    }

    public class MultiBindingItem : DependencyObject
    {
        MultiBindingItem parentItem;

        internal Binding binding;

        internal MultiBindingCollection Bindings;

        public MultiBindingItem(AtomMultiBinding b)
        {
            Bindings = new MultiBindingCollection(this, b);
        }

        public MultiBindingItem(MultiBindingItem parentItem, Binding b)
        {
            this.parentItem = parentItem;
            SetBinding(b);
        }

        internal void SetBinding(Binding b)
        {
            BindingOperations.SetBinding(this, MultiBindingItem.ValueProperty, b);
            binding = b;
        }

        ///<summary>
        ///DependencyProperty Value
        ///</summary>
        #region Dependency Property Value
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(MultiBindingItem), new PropertyMetadata(null, OnValueChangedCallback));

        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiBindingItem obj = d as MultiBindingItem;
            if (obj != null && obj.parentItem != null)
            {
                obj.parentItem.UpdateValue();
            }
        }
        #endregion

		AtomLogicContext recursion = new AtomLogicContext();

        #region private void UpdateValue()
        internal void UpdateValue()
        {
			recursion.PreventRecursive(() => {
				Value = Bindings.ToValue();
			});
        }
        #endregion



    }

    public interface IMultiValueConverter
    {
        object Convert(object[] values,
        Type targetType,
        object parameter,
        System.Globalization.CultureInfo culture);

        object[] ConvertBack(object value,
            Type[] targetTypes,
            object parameter,
            System.Globalization.CultureInfo culture);
    }

#endif
}
