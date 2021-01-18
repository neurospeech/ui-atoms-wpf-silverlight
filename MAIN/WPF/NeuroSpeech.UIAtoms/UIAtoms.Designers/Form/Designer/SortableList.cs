using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{

    public class ModelList : SortableList<FormItemModel> { 
    }

    public class SortableList<T> : ListBox
        where T:class
    {

        public SortableList()
        {
            MoveUpCommand = new DelegateCommand<T>(moveUpCommand, CanMoveUp);
            MoveDownCommand = new DelegateCommand<T>(moveDownCommand, CanMoveDown);
            DeleteCommand = new DelegateCommand<T>(deleteCommand, canDelete);
        }


        #region protected override void  OnSelectionChanged(SelectionChangedEventArgs e)
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {

            MoveUpCommand.FireCanExecuteChanged(this);
            MoveDownCommand.FireCanExecuteChanged(this);
            DeleteCommand.FireCanExecuteChanged(this);
            base.OnSelectionChanged(e);


        }
        #endregion


        private void deleteCommand(T model) {
            Collection<T> coll = this.Collection;
            if (coll == null)
                return;
            coll.Remove(model);
        }

        private bool canDelete(T model) {
            return this.SelectedIndex != -1;
        }

        public Collection<T> Collection {
            get {
                return this.ItemsSource as ObservableCollection<T>;
            }
        }

        private bool CanMoveUp(T model)
        {
            int index = this.SelectedIndex;
            if (index < 1)
                return false;
            return true;
        }

        private bool CanMoveDown(T model)
        {
            Collection<T> coll = this.Collection;
            if (coll == null)
                return false;
            int count = coll.Count;
            int index = this.SelectedIndex;
            if (index < count - 1)
                return true;
            return false;
        }

        private void moveUpCommand(T model)
        {
            Collection<T> coll = this.Collection;
            if (coll == null)
                return;
            int i = coll.IndexOf(model);
            coll.Remove(model);
            i--;
            coll.Insert(i, model);
            this.SelectedIndex = i;
        }

        private void moveDownCommand(T model)
        {
            Collection<T> coll = this.Collection;
            if (coll == null)
                return;
            int i = coll.IndexOf(model);
            coll.Remove(model);
            i++;
            coll.Insert(i, model);
            this.SelectedIndex = i;
        }

        public DelegateCommand<T> MoveUpCommand { get; set; }
        public DelegateCommand<T> MoveDownCommand { get; set; }

        public DelegateCommand<T> DeleteCommand { get; set; }

    }
}
