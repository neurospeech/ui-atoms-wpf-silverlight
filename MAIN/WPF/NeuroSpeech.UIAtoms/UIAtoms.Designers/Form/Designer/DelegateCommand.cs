using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class DelegateCommand<T> : GenericCommand
        where T:class
    {

        protected Action<T> Action;
        protected Func<T, bool> CanExecuteHandler;

        public DelegateCommand(Action<T> action)
        {
            Action = action;
        }

        public DelegateCommand(Action<T> action, Func<T,bool> canExecute)
        {
            Action = action;
            CanExecuteHandler = canExecute;
        }

        #region public bool  CanExecute(object parameter)
        public override bool CanExecute(object parameter)
        {
            if (CanExecuteHandler != null) {
                return CanExecuteHandler(parameter as T);
            }
            return true;
        }
        #endregion


        #region public void  Execute(object parameter)
        public override void Execute(object parameter)
        {
            if (Action != null) {
                Action(parameter as T);
            }
        }
        #endregion

    }
}
