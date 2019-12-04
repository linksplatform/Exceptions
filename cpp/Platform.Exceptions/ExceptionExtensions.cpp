namespace Platform::Exceptions
{
    class ExceptionExtensions
    {
    public:
        static readonly char* ExceptionContentsSeparator = "---";

        static readonly char* ExceptionStringBuildingFailed = "Unable to format exception.";

        static void Ignore(Exception exception) { return IgnoredExceptions.RaiseExceptionIgnoredEvent(exception); }

        static char* ToStringWithAllInnerExceptions(Exception exception)
        {
            try
            {
                auto sb = new StringBuilder();
                sb.BuildExceptionString(exception, 0);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        static void BuildExceptionString(StringBuilder sb, Exception exception, int level)
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

        static void Indent(StringBuilder sb, int level) { return sb.Append('\t', level); }
    };
}
