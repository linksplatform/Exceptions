using System;
using Platform.Exceptions;
// Using static directive for convenient access
using static Platform.Exceptions.Static.EnsureStatic;
using static Platform.Exceptions.Static.ThrowStatic;

namespace Platform.Exceptions.Examples
{
    public class StaticExtensionsUsage
    {
        // Example showing traditional usage vs static extensions usage
        public void TraditionalUsage()
        {
            string parameter = null;
            
            // Traditional way - using extension methods on root instances
            Ensure.Always.ArgumentNotNull(parameter, nameof(parameter));
            
            // Throw exceptions the traditional way
            Throw.A.NotSupportedException();
        }
        
        public void StaticExtensionsUsage()
        {
            string parameter = null;
            
            // New way - using static imports for cleaner syntax
            ArgumentNotNull(parameter, nameof(parameter));
            
            // Throw exceptions with static methods
            NotSupportedException();
        }
        
        public void AdvancedStaticUsage()
        {
            int value = 5;
            
            // Ensure argument meets criteria using static extension
            ArgumentMeetsCriteria(value, x => x > 0, nameof(value), "Value must be positive");
            
            // Throw exceptions with custom messages
            NotSupportedException("This feature is not yet implemented");
            NotImplementedException("This method needs to be implemented");
            
            // Throw ArgumentNullException directly
            ArgumentNullException(nameof(value), "Parameter cannot be null");
        }
        
        public T ExampleMethodWithReturn<T>()
        {
            // Return type can be inferred while throwing exception
            return NotSupportedExceptionAndReturn<T>();
        }
    }
}