using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using OpenTap.Plugins.PreLoadCode;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("OpenTap.Plugins.PreLoadCode")]
[assembly: AssemblyDescription("OpenTAP Plugin")]
[assembly: AssemblyCompany("Keysight Technologies")]
[assembly: AssemblyProduct("OpenTap.Plugins.PreLoadCode")]
[assembly: AssemblyCopyright("Copyright © Keysight Technologies 2022")]

// Full name of method that is run before any other plugin code is run or types loaded
[assembly:OpenTap.PluginAssembly(false, $"{nameof(OpenTap)}.{nameof(OpenTap.Plugins)}.{nameof(OpenTap.Plugins.PreLoadCode)}.{nameof(PrePluginLoad)}.{nameof(PrePluginLoad.RunBeforePluginLoad)}")]

[assembly:InternalsVisibleTo("OpenTap.Plugins.PreLoadCode.Test")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("368bfa40-9b9f-4c8c-84df-2dd666bede4c")]

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
[assembly: AssemblyVersion("0.1.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0-Development")]
