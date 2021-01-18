using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design;
using System.Collections.ObjectModel;

namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    public class TypeNamespace
    {




        public static ObservableCollection<TypeNamespace> GetCollection(
            EditingContext Context,
            Type baseType = null, 
            Func<Type,bool> acceptType = null) {
            ObservableCollection<TypeNamespace> coll = new ObservableCollection<TypeNamespace>();
            FillCollection(Context,coll, baseType,acceptType);
            return coll;
        }

        internal static void FillCollection(EditingContext Context, ObservableCollection<TypeNamespace> coll, Type baseType = null, Func<Type, bool> acceptType = null)
        {
            AssemblyReferences ars = Context.Items.FirstOrDefault(x => (x is AssemblyReferences)) as AssemblyReferences;
            string localName = ars.LocalAssemblyName.FullName;
            if (acceptType == null)
            {
                if (baseType == null)
                {
                    acceptType = type =>
                    {
                        string fullName = type.FullName;
                        if (fullName.StartsWith("System."))
                            return false;
                        if (fullName.StartsWith("MS."))
                            return false;
                        if (type.Namespace == null)
                            return false;
                        return true;
                    };
                }
                else {
                    acceptType = type =>
                    {
                        if (!type.IsPublic)
                            return false;
                        if(type.IsClass)
                            return true;
                        return false;
                    };
                }
            }
            if (baseType == null)
                baseType = typeof(object);

            foreach (Type type in ars.GetTypes(baseType))
            {
                if (acceptType(type))
                    InsertType(type, coll);
            }
        }

        internal static TypeNamespace GetNamespace(string nsName, IList<TypeNamespace> parent)
        {

            string rootNS = "";
            string childNS = null;

            int index = nsName.IndexOf('.');
            if (index == -1)
            {
                rootNS = nsName;
            }
            else
            {
                rootNS = nsName.Substring(0, index);
                childNS = nsName.Substring(index + 1);
            }
            TypeNamespace tns = parent.FirstOrDefault(x => x.Namespace == rootNS);
            if (tns == null)
            {
                tns = new TypeNamespace { Namespace = rootNS };
                parent.Add(tns);
            }
            if (childNS != null)
            {
                return GetNamespace(childNS, tns.ChildNamespaces);
            }
            return tns;
        }

        #region private void InsertType(Type type)
        private static void InsertType(Type type,IList<TypeNamespace> nsList)
        {
            string nsName = type.Namespace;
            TypeNamespace tns = GetNamespace(nsName,nsList);
            tns.Types.Add(type);
        }
        #endregion


        public TypeNamespace()
        {
            ChildNamespaces = new List<TypeNamespace>();
            Types = new List<Type>();
        }

        public string Namespace { get; set; }

        public List<TypeNamespace> ChildNamespaces { get; set; }

        public List<Type> Types { get; set; }

        public System.Collections.IEnumerable AllItems {
            get {
                List<object> allItems = new List<object>();
                allItems.AddRange(ChildNamespaces.OrderBy(x=>x.Namespace));
                allItems.AddRange(Types.OrderBy(x=>x.Name));
                return allItems;
            }
        }


        #region internal Type SearchType(string name)
        internal Type SearchType(string name)
        {
            return Types.First(x => x.Name == name);
        }
        #endregion
}
}
