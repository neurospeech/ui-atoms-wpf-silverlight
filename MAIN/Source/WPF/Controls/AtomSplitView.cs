#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Markup;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    [ContentProperty("Items")]
    public partial class AtomSplitView
    {

        // called in constructor...
        partial void OnCreate(){
            this.Items = new ObservableCollection<UIElement>();
            this.Items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Items_CollectionChanged);
        }

        #region void  Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnItemsChanged(e);
        }
        #endregion

        #region private void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // reset layout...
            layoutStack++;
            this.CallLater(ResetLayout);
        }

        #region partial void  OnAfterOrientationPropertyChanged(DependencyPropertyChangedEventArgs e)
        partial void OnAfterOrientationChanged(DependencyPropertyChangedEventArgs e)
        {
            layoutStack++;
            this.CallLater(ResetLayout);
        }
        #endregion


        int layoutStack = 0;

        private void ResetLayout()
        {
            if (layoutStack > 0)
            {
                layoutStack--;
                this.CallLater(ResetLayout);
                return;
            }

            int count = Items.Count;
            if (count == 0)
                return;
            this.Children.Clear();

            if (count == 1)
            {
                this.ColumnDefinitions.Clear();
                this.RowDefinitions.Clear();

                this.Children.Add(Items.First());
                return;
            }

            int items = 2 * count - 1;

            if (Orientation == System.Windows.Controls.Orientation.Horizontal)
            {
                for (int i = 0; i < count; i++)
                {
                    ColumnDefinitions.Add(new ColumnDefinition());
                    ColumnDefinitions.Add(new ColumnDefinition { Width= GridLength.Auto });

                    FrameworkElement e = Items[i] as FrameworkElement;
                    Grid.SetColumn(e,2*i);
                    Children.Add(e);

                    GridSplitter gs = new GridSplitter();
                    Grid.SetColumn(gs, 2*i + 1);
                    gs.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                    gs.Width = 5;
                    gs.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
                    Children.Add(gs);
                }
                Children.Remove(Children[Children.Count- 1]);
                ColumnDefinitions.Remove(ColumnDefinitions.Last());
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    RowDefinitions.Add(new RowDefinition());
                    RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    FrameworkElement e = Items[i] as FrameworkElement;
                    Grid.SetRow(e, 2 * i);
                    Children.Add(e);

                    GridSplitter gs = new GridSplitter();
                    Grid.SetRow(gs, 2*i + 1);
                    gs.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    gs.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                    gs.Height = 5;
                    Children.Add(gs);
                }
                Children.Remove(Children[Children.Count - 1]);
                RowDefinitions.Remove(RowDefinitions.Last());
                
            }
        }

        #endregion




        // called after ApplyTemplate
        //partial void OnAfterTemplateApplied(){
        //}




    }

}
