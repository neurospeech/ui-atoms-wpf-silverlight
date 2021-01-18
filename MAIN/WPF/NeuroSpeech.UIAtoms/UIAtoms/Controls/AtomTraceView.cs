#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Allows trace view in the application to monitor trace information.
    /// </summary>
    [TemplatePart(Name = "PART_Content", Type = typeof(RichTextBox))]
    public class AtomTraceView : Control
    {

#if SILVERLIGHT
        public AtomTraceView()
        {
            this.DefaultStyleKey = typeof(AtomTraceView);
        }

        ~AtomTraceView()
        {
            ReleaseListener();
        }
#else
        static AtomTraceView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomTraceView), new FrameworkPropertyMetadata(typeof(AtomTraceView)));
        }
#endif

        private AtomTraceListener Listener = null;

        /// <summary>
        /// 
        /// </summary>
        protected RichTextBox TextBox = null;

        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            TextBox = GetTemplateChild("PART_Content") as RichTextBox;

            Listener = new AtomTraceListener();
            Listener.Traced += new EventHandler<AtomTraceMessageEventArgs>(Listener_Traced);

            AtomTrace.Listeners.Add(Listener);

#if SILVERLIGHT

            // load history...
            AtomTrace.LoadHistory(Listener);

            TextBox.Blocks.Clear();
            TextBox.Blocks.Add(traceParagraph);
#else
            TextBox.Document.Blocks.Clear();
            TextBox.Document.Blocks.Add(traceParagraph);
#endif
            traceParagraph.Inlines.Add(inline);

        }

        private void ReleaseListener()
        {
            if (Listener != null) {
                AtomTrace.Listeners.Remove(Listener);
                Listener.Traced -= new EventHandler<AtomTraceMessageEventArgs>(Listener_Traced);
            }
        }

        void Listener_Traced(object sender, AtomTraceMessageEventArgs e)
        {
#if SILVERLIGHT
            Dispatcher.BeginInvoke((Action)delegate() {
                AppendText(e.Message);
            });
#else
            Dispatcher.BeginInvoke((Action)delegate()
            {
                AppendText(e.Message);
            });
#endif
        }


        Paragraph traceParagraph = new Paragraph();
        Run inline = new Run();

        private void AppendText(string p)
        {

            inline.Text += p;

            TextBox.Selection.Select(traceParagraph.ContentEnd, traceParagraph.ContentEnd);

#if !SILVERLIGHT
            TextBox.ScrollToEnd();
#endif
        }

    }
}
