using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;
using System.Reflection;
using System.ComponentModel;
using System.Windows;

[assembly: ProvideMetadata(typeof(NeuroSpeech.UIAtoms.Design.RegisterMetadata))]

namespace NeuroSpeech.UIAtoms.Design
{
    public class RegisterMetadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get { 
                MetadataBuilder builder = new MetadataBuilder();
                return builder.CreateTable();
            }
        }
    }

}
