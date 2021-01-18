using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;

namespace NeuroSpeech.UIAtoms.VisualStudio.Design
{
    public class MetadataRegistration : IRegisterMetadata
    {

        private static bool _IsInitialized = false;
        public void Register()
        {
            if (_IsInitialized)
                return;
            MetadataStore.AddAttributeTable(BuildAttributeTable());
            _IsInitialized = true;
        }

        private AttributeTable BuildAttributeTable()
        {
            NeuroSpeech.UIAtoms.Design.MetadataBuilder builder = new UIAtoms.Design.MetadataBuilder();
            return builder.CreateTable();
        }
    }
}
