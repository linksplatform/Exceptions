using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Platform.Exceptions
{
    public static class EnsureAlwaysExtensions
    {
        #region Always

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName, string message)
            where TArgument : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName) where TArgument : class => ArgumentNotNull(root, argument, argumentName, $"Argument {argumentName} is null.");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument) where TArgument : class => ArgumentNotNull(root, argument, null);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, Predicate<TArgument> predicate, TArgument argument, string argumentName, string message)
        {
            if (!predicate(argument))
            {
                throw new ArgumentException(argumentName, message);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, Predicate<TArgument> predicate, TArgument argument, string argumentName) => ArgumentMeetsCriteria(root, predicate, argument, argumentName, $"Argument {argumentName} is does not meet criteria.");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, Predicate<TArgument> predicate, TArgument argument) => ArgumentMeetsCriteria(root, predicate, argument, null);

        #endregion

        #region OnDebug

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, string argumentName, string message) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName, message);

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, string argumentName) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument) where TArgument : class => Ensure.Always.ArgumentNotNull(argument);

        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, Predicate<TArgument> predicate, TArgument argument, string argumentName, string message) => Ensure.Always.ArgumentMeetsCriteria(predicate, argument, argumentName, message);

        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, Predicate<TArgument> predicate, TArgument argument, string argumentName) => Ensure.Always.ArgumentMeetsCriteria(predicate, argument, argumentName);

        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, Predicate<TArgument> predicate, TArgument argument) => Ensure.Always.ArgumentMeetsCriteria(predicate, argument);

        #endregion
    }
}
