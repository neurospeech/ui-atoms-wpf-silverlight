#if NETFX_CORE
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
    public partial class AtomTitleTextBox : AtomTextBox
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


		#region partial void  OnAfterCapitalizeAllChanged(DependencyPropertyChangedEventArgs e)
		partial void OnAfterCapitalizeAllChanged(DependencyPropertyChangedEventArgs e)
		{
			OnCapitalize();
		}
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
 
