using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.IO;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class WidthControl : Control
    {

        private static readonly string template = 
"<ControlTemplate " 
+"            xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'"
+"            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'"
+ "    xmlns:local='clr-namespace:NeuroSpeech.UIAtoms.Designers.Form.Designer;assembly=NeuroSpeech.UIAtoms.Designers'"
+ "    TargetType='{x:Type local:WidthControl}'"
+"             >"
+"    <Grid Margin='2'>"
+"        <Grid.ColumnDefinitions>"
+"            <ColumnDefinition Width='Auto'/>"
//+"            <ColumnDefinition Width='5'/>"
+"            <ColumnDefinition/>"
+"        </Grid.ColumnDefinitions>"
+"        <CheckBox VerticalAlignment='Center' Content='Full Width' x:Name='PART_CB'/>"
//+"        <TextBlock Grid.Column='1'>:</TextBlock>"
+"        <TextBox x:Name='PART_TB' Grid.Column='1'/>"
+"    </Grid>"
+"</ControlTemplate>"  ;

        public WidthControl()
        {

            string t = template;

#if DesignSL
            t = t.Replace("NeuroSpeech.UIAtoms.Designers.Form.Designer", "NeuroSpeech.UIAtoms.Silverlight.VisualStudio.Design");
#endif

            MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(t));
            this.Template = XamlReader.Load(ms) as ControlTemplate;

        }


        private TextBox tb;
        private CheckBox cb;

        #region public override void  OnApplyTemplate()
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            tb = GetTemplateChild("PART_TB") as TextBox;
            cb = GetTemplateChild("PART_CB") as CheckBox;

            // setup bindings...

            cb.Checked += new RoutedEventHandler(cb_Checked);
            SetBinding(tb, TextBox.IsEnabledProperty, cb, "IsChecked", false, new InverseBooleanConverter());
            SetBinding(tb, TextBox.TextProperty, this, "Value", true, null);
            //cb.Unchecked += new RoutedEventHandler(cb_Checked);
            SetCBValue();
        }

        #region void  cb_Checked(object sender, RoutedEventArgs e)
        void cb_Checked(object sender, RoutedEventArgs e)
        {
            ProcessOneTime(ref IsValueChanging, () => {
                this.Value = double.NaN;
            });
        }
        #endregion

        #endregion


        class InverseBooleanConverter : IValueConverter {
            #region public object  Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                bool val = (bool)value;
                return !val;
            }
            #endregion


            #region public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            #endregion

        }



        private bool IsValueChanging = false;

        ///<summary>
        ///DependencyProperty Value
        ///</summary>
        #region Dependency Property Value
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(WidthControl), new FrameworkPropertyMetadata(0D, OnValueChangedCallback));

        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            WidthControl obj = d as WidthControl;
            if (obj != null)
            {
                obj.OnValueChanged(e);
            }
        }

        /// <summary>
        /// Fires ValueChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {
            ProcessOneTime(ref IsValueChanging, () => {
                SetCBValue();
            });
            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

        #region private void SetCBValue(double p)
        private void SetCBValue()
        {
            double v = Value;
            if(cb!=null)
                cb.IsChecked = double.IsNaN(v);
        }
        #endregion


        ///<summary>
        ///
        ///</summary>
        public event EventHandler ValueChanged;

        #endregion



        private void SetBinding(DependencyObject dest, DependencyProperty destProperty, object src, string srcPath, bool twoWay, IValueConverter cnv) {
            Binding b = new Binding(srcPath);
            b.Source = src;
            b.Mode = twoWay ? BindingMode.TwoWay : BindingMode.OneWay;
            b.Converter = cnv;
            BindingOperations.SetBinding(dest, destProperty, b);
        }


        public static void ProcessOneTime(
            ref bool isChanging,
            Action vh)
        {
            if (isChanging)
                return;
            isChanging = true;
            try
            {
                vh();
            }
            finally
            {
                isChanging = false;
            }

        }



    }
}
