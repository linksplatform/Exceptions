using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Platform.Exceptions
{
    public static class IgnoredExceptions
    {
        private static readonly ConcurrentBag<Exception> ExceptionsBag = new ConcurrentBag<Exception>();

        public static event EventHandler<Exception> ExceptionIgnored = OnExceptionIgnored;

        public static IReadOnlyCollection<Exception> All => ExceptionsBag;

        public static bool CollectExceptions { get; set; }

        public static void RaiseExceptionIgnoredEvent(Exception exception) => ExceptionIgnored.Invoke(null, exception);

        private static void OnExceptionIgnored(object sender, Exception exception)
        {
            if (CollectExceptions)
            {
                ExceptionsBag.Add(exception);
            }
        }
    }
}
