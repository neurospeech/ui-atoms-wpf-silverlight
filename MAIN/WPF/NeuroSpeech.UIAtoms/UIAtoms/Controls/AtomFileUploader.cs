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

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// </summary>
    public class AtomFileUploader : Control
    {


#if SILVERLIGHT
        public AtomFileUploader()
        {
            this.DefaultStyleKey = typeof(AtomFileUploader);
        }
#else
        static AtomFileUploader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomFileUploader), new FrameworkPropertyMetadata(typeof(AtomFileUploader)));
        }
#endif

        /// <summary>
        /// Start uploading...
        /// </summary>
        public void Upload() 
        {
            
        }



    }
}
