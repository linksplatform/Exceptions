using Platform.Exceptions.ExtensionRoots;

namespace Platform.Exceptions
{
    /// <summary>
    /// <para>Contains two extensible classes instances that can be supplemented with static helper methods by using the extension mechanism. These methods ensure the contract compliance.</para>
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// <para>Gets an instance of the extension root class that contains helper methods to guarantee compliance with the contract.</para>
        /// </summary>
        public static readonly EnsureAlwaysExtensionRoot Always = new EnsureAlwaysExtensionRoot();

        /// <summary>
        /// <para>Gets an instance of the extension root class that contains helper methods to guarantee compliance with the contract, but are executed only during debugging.</para>
        /// </summary>
        public static readonly EnsureOnDebugExtensionRoot OnDebug = new EnsureOnDebugExtensionRoot();
    }
}
