namespace Platform::Exceptions
{
    class EnsureExtensions
    {
    public:
        #region Always

        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument, char* argumentName, char* message)
        {
            if (argument == null)
            {
                throw std::invalid_argument(((std::string)"Argument ").append(argumentName).append(" is null: ").append(message).append("."));
            }
        }

        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument, char* argumentName) { return ArgumentNotNull(root, argument, argumentName, "Argument {argumentName} is null."); }

        template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument& argument) { return ArgumentNotNull(root, argument, null); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName, char* message)
        {
            if (!predicate(argument))
            {
                throw std::invalid_argument(((std::string)"Invalid ").append(argumentName).append(" argument: ").append(message).append("."));
            }
        }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName) { return ArgumentMeetsCriteria(root, argument, predicate, argumentName, "Argument {argumentName} is does not meet criteria."); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { return ArgumentMeetsCriteria(root, argument, predicate, null); }

        #endregion

        #region OnDebug

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument, char* argumentName, char* message) { return Ensure.Always.ArgumentNotNull(argument, argumentName, message); }

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument, char* argumentName) { return Ensure.Always.ArgumentNotNull(argument, argumentName); }

        template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument& argument) { return Ensure.Always.ArgumentNotNull(argument); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName, char* message) { return Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName, message); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, char* argumentName) { return Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName); }

        template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { return Ensure.Always.ArgumentMeetsCriteria(argument, predicate); }

        #endregion
    };
}
