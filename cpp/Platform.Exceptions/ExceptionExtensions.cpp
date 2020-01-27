namespace Platform::Exceptions
{
    class ExceptionExtensions
    {
        public: inline static const char* ExceptionContentsSeparator = "---";

        public: inline static const char* ExceptionStringBuildingFailed = "Unable to format exception.";

        public: static void Ignore(const std::exception& exception) { IgnoredExceptions.RaiseExceptionIgnoredEvent(exception); }

        public: static const char* ToStringWithAllInnerExceptions(const std::exception& exception)
        {
            try
            {
                std::string sb;
                BuildExceptionString(sb, exception, 0);
                return sb.data();
            }
            catch (const std::exception& ex)
            {
                ex.Ignore();
                return ExceptionStringBuildingFailed;
            }
        }

        private: static void BuildExceptionString(std::string& sb, const std::exception& exception, int level)
        {
            Indent(sb, level);
            sb.append(exception.Message).append('\n');
            Indent(sb, level);
            sb.append(ExceptionContentsSeparator).append('\n');
            if (exception.InnerException != nullptr)
            {
                Indent(sb, level);
                sb.append("Inner exception: ").append('\n');
                BuildExceptionString(sb, exception.InnerException, level + 1);
            }
            Indent(sb, level);
            sb.append(ExceptionContentsSeparator).append('\n');
            Indent(sb, level);
            sb.append(exception.StackTrace).append('\n');
        }

        private: static void Indent(std::string& sb, int level) { sb.append(level, '\t'); }
    };
}
