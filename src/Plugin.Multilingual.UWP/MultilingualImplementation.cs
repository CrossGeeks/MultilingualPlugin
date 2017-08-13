using Plugin.Multilingual.Abstractions;
using System;
using System.Globalization;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace Plugin.Multilingual
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class MultilingualImplementation : IMultilingual
    {
        CultureInfo[] cultureInfoList = Windows.Globalization.ApplicationLanguages.Languages.Select(c => new CultureInfo(c)).ToArray();
        CultureInfo[] neutralCultureInfoList = Windows.Globalization.ApplicationLanguages.Languages.Select(c => new CultureInfo(c.Substring(0, c.IndexOf("-") == -1 ? c.Length : c.IndexOf("-")))).Distinct().ToArray();

        string[] allLanguageCodes = new string[] { "ar", "bg", "ca", "zh-Hans", "cs", "da", "de", "el", "en", "es", "fi", "fr", "he", "hu", "is", "it", "ja", "ko", "nl", "no", "pl", "pt", "rm", "ro", "ru", "hr", "sk", "sq", "sv", "th", "tr", "ur", "id", "uk", "be", "sl", "et", "lv", "lt", "tg", "fa", "vi", "hy", "az", "eu", "hsb", "mk", "st", "ts", "tn", "xh", "zu", "af", "ka", "fo", "hi", "mt", "se", "ga", "ms", "kk", "ky", "sw", "tk", "uz", "bn", "pa", "gu", "or", "ta", "te", "kn", "ml", "as", "mr", "mn", "bo", "cy", "km", "lo", "my", "gl", "kok", "si", "chr", "am", "tzm", "ne", "fy", "ps", "fil", "ff", "ha", "yo", "nso", "lb", "kl", "ig", "om", "ti", "haw", "so", "ii", "br", "ug", "gsw", "sah", "rw", "gd", "ar-SA", "bg-BG", "ca-ES", "zh-TW", "cs-CZ", "da-DK", "de-DE", "el-GR", "en-US", "fi-FI", "fr-FR", "he-IL", "hu-HU", "is-IS", "it-IT", "ja-JP", "ko-KR", "nl-NL", "nb-NO", "pl-PL", "pt-BR", "rm-CH", "ro-RO", "ru-RU", "hr-HR", "sk-SK", "sq-AL", "sv-SE", "th-TH", "tr-TR", "ur-PK", "id-ID", "uk-UA", "be-BY", "sl-SI", "et-EE", "lv-LV", "lt-LT", "tg-Cyrl-TJ", "fa-IR", "vi-VN", "hy-AM", "az-Latn-AZ", "eu-ES", "hsb-DE", "mk-MK", "st-ZA", "ts-ZA", "tn-ZA", "xh-ZA", "zu-ZA", "af-ZA", "ka-GE", "fo-FO", "hi-IN", "mt-MT", "se-NO", "ms-MY", "kk-KZ", "ky-KG", "sw-KE", "tk-TM", "uz-Latn-UZ", "bn-IN", "gu-IN", "or-IN", "ta-IN", "te-IN", "kn-IN", "ml-IN", "as-IN", "mr-IN", "mn-MN", "bo-CN", "cy-GB", "km-KH", "lo-LA", "my-MM", "gl-ES", "kok-IN", "si-LK", "am-ET", "ne-NP", "fy-NL", "ps-AF", "fil-PH", "ha-Latn-NG", "yo-NG", "nso-ZA", "lb-LU", "kl-GL", "ig-NG", "om-ET", "ti-ET", "haw-US", "so-SO", "ii-CN", "br-FR", "ug-CN", "gsw-FR", "sah-RU", "rw-RW", "gd-GB", "ar-IQ", "ca-ES-valencia", "zh-CN", "de-CH", "en-GB", "es-MX", "fr-BE", "it-CH", "nl-BE", "nn-NO", "pt-PT", "ro-MD", "ru-MD", "sv-FI", "ur-IN", "az-Cyrl-AZ", "dsb-DE", "tn-BW", "se-SE", "ga-IE", "ms-BN", "uz-Cyrl-UZ", "bn-BD", "pa-Arab-PK", "ta-LK", "ne-IN", "ti-ER", "ar-EG", "zh-HK", "de-AT", "en-AU", "es-ES", "fr-CA", "se-FI", "ar-LY", "zh-SG", "de-LU", "en-CA", "es-GT", "fr-CH", "hr-BA", "ar-DZ", "zh-MO", "de-LI", "en-NZ", "es-CR", "fr-LU", "bs-Latn-BA", "ar-MA", "en-IE", "es-PA", "fr-MC", "sr-Latn-BA", "ar-TN", "en-ZA", "es-DO", "sr-Cyrl-BA", "ar-OM", "en-JM", "es-VE", "fr-RE", "bs-Cyrl-BA", "ar-YE", "es-CO", "fr-CD", "sr-Latn-RS", "smn-FI", "ar-SY", "en-BZ", "es-PE", "fr-SN", "sr-Cyrl-RS", "ar-JO", "en-TT", "es-AR", "fr-CM", "sr-Latn-ME", "ar-LB", "en-ZW", "es-EC", "fr-CI", "sr-Cyrl-ME", "ar-KW", "en-PH", "es-CL", "fr-ML", "ar-AE", "es-UY", "fr-MA", "ar-BH", "en-HK", "es-PY", "fr-HT", "ar-QA", "en-IN", "es-BO", "en-MY", "es-SV", "en-SG", "es-HN", "es-NI", "es-PR", "es-US", "es-CU", "bs-Cyrl", "bs-Latn", "sr-Cyrl", "sr-Latn", "smn", "az-Cyrl", "zh", "nn", "bs", "az-Latn", "uz-Cyrl", "mn-Cyrl", "zh-Hant", "nb", "sr", "tg-Cyrl", "dsb", "uz-Latn", "pa-Arab", "tzm-Latn", "ha-Latn" };
        string[] neutralLanguageCodes = new string[] { "ar","bg","ca","zh-Hans","cs","da","de","el","en","es","fi","fr","he","hu","is","it","ja","ko","nl","no","pl","pt","rm","ro","ru","hr","sk","sq","sv","th","tr","ur","id","uk","be","sl","et","lv","lt","tg","fa","vi","hy","az","eu","hsb","mk","st","ts","tn","xh","zu","af","ka","fo","hi","mt","se","ga","ms","kk","ky","sw","tk","uz","bn","pa","gu","or","ta","te","kn","ml","as","mr","mn","bo","cy","km","lo","my","gl","kok","si","chr","am","tzm","ne","fy","ps","fil","ff","ha","yo","nso","lb","kl","ig","om","ti","haw","so","ii","br","ug","gsw","sah","rw","gd","bs-Cyrl","bs-Latn","sr-Cyrl","sr-Latn","smn","az-Cyrl","zh","nn","bs","az-Latn","uz-Cyrl","mn-Cyrl","zh-Hant","nb","sr","tg-Cyrl","dsb","uz-Latn","pa-Arab","tzm-Latn","ha-Latn" };

        CultureInfo _currentCultureInfo = null;

        public MultilingualImplementation()
        {
            var allCultures = new List<CultureInfo>();
            foreach(var l in allLanguageCodes)
            {
     
                  allCultures.Add(new CultureInfo(l));
               
            }
            cultureInfoList = allCultures.ToArray();

            var neutralCultures = new List<CultureInfo>();
            foreach (var n in neutralLanguageCodes)
            {
                  neutralCultures.Add(new CultureInfo(n));
            }

            neutralCultureInfoList = neutralCultures.ToArray();
        }
        public CultureInfo CurrentCultureInfo
        {
            get
            {
                if (_currentCultureInfo == null)
                {
                    _currentCultureInfo = CultureInfo.CurrentUICulture;
                    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = _currentCultureInfo.Name;
                    Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                    Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
                }
                return _currentCultureInfo;
            }
            set
            {
                _currentCultureInfo = value;
                CultureInfo.CurrentCulture = value;
                CultureInfo.CurrentUICulture = value;
                Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = value.Name;
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
            }
        }

        public CultureInfo DeviceCultureInfo { get { return CultureInfo.CurrentUICulture; } }

        public CultureInfo[] CultureInfoList { get { return cultureInfoList; } }

        public CultureInfo[] NeutralCultureInfoList { get { return neutralCultureInfoList; } }

        public CultureInfo GetCultureInfo(string name)
        {

            CultureInfo retVal = CultureInfoList.FirstOrDefault(p => p.Name == name);
            return retVal;
        }

    }

}