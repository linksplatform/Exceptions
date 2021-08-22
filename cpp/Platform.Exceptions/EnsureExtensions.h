namespace Platform::Exceptions::Ensure::Always
{
    void ArgumentNotNull(auto argument, const std::string& argumentName, const std::string& message)
        requires std::is_pointer_v<decltype(argument)> || std::is_null_pointer_v<decltype(argument)>
    {
        if (argument == nullptr)
        {
            throw std::invalid_argument(std::string("Argument ").append(argumentName).append(" is null: ").append(message).append(1, '.'));
        }
    }

    void ArgumentNotNull(auto argument, const std::string& argumentName)
        requires std::is_pointer_v<decltype(argument)> || std::is_null_pointer_v<decltype(argument)>
    {
        if (argument == nullptr)
        {
            throw std::invalid_argument(std::string("Argument ").append(argumentName).append(" is null."));
        }
    }

    void ArgumentNotNull(auto argument)
        requires std::is_pointer_v<decltype(argument)> || std::is_null_pointer_v<decltype(argument)>
    {
        if (argument == nullptr)
        {
            throw std::invalid_argument(std::string("Argument is null."));
        }
    }

    void ArgumentMeetsCriteria(auto&& argument, auto&& predicate, const std::string& argumentName, const std::string& message)
        requires requires { { predicate(argument) } -> std::integral; }
    {
        if (not predicate(std::forward<decltype(argument)>(argument)))
        {
            throw std::invalid_argument(std::string("Invalid ").append(argumentName).append(" argument: ").append(message).append(1, '.'));
        }
    }

    void ArgumentMeetsCriteria(auto&& argument, auto&& predicate, const std::string& argumentName)
    {
        ArgumentMeetsCriteria(std::forward<decltype(argument)>(argument), predicate, argumentName, std::string("Argument ").append(argumentName).append(" does not meet the criteria."));
    }

    void ArgumentMeetsCriteria(auto&& argument, auto&& predicate)
    {
        ArgumentMeetsCriteria(std::forward<decltype(argument)>(argument), predicate, {});
    }
}

namespace Platform::Exceptions::Ensure::OnDebug
{
#ifdef NDEBUG
    #define NDEBUG_CONSTEVAL consteval
#else
    #define NDEBUG_CONSTEVAL
#endif

    NDEBUG_CONSTEVAL static void ArgumentNotNull(auto&&... args)
    #ifdef NDEBUG
        noexcept {}
    #else
        { Always::ArgumentNotNull(std::forward<decltype(args)>(args)...); }
    #endif

    NDEBUG_CONSTEVAL static void ArgumentMeetsCriteria(auto&&... args)
    #ifdef NDEBUG
        noexcept {}
    #else
        { Always::ArgumentMeetsCriteria(std::forward<decltype(args)>(args)...); }
    #endif
}