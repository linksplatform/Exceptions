using System;
using Xunit;

namespace Platform.Assertions.Tests
{
    public static class EnsuranceTests
    {
        [Fact]
        public static void ArgumentNotNullEnsuranceTest()
        {
            // Should throw an exception
            Assert.Throws<ArgumentNullException>(() => Ensure.Always.ArgumentNotNull<object>(null, "object"));
        }
    }
}