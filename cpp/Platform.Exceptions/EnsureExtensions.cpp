namespace Platform::Exceptions
{
    class EnsureExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName, const char* message)
        {
            if (argument == nullptr)
            {
                throw std::invalid_argument(((std::string)"Argument ").append(argumentName).append(" is null: ").append(message).append("."));
            }
        }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName) { ArgumentNotNull(root, argument, argumentName, ((std::string)"Argument ").append(argumentName).append(" is null.").data()); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument) { ArgumentNotNull(root, argument, nullptr); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName, const char* message)
        {
            if (!predicate(argument))
            {
                throw std::invalid_argument(((std::string)"Invalid ").append(argumentName).append(" argument: ").append(message).append("."));
            }
        }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName) { ArgumentMeetsCriteria(root, argument, predicate, argumentName, ((std::string)"Argument ").append(argumentName).append(" is does not meet criteria.").data()); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { ArgumentMeetsCriteria(root, argument, predicate, nullptr); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument, const char* argumentName, const char* message) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Ensure::Always, argument, argumentName, message); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument, const char* argumentName) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Ensure::Always, argument, argumentName); }

        public: template <typename TArgument> static void ArgumentNotNull(EnsureOnDebugExtensionRoot root, TArgument* argument) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Ensure::Always, argument); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName, const char* message) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Ensure::Always, argument, predicate, argumentName, message); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, const char* argumentName) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Ensure::Always, argument, predicate, argumentName); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Ensure::Always, argument, predicate); }
    };
}
