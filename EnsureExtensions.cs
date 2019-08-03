using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    public static class EnsureAlwaysExtensions
    {
        #region Always

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName)
           where TArgument : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentZeroOrPositive(this EnsureAlwaysExtensionRoot root, long argument, string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, "Must be positive.");
            }
        }

        #endregion

        #region OnDebug

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, string argumentName) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentZeroOrPositive(this EnsureOnDebugExtensionRoot root, long argument, string argumentName) => Ensure.Always.ArgumentZeroOrPositive(argument, argumentName);

        #endregion
    }
}
