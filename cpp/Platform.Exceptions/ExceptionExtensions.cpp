namespace Platform::Exceptions
{
    class ExceptionExtensions
    {
    public:
        inline static const char* ExceptionContentsSeparator = "---";

        inline static const char* ExceptionStringBuildingFailed = "Unable to format exception.";

        static void Ignore(const std::exception& exception) { IgnoredExceptions.RaiseExceptionIgnoredEvent(exception); }

        static const char* ToStringWithAllInnerExceptions(const std::exception& exception)
        {
            try
            {
                std::string sb;
                sb.BuildExceptionString(exception, 0);
                return sb.data();
            }
            catch (const std::exception& ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        static void BuildExceptionString(std::string& sb, const std::exception& exception, int level)
        {
            sb.Indent(level);
            sb.append(exception.Message).append('\n');
            sb.Indent(level);
            sb.append(ExceptionContentsSeparator).append('\n');
            if (exception.InnerException != NULL)
            {
                sb.Indent(level);
                sb.append("Inner exception: ").append('\n');
                sb.BuildExceptionString(exception.InnerException, level + 1);
            }
            sb.Indent(level);
            sb.append(ExceptionContentsSeparator).append('\n');
            sb.Indent(level);
            sb.append(exception.StackTrace).append('\n');
        }

        static void Indent(std::string& sb, int level) { sb.append(level, '\t'); }
    };
}
