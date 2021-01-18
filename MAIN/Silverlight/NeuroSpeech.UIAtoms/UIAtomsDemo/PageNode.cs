using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace UIAtomsDemo
{
    public class PageNode
    {

        public PageNode()
        {
            Source = "";
            DescriptionSource = "";
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Source { get; set; }

        [XmlAttribute]
        public string Introduction { get; set; }

        [XmlAttribute]
        public string DescriptionSource { get; set; }

        [XmlAttribute]
        public string XAMLName { get; set; }

        [XmlAttribute]
        public bool HasChildren { get; set; }

        public string XAMLSource
        {
            get
            {
                if (string.IsNullOrWhiteSpace(XAMLName))
                    return "";
                try
                {
                    return SourceResources.ResourceManager.GetString(XAMLName);
                }
                catch { }
                return "";
            }
        }

        public string CSSource
        {
            get
            {
                if (string.IsNullOrWhiteSpace(XAMLName))
                    return "";
                try
                {
                    return SourceResources.ResourceManager.GetString(XAMLName + "_xaml");
                }
                catch { }
                return "";
            }
        }

        public PageNode[] Children { get; set; }

        [XmlIgnore]
        public static PageNode[] RootPages
        {

            get
            {

                PageNode rootPage = null;
                XmlSerializer xs = new XmlSerializer(typeof(PageNode));
                rootPage = xs.Deserialize(new StringReader(SourceResources.Samples)) as PageNode;
                return rootPage.Children;
            }

        }
    }
}
