#if NETFX_CORE
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Code Syntax Viewer
    /// </summary>

    public partial class AtomCodeViewer : Control
    {

		#region partial void  OnAfterTemplateApplied()
		partial void OnAfterTemplateApplied()
		{
			context.PreventRecursive(FormatCode);
#if SILVERLIGHT
#else
			PART_Code.TextChanged += (s, e) =>
			{
				if (ContainsMajorChanges(e))
					UpdateTextFromCode();
			};
#endif
			//PART_Code.TextInput += new TextCompositionEventHandler(PART_Code_TextInput);
		}
		#endregion


        #region private bool ContainsMajorChanges(TextChangedEventArgs e)
#if SILVERLIGHT
#else


        #region protected override void  OnLostFocus(RoutedEventArgs e)
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            UpdateTextFromCode();
        }
        #endregion


        #region protected override void  OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            UpdateTextFromCode();
        }
        #endregion



        private bool ContainsMajorChanges(TextChangedEventArgs e)
        {
            if (e.Changes.Count > 1)
                return true;
            TextPointer tp = PART_Code.CaretPosition;
            TextPointer s = tp.GetInsertionPosition(LogicalDirection.Backward);
            string str = s.GetTextInRun(LogicalDirection.Backward);
            if (str.Length > 0) {
                char ch = str[str.Length-1];
                if (char.IsLetterOrDigit(ch) || ch == '_')
                    return false;
            }
            return true;
        }
#endif
        #endregion


        #region void  PART_Code_TextInput(object sender, TextCompositionEventArgs e)
        private void UpdateTextFromCode()
        {
            context.PreventRecursive(() =>
            {

                Rect r = PART_Code.Selection.Start.GetCharacterRect(LogicalDirection.Forward);
                Point pr = new Point(r.X, r.Y);

#if SILVERLIGHT
                Text = GetText(PART_Code.Blocks);
#else
                if (PART_Code.Document != null)
                {
                    string newText = GetText(PART_Code.Document.Blocks);
                    if (newText != Text)
                    {
                        Text = newText;
                    }
                }
#endif
                FormatCode();
#if SILVERLIGHT
                TextPointer tp = PART_Code.GetPositionFromPoint(pr);
#else
                TextPointer tp = PART_Code.GetPositionFromPoint(pr, false) ?? PART_Code.GetPositionFromPoint(pr,true);
#endif
                if (tp == null)
                {
                    //Trace.WriteLine("Doing select all..");
                    //tp = PART_Code.GetPositionFromPoint(pr, true);
                    //tp = PART_Code.Document.ContentEnd;
                    PART_Code.SelectAll();
                    tp = PART_Code.Selection.End;
                    
                }
                PART_Code.Selection.Select(tp, tp);
                //PART_Code.Selection.Select()

            });
        }
        #endregion


        #region private string GetText(BlockCollection blockCollection)
        private string GetText(BlockCollection blockCollection)
        {

#if SILVERLIGHT
            StringBuilder sb = new StringBuilder();
            foreach (Paragraph item in blockCollection)
            {
                sb.Append(Formatter.GetCode(item.Inlines));
            }
            return sb.ToString();
#else
            TextRange tr = new TextRange(PART_Code.Document.ContentStart, PART_Code.Document.ContentEnd);
            string t = tr.Text;
            //Trace.WriteLine("'" + t + "'");
            // remove trailing multi line characters...
            while (t.EndsWith("\r\n\r\n")) {
                t = t.Substring(0, t.Length - 2);
            }
            return t;
#endif


        }
        #endregion

		#region partial void  OnAfterFormatterChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterFormatterChanged(DependencyPropertyChangedEventArgs e)
		{
			FormatCode();
		}
		#endregion


        AtomLogicContext context = new AtomLogicContext();


        /// <summary>
        /// 
        /// </summary>
        public void FormatCode()
        {

            string code = Text;
            AtomCodeFormatter fm = Formatter;
            if (fm == null)
                return;
            if (PART_Code == null)
                return;

#if SILVERLIGHT
            PART_Code.Blocks.Clear();
            Paragraph p = new Paragraph();
            PART_Code.Blocks.Add(p);
            fm.FormatCode(code, p.Inlines);
#else
            FlowDocument fd = PART_Code.Document ?? new FlowDocument();
            //fd.Blocks.Clear();
            Paragraph p = fd.Blocks.OfType<Paragraph>().FirstOrDefault();
            if (p != null)
            {
                fd.Blocks.Clear();
            }
            p = new Paragraph();
            fm.FormatCode(code, p.Inlines);
            fd.Blocks.Add(p);
            if (PART_Code.Document == null)
                PART_Code.Document = fd;
#endif
        }

    }
}
