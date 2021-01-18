#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// Textbox that automatically converts input text into Title Case.
    /// </summary>
    /// <remarks>
    /// 	<para>
    /// Essentially an AtomTextBox, this converts all input text into title case or upper case, depending upon the parameter settings. 
    /// </para>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomTitleTextBox : AtomTextBox
    {

#if SILVERLIGHT
        public AtomTitleTextBox()
        {
            this.TextChanged += new System.Windows.Controls.TextChangedEventHandler(AtomTitleTextBox_TextChanged);
        }

        void AtomTitleTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            OnCapitalize();
        }

#endif
        private AtomLogicContext selectionContext = new AtomLogicContext();

        /// <summary>
        /// CapitalizeAll capitalizes all the characeters of the TextBox
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// CapitalizeAll
        /// </listheader>
        /// 		<item>
        /// This property capitalizes all the text input in the AtomTextBox instead of setting the text in Title Case.
        /// </item>
        /// 		<item>
        /// The default is set to fault.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property CapitalizeAll
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public bool CapitalizeAll
        {
            get { return (bool)GetValue(CapitalizeAllProperty); }
            set { SetValue(CapitalizeAllProperty, value); }
        }

        ///<summary>
        ///Using a DependencyProperty as the backing store for CapitalizeAll.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty CapitalizeAllProperty =
            DependencyProperty.Register("CapitalizeAll", typeof(bool), typeof(AtomTitleTextBox), new PropertyMetadata(false));
#else
        public static readonly DependencyProperty CapitalizeAllProperty =
            DependencyProperty.Register("CapitalizeAll", typeof(bool), typeof(AtomTitleTextBox), new UIPropertyMetadata(false));
#endif

        #endregion

        /// <summary>
        /// IgnoreWords is a list of words that the system must ignore while setting to Title Case
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// IgnoreWords
        /// </listheader>
        /// 		<item>
        /// This property is a string where words which need to be ignored during Title Case can be listed.
        /// </item>
        /// 		<item>
        /// Typical words that need to be ignored while converting to Title Case are words like a, of, the, etc..
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property IgnoreWords
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string IgnoreWords
        {
            get { return (string)GetValue(IgnoreWordsProperty); }
            set { SetValue(IgnoreWordsProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for IgnoreWords.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty IgnoreWordsProperty =
            DependencyProperty.Register("IgnoreWords", typeof(string), typeof(AtomTitleTextBox), new PropertyMetadata("of, at, in, with, is, a, an, the", OnIgnoreWordsChangedCallback));
#else
        public static readonly DependencyProperty IgnoreWordsProperty =
            DependencyProperty.Register("IgnoreWords", typeof(string), typeof(AtomTitleTextBox), new UIPropertyMetadata("of, at, in, with, is, a, an, the", OnIgnoreWordsChangedCallback));
#endif
        private static void OnIgnoreWordsChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomTitleTextBox obj = d as AtomTitleTextBox;
            if (obj != null)
            {
                obj.OnIgnoreWordsChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnIgnoreWordsChanged(DependencyPropertyChangedEventArgs e)
        {
            OnCapitalize();
            if (IgnoreWordsChanged != null)
            {
                IgnoreWordsChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler IgnoreWordsChanged;

        #endregion



#if !SILVERLIGHT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnTextChanged(System.Windows.Controls.TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnCapitalize();
        }

#endif
        private void OnCapitalize()
        {
            selectionContext.PreventRecursive(() =>
            {
                string text = this.Text;
                int i = this.SelectionStart;
                int l = this.SelectionLength;
                text = AtomUtils.TitleCapitalize(text, CapitalizeAll, IgnoreWords);
                this.Text = text;
                this.Select(i, l);
            });
        }
    }
}
 
