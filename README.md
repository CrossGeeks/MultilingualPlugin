## Multilingual Plugin for Xamarin Forms, Xamarin iOS and Android
Simple cross platform plugin for handling language localization.

<p align="center">
<img src="https://github.com/CrossGeeks/MultilingualPlugin/blob/master/Multilingual.gif" title="Multilingual"/>
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

### Xamarin Forms Specifics

When installing the plugin it will create a **TranslateExtension.txt** file in folder Helpers, rename the extension for this file to **TranslateExtension.cs**.


### API Usage

Call **CrossMultilingual.Current** from any project or PCL to gain access to APIs.

**CurrentCultureInfo**

Gets and set the current culture. By default will be set to the device culture.

Usage sample:
```csharp
  CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
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

#### Contributors

* [Charlin Agramonte](https://github.com/char0394)
* [Rendy Del Rosario](https://github.com/rdelrosario)

