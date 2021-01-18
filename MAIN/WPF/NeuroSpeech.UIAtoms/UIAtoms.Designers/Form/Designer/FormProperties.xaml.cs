using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    /// <summary>
    /// Interaction logic for FormProperties.xaml
    /// </summary>
    public partial class FormProperties : UserControl
    {
        public FormProperties()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
        }



        ///<summary>
        ///DependencyProperty FormItem
        ///</summary>
        #region Dependency Property FormItem
        public FormItemModel FormItem
        {
            get { return (FormItemModel)GetValue(FormItemProperty); }
            set { SetValue(FormItemProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for FormItem.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty FormItemProperty =
            DependencyProperty.Register("FormItem", typeof(FormItemModel), typeof(FormProperties), new FrameworkPropertyMetadata(null, OnFormItemChangedCallback));

        private static void OnFormItemChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FormProperties obj = d as FormProperties;
            if (obj != null)
            {
                obj.OnFormItemChanged(e);
            }
        }

        /// <summary>
        /// Fires FormItemChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFormItemChanged(DependencyPropertyChangedEventArgs e)
        {
            this.DataContext = e.NewValue;
            if (e.NewValue != null)
                this.Visibility = System.Windows.Visibility.Visible;
            if (FormItemChanged != null)
            {
                FormItemChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler FormItemChanged;

        #endregion


    }
}
