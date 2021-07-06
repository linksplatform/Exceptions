namespace Platform::Exceptions
{
    void NotSupportedException() { throw std::logic_error("Not supported exception."); }

    auto NotSupportedExceptionAndReturn() { throw std::logic_error("Not supported exception."); }

    void NotImplementedException() { throw std::logic_error("Not implemented exception."); }

    auto NotImplementedExceptionAndReturn() { throw std::logic_error("Not implemented exception."); }
}
