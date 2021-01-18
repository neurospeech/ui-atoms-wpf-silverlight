#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.MathControls
{

    /// <summary>
    /// 
    /// </summary>
    public class XmlAliasAttribute : Attribute
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        public XmlAliasAttribute(string alias)
        {
            Alias = alias;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }

    }
}
