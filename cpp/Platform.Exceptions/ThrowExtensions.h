namespace Platform::Exceptions
{
    auto NotSupportedException() { return std::logic_error("Not supported exception."); }

    auto NotSupportedExceptionAndReturn() { return std::logic_error("Not supported exception."); }

    auto NotImplementedException() { return std::logic_error("Not implemented exception."); }

    auto NotImplementedExceptionAndReturn() { return std::logic_error("Not implemented exception."); }

    auto ArgumentLinkDoesNotExistsException() { return std::logic_error("The passed link does not exists."); }

    auto ArgumentLinkHasDependenciesException() { return std::logic_error("The passed link inner structure changes are prevented by its dependencies."); }

    auto LinkWithSameValueAlreadyExistsException() { return std::logic_error("Link with same value already exists."); }

    auto LinksLimitReachedException() { return std::logic_error("Storage links limit has been reached."); }
}
