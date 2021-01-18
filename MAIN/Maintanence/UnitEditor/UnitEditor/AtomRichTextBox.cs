using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using NeuroSpeech.UIAtoms.Core;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Diagnostics;

namespace UnitEditor
{
    public class AtomRichTextBox : RichTextBox
    {

        public AtomRichTextBox()
        {
            this.TextChanged += new TextChangedEventHandler(AtomRichTextBox_TextChanged);

        }


        void AtomRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtomUtils.ProcessOneTime(ref xamlChanging, () => {
                try
                {
                    Section s = Document.Blocks.FirstBlock as Section;
                    if (s != null)
                    {
                        Xaml = XamlWriter.Save(s);
                        Trace.WriteLine(Xaml);
                    }
                }
                catch { }
            });
        }


        private bool xamlChanging = false;

        ///<summary>
        ///DependencyProperty Xaml
        ///</summary>
        #region Dependency Property Xaml
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string Xaml
        {
            get { return (string)GetValue(XamlProperty); }
            set { SetValue(XamlProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Xaml.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty XamlProperty = 
    DependencyProperty.Register("Xaml", typeof(string), typeof(AtomRichTextBox), new PropertyMetadata("",OnXamlChangedCallback));
#else
        public static readonly DependencyProperty XamlProperty =
            DependencyProperty.Register("Xaml", typeof(string), typeof(AtomRichTextBox), new FrameworkPropertyMetadata("", OnXamlChangedCallback));
#endif

        private static void OnXamlChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomRichTextBox obj = d as AtomRichTextBox;
            if (obj != null)
            {
                obj.OnXamlChanged(e);
            }
        }

        /// <summary>
        /// Fires XamlChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnXamlChanged(DependencyPropertyChangedEventArgs e)
        {

            if (e.NewValue == null)
                return;

            string xml = Xaml;

            AtomUtils.ProcessOneTime(ref xamlChanging, () => {
                try
                {
                    Section s = (Section)XamlReader.Parse(xml);
                    FlowDocument doc = new FlowDocument();
                    doc.Blocks.Add(s);
                    this.Document = doc;
                }
                catch 
                {
                    Section s = new Section();
                    Paragraph p = new Paragraph();
                    s.Blocks.Add(p);
                    p.Inlines.Add(xml);
                    FlowDocument doc = new FlowDocument();
                    doc.Blocks.Add(s);
                    Document = doc;

                }
            });

            if (XamlChanged != null)
            {
                XamlChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler XamlChanged;

        #endregion



    }
}
