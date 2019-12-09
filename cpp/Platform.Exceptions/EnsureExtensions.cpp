namespace Platform::Exceptions
{
    class EnsureExtensions
    {
    public:
        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument, char* argumentName, char* message)
        {
            if (argument == null)
            {
                throw std::invalid_argument(((std::string)"Argument ").append(argumentName).append(" is null: ").append(message).append("."));
            }
        }

        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument, char* argumentName) { ArgumentNotNull(root, argument, argumentName, "Argument {argumentName} is null."); }

        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument) { ArgumentNotNull(root, argument, null); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName, char* message)
        {
            if (!predicate(argument))
            {
                throw std::invalid_argument(((std::string)"Invalid ").append(argumentName).append(" argument: ").append(message).append("."));
            }
        }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName) { ArgumentMeetsCriteria(root, argument, predicate, argumentName, "Argument {argumentName} is does not meet criteria."); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { ArgumentMeetsCriteria(root, argument, predicate, null); }

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument, char* argumentName, char* message) { Ensure.Always.ArgumentNotNull(argument, argumentName, message); }

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument, char* argumentName) { Ensure.Always.ArgumentNotNull(argument, argumentName); }

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument) { Ensure.Always.ArgumentNotNull(argument); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName, char* message) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName, message); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate); }
    };
}
