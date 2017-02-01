# GravatarHelper.NetStandard

A simple [.Net standard library](https://docs.microsoft.com/en-us/dotnet/articles/standard/library) to easily get profile picture URL, QR code image URL for profile and profile information for a user using email address from [Gravatar](http://en.gravatar.com/).


## Setup
- Available on Nuget: https://www.nuget.org/packages/GravatarHelper.NetStandard
- To use this library in Xamarin.Forms application, install the [GravatarHelper.NetStandard](https://www.nuget.org/packages/GravatarHelper.NetStandard) nuget package in portable class library and [PCLCrypto](https://www.nuget.org/packages/PCLCrypto/) package in each client project (e.g Android, iOS and UWP).

## Build Status

![App Veyor](https://ci.appveyor.com/api/projects/status/9gwwfn9lb0bxq846?svg=true)
[![MyGet CI](https://img.shields.io/myget/manojkulkarni30/v/GravatarHelper.NetStandard.svg)](http://myget.org/gallery/manojkulkarni30)
[![NuGet](https://img.shields.io/nuget/v/GravatarHelper.NetStandard.svg)](https://www.nuget.org/packages/GravatarHelper.NetStandard/)

## Supported Platform
- .NetFramework 3.5
- .NetFramework 4
- .NetFramework 4.5
- .NetFramework 4.5.1
- .NetFramework 4.5.2
- .NetFramework 4.6
- .NetFramework 4.6.1
- .NetFramework 4.6.2
- .NetStandard 1.3
- Portable Class Library (.NETFramework 4.5, Windows 8.0, WindowsPhone 8.0, WindowsPhoneApp 8.1)- Profile 259

## Get Gravatar Image URL:

To get gravatar image URL for email address "[example@test.com](mailto:example@test.com)", use the following syntax.

```csharp

Gravatar.GetGravatarImageUrl("example@test.com");

```
To get image URL over https, use following syntax
```csharp

Gravatar.GetSecureGravatarImageUrl("example@test.com");

```
There are different overload methods available where you can specify different parameters like image size, required extension for an image, rating, gravatar default image type etc. 

## Get the QR Code Image URL:

To get the QR code image URL for email address "[example@test.com](mailto:example@test.com)", use the following syntax.

```csharp

Gravatar.GetGravatarProfileQrCodeImage("example@test.com");

```

## Get Gravatar Profile Information:

To get the gravatar profile information for a user using email address "[example@test.com](mailto:example@test.com)", use the following syntax.

```csharp

// Available only for .Net Framework 4.5 and above
await Gravatar.GetGravatarProfileInformationAsync("example@test.com");

// For .Net Framework 3.5 and 4.0
Gravatar.GetGravatarProfileInformation("example@test.com");

```
Above method will return an object of type ```OperationResult```. 

```csharp

    public class OperationResult
    {
        public bool Success { get; set; }

        public ProfileInformation Profile { get; set; }

        public string Error { get; set; }
    }

```
If request for profile information is successful, then ```Success``` property will be set to true and ```Profile``` object will contain the profile information.

If request for profile information failed, then ```Success``` property will be set to false, ```Profile``` object will be ```null``` and ```Error``` property will contain the error message.

**Note: Profile requests will only resolve for the primary email address**

## License

[Apache 2.0](https://github.com/manojkulkarni30/GravatarHelper.NetStandard/blob/master/License.txt)