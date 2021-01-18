#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NeuroSpeech.UIAtoms.Controls;
using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.UnitControls.Units;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.UnitControls
{
    /// <summary>
    /// Base class for Measurement Unit Editor Control
    /// </summary>

    [TemplatePart(Name = "PART_Display", Type = typeof(AtomDoubleTextBox))]
    [TemplatePart(Name = "PART_DisplayUnit", Type = typeof(AtomComboBox))]
    [AtomDesign(
        DisplayInToolbox=false
        )]
    public abstract class AtomEditorConverter : Control
    {

#if SILVERLIGHT
        public AtomEditorConverter()
        {
            DefaultStyleKey = typeof(AtomEditorConverter);
            _UnitConverter = LoadConverter();
        }
#else

        /// <summary>
        /// 
        /// </summary>
        public AtomEditorConverter()
        {
            _UnitConverter = LoadConverter();
        }


        static AtomEditorConverter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomEditorConverter), new FrameworkPropertyMetadata(typeof(AtomEditorConverter)));
        }
#endif



        AtomUnitConverter _UnitConverter = null;

        /// <summary>
        /// 
        /// </summary>
        public AtomUnitConverter UnitConverter {
            get {
                if (_UnitConverter == null) {
                    _UnitConverter = CreateUnitConverter();
                }
                return _UnitConverter;
            }
        }

        private AtomUnitConverter LoadConverter()
        {
            AtomUnitConverter converter = CreateUnitConverter();
            this.DisplayUnitID = converter.MeasurementUnit.ID;
            this.ValueUnitID = converter.MeasurementUnit.ID;
            return converter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual AtomUnitConverter CreateUnitConverter()
        {
            return AtomUnitConverter.GetConverterFromResource(UnitName);
        }


        /// <summary>
        /// Name of the Measurement Unit. Length, Velocity, Temperature etc.
        /// </summary>
        public virtual string UnitName {
            get {
                throw new NotImplementedException();
            }
        }
         
        /// <summary>
        /// Available units for conversion.
        /// </summary>
        public List<AtomBaseUnit> AvailableUnits
        {
            get {
                return UnitConverter.AvailableUnits;
            }
        }

        /// <summary>
        /// List of available unit IDs
        /// </summary>
        public List<string> AvailableUnitNames 
        {
            get {
                return UnitConverter.UnitNames;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected AtomDoubleTextBox PART_Display;

        /// <summary>
        /// 
        /// </summary>
        protected AtomComboBox PART_DisplayUnit;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            PART_Display = GetTemplateChild("PART_Display") as AtomDoubleTextBox;
            PART_DisplayUnit = GetTemplateChild("PART_DisplayUnit") as AtomComboBox;
            //PART_DisplayUnit.DisplayMemberPath = "FullText";
            PART_DisplayUnit.SelectedValuePath = "ID";


            PART_DisplayUnit.ItemsSource = AvailableUnits;

            Binding b = new Binding();
            b.Path = new PropertyPath("DisplayValue");
            b.Source = this;
            b.Mode = BindingMode.TwoWay;
            PART_Display.SetBinding(AtomDoubleTextBox.ValueProperty, b);

            b = new Binding();
            b.Path = new PropertyPath("DisplayUnitID");
            b.Mode = BindingMode.TwoWay;
            b.Source = this;
            PART_DisplayUnit.SetBinding(AtomComboBox.SelectedValueProperty, b);

        }


        ///<summary>
        ///Value should be used for databinding and the ValueUnit will be defaulted to SI unit.
        ///Whenever you edit the displayed value, control will convert the number to "ValueUnit"
        ///</summary>
        #region Dependency Property Value
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty ValueProperty = 
    DependencyProperty.Register("Value", typeof(double), typeof(AtomEditorConverter), new PropertyMetadata((double)0,OnValueChangedCallback));
#else
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(AtomEditorConverter), new FrameworkPropertyMetadata((double)0, OnValueChangedCallback));
#endif

        private static void OnValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomEditorConverter obj = d as AtomEditorConverter;
            if (obj != null)
            {
                obj.OnValueChanged(e);
            }
        }

        private AtomLogicContext valueContext = new AtomLogicContext();

        /// <summary>
        /// Fires ValueChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {

            // Change Value..

            RefreshDisplayValue();

            if (ValueChanged != null)
            {
                ValueChanged(this, EventArgs.Empty);
            }
        }

        private void RefreshDisplayValue()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            valueContext.PreventRecursive(() =>
            {
                DisplayValue = UnitConverter.ConvertFrom(Value, ValueUnitID, DisplayUnitID);

            });
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler ValueChanged;

        #endregion




        ///<summary>
        ///Unit ID of "Value" field, this is the unit of value.
        ///</summary>
        #region Dependency Property ValueUnitID
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default,
          RegisterUnitControl=true
        )]
        public string ValueUnitID
        {
            get { return (string)GetValue(ValueUnitIDProperty); }
            set { SetValue(ValueUnitIDProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ValueUnit.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty ValueUnitIDProperty = 
    DependencyProperty.Register("ValueUnit", typeof(string), typeof(AtomEditorConverter), new PropertyMetadata("",OnValueUnitIDChangedCallback));
#else
        public static readonly DependencyProperty ValueUnitIDProperty =
            DependencyProperty.Register("ValueUnit", typeof(string), typeof(AtomEditorConverter), new FrameworkPropertyMetadata("", OnValueUnitIDChangedCallback));
#endif

        private static void OnValueUnitIDChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomEditorConverter obj = d as AtomEditorConverter;
            if (obj != null)
            {
                obj.OnValueUnitIDChanged(e);
            }
        }

        /// <summary>
        /// Fires ValueUnitChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnValueUnitIDChanged(DependencyPropertyChangedEventArgs e)
        {

            // change value...
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            if (IsValid(e.OldValue) && IsValid(e.NewValue))
                this.Value = UnitConverter.ConvertFrom(this.Value, (string)e.OldValue, (string)e.NewValue);

            if (ValueUnitIDChanged != null)
            {
                ValueUnitIDChanged(this, EventArgs.Empty);
            }
        }

        private bool IsValid(object p)
        {
            string v = p as string;
            return !string.IsNullOrEmpty(v);
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler ValueUnitIDChanged;

        #endregion


        ///<summary>
        ///Display value can not be used for databinding, it is the editor's text value.
        ///You can change "DisplayUnit" to enter/view value in desired in unit
        ///</summary>
        #region Dependency Property DisplayValue
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public double DisplayValue
        {
            get { return (double)GetValue(DisplayValueProperty); }
            set { SetValue(DisplayValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for DisplayValue.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty DisplayValueProperty = 
    DependencyProperty.Register("DisplayValue", typeof(double), typeof(AtomEditorConverter), new PropertyMetadata((double)0,OnDisplayValueChangedCallback));
#else
        public static readonly DependencyProperty DisplayValueProperty =
            DependencyProperty.Register("DisplayValue", typeof(double), typeof(AtomEditorConverter), new FrameworkPropertyMetadata((double)0, OnDisplayValueChangedCallback));
#endif

        private static void OnDisplayValueChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomEditorConverter obj = d as AtomEditorConverter;
            if (obj != null)
            {
                obj.OnDisplayValueChanged(e);
            }
        }

        /// <summary>
        /// Fires DisplayValueChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDisplayValueChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshValue();

            if (DisplayValueChanged != null)
            {
                DisplayValueChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler DisplayValueChanged;


        private void RefreshValue()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            valueContext.PreventRecursive(() =>
            {
                Value = UnitConverter.ConvertFrom(DisplayValue, DisplayUnitID, ValueUnitID);
            });
        }

        #endregion




        ///<summary>
        ///Display value can not be used for databinding, it is the editor's text value.
        ///You can change "DisplayUnit" to enter/view value in desired in unit
        ///</summary>
        #region Dependency Property DisplayUnitID
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default,
          RegisterUnitControl = true)]
        public string DisplayUnitID
        {
            get { return (string)GetValue(DisplayUnitIDProperty); }
            set { SetValue(DisplayUnitIDProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for DisplayUnit.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty DisplayUnitIDProperty = 
    DependencyProperty.Register("DisplayUnitID", typeof(string), typeof(AtomEditorConverter), new PropertyMetadata("",OnDisplayUnitIDChangedCallback));
#else
        public static readonly DependencyProperty DisplayUnitIDProperty =
            DependencyProperty.Register("DisplayUnitID", typeof(string), typeof(AtomEditorConverter), new FrameworkPropertyMetadata("", OnDisplayUnitIDChangedCallback));
#endif

        private static void OnDisplayUnitIDChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomEditorConverter obj = d as AtomEditorConverter;
            if (obj != null)
            {
                obj.OnDisplayUnitIDChanged(e);
            }
        }

        /// <summary>
        /// Fires DisplayUnitChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnDisplayUnitIDChanged(DependencyPropertyChangedEventArgs e)
        {
            if (IsValid(e.OldValue) && IsValid(e.NewValue))
                RefreshDisplayValue();


            if (DisplayUnitIDChanged != null)
            {
                DisplayUnitIDChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler DisplayUnitIDChanged;

        #endregion

    }
}
