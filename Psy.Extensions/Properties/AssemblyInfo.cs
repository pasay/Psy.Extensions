using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Psy.Extensions")]
[assembly: AssemblyDescription("Nesnelere genişletilmiş özellikler ekleyen kütüphanedir.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Pasa YAZICI")]
[assembly: AssemblyProduct("pasay")]
[assembly: AssemblyCopyright("Copyright ©2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("af43f8da-0f45-4579-b9d1-e44b39df0a89")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("2.0.0.0")]
#if !WindowsCE
[assembly: AssemblyFileVersion("1.0.0.0")]
#else
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
#endif
