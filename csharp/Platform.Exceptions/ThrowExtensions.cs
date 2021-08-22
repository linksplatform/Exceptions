using System;
using System.Runtime.CompilerServices;
using Platform.Exceptions.ExtensionRoots;

#pragma warning disable IDE0060 // Remove unused parameter

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="ThrowExtensionRoot"/> objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов <see cref="ThrowExtensionRoot"/>.</para>
    /// </summary>
    public static class ThrowExtensions
    {
        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/>.</para>
        /// </summary>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotSupportedException(this ThrowExtensionRoot root) => throw new NotSupportedException();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotSupportedException"/>, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotSupportedException"/>, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotSupportedExceptionAndReturn<TReturn>(this ThrowExtensionRoot root) => throw new NotSupportedException();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/>.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/>.</para>
        /// </summary>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void NotImplementedException(this ThrowExtensionRoot root) => throw new NotImplementedException();

        /// <summary>
        /// <para>Throws a new <see cref="System.NotImplementedException"/>, while returning a value of <typeparamref name="TReturn"/> type.</para>
        /// <para>Выбрасывает новое <see cref="System.NotImplementedException"/>, вовращая при этом значение типа <typeparamref name="TReturn"/>.</para>
        /// </summary>
        /// <typeparam name="TReturn"><para>The type of returned value.</para><para>Тип возвращаемого значения.</para></typeparam>
        /// <param name="root"><para>The extension root to which this method is bound.</para><para>Корень-расширения, к которому привязан этот метод.</para></param>
        /// <returns><para>A value of <typeparamref name="TReturn"/> type.</para><para>Значение типа <typeparamref name="TReturn"/>.</para></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TReturn NotImplementedExceptionAndReturn<TReturn>(this ThrowExtensionRoot root) => throw new NotImplementedException();
    }
}
