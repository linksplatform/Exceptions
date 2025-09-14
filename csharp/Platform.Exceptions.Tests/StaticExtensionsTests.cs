using System;
using Xunit;
using static Platform.Exceptions.Static.EnsureStatic;
using static Platform.Exceptions.Static.ThrowStatic;

namespace Platform.Exceptions.Tests
{
    public static class StaticExtensionsTests
    {
        [Fact]
        public static void StaticArgumentNotNullTest()
        {
            // Test static extension usage with using static directive
            Assert.Throws<ArgumentNullException>(() => ArgumentNotNull<object>(null, "object"));
        }

        [Fact]
        public static void StaticNotSupportedExceptionTest()
        {
            // Test static extension usage with using static directive
            Assert.Throws<NotSupportedException>(() => NotSupportedException());
        }

        [Fact]
        public static void StaticNotImplementedExceptionTest()
        {
            // Test static extension usage with using static directive
            Assert.Throws<NotImplementedException>(() => NotImplementedException());
        }

        [Fact]
        public static void StaticArgumentMeetsCriteriaTest()
        {
            // Test static extension usage with using static directive
            Assert.Throws<ArgumentException>(() => ArgumentMeetsCriteria(5, x => x > 10, "number", "Number must be greater than 10"));
        }

        [Fact]
        public static void StaticNotSupportedExceptionWithMessageTest()
        {
            // Test static extension usage with custom message
            var exception = Assert.Throws<NotSupportedException>(() => NotSupportedException("Custom message"));
            Assert.Equal("Custom message", exception.Message);
        }

        [Fact]
        public static void StaticArgumentNullExceptionTest()
        {
            // Test static extension usage for ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => ArgumentNullException("testParam"));
        }

        [Fact]
        public static void StaticArgumentExceptionTest()
        {
            // Test static extension usage for ArgumentException
            Assert.Throws<ArgumentException>(() => ArgumentException("Invalid argument", "testParam"));
        }

        [Fact]
        public static void StaticNotSupportedExceptionAndReturnTest()
        {
            // Test static extension usage that returns a value
            Assert.Throws<NotSupportedException>(() => NotSupportedExceptionAndReturn<int>());
        }

        [Fact]
        public static void StaticNotImplementedExceptionAndReturnTest()
        {
            // Test static extension usage that returns a value
            Assert.Throws<NotImplementedException>(() => NotImplementedExceptionAndReturn<string>());
        }
    }
}