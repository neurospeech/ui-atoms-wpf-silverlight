using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class LinkedCollection<TDest,TSrc> : List<TDest>, INotifyCollectionChanged
        where TDest: ItemHolder<TSrc>
        where TSrc: class
    {
        Func<TSrc, TDest> Converter = null;

        public IList<TSrc> InternalCollection { get; private set; }

        public void Reset() {
            RebuildItems();
        }

        public LinkedCollection(INotifyCollectionChanged coll , Func<TSrc,TDest> converter)
        {
            coll.CollectionChanged += new NotifyCollectionChangedEventHandler(coll_CollectionChanged);

            Converter = converter;

            InternalCollection = coll as IList<TSrc>;

            RebuildItems();
        }

        private void RebuildItems()
        {
            foreach (var item in this)
            {
                item.Item = null;
            }
            this.Clear();
            foreach (TSrc item in InternalCollection)
            {
                this.Add(Converter(item));
            }
            NotifyCollectionChanged();
        }



        #region void  coll_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        void coll_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RebuildItems();
            NotifyCollectionChanged();
        }

        private void NotifyCollectionChanged()
        {
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        #endregion


        public event NotifyCollectionChangedEventHandler CollectionChanged;
    }

    public abstract class ItemHolder<T> {

        public string Prefix;

        private T _Item;
        public virtual T Item 
        {
            get {
                return _Item;
            }
            set {
                T oldItem = _Item;
                _Item = value;
                OnItemSet(oldItem,value);
            } 
        }

        #region private void OnItemSet(T oldItem,T value)
        protected virtual void OnItemSet(T oldValue, T newValue)
        {
        }
        #endregion



    }
}
