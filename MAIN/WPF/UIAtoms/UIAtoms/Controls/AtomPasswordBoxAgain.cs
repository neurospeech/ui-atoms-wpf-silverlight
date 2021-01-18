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
    public partial class AtomPasswordBoxAgain : AtomPasswordBox
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
			AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Password", ValidationRule = AtomUtils.GetDefaultInstance<AtomPasswordMatchValidationRule>() });
			AtomForm.SetInvalidValueMessage(this, "Password does not match");
		}
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
