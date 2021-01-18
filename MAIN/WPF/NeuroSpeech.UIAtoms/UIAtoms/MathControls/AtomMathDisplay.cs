#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.Diagnostics;

namespace NeuroSpeech.UIAtoms.MathControls
{
    /// <summary>
    /// </summary>
    public class AtomMathDisplay : ContentControl
    {




        ///<summary>
        ///DependencyProperty EquationText
        ///</summary>
        #region Dependency Property EquationText
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string EquationText
        {
            get { return (string)GetValue(EquationTextProperty); }
            set { SetValue(EquationTextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for EquationText.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty EquationTextProperty = 
    DependencyProperty.Register("EquationText", typeof(string), typeof(AtomMathDisplay), new PropertyMetadata("",OnEquationTextChangedCallback));
#else
        public static readonly DependencyProperty EquationTextProperty =
            DependencyProperty.Register("EquationText", typeof(string), typeof(AtomMathDisplay), new FrameworkPropertyMetadata("", OnEquationTextChangedCallback));
#endif

        private static void OnEquationTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomMathDisplay obj = d as AtomMathDisplay;
            if (obj != null)
            {
                obj.OnEquationTextChanged(e);
            }
        }

        /// <summary>
        /// Fires EquationTextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEquationTextChanged(DependencyPropertyChangedEventArgs e)
        {

            RefreshText();


            if (EquationTextChanged != null)
            {
                EquationTextChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler EquationTextChanged;

        #endregion


        private void RefreshText() {
            string text = EquationText;
            if (string.IsNullOrEmpty(text))
                return;

            try
            {
                this.Content = AtomMathReader.Load(text, EquationLanguage);
            }
            catch (Exception ex)
            {
                AtomTrace.WriteLine(ex.ToString());
            }
        }


        ///<summary>
        ///DependencyProperty EquationLanguage
        ///</summary>
        #region Dependency Property EquationLanguage
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public AtomMathLanguage EquationLanguage
        {
            get { return (AtomMathLanguage)GetValue(EquationLanguageProperty); }
            set { SetValue(EquationLanguageProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for EquationLanguage.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty EquationLanguageProperty = 
    DependencyProperty.Register("EquationLanguage", typeof(AtomMathLanguage), typeof(AtomMathDisplay), new PropertyMetadata(AtomMathLanguage.MathXML,OnEquationLanguageChangedCallback));
#else
        public static readonly DependencyProperty EquationLanguageProperty =
            DependencyProperty.Register("EquationLanguage", typeof(AtomMathLanguage), typeof(AtomMathDisplay), new FrameworkPropertyMetadata(AtomMathLanguage.MathXML, OnEquationLanguageChangedCallback));
#endif

        private static void OnEquationLanguageChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomMathDisplay obj = d as AtomMathDisplay;
            if (obj != null)
            {
                obj.OnEquationLanguageChanged(e);
            }
        }

        /// <summary>
        /// Fires EquationLanguageChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnEquationLanguageChanged(DependencyPropertyChangedEventArgs e)
        {
            RefreshText();
            if (EquationLanguageChanged != null)
            {
                EquationLanguageChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler EquationLanguageChanged;

        #endregion




    }
}
