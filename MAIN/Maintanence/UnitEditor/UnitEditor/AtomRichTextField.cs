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
using NeuroSpeech.UIAtoms.Core;

namespace UnitEditor
{
    /// <summary>
    /// </summary>
    [TemplatePart(Name = "PART_Text", Type = typeof(AtomRichTextBox))]
    public class AtomRichTextField : Control
    {
        static AtomRichTextField()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomRichTextField), new FrameworkPropertyMetadata(typeof(AtomRichTextField)));

            //HorizontalAlignmentProperty.OverrideMetadata(typeof(AtomRichTextField), new FrameworkPropertyMetadata(HorizontalAlignment.Left));
        }

        AtomRichTextBox PART_Text;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Text = GetTemplateChild("PART_Text") as AtomRichTextBox;
        }

        ///<summary>
        ///DependencyProperty Text
        ///</summary>
        #region Dependency Property Text
        [AtomDesign(
          Category = "Atoms",
          Bindable = true,
          BrowseMode = AtomPropertyBrowseMode.Default
        )]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
public static readonly DependencyProperty TextProperty = 
    DependencyProperty.Register("Text", typeof(string), typeof(AtomRichTextField), new PropertyMetadata("",OnTextChangedCallback));
#else
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(AtomRichTextField), new FrameworkPropertyMetadata("", OnTextChangedCallback));
#endif

        private static void OnTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomRichTextField obj = d as AtomRichTextField;
            if (obj != null)
            {
                obj.OnTextChanged(e);
            }
        }

        /// <summary>
        /// Fires TextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e)
        {

            if (TextChanged != null)
            {
                TextChanged(this, EventArgs.Empty);
            }
        }

        ///<summary>
        ///
        ///</summary>
        public event EventHandler TextChanged;

        #endregion





    }
}
