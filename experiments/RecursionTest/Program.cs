using System;
using System.Text;
using System.Collections.Generic;

namespace Platform.Exceptions.Tests
{
    /// <summary>
    /// Test program to compare recursive vs iterative implementations of BuildExceptionString
    /// </summary>
    public class RecursionTest
    {
        public static readonly string ExceptionContentsSeparator = "---";
        
        static void Main()
        {
            // Create nested exceptions for testing
            var innermost = new ArgumentException("Innermost exception");
            var middle = new InvalidOperationException("Middle exception", innermost);
            var outer = new Exception("Outer exception", middle);
            
            Console.WriteLine("Testing recursive vs iterative implementations:");
            Console.WriteLine();
            
            // Test recursive version (current implementation)
            var recursiveResult = ToStringWithAllInnerExceptionsRecursive(outer);
            Console.WriteLine("RECURSIVE VERSION:");
            Console.WriteLine(recursiveResult);
            Console.WriteLine();
            
            // Test iterative version
            var iterativeResult = ToStringWithAllInnerExceptionsIterative(outer);
            Console.WriteLine("ITERATIVE VERSION:");
            Console.WriteLine(iterativeResult);
            Console.WriteLine();
            
            // Compare results
            bool areEqual = recursiveResult == iterativeResult;
            Console.WriteLine($"Results are equal: {areEqual}");
            
            if (!areEqual)
            {
                Console.WriteLine("DIFFERENCE FOUND!");
                Console.WriteLine($"Recursive length: {recursiveResult.Length}");
                Console.WriteLine($"Iterative length: {iterativeResult.Length}");
            }
        }
        
        // Current recursive implementation
        public static string ToStringWithAllInnerExceptionsRecursive(Exception exception)
        {
            try
            {
                var sb = new StringBuilder();
                BuildExceptionStringRecursive(sb, exception, 0);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Unable to format exception.";
            }
        }
        
        private static void BuildExceptionStringRecursive(StringBuilder sb, Exception exception, int level)
        {
            Indent(sb, level);
            sb.AppendLine(exception.Message);
            Indent(sb, level);
            sb.AppendLine(ExceptionContentsSeparator);
            if (exception.InnerException != null)
            {
                Indent(sb, level);
                sb.AppendLine("Inner exception: ");
                BuildExceptionStringRecursive(sb, exception.InnerException, level + 1);
            }
            Indent(sb, level);
            sb.AppendLine(ExceptionContentsSeparator);
            Indent(sb, level);
            sb.AppendLine(exception.StackTrace);
        }
        
        // New iterative implementation
        public static string ToStringWithAllInnerExceptionsIterative(Exception exception)
        {
            try
            {
                var sb = new StringBuilder();
                BuildExceptionStringIterative(sb, exception);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "Unable to format exception.";
            }
        }
        
        private static void BuildExceptionStringIterative(StringBuilder sb, Exception exception)
        {
            // Let's trace through the exact recursive pattern step by step
            // For each exception, we need:
            // 1. Message
            // 2. Separator
            // 3. If there's an inner exception: "Inner exception: " + recurse
            // 4. Separator
            // 5. Stack trace
            
            // Use a simple iteration from outer to inner
            var current = exception;
            var level = 0;
            
            while (current != null)
            {
                // Step 1: Message with indent
                Indent(sb, level);
                sb.AppendLine(current.Message);
                
                // Step 2: Separator with indent
                Indent(sb, level);
                sb.AppendLine(ExceptionContentsSeparator);
                
                // Step 3: Check for inner exception
                if (current.InnerException != null)
                {
                    Indent(sb, level);
                    sb.AppendLine("Inner exception: ");
                    
                    // Move to inner exception for next iteration
                    current = current.InnerException;
                    level++;
                }
                else
                {
                    // Step 4: Final separator for innermost
                    Indent(sb, level);
                    sb.AppendLine(ExceptionContentsSeparator);
                    
                    // Step 5: Stack trace for innermost
                    Indent(sb, level);
                    sb.AppendLine(current.StackTrace);
                    break;
                }
            }
            
            // Now we need to add the trailing separators and stack traces for all outer exceptions
            // Working backwards from the chain
            var exceptions = new List<Exception>();
            current = exception;
            while (current != null)
            {
                exceptions.Add(current);
                current = current.InnerException;
            }
            
            // Add the closing parts for each exception (except the innermost which we already handled)
            for (int i = exceptions.Count - 2; i >= 0; i--)
            {
                Indent(sb, i);
                sb.AppendLine(ExceptionContentsSeparator);
                Indent(sb, i);
                sb.AppendLine(exceptions[i].StackTrace);
            }
        }
        
        private static void Indent(StringBuilder sb, int level) => sb.Append('\t', level);
    }
}
