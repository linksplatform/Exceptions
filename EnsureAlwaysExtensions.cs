using System;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    public static class EnsureAlwaysExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot ensure, TArgument argument, string argumentName)
           where TArgument : class
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentZeroOrPositive(this EnsureAlwaysExtensionRoot ensure, long argument, string argumentName)
        {
            if (argument < 0)
                throw new ArgumentOutOfRangeException(argumentName, "Must be positive.");
        }
    }
}
