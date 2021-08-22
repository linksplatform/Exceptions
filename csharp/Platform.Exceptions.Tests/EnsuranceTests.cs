using System;
using Xunit;

namespace Platform.Exceptions.Tests
{
    /// <summary>
    /// <para>
    /// Represents the ensurance tests.
    /// </para>
    /// <para></para>
    /// </summary>
    public static class EnsuranceTests
    {
        /// <summary>
        /// <para>
        /// Tests that argument not null ensurance test.
        /// </para>
        /// <para></para>
        /// </summary>
        [Fact]
        public static void ArgumentNotNullEnsuranceTest()
        {
            // Should throw an exception (even if in neighbour "Ignore" namespace it was overridden, but here this namespace is not used)
            Assert.Throws<ArgumentNullException>(() => Ensure.Always.ArgumentNotNull<object>(null, "object"));
        }
    }
}
