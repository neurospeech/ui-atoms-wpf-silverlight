#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
#else
using System.Windows;
using System.Windows.Media;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// AtomImageButton is a collection of advanced buttons with images and commonly used functionalities preset.
    /// </summary>
    /// <remarks>
    /// 	<list type="bullet">
    /// 		<listheader>
    /// AtomImageButton
    /// </listheader>
    /// 		<item>
    /// 			<para>
    /// Commonly used buttons like delete, submit, cancel, play, stop, etc.. with their universally accepted symbols or images are preset on these buttons. Their functionalities are standard, and their error messages can be customized as per the application's needs.
    /// </para>
    /// 		</item>
    /// 	</list>
    /// </remarks>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomImageButton : AtomButton
    {

#if SILVERLIGHT
        public AtomImageButton()
        {
            DefaultStyleKey = typeof(AtomImageButton);
        }
#else
        static AtomImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(AtomImageButton),
                new FrameworkPropertyMetadata(typeof(AtomImageButton)));
        }
#endif



        /// <summary>
        /// ImageSource sets the icon for the AtomAdvancedButton
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// ImageSource
        /// </listheader>
        /// 		<item>
        /// This property defines the source of the icon that needs to be displayed on the advanced buttons
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property ImageSource
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        ///</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(AtomImageButton), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(AtomImageButton), new UIPropertyMetadata(null));
#endif

        #endregion





    }
}
