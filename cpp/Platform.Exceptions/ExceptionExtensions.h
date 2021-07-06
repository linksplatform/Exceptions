namespace Platform::Exceptions
{
    namespace Internal
    {
        void Indent(std::string& sb, std::integral auto level)
        {
            sb.append(level, '\t');
        }

        void BuildExceptionString(std::string& sb, const std::exception& exception, std::integral auto level)
        {
            Indent(sb, level);
            sb.append(exception.what()).append(1, '\n');
        }
    }

    static const std::string ExceptionContentsSeparator = "---";

    static const std::string ExceptionStringBuildingFailed = "Unable to format exception.";

    static void Ignore(const std::exception& exception) { IgnoredExceptions::RaiseExceptionIgnoredEvent(exception); }

    static std::string ToStringWithAllInnerExceptions(const std::exception& exception)
    {
        try
        {
            std::string sb;
            Internal::BuildExceptionString(sb, exception, 0);
            return sb;
        }
        catch (const std::exception& ex)
        {
            Ignore(ex);
            return ExceptionStringBuildingFailed;
        }
    }


}
