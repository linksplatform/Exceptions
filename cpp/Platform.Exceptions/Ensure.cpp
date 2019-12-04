namespace Platform::Exceptions
{
    class Ensure
    {
    public:
        static EnsureAlwaysExtensionRoot Always;

        static EnsureOnDebugExtensionRoot OnDebug;
    };
    EnsureAlwaysExtensionRoot Ensure::Always;
    EnsureOnDebugExtensionRoot Ensure::OnDebug;
}
