using System;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    public static class ThrowExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotSupportedException(this ThrowExtensionRoot root) => throw new NotSupportedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotSupportedExceptionAndReturn<T>(this ThrowExtensionRoot root) => throw new NotSupportedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotImplementedException(this ThrowExtensionRoot root) => throw new NotImplementedException();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NotImplementedExceptionAndReturn<T>(this ThrowExtensionRoot root) => throw new NotImplementedException();
    }
}
