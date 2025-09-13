using System;
using Xunit;

namespace Platform.Exceptions.Tests
{
    public static class ContractTests
    {
        [Fact]
        public static void ArgumentNotNullContractTest()
        {
            // Should throw an exception (even if in neighbour "Ignore" namespace it was overridden, but here this namespace is not used)
            Assert.Throws<ArgumentNullException>(() => Contract.Always.ArgumentNotNull<object>(null, "object"));
        }
    }
}
