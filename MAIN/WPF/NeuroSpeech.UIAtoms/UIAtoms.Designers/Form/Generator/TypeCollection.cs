using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Windows.Design;

namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    public class TypeCollection : ObservableCollection<TypeNamespace>
    {

        private EditingContext Context;

        public TypeCollection(EditingContext context,Type baseType)
        {
            Context = context;

            TypeNamespace.FillCollection(Context, this, baseType);
        }

        public Type SearchType(string name, string nsName) {

            TypeNamespace tns = GetNamespace(nsName, this);
            // look up type...
            return tns.SearchType(name);
        }

        #region private TypeNamespace GetNamespace(string nsName,TypeCollection typeCollection)
        private TypeNamespace GetNamespace(string nsName, IList<TypeNamespace> nsList)
        {
            int index = nsName.IndexOf('.');
            string leftName = null;
            string rightName = null;
            if (index == -1)
            {
                // no right name..
                leftName = nsName;
            }
            else {
                leftName = nsName.Substring(0, index);
                rightName = nsName.Substring(index + 1);
            }
            TypeNamespace tns = nsList.First(x => x.Namespace == leftName);
            if (rightName == null)
                return tns;
            return GetNamespace(rightName, tns.ChildNamespaces);
        }
        #endregion


    }
}
