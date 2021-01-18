#if NETFX_CORE
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
    /// 
    /// </summary>
    public partial class AtomValueDialogButton : AtomImageButton
    {



        /// <summary>
        /// 
        /// </summary>
        protected override void OnClick()
        {
            base.OnClick();



#if SILVERLIGHT
            Type t = Type.GetType(DialogTypeName);
            if (t == null)
            {
                //MessageBox.Show("Dialog Type not set", "Error", MessageBoxButton.OK);
                return;
            }

            ChildWindow avd = Activator.CreateInstance(t) as ChildWindow;
            if (avd == null) {
                MessageBox.Show("DialogType should be derived from Window", "Error", MessageBoxButton.OK);
                return;
            }
            avd.Title = Title;
            IAtomValueProvider ivp = avd as IAtomValueProvider;
            if (ivp == null)
            {
                MessageBox.Show("DialogType must implement IAtomValueProvider", "Error", MessageBoxButton.OK);
                return;
            }
            ivp.Value = this.Value;
            avd.Closed += (s, e) => {
                if (avd.DialogResult == true) {
                    this.Value = ivp.Value;
                }
            };
            avd.Show();
#else

            Type t = DialogType;
            if (t == null)
            {
                //MessageBox.Show("Dialog Type not set", "Error", MessageBoxButton.OK);
                return;
            }
            
            Window avd = Activator.CreateInstance(t) as Window;
            if (avd == null) {
                MessageBox.Show("DialogType should be derived from Window", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            avd.Title = Title;
            IAtomValueProvider ivp = avd as IAtomValueProvider;
            if (ivp == null) {
                MessageBox.Show("DialogType must implement IAtomValueProvider", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ivp.Value = this.Value;
            if (avd.ShowDialog() == true) {
                this.Value = ivp.Value;
            }
#endif
        }        

    }
}
