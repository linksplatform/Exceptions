using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions
{
    public static class Ensure
    {
        public static readonly EnsureOnDebugExtensionRoot OnDebug = new EnsureOnDebugExtensionRoot();
        public static readonly EnsureAlwaysExtensionRoot Always = new EnsureAlwaysExtensionRoot();
    }
}
