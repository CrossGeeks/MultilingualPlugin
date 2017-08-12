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
        CultureInfo _currentCultureInfo = CultureInfo.CurrentUICulture;
        public CultureInfo CurrentCultureInfo
        {
            get
            {
                return _currentCultureInfo;
            }
            set
            {
                _currentCultureInfo = value;
                CultureInfo.CurrentCulture = value;
                CultureInfo.CurrentUICulture = value;
            }
        }

        public CultureInfo DeviceCultureInfo { get { return CultureInfo.CurrentUICulture; } }

        public CultureInfo[] CultureInfoList { get { return  CultureInfo.GetCultures(CultureTypes.AllCultures); } }

        public CultureInfo[] NeutralCultureInfoList { get { return CultureInfo.GetCultures(CultureTypes.NeutralCultures); } }

        public CultureInfo GetCultureInfo(string name) { return CultureInfo.GetCultureInfo(name); }
    }
}