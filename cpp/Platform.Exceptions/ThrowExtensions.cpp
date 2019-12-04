namespace Platform::Exceptions
{
    class ThrowExtensions
    {
    public:
        static void NotSupportedException(ThrowExtensionRoot root) { return throw std::logic_error("Not supported exception."); }

        template <typename TReturn> static TReturn NotSupportedExceptionAndReturn(ThrowExtensionRoot root) { return throw std::logic_error("Not supported exception."); }

        static void NotImplementedException(ThrowExtensionRoot root) { return throw std::logic_error("Not implemented exception."); }

        template <typename TReturn> static TReturn NotImplementedExceptionAndReturn(ThrowExtensionRoot root) { return throw std::logic_error("Not implemented exception."); }
    };
}
