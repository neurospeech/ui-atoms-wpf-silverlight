using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class GenericCommand : ICommand
    {


        public void FireCanExecuteChanged(object sender)
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(sender, EventArgs.Empty);
            }
        }

        #region public bool  CanExecute(object parameter)
        public virtual bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        #endregion


        public event EventHandler CanExecuteChanged;

        #region public void  Execute(object parameter)
        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
