using System;
using System.Collections.Generic;
using System.Globalization;

namespace Plugin.Multilingual.Abstractions
{
    /// <summary>
    /// Interface for Multilingual
    /// </summary>
    public interface IMultilingual
    {
        CultureInfo CurrentCultureInfo {get; set;}
        CultureInfo DeviceCultureInfo { get; }
        CultureInfo[] DeviceCultureInfoList { get; }

    }
}
