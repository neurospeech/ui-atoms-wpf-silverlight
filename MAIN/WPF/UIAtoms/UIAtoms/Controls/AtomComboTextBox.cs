#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Controls.Primitives;
#else
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Collections.Specialized;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    public partial class AtomComboTextBox : System.Windows.Controls.TextBox
    {

        // called in constructor...
        //partial void OnCreated(){
        //}

        private ListBox listBox;

        partial void OnAfterTemplateApplied(){
            if (listBox != null)
            {
                listPresenter.Content = listBox;
                return;
            }

            listBox = new ListBox();
            listBox.Width = double.NaN;
            listBox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;

            listBox.SetOneWayBinding(ListBox.DisplayMemberPathProperty, this, "DisplayMemberPath");
            listBox.Bind(ListBox.ItemsSourceProperty, () => this.ItemsSource);
            listBox.SelectionChanged += new SelectionChangedEventHandler(listBox_SelectionChanged);
            //listBox.SetTwoWayBinding(ListBox.SelectedIndexProperty, this, "SelectedIndex");
            watermark.BindVisibility(() => this.IsPopupOpen);
            watermark.Bind(TextBlock.TextProperty, () => GetString(listBox.SelectedItem, this.DisplayMemberPath));
            this.Bind(TextBox.TextProperty, () => GetString(this.SelectedItem, this.DisplayMemberPath));
            listPresenter.Content = listBox;
            popup.Bind(Popup.IsOpenProperty, () => this.IsPopupOpen);
            //listPresenter.Bind(Popup.WidthProperty, () => this.RenderSize);

            toggleButton.SetTwoWayBinding(ToggleButton.IsCheckedProperty, this, "IsPopupOpen");
            
        }
        bool IsSelected = false;

        void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionContext.PreventRecursive(() =>
            {
                SetSelection(listBox.SelectedItem);
                IsSelected = true;
                this.Focus();
            });
        }

        private void SetSelection(object p)
        {
            if (this.SelectedItem != null && p != null && this.SelectedItem.Equals(p))
                return;
            this.SelectedItem = p;
            if (p != null && !string.IsNullOrEmpty(SelectedValuePath))
            {
                object obj = this.SelectedItem.Property(SelectedValuePath);
                if (this.SelectedValue == null || !obj.Equals(this.SelectedValue))
                    this.SelectedValue = obj;
            }

            this.IsPopupOpen = false;
        }

        private string GetString(object p, string path)
        {
            if (p == null)
                return string.Empty;
            if (string.IsNullOrEmpty(path))
                return p.ToString();
            object v = p.Property(path);
            if (v == null)
                return string.Empty;
            return v.ToString();
        }


        AtomLogicContext selectionContext = new AtomLogicContext();

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Key.Tab)
            {
                if (this.IsPopupOpen)
                {
                    this.SetSelection(listBox.SelectedItem);
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            selectionContext.PreventRecursive(() =>
            {
                if (e.Key == Key.Down)
                {
                    if (!this.IsPopupOpen)
                        this.IsPopupOpen = true;
                    else
                        if (listBox.Items.Count > listBox.SelectedIndex + 1)
                        {
                            listBox.SelectedIndex = listBox.SelectedIndex + 1;
                        }
                    this.Text = "";
                    return;
                }

                if (e.Key == Key.Up)
                {
                    if (!this.IsPopupOpen)
                        this.IsPopupOpen = true;
                    else
                        if (listBox.SelectedIndex > 0)
                            listBox.SelectedIndex = listBox.SelectedIndex - 1;
                    this.Text = "";
                    return;
                }

                if (e.Key == Key.Escape)
                {
                    listBox.SelectedItem = this.SelectedItem;
                    this.IsPopupOpen = false;
                }

                if (e.Key == Key.Enter)
                {
                    this.SetSelection(listBox.SelectedItem);
                }
            });
        }


        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);
            string t = e.Text.ToUpper();
            foreach (var item in ItemsSource)
            {
                object v = item.Property(DisplayMemberPath);
                if (v == null)
                    return;
                string s = v.ToString();
                if (s.ToUpper().StartsWith(t))
                {
                    selectionContext.PreventRecursive(() =>
                    {
                        listBox.SelectedItem = item;
                    });
                    return;
                }
            }
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (!this.IsPopupOpen && !IsSelected)
                this.IsPopupOpen = true;
            IsSelected = false;
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (this.IsPopupOpen)
                this.IsPopupOpen = false;
        }

		#region partial void  OnAfterIsPopupOpenChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterIsPopupOpenChanged(DependencyPropertyChangedEventArgs e)
		{
			if (this.IsPopupOpen)
			{
#if SILVERLIGHT
                if (FocusManager.GetFocusedElement() != this)
                    this.Focus();
#else
				if (Keyboard.FocusedElement != this)
					Keyboard.Focus(this);
#endif
				this.CallLater(ArrangePopup);
				//ArrangePopup();
			}
			else
			{
				this.Bind(TextProperty, () => GetString(this.SelectedItem, this.DisplayMemberPath));
				this.SelectAll();
			}
		}
		#endregion


        private void ArrangePopup()
        {
            if (popup == null)
                return;

            selectionContext.PreventRecursive(() =>
            {
                listBox.SelectedItem = this.SelectedItem;
            });

            this.Text = GetString(listBox.SelectedItem, this.DisplayMemberPath);
            this.SelectAll();


            listPresenter.Width = this.RenderSize.Width;

#if SILVERLIGHT
            UIElement rootVisual = Application.Current.RootVisual;
#else
            UIElement rootVisual = Window.GetWindow(this);
#endif

            GeneralTransform gt = this.TransformToVisual(rootVisual);
            Point offsetStart = gt.Transform(new Point());
            Size s = this.RenderSize;
            Point offsetEnd = gt.Transform(new Point(s.Width, s.Height));

            double rootHeight = rootVisual.RenderSize.Height;
            double height = offsetStart.Y;
            double bottom = offsetEnd.Y;
            double m = Math.Min(height, 150);
            if (m < rootHeight - bottom)
            {
                popup.VerticalOffset = this.ActualHeight;
                listPresenter.MaxHeight = rootHeight - bottom;
            }
            else
            {
                //AtomTrace.WriteLine(m.ToString());
                popup.Bind(Popup.VerticalOffsetProperty, () => -listPresenter.ActualHeight);
                //popup.VerticalOffset = - m;
                listPresenter.MaxHeight = m;
            }
        }

        #region partial void  OnAfterSelectedValuePropertyChanged(DependencyPropertyChangedEventArgs e)
        partial void OnAfterSelectedValueChanged(DependencyPropertyChangedEventArgs e)
        {
            ResetValue();
        }
        #endregion


        #region partial void  OnAfterItemsSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
        partial void OnAfterItemsSourceChanged(DependencyPropertyChangedEventArgs e)
        {
            INotifyCollectionChanged nc = e.OldValue as INotifyCollectionChanged;
            if (nc != null)
            {
                nc.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnCollectionChanged);
            }
            nc = e.NewValue as INotifyCollectionChanged;
            if (nc != null)
            {
                nc.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
            }
            this.CallLater(ResetValue);
            
        }
        #endregion


        protected virtual void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.CallLater(ResetValue);
        }

        private void ResetValue()
        {
            if (ItemsSource == null)
                return;
            if (string.IsNullOrEmpty(SelectedValuePath))
                return;

            selectionContext.PreventRecursive(() =>
            {
                if (SelectedValue == null)
                {
                    this.SelectedItem = null;
                    return;
                }
                foreach (var item in ItemsSource)
                {
                    object val = item.Property(SelectedValuePath);
                    if (val == null)
                        continue;
                    if (val.Equals(SelectedValue))
                    {
                        SelectedItem = item;
                        return;
                    }
                }
            });

        }
    }
}
