//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Animation;
//using System.Windows.Shapes;
//using System.ComponentModel;
//using NeuroSpeech.UIAtoms.Core;

//namespace NeuroSpeech.UIAtoms.Controls
//{

//    [TemplatePart( Name="PART_Content" , Type= typeof(TextBox))]
//    public class AtomTraceView : Control
//    {
//        public AtomTraceView()
//        {
//            this.DefaultStyleKey = typeof(AtomTraceView);

//        }

//        ~AtomTraceView()
//        {
//            Trace.Traced -= new EventHandler(Trace_Traced);
//        }

//        private TextBox PART_Content;

//        public override void OnApplyTemplate()
//        {
//            base.OnApplyTemplate();

//            PART_Content = (TextBox)GetTemplateChild("PART_Content");

//            Trace.Traced += new EventHandler(Trace_Traced);
//        }

        

//        void Trace_Traced(object sender, EventArgs e)
//        {
//            this.Dispatcher.BeginInvoke(() =>
//            {
//                PART_Content.Text = Trace.TraceLog;
//                PART_Content.Select(PART_Content.Text.Length, 0);
//            });
//        }

//    }
//}
