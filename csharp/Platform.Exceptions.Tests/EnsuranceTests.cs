﻿using System;
using Xunit;

namespace Platform.Exceptions.Tests
{
    public static class EnsuranceTests
    {
        [Fact]
        public static void ArgumentNotNullEnsuranceTest()
        {
            // Should throw an exception (even if in neighbour "Ignore" namespace it was overridden, but here this namespace is not used)
            Assert.Throws<ArgumentNullException>(() => Ensure.Always.ArgumentNotNull<object>(null, "object"));
        }
    }
}
