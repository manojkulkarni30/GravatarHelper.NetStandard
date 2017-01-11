using System;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if (NET35)
[assembly: AssemblyTitle("GravatarHelper.NetStandard .NET 3.5")]
#elif (NET40)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.0")]
#elif (NET45)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.5")]
#elif (NET451)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.5.1")]
#elif (NET452)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.5.2")]
#elif (NET46)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.6")]
#elif (NET461)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.6.1")]
#elif (NET462)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET 4.6.2")]
#elif (NETSTANDARD1_3)
[assembly:AssemblyTitle("GravatarHelper.NetStandard .NET Standard 1.3")]
#elif (PORTABLE259)
[assembly:AssemblyTitle("GravatarHelper.NetStandard Portable 4.5")]
#else
[assembly:AssemblyTitle("GravatarHelper.NetStandard")]
#endif

[assembly: AssemblyDescription("A simple .Net Standard library to easily get profile picture, QR code image for profile and profile information for a user from Gravatar.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Manoj Kulkarni")]
[assembly: NeutralResourcesLanguage("en-us")]
[assembly: AssemblyProduct("GravatarHelper.NetStandard")]
[assembly: AssemblyVersion("1.0.0.*")]
[assembly: AssemblyCopyright("Copyright © Manoj Kulkarni 2017")]
[assembly: AssemblyTrademark("")]

#if !(PORTABLE259 || NETSTANDARD1_3)
// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("2320fe5d-b009-4969-a7e1-56e575d5491d")]
#endif