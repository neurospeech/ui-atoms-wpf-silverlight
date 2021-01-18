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
    /// </summary>
    public partial class AtomUsernameTextBox : AtomTextBox
    {

		#region partial void  OnCreate()
		partial void OnCreate()
		{
#if SILVERLIGHT
            AtomUsernameValidationRule.SetMinimumLength(this, 5);
            AtomForm.SetMissingValueMessage(this, "Username is required");
            WatermarkText = "Alpha numeric only";
#endif
			AtomForm.SetAtomValidator(this, new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomUsernameValidationRule>() });
		}
		#endregion


		#region static partial void  OnCreateStatic()
		static partial void OnCreateStatic()
		{
#if SILVERLIGHT || NETFX_CORE
#else
			AtomUsernameValidationRule.MinimumLengthProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata(5));
			AtomForm.MissingValueMessageProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata("Username is required"));

			WatermarkTextProperty.OverrideMetadata(typeof(AtomUsernameTextBox), new FrameworkPropertyMetadata("Alpha numeric only"));

			AtomForm.AtomValidatorProperty.OverrideMetadata(
				typeof(AtomUsernameTextBox),
				new FrameworkPropertyMetadata(new AtomPropertyValidator { Property = "Text", ValidationRule = AtomUtils.GetDefaultInstance<AtomUsernameValidationRule>() }));
#endif
		}
		#endregion


    }
}
