#if WINRT
using Windows.UI.Xaml.Markup;
#else
using System.Windows.Markup;
#endif
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NeuroSpeech.UIAtoms.Silverlight")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NeuroSpeech.UIAtoms.Silverlight")]
[assembly: AssemblyCopyright("Copyright ©  2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("937395d3-8538-4b01-a210-0dfa29b7d86d")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: XmlnsDefinition("http://uiatoms.neurospeech.com/silverlight", "NeuroSpeech.UIAtoms.Controls")]
[assembly: XmlnsPrefix("http://uiatoms.neurospeech.com/silverlight", "ns")]

[assembly: XmlnsDefinition("http://uiatoms.neurospeech.com/silverlight/buttons", "NeuroSpeech.UIAtoms.Controls.Buttons")]
[assembly: XmlnsPrefix("http://uiatoms.neurospeech.com/silverlight/buttons", "nsb")]

[assembly: XmlnsDefinition("http://uiatoms.neurospeech.com/silverlight/validations", "NeuroSpeech.UIAtoms.Validation")]
[assembly: XmlnsPrefix("http://uiatoms.neurospeech.com/silverlight/validations", "nsv")]

[assembly: XmlnsDefinition("http://uiatoms.neurospeech.com/silverlight/unitcontrols", "NeuroSpeech.UIAtoms.UnitControls")]
[assembly: XmlnsPrefix("http://uiatoms.neurospeech.com/silverlight/unitcontrols", "nsu")]

[assembly: XmlnsDefinition("http://uiatoms.neurospeech.com/silverlight/mathcontrols", "NeuroSpeech.UIAtoms.MathControls")]
[assembly: XmlnsPrefix("http://uiatoms.neurospeech.com/silverlight/mathcontrols", "nsm")]
