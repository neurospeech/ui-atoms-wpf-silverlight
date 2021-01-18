#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    public class AtomValueDialogButton : AtomImageButton
    {



#if SILVERLIGHT

        ///<summary>
        ///
        ///</summary>
        #region Dependency Property DialogTypeName
        [System.ComponentModel.Category("Category")]
        public string DialogTypeName
        {
            get { return (string)GetValue(DialogTypeNameProperty); }
            set { SetValue(DialogTypeNameProperty, value); }
        }

        ///<summary>
        ///
        ///</summary>
        public static readonly DependencyProperty DialogTypeNameProperty =
            DependencyProperty.Register("DialogTypeName", typeof(string), typeof(AtomValueDialogButton), new PropertyMetadata(""));

        #endregion

#else
        ///<summary>
        ///DependencyProperty DialogType
        ///</summary>
        #region Dependency Property DialogType
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public Type DialogType
        {
            get { return (Type)GetValue(DialogTypeProperty); }
            set { SetValue(DialogTypeProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for DialogType.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty DialogTypeProperty =
            DependencyProperty.Register("DialogType", typeof(Type), typeof(AtomValueDialogButton), new UIPropertyMetadata(null));
        #endregion
#endif


        ///<summary>
        ///DependencyProperty Value
        ///</summary>
        #region Dependency Property Value
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(AtomValueDialogButton),
            new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(AtomValueDialogButton), 
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
#endif
        #endregion



        ///<summary>
        /// Dependency Property Title
        ///</summary>
        #region Dependency Property Title
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("Title", typeof(string), typeof(AtomValueDialogButton), new PropertyMetadata("", OnTitleChangedCallback));
            
        private static void OnTitleChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
          AtomValueDialogButton obj = d as AtomValueDialogButton;
}
    
#else
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AtomValueDialogButton), new FrameworkPropertyMetadata(""));
#endif

        #endregion






        /// <summary>
        /// 
        /// </summary>
        protected override void OnClick()
        {
            base.OnClick();



#if SILVERLIGHT
            Type t = Type.GetType(DialogTypeName);
            if (t == null)
            {
                //MessageBox.Show("Dialog Type not set", "Error", MessageBoxButton.OK);
                return;
            }

            ChildWindow avd = Activator.CreateInstance(t) as ChildWindow;
            if (avd == null) {
                MessageBox.Show("DialogType should be derived from Window", "Error", MessageBoxButton.OK);
                return;
            }
            avd.Title = Title;
            IAtomValueProvider ivp = avd as IAtomValueProvider;
            if (ivp == null)
            {
                MessageBox.Show("DialogType must implement IAtomValueProvider", "Error", MessageBoxButton.OK);
                return;
            }
            ivp.Value = this.Value;
            avd.Closed += (s, e) => {
                if (avd.DialogResult == true) {
                    this.Value = ivp.Value;
                }
            };
            avd.Show();
#else

            Type t = DialogType;
            if (t == null)
            {
                //MessageBox.Show("Dialog Type not set", "Error", MessageBoxButton.OK);
                return;
            }
            
            Window avd = Activator.CreateInstance(t) as Window;
            if (avd == null) {
                MessageBox.Show("DialogType should be derived from Window", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            avd.Title = Title;
            IAtomValueProvider ivp = avd as IAtomValueProvider;
            if (ivp == null) {
                MessageBox.Show("DialogType must implement IAtomValueProvider", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ivp.Value = this.Value;
            if (avd.ShowDialog() == true) {
                this.Value = ivp.Value;
            }
#endif
        }        

    }
}
