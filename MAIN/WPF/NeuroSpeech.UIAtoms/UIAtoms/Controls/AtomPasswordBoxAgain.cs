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
using NeuroSpeech.UIAtoms.Validation;
using System.ComponentModel;

namespace NeuroSpeech.UIAtoms.Controls
{
    /// <summary>
    /// Automates logic of verifying same passwords entered in FirstPasswordBox
    /// </summary>
    [AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atoms"
        )]
    public class AtomPasswordBoxAgain : AtomPasswordBox
    {

        /// <summary>
        /// 
        /// </summary>
        public AtomPasswordBoxAgain()
        {
            AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Password", ValidationRule = AtomUtils.GetDefaultInstance<AtomPasswordMatchValidationRule>() });
            AtomForm.SetInvalidValueMessage(this, "Password does not match");
        }



        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property FirstPasswordBoxName
        [AtomDesign(
            Category = "Atoms",
            Bindable = true,
            BrowseMode = AtomPropertyBrowseMode.Default
            )]
        public string FirstPasswordBoxName
        {
            get { return (string)GetValue(FirstPasswordBoxNameProperty); }
            set { SetValue(FirstPasswordBoxNameProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for FirstPasswordBox.  This enables animation, styling, binding, etc...</summary>
#if SILVERLIGHT
        public static readonly DependencyProperty FirstPasswordBoxNameProperty =
            DependencyProperty.Register("FirstPasswordBoxName", typeof(string), typeof(AtomPasswordBoxAgain), new PropertyMetadata(null));
#else
        public static readonly DependencyProperty FirstPasswordBoxNameProperty =
            DependencyProperty.Register("FirstPasswordBoxName", typeof(string), typeof(AtomPasswordBoxAgain), new UIPropertyMetadata(null));
#endif

        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Property FirstPasswordBox
        public AtomPasswordBox FirstPasswordBox
        {
            get
            {
                if (_FirstPasswordBox == null) {

                    string name = this.FirstPasswordBoxName;
                    if (name == null)
                    {
                        throw new InvalidOperationException("Please define FirstPasswordBox Property of NSPasswordAgain Control");
                    }

                    object obj = AtomUtils.FindControl(this, name);
                    if (obj == null)
                    {
                        throw new InvalidOperationException("Control named '" + FirstPasswordBoxName + "' not found.");
                    }
                    AtomPasswordBox pb = obj as AtomPasswordBox;
                    if (pb == null)
                    {
                        throw new InvalidOperationException("Control named '" + FirstPasswordBoxName + "' is not of the type NSPasswordBox.");
                    }
                    return pb;
                }
                return _FirstPasswordBox;
            }
            set
            {
                _FirstPasswordBox = value;
            }
        }

        private AtomPasswordBox _FirstPasswordBox = null;

        #endregion
	



    }
}
