using System;
using System.Text;

namespace Platform.Exceptions
{
    public static class ExceptionExtensions
    {
        public static readonly string ExceptionContentsSeparator = "---";
        public static readonly string ExceptionStringBuildingFailed = "Unable to format exception.";

        public static void Ignore(this Exception exception) => IgnoredExceptions.RaiseExceptionIgnoredEvent(exception);

        public static string ToStringWithAllInnerExceptions(this Exception exception)
        {
            try
            {
                var sb = new StringBuilder();
                BuildExceptionString(sb, exception, 0);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        private static void BuildExceptionString(StringBuilder sb, Exception exception, int level)
        {
            sb.Append('\t', level);
            sb.Append("Exception message: ");
            sb.AppendLine(exception.Message);
            sb.Append('\t', level);
            sb.AppendLine(ExceptionContentsSeparator);
            if (exception.InnerException != null)
            {
                sb.Append('\t', level);
                sb.AppendLine("Inner Exception: ");
                BuildExceptionString(sb, exception.InnerException, level + 1);
            }
            sb.Append('\t', level);
            sb.AppendLine(ExceptionContentsSeparator);
            sb.Append('\t', level);
            sb.AppendLine(exception.StackTrace);
        }
    }
}
