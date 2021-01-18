#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Interaction logic for AtomPrompt.xaml
    /// </summary>
    public partial class AtomPrompt : Window
    {
        /// <summary>
        /// 
        /// </summary>
        public AtomPrompt()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        ///<summary>
        /// Dependency Property PromptTitle
        ///</summary>
        #region Dependency Property PromptTitle
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string PromptTitle
        {
            get { return (string)GetValue(PromptTitleProperty); }
            set { SetValue(PromptTitleProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for PromptTitle.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty PromptTitleProperty =
            DependencyProperty.Register("PromptTitle", typeof(string), typeof(AtomPrompt), new UIPropertyMetadata("Please Enter The Text"));


        #endregion



        ///<summary>
        /// Dependency Property PromptDescription
        ///</summary>
        #region Dependency Property PromptDescription
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string PromptDescription
        {
            get { return (string)GetValue(PromptDescriptionProperty); }
            set { SetValue(PromptDescriptionProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for PromptDescription.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty PromptDescriptionProperty =
            DependencyProperty.Register("PromptDescription", typeof(string), typeof(AtomPrompt), new UIPropertyMetadata("Please Enter The Text"));


        #endregion

        ///<summary>
        /// Dependency Property PromptValue
        ///</summary>
        #region Dependency Property PromptValue
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string PromptValue
        {
            get { return (string)GetValue(PromptValueProperty); }
            set { SetValue(PromptValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for PromptValue.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty PromptValueProperty =
            DependencyProperty.Register("PromptValue", typeof(string), typeof(AtomPrompt), new UIPropertyMetadata("Undefined.."));


        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textField.SelectAll();
            textField.Focus();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static string Prompt(
            string title,
            string desc,
            string def) 
        {
            AtomPrompt p = new AtomPrompt();
            p.PromptTitle = title;
            p.PromptDescription = desc;
            p.PromptValue = def;
            if (p.ShowDialog() == true) {
                return p.PromptValue;
            }
            return def;
        }

    }
}
