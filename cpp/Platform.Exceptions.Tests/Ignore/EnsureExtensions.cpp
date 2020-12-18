namespace Platform::Exceptions::Tests::Ignore
{
    class EnsureExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument* argument, std::string argumentName)
        {
        }
    };
}
