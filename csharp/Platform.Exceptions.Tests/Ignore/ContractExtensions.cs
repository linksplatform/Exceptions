using System.Diagnostics;
using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions.Tests.Ignore
{
    public static class ContractExtensions
    {
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this ContractAlwaysExtensionRoot root, TArgument argument, string argumentName)
            where TArgument : class
        {
            // Override logic to do nothing (this should be used to reduce the overhead of the Contract checks, when it is critical to performance)
        }
    }
}
