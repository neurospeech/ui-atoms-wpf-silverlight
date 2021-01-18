#if WINRT
#else
#endif
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using NeuroSpeech.UIAtoms.Core;
//using System.Windows;
//using System.Windows.Controls;
//using System.Xml;
//using System.IO;
//using System.Windows.Documents;
//using System.Windows.Media;

//namespace NeuroSpeech.UIAtoms.Controls
//{
//    public class AtomXAMLFormatter : AtomCodeFormatter
//    {

//        public override void Format(TextBlock text, string code)
//        {

//            IEnumerable<char> enb = code;
//            IEnumerator<char> en = enb.GetEnumerator();

//            StringBuilder lastText = new StringBuilder();

//            while (en.MoveNext()) {
//                char ch = en.Current;
//                if (ch == '\n') {
//                    NewLine(text);
//                    continue;
//                }
//                if (ch != '<')
//                {
//                    lastText.Append(ch);
//                }
//                else
//                {
//                    // read tag till '>'
//                    AddTextIfNotEmpty(text, lastText);

                    

//                }
//            }

//            AddTextIfNotEmpty(text, lastText);

//        }

//        private void AddTextIfNotEmpty(TextBlock text, StringBuilder lastText)
//        {
//            if (lastText.Length == 0)
//                return;
//            string t = lastText.ToString();
//            AddText(text, t, Colors.Black, FontWeights.Normal);
//            lastText.Length = 0;
//        }

//        private void AddText(TextBlock text, string p, Color color, FontWeight fontWeight)
//        {
//            Run r = new Run();
//            r.Text = p;
//            r.Foreground = new SolidColorBrush(color);
//            r.FontWeight = fontWeight;
//            text.Inlines.Add(r);
//        }

//        private void NewLine(TextBlock text)
//        {
//            text.Inlines.Add(new LineBreak());
//        }

//    }
//}
