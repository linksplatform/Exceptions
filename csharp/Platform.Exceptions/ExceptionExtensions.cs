using System;
using System.Text;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Provides a set of extension methods for <see cref="Exception"/> objects.</para>
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// <para>Represents the separator used within the process of generating a representation string (<see cref="ToStringWithAllInnerExceptions(Exception)"/>) to separate different inner exceptions from each other. This field is constant.</para>
        /// </summary>
        public static readonly string ExceptionContentsSeparator = "---";

        /// <summary>
        /// <para>Represents a string returned from <see cref="ToStringWithAllInnerExceptions(Exception)"/> in the event of an unsuccessful attempt to format an exception. This field is a constant.</para>
        /// </summary>
        public static readonly string ExceptionStringBuildingFailed = "Unable to format exception.";

        /// <summary>
        /// <para>Ignores the exception, notifying the <see cref = "IgnoredExceptions" /> class about it.</para>
        /// </summary>
        /// <param name="exception"><para></para><para></para></param>
        public static void Ignore(this Exception exception) => IgnoredExceptions.RaiseExceptionIgnoredEvent(exception);

        /// <summary>
        /// <para>Returns a string that represents the specified exception with all its inner exceptions.</para>
        /// </summary>
        /// <param name="exception"><para>The exception that will be represented as a string.</para></param>
        /// <returns><para>A string that represents the specified exception with all its inner exceptions.</para></returns>
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
            sb.AppendLine(exception.Message);
            sb.Indent(level);
            sb.AppendLine(ExceptionContentsSeparator);
            if (exception.InnerException != null)
            {
                sb.Indent(level);
                sb.AppendLine("Inner exception: ");
                sb.BuildExceptionString(exception.InnerException, level + 1);
            }
            sb.Indent(level);
            sb.AppendLine(ExceptionContentsSeparator);
            sb.Indent(level);
            sb.AppendLine(exception.StackTrace);
        }
        private static void Indent(this StringBuilder sb, int level) => sb.Append('\t', level);
    }
}
