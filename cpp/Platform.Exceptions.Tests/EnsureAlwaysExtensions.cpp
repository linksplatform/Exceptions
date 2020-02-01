namespace Platform::Exceptions::Tests::Ignore
{
    class EnsureAlwaysExtensions
    {
        public: template <typename TArgument> static void ArgumentNotNull(EnsureAlwaysExtensionRoot root, TArgument* argument, const char* argumentName)
        {
        }
    };
}
