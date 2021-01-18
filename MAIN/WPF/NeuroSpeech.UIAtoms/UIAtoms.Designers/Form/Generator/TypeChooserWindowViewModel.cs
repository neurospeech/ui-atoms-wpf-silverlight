using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using NeuroSpeech.UIAtoms.Designers.OleServices;
using EnvDTE;
using VSLangProj;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell.Design;
using System.Diagnostics;
using Microsoft.VisualStudio.Shell;
using Microsoft.Windows.Design;
using System.Windows;
using System.Reflection;

namespace NeuroSpeech.UIAtoms.Designers.Form.Generator
{
    public class TypeChooserWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Func<Type,bool> AcceptDelegate { get; set; }

        #region Property BaseType
        private Type _BaseType = typeof(object);
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(typeof(object))]
        [System.ComponentModel.Category("Category")]
        public Type BaseType
        {
            get
            {
                return _BaseType;
            }
            set
            {
                _BaseType = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("BaseType"));
            }
        }

        #endregion

        #region Property Context
        private EditingContext _Context = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public EditingContext Context
        {
            get
            {
                return _Context;
            }
            set
            {
                _Context = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Context"));
            }
        }

        #endregion

        #region Property SelectedType
        private object _SelectedType = null;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Category("Category")]
        public object SelectedType
        {
            get
            {
                return _SelectedType;
            }
            set
            {
                _SelectedType = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SelectedType"));
                CanClose = _SelectedType is Type;
            }
        }

        #endregion

        #region Property CanClose
        private bool _CanClose = false;
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.DefaultValue(false)]
        [System.ComponentModel.Category("Category")]
        public bool CanClose
        {
            get
            {
                return _CanClose;
            }
            set
            {
                _CanClose = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CanClose"));
            }
        }

        #endregion
	


        public TypeChooserWindowViewModel()
        {

        }

        private ObservableCollection<TypeNamespace> _TypeCollection = null;
        public ObservableCollection<TypeNamespace> TypeCollection
        {
            get {
                if (_TypeCollection == null) {
                    LoadTypes();
                }
                return _TypeCollection;
            }
        }



        private void LoadTypes()
        {
            _TypeCollection = TypeNamespace.GetCollection(Context,BaseType,AcceptDelegate);
        }





        internal static void ShowMessage<T>(System.Collections.IEnumerable list, Func<T, string> messageFunc, string startLine = null, string endLine = null)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(startLine))
                sb.AppendLine(startLine);
            foreach (T item in list)
            {
                sb.AppendLine(messageFunc(item));
            }
            if (!string.IsNullOrWhiteSpace(endLine))
                sb.AppendLine(endLine);
            MessageBox.Show(sb.ToString());
        }

        internal static void TraceMessage<T>(System.Collections.IEnumerable list, Func<T, string> messageFunc, string startLine = null, string endLine = null)
        {
            if (!string.IsNullOrWhiteSpace(startLine))
                Trace.WriteLine(startLine);
            foreach (T item in list)
            {
                Trace.WriteLine(messageFunc(item));
            }
            if (!string.IsNullOrWhiteSpace(endLine))
                Trace.WriteLine(endLine);
        }


    }
}
