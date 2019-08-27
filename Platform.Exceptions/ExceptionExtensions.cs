using System;
using System.Text;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="Exception"/> objects.</para>
    /// <para>Предоставляет набор методов расширения для объектов <see cref="Exception"/>.</para>
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// <para>Represents the separator used within the process of generating a representation string (<see cref="ToStringWithAllInnerExceptions(Exception)"/>) to separate different inner exceptions from each other. This field is constant.</para>
        /// <para>Представляет разделитель, используемый внутри процесса формирования строки-представления (<see cref="ToStringWithAllInnerExceptions(Exception)"/>) для разделения различных внутренних исключений друг от друга. Это поле является константой.</para>
        /// </summary>
        public static readonly string ExceptionContentsSeparator = "---";

        /// <summary>
        /// <para>Represents a string returned from <see cref="ToStringWithAllInnerExceptions(Exception)"/> in the event of an unsuccessful attempt to format an exception. This field is a constant.</para>
        /// <para>Представляет строку выдаваемую из <see cref="ToStringWithAllInnerExceptions(Exception)"/> в случае неудачной попытки форматирования исключения. Это поле является константой.</para>
        /// </summary>
        public static readonly string ExceptionStringBuildingFailed = "Unable to format exception.";

        /// <summary>
        /// <para>Ignores the exception, notifying the <see cref = "IgnoredExceptions" /> class about it.</para>
        /// <para>Игнорирует исключение, уведомляя об этом класс <see cref="IgnoredExceptions"/>.</para>
        /// </summary>
        /// <param name="exception"><para></para><para></para></param>
        public static void Ignore(this Exception exception) => IgnoredExceptions.RaiseExceptionIgnoredEvent(exception);

        /// <summary>
        /// <para>Returns a string that represents the specified exception with all its inner exceptions.</para>
        /// <para>Возвращает строку, которая представляет указанное исключение со всеми его внутренними исключениями.</para>
        /// </summary>
        /// <param name="exception"><para>The exception that will be represented as a string.</para><para>Исключение, которое будет представленно в виде строки.</para></param>
        /// <returns><para>A string that represents the specified exception with all its inner exceptions.</para><para>Cтроку, которая представляет указанное исключение со всеми его внутренними исключениями.</para></returns>
        public static string ToStringWithAllInnerExceptions(this Exception exception)
        {
            try
            {
                var sb = new StringBuilder();
                sb.BuildExceptionString(exception, 0);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        private static void BuildExceptionString(this StringBuilder sb, Exception exception, int level)
        {
            sb.Indent(level);
            sb.Append("Exception message: ");
            sb.AppendLine(exception.Message);
            sb.Indent(level);
            sb.AppendLine(ExceptionContentsSeparator);
            if (exception.InnerException != null)
            {
                sb.Indent(level);
                sb.AppendLine("Inner Exception: ");
                sb.BuildExceptionString(exception.InnerException, level + 1);
            }
            sb.Indent(level);
            sb.AppendLine(ExceptionContentsSeparator);
            sb.Indent(level);
            sb.AppendLine(exception.StackTrace);
        }

        private static void Indent(this StringBuilder sb, int level)
        {
            sb.Append('\t', level);
        }
    }
}
