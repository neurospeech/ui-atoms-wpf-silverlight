using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class EnumValueConverter
    {
        #region internal static object ConvertTo(Type type,object p)
        internal static object ConvertTo(Type type, object p)
        {
            return Enum.Parse(type, p.ToString());
        }
        #endregion
}
}
