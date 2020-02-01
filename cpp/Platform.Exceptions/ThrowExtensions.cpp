namespace Platform::Exceptions
{
    class ThrowExtensions
    {
        public: static void NotSupportedException(Platform::Exceptions::ExtensionRoots::ThrowExtensionRoot root) { throw std::logic_error("Not supported exception."); }

        public: template <typename TReturn> static TReturn NotSupportedExceptionAndReturn(Platform::Exceptions::ExtensionRoots::ThrowExtensionRoot root) { throw std::logic_error("Not supported exception."); }

        public: static void NotImplementedException(Platform::Exceptions::ExtensionRoots::ThrowExtensionRoot root) { throw std::logic_error("Not implemented exception."); }

        public: template <typename TReturn> static TReturn NotImplementedExceptionAndReturn(Platform::Exceptions::ExtensionRoots::ThrowExtensionRoot root) { throw std::logic_error("Not implemented exception."); }
    };
}
