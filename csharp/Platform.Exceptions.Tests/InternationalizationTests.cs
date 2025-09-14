using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace Platform.Exceptions.Tests
{
    /// <summary>
    /// <para>Tests for internationalization functionality.</para>
    /// <para>Тесты для функциональности интернационализации.</para>
    /// </summary>
    public class InternationalizationTests
    {
        /// <summary>
        /// <para>Tests that exception messages are localized based on the current culture.</para>
        /// <para>Проверяет, что сообщения исключений локализованы в соответствии с текущей культурой.</para>
        /// </summary>
        [Fact]
        public void TestArgumentNullExceptionLocalization()
        {
            // Test English (default)
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            var englishException = Assert.Throws<ArgumentNullException>(() => 
                Ensure.Always.ArgumentNotNull<string>(null, "testArg"));
            Assert.Contains("Argument testArg is null", englishException.Message);
            
            // Test Russian
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            var russianException = Assert.Throws<ArgumentNullException>(() => 
                Ensure.Always.ArgumentNotNull<string>(null, "testArg"));
            Assert.Contains("Аргумент testArg равен null", russianException.Message);
        }

        /// <summary>
        /// <para>Tests that argument criteria exception messages are localized.</para>
        /// <para>Проверяет, что сообщения исключений критериев аргументов локализованы.</para>
        /// </summary>
        [Fact]
        public void TestArgumentCriteriaExceptionLocalization()
        {
            // Test English (default)
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            var englishException = Assert.Throws<ArgumentException>(() => 
                Ensure.Always.ArgumentMeetsCriteria("test", x => x.Length > 10, "shortArg"));
            Assert.Contains("Argument shortArg does not meet the criteria", englishException.Message);
            
            // Test Russian
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            var russianException = Assert.Throws<ArgumentException>(() => 
                Ensure.Always.ArgumentMeetsCriteria("test", x => x.Length > 10, "shortArg"));
            Assert.Contains("Аргумент shortArg не соответствует критерию", russianException.Message);
        }

        /// <summary>
        /// <para>Tests that exception formatting strings are localized.</para>
        /// <para>Проверяет, что строки форматирования исключений локализованы.</para>
        /// </summary>
        [Fact]
        public void TestExceptionFormattingLocalization()
        {
            // Test English (default)  
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            var innerEx = new InvalidOperationException("Inner");
            var outerEx = new Exception("Outer", innerEx);
            var englishFormatted = outerEx.ToStringWithAllInnerExceptions();
            Assert.Contains("Inner exception:", englishFormatted);
            
            // Test Russian
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            var russianFormatted = outerEx.ToStringWithAllInnerExceptions();
            Assert.Contains("Внутреннее исключение:", russianFormatted);
        }
    }
}