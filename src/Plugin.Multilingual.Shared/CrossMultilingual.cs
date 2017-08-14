using Plugin.Multilingual.Abstractions;
using System;
using System.Globalization;

namespace Plugin.Multilingual
{
  /// <summary>
  /// Cross platform Multilingual implemenations
  /// </summary>
  public class CrossMultilingual
  {
    static Lazy<IMultilingual> Implementation = new Lazy<IMultilingual>(() => CreateMultilingual(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

    /// <summary>
    /// Current settings to use
    /// </summary>
    public static IMultilingual Current
    {
      get
      {
        var ret = Implementation.Value;
        if (ret == null)
        {
          throw NotImplementedInReferenceAssembly();
        }
        return ret;
      }
    }

    static IMultilingual CreateMultilingual()
    {
        #if NETSTANDARD1_0
                    return null;
        #else
        #pragma warning disable IDE0022 // Use expression body for methods
			        return new MultilingualImplementation();
        #pragma warning restore IDE0022 // Use expression body for methods
        #endif
     }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
