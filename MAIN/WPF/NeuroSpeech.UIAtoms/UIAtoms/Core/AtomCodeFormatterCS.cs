#if WINRT
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
#else
using System.Windows.Media;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NeuroSpeech.UIAtoms.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class AtomCodeFormatterCS : AtomCodeFormatter
    {
        private readonly AtomCodeStyle Keyword = 
            new AtomCodeStyle { 
                Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0, 0, 0xff)), 
                FontWeight = FontWeights.Bold };

        private readonly AtomCodeStyle Comment =
            new AtomCodeStyle
            {
                Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0, 0x80, 0)),
                FontWeight = FontWeights.Bold
            };

        private readonly AtomCodeStyle String = 
            new AtomCodeStyle { 
                Foreground = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0, 0xff)) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public override IEnumerable<AtomCodePart> GetCodeParts(string code)
        {
            List<AtomCodePart> parts = new List<AtomCodePart>();
            #region OLD
            string lastWord = "";

            char[] buf = code.ToCharArray();
            int n = buf.Length;

            Mode mode = Mode.None;
            string comment = "";

            for (int i = 0; i < n; i++)
            {
                char ch = buf[i];
                switch (mode)
                {
                    case Mode.Comment:
                        if (ch == '\r' && buf[i + 1] == '\n')
                        {
                            mode = Mode.None;
                        }
                        else
                        {
                            comment += ch;
                            continue;
                        }
                        break;
                    case Mode.String:
                        break;
                }
                if (Char.IsLetterOrDigit(ch))
                {
                    lastWord += ch;
                }
                else
                {
                    AddLastWord(parts, ref lastWord, null);
                    AddLastWord(parts, ref comment, Comment);
                    if (ch == '\r' && buf[i + 1] == '\n')
                    {
                        i++;
                        parts.Add(new AtomCodePart { NewLine = true });
                    }
                    else if (ch == '\n')
                    {
                        parts.Add(new AtomCodePart { NewLine = true });
                    }
                    else if (ch == '/' && buf[i + 1] == '/')
                    {
                        comment = "//";
                        i += 2;
                        mode = Mode.Comment;
                        AddLastWord(parts, ref lastWord, null);
                        continue;
                    }
                    else
                    {
                        parts.Add(new AtomCodePart { Text = new string(ch, 1) });
                    }
                }
            }
            AddLastWord(parts, ref lastWord, null);
            AddLastWord(parts, ref comment, null);
            #endregion


            //string[] lines = code.Split('\n');



            return parts;
        }

        enum Mode { 
            None,
            Comment,
            String
        }

        private void AddLastWord(List<AtomCodePart> parts, ref string word, AtomCodeStyle style)
        {
            if (string.IsNullOrEmpty(word))
                return;

            if (IsKeyword(word))
            {
                parts.Add(new AtomCodePart { Text = word, Style = Keyword });
            }
            else
            {
                parts.Add(new AtomCodePart { Text = word , Style=style});
            }
            word = "";
        }

        //private readonly string[] Keywords = new string[] {
        //    "abstract",
        //    "as",
        //    "base",
        //    "bool",
        //    "break",
        //    "byte",
        //    "case",
        //    "catch",
        //    "char",
        //    "checked",
        //    "class",
        //    "const",
        //    "continue",
        //    "decimal",
        //    "default",
        //    "delegate",
        //    "do",
        //    "override",
        //    "virtual",
        //    "partial",
        //    "function",
        //    "foreach",
        //    "for",
        //    "do",
        //    "while"
        //};

        private readonly string[] Keywords = ("function,internal,package,import"+
            "abstract,as,base,bool,break,byte,case,catch,char,checked,class,const,continue,decimal,default,delegate"+
            "do,double,else,enum,event,explicit,extern,false,finally,fixed,float,for,foreach,goto,if,implicit,in,int,interface"+
            "internal,is,lock,long,namespace,new,null,object,operator,out,override,params,private,protected,public,readonly,ref,return,sbyte" +
            "sealed,short,sizeof,stackalloc,static,string,struct,switch,this,throw,true,try,typeof,unit,ulong,unchecked,unsafe,ushort,using" + 
            "virtual,void,volatile,while"+
            "add,alias,ascending,descending,dynamic,from,get,global,group,into,join,let,orderby,partial,remove,select,set,value,var,where,yield").Split(',');

        private bool IsKeyword(string lastWord)
        {
            return Keywords.Contains(lastWord);    
        }
    }
}
