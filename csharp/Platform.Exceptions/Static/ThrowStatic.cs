using System;
using System.Runtime.CompilerServices;

namespace Platform.Exceptions.Static
{
    /// <summary>
    /// <para>Provides static methods for throwing exceptions that can be used with 'using static' directive.</para>
    /// <para>Предоставляет статические методы для выбрасывания исключений, которые можно использовать с директивой 'using static'.</para>
    /// </summary>
    public static class ThrowStatic
    {
        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/>.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotSupportedException() => Throw.A.NotSupportedException();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/> with the specified message.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/> с указанным сообщением.</para>
        /// </summary>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotSupportedException(string message) => throw new NotSupportedException(message);

        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/>, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/>, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotSupportedExceptionAndReturn<TReturn>() => Throw.A.NotSupportedExceptionAndReturn<TReturn>();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/> with the specified message, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/> с указанным сообщением, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotSupportedExceptionAndReturn<TReturn>(string message) => throw new NotSupportedException(message);

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/>.</para>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotImplementedException() => Throw.A.NotImplementedException();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/> with the specified message.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/> с указанным сообщением.</para>
        /// </summary>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotImplementedException(string message) => throw new NotImplementedException(message);

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/>, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/>, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotImplementedExceptionAndReturn<TReturn>() => Throw.A.NotImplementedExceptionAndReturn<TReturn>();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/> with the specified message, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/> с указанным сообщением, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotImplementedExceptionAndReturn<TReturn>(string message) => throw new NotImplementedException(message);

        /// <summary>
        /// <para>Throws a new <see cref="System.ArgumentNullException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.ArgumentNullException"/>.</para>
        /// </summary>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNullException(string argumentName) => throw new ArgumentNullException(argumentName);

        /// <summary>
        /// <para>Throws a new <see cref="System.ArgumentNullException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.ArgumentNullException"/>.</para>
        /// </summary>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNullException(string argumentName, string message) => throw new ArgumentNullException(argumentName, message);

        /// <summary>
        /// <para>Throws a new <see cref="System.ArgumentException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.ArgumentException"/>.</para>
        /// </summary>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentException(string message, string argumentName) => throw new ArgumentException(message, argumentName);
    }
}