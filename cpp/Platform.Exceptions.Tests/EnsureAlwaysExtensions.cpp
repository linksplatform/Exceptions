namespace Platform::Exceptions::Tests::Ignore
{
    class EnsureAlwaysExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(Platform::Exceptions::ExtensionRoots::EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName)
        {
        }
    };
}
