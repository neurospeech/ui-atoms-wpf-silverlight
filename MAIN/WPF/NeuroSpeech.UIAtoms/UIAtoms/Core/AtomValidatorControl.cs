#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Data;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Validation;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// Base class encapsulating all functionality to validate and display the data control.
    /// </summary>
    public abstract class AtomContainerControl : Control
    {

#if SILVERLIGHT
        public AtomContainerControl()
        {
            this.IsTabStop = false;
        }
#else

        static AtomContainerControl()
        {
            AtomFocusManager.IgnoreFocus(typeof(AtomContainerControl));
        }
#endif

#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        protected CommandBinding copyBinding;

        /// <summary>
        /// 
        /// </summary>
        protected CommandBinding pasteBinding;

        /// <summary>
        /// 
        /// </summary>
        protected void CreateDefaultClipboardBinding()
        {
            copyBinding = new CommandBinding(ApplicationCommands.Copy);
            copyBinding.CanExecute += new CanExecuteRoutedEventHandler(copyBinding_CanExecute);
            copyBinding.Executed += new ExecutedRoutedEventHandler(copyBinding_Executed);
            this.CommandBindings.Add(copyBinding);

            pasteBinding = new CommandBinding(ApplicationCommands.Paste);
            pasteBinding.CanExecute += new CanExecuteRoutedEventHandler(pasteBinding_CanExecute);
            pasteBinding.Executed += new ExecutedRoutedEventHandler(pasteBinding_Executed);
            this.CommandBindings.Add(pasteBinding);
        }

        void pasteBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SetValueFromClipboard(Clipboard.GetText());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        protected virtual void SetValueFromClipboard(string p)
        {
            throw new NotImplementedException();
        }

        void pasteBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsText();
            e.Handled = true;
        }

        void copyBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(GetValueForClipboard());
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string GetValueForClipboard()
        {
            throw new NotImplementedException();
        }

        void copyBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        protected void ResetClipboardCommandBindings(Control control) {
            ResetCommandBindings(control, ApplicationCommands.Copy, copyBinding);
            ResetCommandBindings(control, ApplicationCommands.Paste, pasteBinding);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="command"></param>
        /// <param name="cb"></param>
        protected void ResetCommandBindings(Control control, ICommand command, CommandBinding cb)
        {
            foreach (CommandBinding b in control.CommandBindings)
                if (b.Command == command)
                {
                    control.CommandBindings.Remove(b);
                    break;
                }

            control.CommandBindings.Add(cb);
        }

#endif

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T GetNamedChild<T>(string name)
            where T : DependencyObject
        {
            T child = GetTemplateChild(name) as T;
            if (child == null)
                throw new Exception("Please define '" + name + "' of type '" + typeof(T).FullName + "'");
            return child;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="p"></param>
        /// <param name="name"></param>
        protected void BindProperties(Control control, DependencyProperty p, string name) {
            Binding b = new Binding(name);
            b.Source = this;
            b.Mode = BindingMode.TwoWay;
            control.SetBinding(p, b);
        }

    }
}
