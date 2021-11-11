using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Сontains a mechanism for notifying about the occurrence of ignored exceptions, as well as a mechanism for their collection.</para>
    /// <para>Содержит механизм уведомления о возникновении игнорируемых исключений, а так же механизм их сбора.</para>
    /// </summary>
    public static class IgnoredExceptions
    {
        private static readonly ConcurrentBag<Exception> _exceptionsBag = new ConcurrentBag<Exception>();

        /// <summary>
        /// <para>An event that is raised every time an exception has been ignored.</para>
        /// <para>Событие, которое генерируется каждый раз, когда исключение было проигнорировано.</para>
        /// </summary>
        public static event EventHandler<Exception> ExceptionIgnored = OnExceptionIgnored;

        /// <summary>
        /// <para>Gets an immutable collection with all collected exceptions that were ignored.</para>
        /// <para>Возвращает неизменяемую коллекцию со всеми собранными исключениями которые были проигнорированы.</para>
        /// </summary>
        public static IReadOnlyCollection<Exception> CollectedExceptions => _exceptionsBag;

        /// <summary>
        /// <para>Gets or sets a value that determines whether to collect ignored exceptions into CollectedExceptions.</para>
        /// <para>Возвращает или устанавливает значение, определяющие нужно ли собирать игнорируемые исключения в CollectedExceptions.</para>
        /// </summary>
        public static bool CollectExceptions { get; set; }

        /// <summary>
        /// <para>Raises an exception ignored event.</para>
        /// <para>Генерирует событие игнорирования исключения.</para>
        /// </summary>
        /// <param name="exception"><para>The ignored exception.</para><para>Игнорируемое исключение.</para></param>
        /// <remarks>
        /// <para>It is recommended to call this method in cases where you have a catch block, but you do not do anything with exception in it.</para>
        /// <para>Рекомендуется вызывать этот метод в тех случаях, когда у вас есть catch блок, но вы ничего не делаете в нём с исключением.</para>
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
