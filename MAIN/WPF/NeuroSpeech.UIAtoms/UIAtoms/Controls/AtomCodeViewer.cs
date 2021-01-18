#if WINRT
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

    [TemplatePart(Name = "PART_Code", Type = typeof(RichTextBox))]
    public class AtomCodeViewer : Control
    {

#if SILVERLIGHT

        RichTextBox PART_Code;

        public AtomCodeViewer()
        {
            DefaultStyleKey = typeof(AtomCodeViewer);
        }


#else

        RichTextBox PART_Code;

        static AtomCodeViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomCodeViewer), new FrameworkPropertyMetadata(typeof(AtomCodeViewer)));
        }

#endif


        /// <summary>
        /// 
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Code = (RichTextBox)GetTemplateChild("PART_Code");

            context.PreventRecursive(FormatCode);
#if SILVERLIGHT
#else
            PART_Code.TextChanged += (s, e) => {
                if(ContainsMajorChanges(e))
                    UpdateTextFromCode();
            };
#endif
            //PART_Code.TextInput += new TextCompositionEventHandler(PART_Code_TextInput);

        }

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
                        if (TextChanged != null)
                        {
                            TextChanged(this, EventArgs.Empty);
                        }
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





        ///<summary>
        ///DependencyProperty Text
        ///</summary>
        #region Dependency Property Text
        [AtomDesign(
            Category="Atoms",
            Bindable=true,
            BrowseMode=AtomPropertyBrowseMode.Default
            )]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AtomCodeViewer), new PropertyMetadata("", OnTextChangedCallback));
#else
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AtomCodeViewer), new UIPropertyMetadata("", OnTextChangedCallback));
#endif

        private static void OnTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomCodeViewer obj = d as AtomCodeViewer;
            if (obj != null)
            {
                obj.OnTextChanged(e);
            }
        }

        /// <summary>
        /// Fires TextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
        {
            context.PreventRecursive(() => {
                FormatCode();
                if (TextChanged != null)
                {
                    TextChanged(this, EventArgs.Empty);
                }
            });
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler TextChanged;

        #endregion






        ///<summary>
        ///DependencyProperty Formatter
        ///</summary>
        #region Dependency Property Formatter
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public AtomCodeFormatter Formatter
        {
            get { return (AtomCodeFormatter)GetValue(FormatterProperty); }
            set { SetValue(FormatterProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Formatter.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FormatterProperty =
            DependencyProperty.Register("Formatter", typeof(AtomCodeFormatter), typeof(AtomCodeViewer), new PropertyMetadata(null, OnFormatterChangedCallback));
#else
        public static readonly DependencyProperty FormatterProperty =
            DependencyProperty.Register("Formatter", typeof(AtomCodeFormatter), typeof(AtomCodeViewer), new UIPropertyMetadata(null, OnFormatterChangedCallback));
#endif

        private static void OnFormatterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomCodeViewer obj = d as AtomCodeViewer;
            if (obj != null)
            {
                obj.OnFormatterChanged(e);
            }
        }

        /// <summary>
        /// Fires FormatterChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFormatterChanged(DependencyPropertyChangedEventArgs e)
        {
            FormatCode();
            if (FormatterChanged != null)
            {
                FormatterChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FormatterChanged;

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
