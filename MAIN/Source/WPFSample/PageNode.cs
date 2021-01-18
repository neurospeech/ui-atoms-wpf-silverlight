using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using UIAtoms.WPFSamples.Properties;

namespace UIAtoms.WPFSamples
{
    public class PageNode
    {
        public PageNode()
        {

        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string Source { get; set; }

        [XmlAttribute]
        public string XAMLName { get; set; }

        [XmlAttribute]
        public string Introduction { get; set; }

        [XmlAttribute]
        public string DescriptionSource { get; set; }

        [XmlIgnore]
        public string CSSource
        {
            get
            {
                try
                {
                    return Resources.ResourceManager.GetString(XAMLName + "_xaml");
                }
                catch
                {
                    return null;
                }
            }
        }

        [XmlIgnore]
        public string XAMLSource
        {
            get
            {
                try
                {
                    return Resources.ResourceManager.GetString(XAMLName);
                }
                catch
                {
                    return null;
                }
            }
        }

        [XmlAttribute]
        public bool HasChildren { get; set; }

        public PageNode[] Children { get; set; }

        [XmlIgnore]
        public static PageNode[] RootPages
        {

            get {

                PageNode rootPage = null;
                XmlSerializer xs = new XmlSerializer(typeof(PageNode));
                rootPage = xs.Deserialize(new StringReader(Resources.Samples)) as PageNode;
                return rootPage.Children;
            }

        }

        /*private static PageNode AddEditorSamples()
        {
            return new PageNode
            {
                Name = "Data Editors",
                HasChildren=true,
                Children = new PageNode[]{
                    new PageNode("Text Box","FormSamples\\TextBoxSample"),
                    new PageNode("Email Text Box","EditorSamples\\EmailTextBoxSample.xaml"),
                    new PageNode("Double Text Box","EditorSamples\\DoubleTextBox.xaml"),
                    new PageNode("Currency Text Box","EditorSamples\\CurrencyTextBoxSample.xaml"),
                    new PageNode("Integer Text Box","EditorSamples\\IntegerTextBoxSample.xaml"),
                    new PageNode("File Path Editor","EditorSamples\\FilePathEditorSample.xaml"),
                    new PageNode("Password Box","FormSamples\\PasswordBoxSample.xaml"),
                    new PageNode("Password Again","EditorSamples\\PasswordBoxAgain.xaml"),
                    new PageNode("Text Box With RegEx","EditorSamples\\TextBoxWithRegExSample.xaml"),
                    new PageNode("TitleTextBox","LayoutSamples\\TitleTextBoxSample.xaml"),
                    new PageNode("Filesize","EditorSamples\\FileSizeSample.xaml"),
                    new PageNode("Filter Text Box","EditorSamples\\FilterTextBoxSample.xaml"),
                    
                    
                }

               
            };
        }

        private static PageNode AddFormSamples()
        {
            return new PageNode
            {
                Name = "Form Controls",
                HasChildren = true,
                Children = new PageNode[] { 
                    new PageNode("Basic Form Sample","FormSamples\\Home.xaml"),
                    new PageNode("Complex Form Sample 1","FormSamples\\HomeBasicSample.xaml"),
                    new PageNode("Complex Form Sample 2","FormSamples\\HomePremiumSample.xaml"),
                    new PageNode("Business Form Sample","FormSamples\\HomeVistaSample.xaml"),
                    new PageNode("List Form with Image","FormSamples\\HomeProfessionalSample.xaml"),
                    new PageNode("Button","FormSamples\\ButtonSample.xaml"),
                    new PageNode("Advanced Buttons","LayoutSamples\\AdvancedButtonSample.xaml"),
                }
            };
        }


        private static PageNode AddListSamples()
        {
            return new PageNode
            {
                Name = "List Samples",
                HasChildren = true,
                Children = new PageNode[]{
                    new PageNode("Combo Box","ListSamples\\ComboBoxSample.xaml"),
                    new PageNode("List Boxes","FormSamples\\List.xaml"),
                    new PageNode("Number Combo Box","EditorSamples\\NumberComboBoxSample.xaml"),
                    new PageNode("Checkbox List","ListSamples\\CheckBoxListSample.xaml"),
                    new PageNode("Radio Button","ListSamples\\RadioButtonList.xaml"),
                    new PageNode("Country Combo Box","ListSamples\\CountryComboBoxSample.xaml"),
                }
            };
        }

        private static PageNode AddLayoutSamples()
        {
            return new PageNode { 
                Name="Layout Controls",
                HasChildren= true,
                Children = new PageNode[]{
                    new PageNode("Stack Panel","LayoutSamples\\AtomStackPanelSample.xaml"),
                    new PageNode("Uniform Grid","LayoutSamples\\UniformGridSample.xaml"),
                    new PageNode("Accordion","LayoutSamples\\AccordionSample.xaml"),
                    new PageNode("Toggle Button Bar","LayoutSamples\\ToggleButtonBarSample.xaml"),
                    new PageNode("View Panel","LayoutSamples\\ViewPanelSample.xaml"),
                }
            };
        }*/

    }
}
