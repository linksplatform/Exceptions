namespace Platform::Exceptions::Tests::Ignore::Always
{
    void ArgumentNotNull(auto argument, const std::string& argumentName)
        requires std::is_pointer_v<decltype(argument)> || std::is_null_pointer_v<decltype(argument)>
    {
    }
}
