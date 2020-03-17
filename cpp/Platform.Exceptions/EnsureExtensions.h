namespace Platform::Exceptions
{
    class EnsureExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument* argument, std::string argumentName, std::string message)
        {
            if (argument == nullptr)
            {
                throw std::invalid_argument(std::string("Argument ").append(argumentName).append(" is null: ").append(message).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument* argument, std::string argumentName) { ArgumentNotNull(root, argument, argumentName, std::string("Argument ").append(argumentName).append(" is null.")); }

        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument* argument) { ArgumentNotNull(root, argument, {}); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, std::string argumentName, std::string message)
        {
            if (!predicate(argument))
            {
                throw std::invalid_argument(std::string("Invalid ").append(argumentName).append(" argument: ").append(message).append(1, '.'));
            }
        }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, std::string argumentName) { ArgumentMeetsCriteria(root, argument, predicate, argumentName, std::string("Argument ").append(argumentName).append(" does not meet the criteria.")); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { ArgumentMeetsCriteria(root, argument, predicate, {}); }

        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument* argument, std::string argumentName, std::string message) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Platform::Exceptions::Ensure::Always, argument, argumentName, message); }

        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument* argument, std::string argumentName) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Platform::Exceptions::Ensure::Always, argument, argumentName); }

        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument* argument) { Platform::Exceptions::EnsureExtensions::ArgumentNotNull(Platform::Exceptions::Ensure::Always, argument); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, std::string argumentName, std::string message) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Platform::Exceptions::Ensure::Always, argument, predicate, argumentName, message); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate, std::string argumentName) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Platform::Exceptions::Ensure::Always, argument, predicate, argumentName); }

        public: template <typename TArgument> static void ArgumentMeetsCriteria(Platform::Exceptions::ExtensionRoots::EnsureOnDebugExtensionRoot root, TArgument argument, std::function<bool(TArgument)> predicate) { Platform::Exceptions::EnsureExtensions::ArgumentMeetsCriteria(Platform::Exceptions::Ensure::Always, argument, predicate); }
    };
}
