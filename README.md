## Multilingual Plugin for Xamarin Forms, Xamarin iOS and Android
Simple cross platform plugin for handling language localization.

<p align="center">
<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual.gif" height="400" width="240" title="Multilingual"/>
</p>

## Features

- Get and set current culture
- Get device culture
- Get culture list
- Get specific culture by name

**Platform Support**

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 7+|
|Xamarin.Android|API 15+|

### Setup
* Available on NuGet: http://www.nuget.org/packages/Plugin.Multilingual [![NuGet](https://img.shields.io/nuget/v/Plugin.Multilingual.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.Multilingual/)
* Install into your PCL project and Client projects.

### Getting Started

1. Add your Resx files 

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual - setup1.png"  title="Multilingual" height="350" width="500" />

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual - setup2.png"  title="Multilingual"/>

Add one resx file per each language you want to support. "It must follow a specific naming convention: use the same filename as the base resources file (eg. AppResources) followed by a period (.) and then the language code".

2. Set the culture of your resource class file when initializing your application. 

For example:
```csharp
  AppResources.Culture = CrossMultilingual.Current.DeviceCultureInfo;
```
<i>If you are using Xamarin Forms it would be in your App.cs</i>

### Xamarin Forms Specifics

When installing the plugin it will create a **TranslateExtension.txt** file in folder Helpers, rename the extension for this file to **TranslateExtension.cs**.

In **TranslateExtension.cs** file in the constant **ResourceId** by default it will assume your resource file is added in the root of the project and the resx file is named as AppResources. If you added it to a folder or named the resx file differently you can change it there.

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual -forms1.png"  title="Multilingual"/>

XAML sample usage:

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual -xaml.png"  title="Multilingual"/>

### iOS Considerations

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual - step1.png"  title="Multilingual" height="150" width="500" />

In the Info.plist file add the keys **Localizations** & **Localization native development region** to change the user interface OS elements. It will take the device language.

<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/multilingual - step2.png" title="Multilingual" height="250" width="400" />

### API Usage

Call **CrossMultilingual.Current** from any project or PCL to gain access to APIs.

**CurrentCultureInfo**

Gets and set the current culture. By default will be set to the device culture.

Usage sample:
```csharp
  CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
```
Note: After changing the current culture is important to update your resx class culture. As follows:

```csharp
AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
```

**DeviceCultureInfo**

Gets the device culture

Usage sample:
```csharp
  CrossMultilingual.Current.DeviceCultureInfo;
```

**CultureInfoList**

Gets all cultures supported in .NET Framework (neutral & specific cultures)

Usage sample:
```csharp
  CrossMultilingual.Current.CultureInfoList;
```


**NeutralCultureInfoList**

Gets all cultures associated with a language (not specific to a country/region).

Usage sample:
```csharp
  CrossMultilingual.Current.NeutralCultureInfoList;
```


**GetCultureInfo**

Gets a specific culture by language code.

Usage sample:
```csharp
  CrossMultilingual.Current.GetCultureInfo("es");
```

In case you want to know more about localization:

https://developer.xamarin.com/guides/xamarin-forms/advanced/localization/

### Contributors

* [Charlin Agramonte](https://github.com/char0394)
* [Rendy Del Rosario](https://github.com/rdelrosario)

