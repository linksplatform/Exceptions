namespace Platform::Exceptions
{
    void NotSupportedException() { throw std::logic_error("Not supported exception."); }

    void NotSupportedExceptionAndReturn() { throw std::logic_error("Not supported exception."); }

    void NotImplementedException() { throw std::logic_error("Not implemented exception."); }

    void NotImplementedExceptionAndReturn() { throw std::logic_error("Not implemented exception."); }

    void ArgumentLinkDoesNotExistsException() { throw std::logic_error("The passed link does not exists."); }

    void ArgumentLinkHasDependenciesException() { throw std::logic_error("The passed link has dependencies that prevents changes of the passed link inner structure."); }

    void LinkWithSameValueAlreadyExistsException() { throw std::logic_error("Link with same value already exists."); }

    void LinksLimitReachedException() { throw std::logic_error("Storage links limit has been reached."); }
}
