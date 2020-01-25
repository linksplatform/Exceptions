namespace Platform::Exceptions
{
    class IgnoredExceptions
    {
        private: static readonly ConcurrentBag<std::exception> _exceptionsBag = new ConcurrentBag<std::exception>();

        public: static event EventHandler<std::exception> ExceptionIgnored = OnExceptionIgnored;

        public: static IReadOnlyCollection<std::exception> GetCollectedExceptions() { return _exceptionsBag; }

        public: static bool CollectExceptions;

        public: static void RaiseExceptionIgnoredEvent(const std::exception& exception) { ExceptionIgnored.Invoke(NULL, exception); }

        private: static void OnExceptionIgnored(void *sender, const std::exception& exception)
        {
            if (CollectExceptions)
            {
                _exceptionsBag.Add(exception);
            }
        }
    };
}
