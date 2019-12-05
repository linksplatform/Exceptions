namespace Platform::Exceptions
{
    class ExceptionExtensions
    {
    public:
        inline static const char* ExceptionContentsSeparator = "---";

        inline static const char* ExceptionStringBuildingFailed = "Unable to format exception.";

        static void Ignore(const std::exception& exception) { return IgnoredExceptions.RaiseExceptionIgnoredEvent(exception); }

        static char* ToStringWithAllInnerExceptions(const std::exception& exception)
        {
            try
            {
                auto sb = new StringBuilder();
                sb.BuildExceptionString(exception, 0);
                return sb.ToString();
            }
            catch (const std::exception& ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        static void BuildExceptionString(StringBuilder sb, const std::exception& exception, int level)
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
