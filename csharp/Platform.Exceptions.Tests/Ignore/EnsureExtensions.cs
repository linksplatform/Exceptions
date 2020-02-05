using System.Diagnostics;
using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions.Tests.Ignore
{
    public static class EnsureExtensions
    {
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName)
            where TArgument : class
        {
            // Override logic to do nothing (this should be used to reduce the overhead of the Ensure checks, when it is critical to performance)
        }
    }
}
