#if WINRT
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NeuroSpeech.UIAtoms.UnitControls.Units.Resources;
using System.IO;
using NeuroSpeech.UIAtoms.Core;
using System.Diagnostics;
using System.Reflection.Emit;

namespace NeuroSpeech.UIAtoms.UnitControls.Units
{

    
    /// <summary>
    /// Base Measurement Unit
    /// </summary>
    public class AtomBaseUnit {

        /// <summary>
        /// SI Unit Name, Case insensitive
        /// </summary>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// SI Unit Symbol
        /// </summary>
        [XmlAttribute]
        public string Symbol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute]
        public string ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute]
        public string SubType { get; set; }

        /// <summary>
        /// Symbol (Name)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullText;
        }

        /// <summary>
        /// Symbol (Name)
        /// </summary>
        [XmlIgnore]
        public string FullText
        {
            get
            {
                if (string.IsNullOrEmpty(SubType))
                    return string.Format("{0} ({1})", Symbol, Name);
                return string.Format("{0} ({1}) ({2})", Symbol, Name, SubType);
            }
        }
    }


    /// <summary>
    /// Measurement Unit including conversions
    /// </summary>
    [XmlType(TypeName = "Unit")]
    public class AtomMeasurementUnit : AtomBaseUnit
    {
        /// <summary>
        /// Available Conversions
        /// </summary>
        public AtomDerivedUnit[] Conversions { get; set; }
    }

    /// <summary>
    /// Base Conversion Unit
    /// </summary>
    [XmlType(TypeName="Conversion")]
    public class AtomDerivedUnit : AtomBaseUnit {

        /// <summary>
        /// Factor (Double) to multiplied to Base Unit
        /// </summary>
        [XmlAttribute]
        public double Factor { get; set; }

        /// <summary>
        /// 10 raised to Factor10 multiplied to Base Unit
        /// </summary>
        [XmlAttribute]
        public int Factor10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute]
        public string FormulaFromBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute]
        public string FormulaToBase { get; set; }


        internal Func<double,double> ToBaseMethod;
        internal Func<double,double> FromBaseMethod;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual double ToBase(double value)
        {

            if (ToBaseMethod == null) {
                if (!string.IsNullOrEmpty(FormulaToBase))
                {
                    //FormulaToBase = string.Format("input*({0}*(10^{1}))", Factor, Factor10);
                    ToBaseMethod = CreateMethod(FormulaToBase);
                }
                else
                {
                    ToBaseMethod = (v) => v * (Factor*Math.Pow(10,Factor10)) ;
                }
            }

            return ToBaseMethod(value);
        }

        private Func<double, double> CreateMethod(string exp)
        {
            DynamicMethod method = SimpleEvaluator.GetAssembly(exp);
            return (Func<double,double>)method.CreateDelegate(typeof(Func<double,double>));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public virtual double FromBase(double value)
        {

            if (FromBaseMethod == null) {
                if (!string.IsNullOrEmpty(FormulaFromBase))
                {
                    //FormulaFromBase = string.Format("input/({0}*(10^{1}))",Factor,Factor10);
                    FromBaseMethod = CreateMethod(FormulaFromBase);
                }
                else { 
                    FromBaseMethod = (v)=> v /(Factor * (Math.Pow(10,Factor10)));
                }
            }

            return FromBaseMethod(value);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class AtomUnitFormula : AtomDerivedUnit {

        /// <summary>
        /// 
        /// </summary>
        public Func<double,double> ToBaseFormula { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Func<double,double> FromBaseFormula { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override double ToBase(double value)
        {
            return ToBaseFormula(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override double FromBase(double value)
        {
            return FromBaseFormula(value);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomUnitConverter {

        private static Dictionary<string, AtomUnitConverter> Converters = new Dictionary<string, AtomUnitConverter>();

        /// <summary>
        /// Unit
        /// </summary>
        public AtomMeasurementUnit MeasurementUnit { get; set; }

        private AtomUnitConverter(string name, string xml)
        {

            /*switch (name)
            {
                case "Temperature":
                    MeasurementUnit = new Temperature();
                    break;
                default:
                    break;
            }*/

            if (MeasurementUnit == null)
            {

                XmlSerializer xs = new XmlSerializer(typeof(AtomMeasurementUnit));
                using (StringReader sr = new StringReader(xml))
                {
                    MeasurementUnit = xs.Deserialize(sr) as AtomMeasurementUnit;
                }
            }
        }

        /// <summary>
        /// Load Cached Converter from Resource
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static AtomUnitConverter GetConverterFromResource(string name) {

            AtomUnitConverter c = null;
            if (Converters.TryGetValue(name, out c)) {
                return c;
            }
            c = new AtomUnitConverter(name, ConversionResource.ResourceManager.GetString(name));
            Converters[name] = c;
            return c;
        }


        private List<string> _UnitNames = null;

        /// <summary>
        /// Available Unit Names...
        /// </summary>
        public List<string> UnitNames {
            get {
                if (_UnitNames == null)
                {
                    List<string> names = new List<string>();
                    foreach (AtomBaseUnit unit in AvailableUnits)
                    {
                        names.Add(unit.Name);
                    }
                    _UnitNames = names;
                }
                return _UnitNames;
            }
        }

        private List<AtomBaseUnit> _AvailableUnits = null;

        /// <summary>
        /// 
        /// </summary>
        public List<AtomBaseUnit> AvailableUnits {
            get {
                if (_AvailableUnits == null) {
                    List<AtomBaseUnit> units = new List<AtomBaseUnit>();
                    units.Add((AtomBaseUnit)MeasurementUnit);
                    units.AddRange(MeasurementUnit.Conversions);
                    _AvailableUnits = units;
                }
                return _AvailableUnits;
            }
        }


        internal double ConvertFrom(double src, string srcUnit, string destUnit)
        {
            double dest = src;

            // if same, dont convert...
            if (srcUnit == destUnit)
                return dest;

            dest = ToBase(src, srcUnit);
            dest = FromBase(dest, destUnit);
            return dest;
        }

        private double FromBase(double baseValue, string destUnit)
        {
            double result = baseValue;
            if (destUnit == MeasurementUnit.ID)
                return result;

            AtomDerivedUnit d = GetUnit(destUnit);
            result = d.FromBase(result);

            return result;
        }

        private AtomDerivedUnit GetUnit(string name)
        {
            AtomDerivedUnit d = MeasurementUnit.Conversions.FirstOrDefault(x => x.ID == name);
            if (d == null)
                throw new InvalidOperationException("Invalid Unit " + name);

            return d;
        }

        private double ToBase(double src, string srcUnit)
        {
            double result = src;
            if (srcUnit == MeasurementUnit.ID)
                return result;

            AtomDerivedUnit d = GetUnit(srcUnit);
            result = d.ToBase(result);
            return result;
        }

        /// <summary>
        /// Returns IValueConverter for available units and types
        /// </summary>
        /// <param name="unit">SI Name of Unit, Length, Temperature etc</param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static IValueConverter GetConverter(string unit,  string from, string to) {
            return new UnitConverter(unit, from, to);
        }

        internal class UnitConverter : IValueConverter
        {
            internal string From { get; set; }
            internal string To { get; set; }

            internal string Unit { get; set; }

            private AtomUnitConverter Converter;

            internal UnitConverter(string unit, string from, string to)
            {
                Converter = AtomUnitConverter.GetConverterFromResource(unit);
                Unit = unit;
                From = from;
                To = to;
            }


            object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                double val = Converter.ConvertFrom( (double)System.Convert.ChangeType(value,typeof(double),null), From, To);
                return System.Convert.ChangeType(val, targetType,null);
            }

            object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                double val = Converter.ConvertFrom((double)System.Convert.ChangeType(value, typeof(double),null), To, From);
                return System.Convert.ChangeType(val, targetType,null);
            }
        }


        internal static AtomBaseUnit GetUnit(string unitName, string id)
        {
            if (string.IsNullOrEmpty(unitName))
                return null;
            if (string.IsNullOrEmpty(id))
                return null;
            AtomUnitConverter uc = GetConverterFromResource(unitName);
            if (uc.MeasurementUnit.ID == id)
                return uc.MeasurementUnit;
            return uc.AvailableUnits.FirstOrDefault(x => x.ID == id);
        }
    }
}
