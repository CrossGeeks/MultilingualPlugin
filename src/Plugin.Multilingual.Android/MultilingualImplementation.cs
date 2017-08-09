using Plugin.Multilingual.Abstractions;
using System;
using System.Globalization;

namespace Plugin.Multilingual
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class MultilingualImplementation : IMultilingual
    {
        public CultureInfo CurrentCultureInfo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public CultureInfo DeviceCultureInfo => throw new NotImplementedException();

        public CultureInfo[] DeviceCultureInfoList => throw new NotImplementedException();
    }
}