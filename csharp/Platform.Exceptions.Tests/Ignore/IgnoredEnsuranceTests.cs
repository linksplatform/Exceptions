using Xunit;

namespace Platform.Exceptions.Tests.Ignore
{
    /// <summary>
    /// <para>
    /// Represents the ignored ensurance tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class IgnoredEnsuranceTests
    {
        /// <summary>
        /// <para>
        /// Tests that ensurance ignored test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void EnsuranceIgnoredTest()
        {
            // Should not throw an exception (because logic is overriden in EnsureAlwaysExtensions that is located within the same namespace)
            // And even should be optimized out at RELEASE (because method is now marked conditional DEBUG)
            // This can be useful in performance critical situations there even an check for exception is hurting performance enough
            Ensure.Always.ArgumentNotNull<object>(null, "object");
        }
    }
}
