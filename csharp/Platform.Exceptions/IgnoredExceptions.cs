using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Contains a mechanism for notifying about the occurrence of ignored exceptions, as well as a mechanism for their collection.</para>
    /// </summary>
    public static class IgnoredExceptions
    {
        private static readonly ConcurrentBag<Exception> _exceptionsBag = new ConcurrentBag<Exception>();

        /// <summary>
        /// <para>An event that is raised every time an exception has been ignored.</para>
        /// </summary>
        public static event EventHandler<Exception> ExceptionIgnored = OnExceptionIgnored;

        /// <summary>
        /// <para>Gets an immutable collection with all collected exceptions that were ignored.</para>
        /// </summary>
        public static IReadOnlyCollection<Exception> CollectedExceptions => _exceptionsBag;

        /// <summary>
        /// <para>Gets or sets a value that determines whether to collect ignored exceptions into CollectedExceptions.</para>
        /// </summary>
        public static bool CollectExceptions { get; set; }

        /// <summary>
        /// <para>Raises an exception ignored event.</para>
        /// </summary>
        /// <param name="exception"><para>The ignored exception.</para></param>
        /// <remarks>
        /// <para>It is recommended to call this method in cases where you have a catch block, but you do not do anything with exception in it.</para>
        /// </remarks>
        public static void RaiseExceptionIgnoredEvent(Exception exception) => ExceptionIgnored.Invoke(null, exception);
        private static void OnExceptionIgnored(object sender, Exception exception)
        {
            if (CollectExceptions)
            {
                _exceptionsBag.Add(exception);
            }
        }
    }
}
