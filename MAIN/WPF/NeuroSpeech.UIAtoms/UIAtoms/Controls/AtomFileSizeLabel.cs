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
    /// Displays file size in Human readable format.
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomFileSizeLabel : BaseAtomTextBlock
    {
        /// <summary>
        /// 
        /// </summary>
        public AtomFileSizeLabel()
        {

        }


        /// <summary>
        /// FileSizeText is for internal use only
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FileSizeText
        /// </listheader>
        /// 		<item>
        /// This property is for internal use only.
        /// </item>
        /// 		<item>
        /// This property converts the bytes received in FileSize into a readable format of filesize in MB, GB, etc..
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property FileSizeText
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string FileSizeText
        {
            get { return (string)GetValue(FileSizeTextProperty); }
            set { SetValue(FileSizeTextProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for FileSizeText.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty FileSizeTextProperty =
            DependencyProperty.Register("FileSizeText", typeof(string), typeof(AtomFileSizeLabel), new UIPropertyMetadata("", OnFileSizeTextChangedCallback));

        private static void OnFileSizeTextChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFileSizeLabel obj = d as AtomFileSizeLabel;
            if (obj != null)
            {
                obj.OnFileSizeTextChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileSizeTextChanged(DependencyPropertyChangedEventArgs e)
        {
            ulong n = 0;
            if (ulong.TryParse(FileSizeText, out n))
            {
                FileSize = n;
            }

            if (FileSizeTextChanged != null)
            {
                FileSizeTextChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler FileSizeTextChanged;

        #endregion

        /// <summary>
        /// FileSize is for internal use only
        /// </summary>
        /// <remarks>
        /// 	<list type="bullet">
        /// 		<listheader>
        /// FileSize
        /// </listheader>
        /// 		<item>
        /// This property is set for internal use only. 
        /// </item>
        /// 		<item>
        /// It receives the byte value of the file size.
        /// </item>
        /// 	</list>
        /// </remarks>
        #region Dependency Property FileSize
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public ulong FileSize
        {
            get { return (ulong)GetValue(FileSizeProperty); }
            set { SetValue(FileSizeProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for FileSize.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty FileSizeProperty =
            DependencyProperty.Register("FileSize", typeof(ulong), typeof(AtomFileSizeLabel), new UIPropertyMetadata((ulong)0, OnFileSizeChangedCallback));

        private static void OnFileSizeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AtomFileSizeLabel obj = d as AtomFileSizeLabel;
            if (obj != null)
            {
                obj.OnFileSizeChanged(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileSizeChanged(DependencyPropertyChangedEventArgs e)
        {
            Text = string.Format(new AtomSizeFormatProvider(), "{0:sz}", FileSize);
            if (FileSizeChanged != null)
            {
                FileSizeChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler FileSizeChanged;

        #endregion

    }
}
