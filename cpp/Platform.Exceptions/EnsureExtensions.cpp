namespace Platform::Exceptions
{
    class EnsureExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName, const char* message)
        {
            if (argument == NULL)
            {
                throw std::invalid_argument(((std::string)"Argument ").append(argumentName).append(" is null: ").append(message).append("."));
            }
        }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName) { ArgumentNotNull(root, argument, argumentName, ((std::string)"Argument ").append(argumentName).append(" is null.").data()); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument) { ArgumentNotNull(root, argument, NULL); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName, const char* message)
        {
            if (!predicate(argument))
            {
                throw std::invalid_argument(((std::string)"Invalid ").append(argumentName).append(" argument: ").append(message).append("."));
            }
        }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName) { ArgumentMeetsCriteria(root, argument, predicate, argumentName, ((std::string)"Argument ").append(argumentName).append(" is does not meet criteria.").data()); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { ArgumentMeetsCriteria(root, argument, predicate, NULL); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument, const char* argumentName, const char* message) { Ensure.Always.ArgumentNotNull(argument, argumentName, message); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument, const char* argumentName) { Ensure.Always.ArgumentNotNull(argument, argumentName); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument) { Ensure.Always.ArgumentNotNull(argument); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName, const char* message) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName, message); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate, argumentName); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { Ensure.Always.ArgumentMeetsCriteria(argument, predicate); }
    };
}
