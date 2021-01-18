#if NETFX_CORE
using Windows.UI.Xaml.Media;
#else
using System.Windows.Media;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class AtomCodeFormatterXML : AtomCodeFormatter
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override IEnumerable<AtomCodePart> GetCodeParts(string code)
        {
            List<AtomCodePart> parts = new List<AtomCodePart>();

            

            StringReader sr = new StringReader(code);
            XmlReader reader = XmlReader.Create(sr);
            

            while (reader.Read()) 
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.CDATA:
                        parts.Add(new AtomCodePart { Text = reader.Value, Style = Text, Part = "CDATA" });
                        break;
                    case XmlNodeType.Comment:
                        parts.Add(new AtomCodePart { Text = "<!-- " + reader.Value + " -->", Style = Comments, Part = "Comments" });
                        break;
                    case XmlNodeType.DocumentType:
                        parts.Add(new AtomCodePart { Text = reader.Value, Style = Comments, Part = "DocumentType" });
                        break;
                    case XmlNodeType.Element:
                        ProcessNode(reader, parts);
                        break;
                    case XmlNodeType.EndElement:
                        parts.Add(new AtomCodePart { Text = "</" + reader.Name + ">", Style = TagName, Part = "EndElement" });
                        break;
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        parts.Add(new AtomCodePart { Text = "<SW>", Style = TagName, Part = "SignificantWhitespace" });
                        break;
                    case XmlNodeType.Text:
                        parts.Add(new AtomCodePart { Text = reader.Value, Style = Text, Part = "Text" });
                        break;
                    case XmlNodeType.Whitespace:
                        AddWhiteSpace(parts, reader);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        parts.Add(new AtomCodePart { Text = "<?" + reader.Value + ">", Style = Text, Part = "XmlDeclaration" });
                        break;
                    default:
                        break;
                }
            }

            return parts;
        }

        private static void AddWhiteSpace(List<AtomCodePart> parts, XmlReader reader)
        {
            /*if (reader.Value.Contains("\r\n")) {
                parts.Add(new AtomCodePart { NewLine = true });
                return;
            }*/
            parts.Add(new AtomCodePart { Text = reader.Value, Style = Text, Part = "Whitespace" });
        }

        private void ProcessNode(XmlReader reader, List<AtomCodePart> parts)
        {
            IXmlLineInfo lineInfo = (IXmlLineInfo)reader;
            int line = lineInfo.LineNumber;

            bool emptyTag = reader.IsEmptyElement;

            parts.Add(new AtomCodePart { Text = "<", Part = "<", Style = TagName });
            parts.Add(new AtomCodePart { Text = reader.Name, Part = "TagName", Style = TagName });


            if (reader.MoveToFirstAttribute())
            {
                if (line != lineInfo.LineNumber)
                {
                    parts.Add(new AtomCodePart { NewLine = true });
                    parts.Add(new AtomCodePart { Text = new string(' ', lineInfo.LinePosition) });
                    line = lineInfo.LineNumber;
                }

                parts.Add(new AtomCodePart { Text = " ", Part = "Whitespace", Style = Text });
                parts.Add(new AtomCodePart { Text = reader.Name, Part = "Whitespace", Style = AttributeName });
                parts.Add(new AtomCodePart { Text = "=", Part = "Whitespace", Style = Text });
                parts.Add(new AtomCodePart { Text = "\"", Part = "Whitespace", Style = AttributeValue });
                parts.Add(new AtomCodePart { Text = reader.Value , Part = "AttributeValue", Style = AttributeValue});
                parts.Add(new AtomCodePart { Text = "\"", Part = "Whitespace", Style = AttributeValue });

                while (reader.MoveToNextAttribute())
                {
                    if (line != lineInfo.LineNumber)
                    {
                        parts.Add(new AtomCodePart { NewLine = true });
                        parts.Add(new AtomCodePart { Text = new string(' ', lineInfo.LinePosition) });
                        line = lineInfo.LineNumber;
                    }

                    parts.Add(new AtomCodePart { Text = " ", Part = "Whitespace", Style = Text });
                    parts.Add(new AtomCodePart { Text = reader.Name, Part = "Whitespace", Style = AttributeName });
                    parts.Add(new AtomCodePart { Text = "=", Part = "Whitespace", Style = Text });
                    parts.Add(new AtomCodePart { Text = "\"", Part = "Whitespace", Style = AttributeValue });
                    parts.Add(new AtomCodePart { Text = reader.Value, Part = "AttributeValue", Style = AttributeValue });
                    parts.Add(new AtomCodePart { Text = "\"", Part = "Whitespace", Style = AttributeValue });

                }
            }

            if (emptyTag)
                parts.Add(new AtomCodePart { Text = "/>", Part = "/>", Style = TagName });
            else
                parts.Add(new AtomCodePart { Text = ">", Part = ">", Style = TagName });
            
        }


        private static AtomCodeStyle TagName = new AtomCodeStyle {Foreground = new SolidColorBrush(Color.FromArgb(0xff,0x80,0,0))};
        private static AtomCodeStyle AttributeName = new AtomCodeStyle {Foreground= new SolidColorBrush(Color.FromArgb(0xff,0xff,0,0)) };
        private static AtomCodeStyle AttributeValue = new AtomCodeStyle { Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0, 0, 0xff)) };
        private static AtomCodeStyle Text = new AtomCodeStyle { Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0, 0, 0)) };
        private static AtomCodeStyle Comments = new AtomCodeStyle { Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0x80, 0x80, 0x80)) };

    }
}
