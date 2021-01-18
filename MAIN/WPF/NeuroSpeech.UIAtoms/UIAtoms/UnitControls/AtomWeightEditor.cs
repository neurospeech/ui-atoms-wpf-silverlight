#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.UnitControls
{

    /// <summary>
    /// 
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomWeightEditor : AtomEditorConverter
    {

        /// <summary>
        /// 
        /// </summary>
        public override string UnitName
        {
            get
            {
                return "Weight";
            }
        }

    }
}
