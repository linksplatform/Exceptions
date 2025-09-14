using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="EnsureAlwaysExtensionRoot"/> and <see cref="EnsureOnDebugExtensionRoot"/> objects.</para>
    /// </summary>
    public static class EnsureExtensions
    {
        #region Always

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName, string message)
            where TArgument : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, message);
            }
        }

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, string argumentName) where TArgument : class => ArgumentNotNull(root, argument, argumentName, $"Argument {argumentName} is null.");

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument) where TArgument : class => ArgumentNotNull(root, argument, null);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, Predicate<TArgument> predicate, string argumentName, string message)
        {
            if (!predicate(argument))
            {
                throw new ArgumentException(message, argumentName);
            }
        }

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, Predicate<TArgument> predicate, string argumentName) => ArgumentMeetsCriteria(root, argument, predicate, argumentName, $"Argument {argumentName} does not meet the criteria.");

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed regardless of the build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureAlwaysExtensionRoot root, TArgument argument, Predicate<TArgument> predicate) => ArgumentMeetsCriteria(root, argument, predicate, null);

        #endregion

        #region OnDebug

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, string argumentName, string message) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName, message);

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, string argumentName) where TArgument : class => Ensure.Always.ArgumentNotNull(argument, argumentName);

        /// <summary>
        /// <para>Ensures that argument is not null. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentNotNull<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument) where TArgument : class => Ensure.Always.ArgumentNotNull(argument);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Predicate<TArgument> predicate, string argumentName, string message) => Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName, message);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Predicate<TArgument> predicate, string argumentName) => Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria. This check is performed only for DEBUG build configuration.</para>
        ///         /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para></param>
        /// <param name="argument"><para>The argument.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para></param>
        [Conditional("DEBUG")]
        public static void ArgumentMeetsCriteria<TArgument>(this EnsureOnDebugExtensionRoot root, TArgument argument, Predicate<TArgument> predicate) => Ensure.Always.ArgumentMeetsCriteria(argument, predicate);

        #endregion
    }
}
