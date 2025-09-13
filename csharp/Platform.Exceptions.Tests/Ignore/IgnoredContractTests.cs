using Xunit;

namespace Platform.Exceptions.Tests.Ignore
{
    public static class IgnoredContractTests
    {
        [Fact]
        public static void ContractIgnoredTest()
        {
            // Should not throw an exception (because logic is overriden in ContractAlwaysExtensions that is located within the same namespace)
            // And even should be optimized out at RELEASE (because method is now marked conditional DEBUG)
            // This can be useful in performance critical situations there even an check for exception is hurting performance enough
            Contract.Always.ArgumentNotNull<object>(null, "object");
        }
    }
}
