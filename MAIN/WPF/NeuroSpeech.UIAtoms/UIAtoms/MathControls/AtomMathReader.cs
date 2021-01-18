#if WINRT
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using System.Xml.Linq;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.MathControls
{

    internal class MathType
    {

        private Dictionary<string, PropertyInfo> Properties = new Dictionary<string, PropertyInfo>();

        internal MathType(string name, Type type)
        {
            Type = type;

            foreach (PropertyInfo p in type.GetProperties())
            {
                XmlAttributeAttribute[] atts = (XmlAttributeAttribute[])p.GetCustomAttributes(typeof(XmlAttributeAttribute), true);
                if (atts != null)
                {
                    XmlAttributeAttribute at = atts.FirstOrDefault();
                    if (at != null)
                    {
                        Properties[at.AttributeName] = p;
                        Properties[name + "." + at.AttributeName] = p;
                    }
                }
                Properties[p.Name] = p;
            }
        }

        internal Type Type;

        internal object NewObject()
        {
            return Activator.CreateInstance(Type);
        }

        internal PropertyInfo GetProperty(string p)
        {
            return Properties[p];
        }

    }


    /// <summary>
    /// 
    /// </summary>
    public enum AtomMathLanguage { 
        /// <summary>
        /// 
        /// </summary>
        TeX,
        /// <summary>
        /// 
        /// </summary>
        MathXML,
        /// <summary>
        /// 
        /// </summary>
        MathML
    }


    /// <summary>
    /// 
    /// </summary>
    public class AtomMathReader
    {

        private static Dictionary<string, MathType> _Types = null;
        internal static Dictionary<string, MathType> MathTypes
        {
            get
            {
                if (_Types == null)
                {
                    Dictionary<string, MathType> types = new Dictionary<string, MathType>();

                    /*types["m:eqn"] = new MathType("m:eqn", typeof(MathEquation));
                    types["m:e"] = new MathType("m:e", typeof(MathExp));
                    types["m:f"] = new MathType("m:f", typeof(MathFraction));
                    types["m:rt"] = new MathType("m:rt", typeof(MathSqrt));
                    types["m:b"] = new MathType("m:b", typeof(MathBrackets));
                    types["m:sym"] = new MathType("m:sym",typeof(MathSymbol));*/

                    foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
                    {
                        if (t.IsSubclassOf(typeof(Control)))
                        {
                            AddType(types, t);
                        }
                    }

                    _Types = types;
                }
                return _Types;
            }
        }

        private static void AddType(Dictionary<string, MathType> types, Type t)
        {
            XmlAliasAttribute[] ats = (XmlAliasAttribute[])t.GetCustomAttributes(typeof(XmlAliasAttribute), true);
            if (ats != null && ats.Length > 0)
            {
                XmlAliasAttribute a = ats[0];
                string name = a.Alias;
                types[name] = new MathType(name, t);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static object Load(string text , AtomMathLanguage lang)
        {
            try
            {
                switch (lang)
                {
                    case AtomMathLanguage.TeX:
                        return AtomMathTeXParser.Load(text);
                    case AtomMathLanguage.MathXML:
                        return ParseXml("<!DOCTYPE mathDoc [ <!ENTITY m \"MAX\"> <!ENTITY m.y \"MAX\"> ]><m:eqn xmlns:m='http://uiatoms.neurospeech.com/math'>" + text + "</m:eqn>");
                    case AtomMathLanguage.MathML:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                AtomTrace.WriteLine(ex.ToString());
            }
            return "";
        }

        private static object ParseXml(string text)
        {

            XDocument doc = XDocument.Parse(text);
            //NavigateElement(doc.DocumentElement, 0);
            return CreateElement(doc.Root);
        }

        private static object CreateElement(XElement e)
        {

            MathType type = MathTypes[e.Name.LocalName];

            object obj = type.NewObject();

            List<XObject> attributes = GetChildren(e, true);

            if (!(obj is AtomMathEquation))
            {
                SetProperties(obj, type, attributes);
            }


            List<XObject> children = GetChildren(e, false);

            // only one child??? and it is xmltext?
            if (children.Count == 1)
            {
                // add or set content...

                XText text = children[0] as XText;
                if (text != null)
                {
                    return SetChildText(obj, text);
                }

            }

            ItemsControl ic = null;

            if (obj is ContentControl)
            {
                ContentControl cc = obj as ContentControl;
                ic = new AtomMathEquation();
                cc.Content = ic;
            }
            else if (obj is ItemsControl)
            {
                ic = obj as ItemsControl;
            }
            else
            {
                throw new NotSupportedException();
            }

            foreach (XNode node in children)
            {
                if (node is XElement)
                {
                    ic.Items.Add(CreateElement(node as XElement));
                }
                else if (node is XText)
                {
                    TextBlock tb = new TextBlock();
                    tb.Text = (node as XText).Value;
                    ic.Items.Add(tb);
                }
            }

            // has multiple controls???
            return obj;
        }

        private static List<XObject> GetChildren(XElement e, bool attribute)
        {
            List<XObject> nodes = new List<XObject>();

            if (attribute)
            {
                foreach (XAttribute a in e.Attributes())
                {
                    nodes.Add(a);
                }
            }

            foreach (XNode node in e.Nodes())
            {
                XElement en = node as XElement;
                if (en != null && en.Name.LocalName.StartsWith(e.Name.LocalName + "."))
                {
                    if (attribute)
                        nodes.Add(node);
                }
                else
                {
                    if (!attribute)
                        nodes.Add(node);
                }
            }

            return nodes;
        }

        private static void SetProperties(object obj, MathType type, List<XObject> attributes)
        {
            foreach (XObject a in attributes)
            {
                if (a is XAttribute)
                {
                    XAttribute x = a as XAttribute;
                    string name = x.Name.LocalName;
                    PropertyInfo p = type.GetProperty(name);
                    p.SetValue(obj, x.Value, null);
                }
                else if (a is XElement)
                {
                    XElement c = a as XElement;
                    string name = c.Name.LocalName;
                    PropertyInfo p = type.GetProperty(name);
                    p.SetValue(obj, CreateChildren((a as XElement).Nodes()), null);

                }
            }
        }

        private static object CreateChildren(IEnumerable<XNode> nodes)
        {
            if (nodes.Count() == 0)
                return null;

            if (nodes.Count() == 1)
            {
                XText text = nodes.First() as XText;
                if (text != null)
                    return text.Value;
                XElement e = nodes.First() as XElement;
                if (e != null)
                    return CreateElement(e);
            }

            AtomMathEquation eq = new AtomMathEquation();

            foreach (XNode node in nodes)
            {
                XText text = node as XText;
                if (text != null)
                    eq.Items.Add(GetText(text.Value));
                XElement e = node as XElement;
                if (e != null)
                    eq.Items.Add(CreateElement(e));
            }

            return eq;
        }

        private static TextBlock GetText(string text)
        {
            TextBlock tb = new TextBlock();
            tb.Text = text;
            return tb;
        }

        private static object SetChildText(object obj, XText text)
        {
            ContentControl cc = obj as ContentControl;
            if (cc != null)
            {
                cc.Content = text.Value;
                return cc;
            }

            AtomMathEquation ic = obj as AtomMathEquation;
            if (ic != null)
            {

                ic.Items.Add(GetText(text.Value));
                return ic;
            }

            AtomMathPanel panel = obj as AtomMathPanel;
            if (panel != null)
            {
                panel.Children.Add(GetText(text.Value));
                return panel;
            }
            return null;
        }

        private static void NavigateElement(XElement e, int depth)
        {
            AtomTrace.WriteLine(new String(' ', depth * 5) + e.Name);
            foreach (XNode child in e.Nodes())
            {
                if (child is XElement)
                    NavigateElement(child as XElement, depth + 1);
                else if (child is XText)
                {
                    AtomTrace.WriteLine("#text=" + (child as XText).Value);
                }
                else
                {
                    AtomTrace.WriteLine((child as XElement).Name.LocalName + ":" + child.NodeType.ToString());
                }
            }
        }

    }
}
