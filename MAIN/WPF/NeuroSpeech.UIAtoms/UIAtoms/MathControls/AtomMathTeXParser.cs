#if WINRT
using Windows.UI.Xaml.Controls;
#else
using System.Windows.Controls;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.MathControls
{

    internal class TokenNavigator {

        private string[] Tokens;
        int index = -1;
        int count = 0;
        internal TokenNavigator(string[] tokens)
        {
            List<string> nonEmpty = new List<string>();
            foreach (string item in tokens)
            {
                if (item.Length == 0)
                    continue;
                nonEmpty.Add(item);
            }
            Tokens = nonEmpty.ToArray();
            count = Tokens.Length;
        }

        internal bool Read() {
            index++;
            if (index >= count)
                return false;
            return true;
        }

        internal string Current {
            get {
                return Tokens[index];
            }
        }

        internal string Last {
            get {
                if (index == 0)
                    return null;
                return Tokens[index - 1];
            }
        }

        internal string Next {
            get {
                if (index >= count - 1)
                    return null;
                return Tokens[index + 1];
            }
        }


    }


    /// <summary>
    /// 
    /// </summary>
    internal class AtomMathTeXParser
    {

        private string Text;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        internal AtomMathTeXParser(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal object Parse()
        {

            // splitter...
            Regex reg = new Regex("([a-zA-Z0-9\\.]+)|(\\W{1})");

            AtomMathEquation eqn = new AtomMathEquation();

            List<object> list = new List<object>();

            TokenNavigator tn = new TokenNavigator(reg.Split(Text));
            AtomMathExp exp;
            while (tn.Read()) {

                switch (tn.Current)
                {
                    case "^":
                        exp = ReplaceLast(list);
                        if (tn.Read()) {
                            exp.TopRight = tn.Current;
                            if (tn.Next == " ")
                                tn.Read();
                        }
                        break;
                    case "_": 
                        exp = ReplaceLast(list);
                        if (tn.Read()) {
                            exp.BottomRight = tn.Current;
                            if (tn.Next == " ")
                                tn.Read();
                        }
                        break;
                    case "\\":
                        if (tn.Read())
                        {
                            AddText(list, tn.Current);
                        }
                        break;
                    default :
                        AddText(list, tn.Current);
                        break;
                }

            }

            foreach (object item in list)
            {
                eqn.Items.Add(item);
            }

            return eqn;
        }

        private AtomMathExp ReplaceLast(List<object> list)
        {
            Object obj = list.Last();
            AtomMathExp exp = new AtomMathExp();
            TextBlock tb = obj as TextBlock;
            if (tb != null) {
                list.Remove(obj);
                exp.Content = tb.Text;
                list.Add(exp);
                return exp;
            }
            exp.Content = obj;
            list.Remove(obj);
            list.Add(exp);
            return exp;
        }

        private void AddText(List<object> list, string LastText)
        {
            TextBlock tb = new TextBlock();
            tb.Text = LastText;
            list.Add(tb);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        internal static object Load(string text) {
            AtomMathTeXParser tex = new AtomMathTeXParser(text);
            return tex.Parse();
        }

    }
}
