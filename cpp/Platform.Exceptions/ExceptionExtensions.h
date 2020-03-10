namespace Platform::Exceptions
{
    class ExceptionExtensions
    {
        public: inline static std::string ExceptionContentsSeparator = "---";

        public: inline static std::string ExceptionStringBuildingFailed = "Unable to format exception.";

        public: static void Ignore(const std::exception& exception) { IgnoredExceptions::RaiseExceptionIgnoredEvent(exception); }

        public: static std::string ToStringWithAllInnerExceptions(const std::exception& exception)
        {
            try
            {
                std::string sb;
                BuildExceptionString(sb, exception, 0);
                return sb;
            }
            catch (const std::exception& ex)
            {
                Platform::Exceptions::ExceptionExtensions::Ignore(ex);
                return ExceptionStringBuildingFailed;
            }
        }

        private: static void BuildExceptionString(std::string& sb, const std::exception& exception, std::int32_t level)
        {
            Indent(sb, level);
            sb.append(exception.what()).append(1, '\n');
        }

        private: static void Indent(std::string& sb, std::int32_t level) { sb.append(level, '\t'); }
    };
}
