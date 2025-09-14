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
            var stack = new Stack<(Exception ex, int level)>();
            stack.Push((exception, 0));
            
            while (stack.Count > 0)
            {
                var (current, level) = stack.Pop();
                
                Indent(sb, level);
                sb.AppendLine(current.Message);
                Indent(sb, level);
                sb.AppendLine(ExceptionContentsSeparator);
                
                if (current.InnerException != null)
                {
                    Indent(sb, level);
                    sb.AppendLine("Inner exception: ");
                    stack.Push((current.InnerException, level + 1));
                }
                
                Indent(sb, level);
                sb.AppendLine(ExceptionContentsSeparator);
                Indent(sb, level);
                sb.AppendLine(current.StackTrace);
            }
        }
        
        private static void Indent(StringBuilder sb, int level) => sb.Append('\t', level);
    }
}