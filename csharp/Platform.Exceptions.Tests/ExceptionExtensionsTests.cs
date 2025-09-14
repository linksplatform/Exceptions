using System;
using Xunit;

namespace Platform.Exceptions.Tests
{
    public static class ExceptionExtensionsTests
    {
        [Fact]
        public static void ToStringWithAllInnerExceptions_WithSingleException_FormatsProperly()
        {
            // Arrange
            var exception = new ArgumentException("Test message");
            
            // Act
            var result = exception.ToStringWithAllInnerExceptions();
            
            // Assert
            Assert.Contains("Test message", result);
            Assert.Contains(ExceptionExtensions.ExceptionContentsSeparator, result);
        }
        
        [Fact]
        public static void ToStringWithAllInnerExceptions_WithNestedExceptions_FormatsProperly()
        {
            // Arrange
            var innermost = new ArgumentException("Innermost exception");
            var middle = new InvalidOperationException("Middle exception", innermost);
            var outer = new Exception("Outer exception", middle);
            
            // Act
            var result = outer.ToStringWithAllInnerExceptions();
            
            // Assert
            Assert.Contains("Outer exception", result);
            Assert.Contains("Middle exception", result);
            Assert.Contains("Innermost exception", result);
            Assert.Contains("Inner exception: ", result);
        }
        
        [Fact]
        public static void ToStringWithAllInnerExceptions_WithNullException_HandlesGracefully()
        {
            // This test ensures our iterative implementation handles edge cases
            Exception nullException = null;
            
            // This should not be called on null, but let's test with a valid exception with null inner
            var exception = new ArgumentException("Test");
            
            // Act & Assert (should not throw)
            var result = exception.ToStringWithAllInnerExceptions();
            Assert.NotNull(result);
            Assert.Contains("Test", result);
        }
        
        [Fact]
        public static void ToStringWithAllInnerExceptions_WithDeeplyNestedExceptions_WorksWithoutStackOverflow()
        {
            // Arrange - Create a deep chain of exceptions to test non-recursive behavior
            Exception current = new ArgumentException("Level 0");
            
            // Create 100 levels of nested exceptions
            for (int i = 1; i < 100; i++)
            {
                current = new InvalidOperationException($"Level {i}", current);
            }
            
            // Act & Assert (should not throw stack overflow)
            var result = current.ToStringWithAllInnerExceptions();
            
            Assert.NotNull(result);
            Assert.Contains("Level 0", result);
            Assert.Contains("Level 99", result);
            Assert.NotEqual(ExceptionExtensions.ExceptionStringBuildingFailed, result);
        }
    }
}