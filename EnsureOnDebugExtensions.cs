using System.Diagnostics;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    public static class EnsureOnDebugExtensions
    {
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot ensure, TArgument argument, string argumentName) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentZeroOrPositive(this EnsureOnDebugExtensionRoot ensure, long argument, string argumentName) => Ensure.Always.ArgumentZeroOrPositive(argument, argumentName);
    }
}
