#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAtomItemsFilter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemsControl"></param>
        /// <param name="item"></param>
        /// <param name="filterText"></param>
        /// <param name="filterParameter"></param>
        /// <param name="mode"></param>
        /// <param name="comparison"></param>
        /// <returns>True if item has to be included in display list, false to remove item from display list</returns>
        bool FilterItem(object itemsControl, object item, string filterText, object filterParameter, AtomTextFilterMode mode, StringComparison comparison);

    }
}
