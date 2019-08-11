using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Platform.Exceptions
{
    /// <summary>
    /// Сontains a mechanism for notifying about the occurrence of ignored exceptions, as well as a mechanism for their collection.
    /// Содержит механизм уведомления о возникновении игнорируемых исключений, а так же механизм их сбора.
    /// </summary>
    public static class IgnoredExceptions
    {
        private static readonly ConcurrentBag<Exception> _exceptionsBag = new ConcurrentBag<Exception>();

        /// <summary>
        /// An event that is raised every time an exception has been ignored.
        /// Событие, которое генерируется каждый раз, когда исключение было проигнорировано.
        /// </summary>
        public static event EventHandler<Exception> ExceptionIgnored = OnExceptionIgnored;

        /// <summary>
        /// Gets an immutable collection with all collected exceptions that were ignored.
        /// Возвращает неизменяемую коллекцию со всеми собранными исключениями которые были проигнорированы.
        /// </summary>
        public static IReadOnlyCollection<Exception> CollectedExceptions => _exceptionsBag;

        /// <summary>
        /// Gets or sets a value that determines whether to collect ignored exceptions into CollectedExceptions.
        /// Возвращает или устанавливает значение, определяющие нужно ли собирать игнорируемые исключения в CollectedExceptions.
        /// </summary>
        public static bool CollectExceptions { get; set; }

        /// <summary>
        /// Raises an exception ignored event.
        /// Генерирует событие игнорирования исключения.
        /// </summary>
        /// <param name="exception">The ignored exception. Игнорируемое исключение.</param>
        /// <remarks>
        /// It is recommended to call this method in cases where you have a catch block, but you do not do anything with exception in it.
        /// Рекомендуется вызывать этот метод в тех случаях, когда у вас есть catch блок, но вы ничего не делаете в нём с исключением.
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
