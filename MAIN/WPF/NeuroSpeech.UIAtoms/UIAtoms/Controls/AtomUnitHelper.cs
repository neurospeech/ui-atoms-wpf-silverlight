#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Documents;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Documents;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.UnitControls.Units;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class AtomUnitHelper
    {



        #region Attached Dependency Property UnitName
        ///<summary>
        ///Get Attached Property Unit for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static string GetUnitName(DependencyObject obj)
        {
            return (string)obj.GetValue(UnitNameProperty);
        }

        ///<summary>
        ///Set Attached Property Unit for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetUnitName(DependencyObject obj, string value)
        {
            obj.SetValue(UnitNameProperty, value);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Unit.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.RegisterAttached("UnitName", typeof(string), typeof(AtomUnitHelper), new PropertyMetadata("Length"));
#else
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.RegisterAttached("UnitName", typeof(string), typeof(AtomUnitHelper), new UIPropertyMetadata("Length"));
#endif
        #endregion

        #region Attached Dependency Property UnitIDForSymbol
        ///<summary>
        ///Get Attached Property UnitIDForSymbol for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static string GetUnitIDForSymbol(DependencyObject obj)
        {
            return (string)obj.GetValue(UnitIDForSymbolProperty);
        }

        ///<summary>
        ///Set Attached Property UnitIDForSymbol for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetUnitIDForSymbol(DependencyObject obj, string value)
        {
            obj.SetValue(UnitIDForSymbolProperty, value);

            TextBlock tb = obj as TextBlock;
            if (tb == null)
                return;
            tb.Inlines.Clear();

            string unitName = GetUnitName(obj);
            AtomBaseUnit unit = AtomUnitConverter.GetUnit(unitName,value);
            if(unit!=null)
                SetDisplayText(unit.Symbol, tb);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for UnitIDForSymbol.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty UnitIDForSymbolProperty =
            DependencyProperty.RegisterAttached("UnitIDForSymbol", typeof(string), typeof(AtomUnitHelper), new PropertyMetadata(""));
#else
        public static readonly DependencyProperty UnitIDForSymbolProperty =
            DependencyProperty.RegisterAttached("UnitIDForSymbol", typeof(string), typeof(AtomUnitHelper), new UIPropertyMetadata(""));
#endif

        #endregion

        #region Attached Dependency Property UnitIDForSubType
        ///<summary>
        ///Get Attached Property UnitIDForSubType for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.ComponentModel.Category("Atoms")]
        public static string GetUnitIDForSubType(DependencyObject obj)
        {
            return (string)obj.GetValue(UnitIDForSubTypeProperty);
        }

        ///<summary>
        ///Set Attached Property UnitIDForSubType for DependencyObject
        ///</summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetUnitIDForSubType(DependencyObject obj, string value)
        {
            obj.SetValue(UnitIDForSubTypeProperty, value);
            TextBlock tb = obj as TextBlock;
            if (tb == null)
                return;
            tb.Inlines.Clear();

            string unitName = GetUnitName(obj);
            AtomBaseUnit unit = AtomUnitConverter.GetUnit(unitName, value);
            if(unit!=null)
                SetDisplayText(unit.SubType, tb);
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for UnitIDForSubType.  This enables animation, styling, binding, etc...
        ///</summary>
        
#if SILVERLIGHT
        public static readonly DependencyProperty UnitIDForSubTypeProperty =
            DependencyProperty.RegisterAttached("UnitIDForSubType", typeof(string), typeof(AtomUnitHelper), new PropertyMetadata(""));
#else
        public static readonly DependencyProperty UnitIDForSubTypeProperty =
            DependencyProperty.RegisterAttached("UnitIDForSubType", typeof(string), typeof(AtomUnitHelper), new UIPropertyMetadata(""));
#endif
        #endregion




        private static void SetDisplayText(string value, TextBlock tb)
        {
            // set value...
            try
            {
                if (value.StartsWith("<"))
                {
#if SILVERLIGHT
                    Section s = XamlReader.Load(value) as Section;
                    Paragraph p = s.Blocks.FirstOrDefault() as Paragraph;
#else
                    Section s = (Section)XamlReader.Parse(value);
                    Paragraph p = s.Blocks.FirstBlock as Paragraph;
#endif
                    if (p != null)
                    {
                        foreach (Inline i in p.Inlines.ToArray())
                        {
                            tb.Inlines.Add(i);
                        }
                    }
                }

            }
            catch { }

            tb.Text = value;
        }

    }


}
