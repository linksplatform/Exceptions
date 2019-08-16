using System.Diagnostics;
using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions.Tests.Ignore
{
    public static class EnsureAlwaysExtensions
    {
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName)
            where TArgument : class
        {
        }
    }
}
