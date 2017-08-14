using Plugin.Multilingual.Abstractions;
using System;
using System.Globalization;
using System.Threading;

namespace Plugin.Multilingual
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class MultilingualImplementation : IMultilingual
    {
        CultureInfo _currentCultureInfo = CultureInfo.InstalledUICulture;
        public CultureInfo CurrentCultureInfo
        {
            get
            {
                return _currentCultureInfo;
            }
            set
            {
                _currentCultureInfo = value;
                Thread.CurrentThread.CurrentCulture = value;
                Thread.CurrentThread.CurrentUICulture = value;
            }
        }

        public CultureInfo DeviceCultureInfo { get { return CultureInfo.InstalledUICulture; } }

        public CultureInfo[] CultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.AllCultures); } }

        public CultureInfo[] NeutralCultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.NeutralCultures); } }

        public CultureInfo GetCultureInfo(string name) { return CultureInfo.GetCultureInfo(name); }
    }
}