using System;
using System.Runtime.CompilerServices;

namespace Platform.Exceptions.Static
{
    /// <summary>
    /// <para>Provides static methods for ensuring contract compliance that can be used with 'using static' directive.</para>
    /// <para>Предоставляет статические методы для гарантирования соответствия контракту, которые можно использовать с директивой 'using static'.</para>
    /// </summary>
    public static class EnsureStatic
    {
        /// <summary>
        /// <para>Ensures that argument is not null.</para>
        /// <para>Гарантирует, что аргумент не нулевой.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(TArgument argument, string argumentName, string message)
            where TArgument : class
            => Ensure.Always.ArgumentNotNull(argument, argumentName, message);

        /// <summary>
        /// <para>Ensures that argument is not null.</para>
        /// <para>Гарантирует, что аргумент не нулевой.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(TArgument argument, string argumentName) where TArgument : class
            => Ensure.Always.ArgumentNotNull(argument, argumentName);

        /// <summary>
        /// <para>Ensures that argument is not null.</para>
        /// <para>Гарантирует, что аргумент не нулевой.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentNotNull<TArgument>(TArgument argument) where TArgument : class
            => Ensure.Always.ArgumentNotNull(argument);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria.</para>
        /// <para>Гарантирует, что аргумент соответствует критерию.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para><para>Предикат определяющий, соответствует ли аргумент критерию.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        /// <param name="message"><para>The message of the thrown exception.</para><para>Сообщение выбрасываемого исключения.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(TArgument argument, Predicate<TArgument> predicate, string argumentName, string message)
            => Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName, message);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria.</para>
        /// <para>Гарантирует, что аргумент соответствует критерию.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para><para>Предикат определяющий, соответствует ли аргумент критерию.</para></param>
        /// <param name="argumentName"><para>The argument's name.</para><para>Имя аргумента.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(TArgument argument, Predicate<TArgument> predicate, string argumentName)
            => Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName);

        /// <summary>
        /// <para>Ensures that the argument meets the criteria.</para>
        /// <para>Гарантирует, что аргумент соответствует критерию.</para>
        /// </summary>
        /// <typeparam name="TArgument"><para>Type of argument.</para><para>Тип аргумента.</para></typeparam>
        /// <param name="argument"><para>The argument.</para><para>Аргумент.</para></param>
        /// <param name="predicate"><para>A predicate that determines whether the argument meets a criterion.</para><para>Предикат определяющий, соответствует ли аргумент критерию.</para></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ArgumentMeetsCriteria<TArgument>(TArgument argument, Predicate<TArgument> predicate)
            => Ensure.Always.ArgumentMeetsCriteria(argument, predicate);
    }
}