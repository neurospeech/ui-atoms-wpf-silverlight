#if WINRT
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// Code Formatter Base Class
    /// </summary>
    public abstract class AtomCodeFormatter
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="inlines"></param>
        public void FormatCode(string code, InlineCollection inlines)
        {
            inlines.Clear();
            if (string.IsNullOrEmpty(code))
                return;

            foreach (AtomCodePart codePart in GetCodeParts(code))
            {
                if (codePart.NewLine)
                {
                    inlines.Add(new LineBreak());
                }
                else
                {
                    Run r = new Run();
                    r.Text = codePart.Text;
                    if (codePart.Style != null) {
                        codePart.Style.Apply(r);
                    }
                    inlines.Add(r);
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inlines"></param>
        /// <returns></returns>
        public string GetCode(InlineCollection inlines) {
            StringBuilder sb = new StringBuilder();
            foreach (Inline item in inlines)
            {
                Run r = item as Run;
                if (r != null) {
                    sb.Append(r.Text);
                    continue;
                }
                LineBreak br = item as LineBreak;
                if (br != null) {
                    sb.AppendLine();
                    continue;
                }
            }
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public abstract IEnumerable<AtomCodePart> GetCodeParts(string code);

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomCodePart
    {
        /// <summary>
        /// 
        /// </summary>
        public bool NewLine = false;

        /// <summary>
        /// 
        /// </summary>
        public string Text;

        /// <summary>
        /// 
        /// </summary>
        public string Part;

        /// <summary>
        /// 
        /// </summary>
        public AtomCodeStyle Style;

    }

    /// <summary>
    /// 
    /// </summary>
    public class AtomCodeStyle
    {

        /// <summary>
        /// 
        /// </summary>
        public Brush Foreground = new SolidColorBrush(Color.FromArgb(0xff,0,0,0));

        /// <summary>
        /// 
        /// </summary>
        public FontFamily FontFamily;

        /// <summary>
        /// 
        /// </summary>
        public FontWeight FontWeight = FontWeights.Normal;

        /// <summary>
        /// 
        /// </summary>
        public double FontSize = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public virtual void Apply(Run r)
        {
            r.Foreground = Foreground;
            if(FontFamily!=null)
                r.FontFamily = FontFamily;
            r.FontWeight = FontWeight;
            if (FontSize != 0)
                r.FontSize = FontSize;
        }
    }
}
