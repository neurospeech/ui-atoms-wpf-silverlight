#if NETFX_CORE
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
using NeuroSpeech.UIAtoms.Validation;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
#if SILVERLIGHT
    [TemplateVisualState(Name = "Focused")]
    [TemplateVisualState(Name = "Pressed")]
    [TemplateVisualState(Name = "Normal")]
#endif
    public partial class AtomErrorDisplay : Control
    {


#if SILVERLIGHT

        private TextBlock innerTB;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            innerTB = GetTemplateChild("textBlock") as TextBlock;
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            VisualStateManager.GoToState(this, "Focused", true);

            if (innerTB != null) {
                innerTB.TextDecorations = TextDecorations.Underline;
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            VisualStateManager.GoToState(this, "Normal", true);
            if (innerTB != null) {
                innerTB.TextDecorations = null;
            }
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            IsPressed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);

            IsPressed = false;

            AtomPasswordBox ap = ValidationError.Source as AtomPasswordBox;
            if (ap != null) {
                ap.FocusPasswordBox();
                return;
            }

#if !SILVERLIGHT
            // set focus to error source...
            IInputElement ie = ValidationError.Source as IInputElement;
            if (ie != null)
            {
                Keyboard.Focus(ie);
                return;
            }
#endif

            Control c = ValidationError.Source as Control;
            if (c != null) 
            {
                c.Focus();
            }
        }

    }
}
