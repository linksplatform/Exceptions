namespace Platform::Exceptions
{
    class ThrowExtensions
    {
        public: static void NotSupportedException(ThrowExtensionRoot root) { throw std::logic_error("Not supported exception."); }

        public: template <typename TReturn> static TReturn NotSupportedExceptionAndReturn(ThrowExtensionRoot root) { throw std::logic_error("Not supported exception."); }

        public: static void NotImplementedException(ThrowExtensionRoot root) { throw std::logic_error("Not implemented exception."); }

        public: template <typename TReturn> static TReturn NotImplementedExceptionAndReturn(ThrowExtensionRoot root) { throw std::logic_error("Not implemented exception."); }
    };
}
