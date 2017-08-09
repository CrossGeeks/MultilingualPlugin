using Plugin.Multilingual.Abstractions;
using System;

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
#if PORTABLE
        return null;
#else
        return new MultilingualImplementation();
#endif
    }

    internal static Exception NotImplementedInReferenceAssembly()
    {
      return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
  }
}
