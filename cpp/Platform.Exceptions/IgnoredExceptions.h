namespace Platform::Exceptions
{
    class IgnoredExceptions
    {
        private: inline static std::mutex _exceptionsBag_mutex;

        private: inline static std::vector<std::exception> _exceptionsBag;

        public: static std::vector<std::exception> CollectedExceptions() { return std::vector<std::exception>(_exceptionsBag); }

        public: inline static bool CollectExceptions;

        public: static void RaiseExceptionIgnoredEvent(const std::exception& exception) { ExceptionIgnored.Invoke({}, exception); }

        private: static void OnExceptionIgnored(void *sender, const std::exception& exception)
        {
            if (CollectExceptions)
            {
                _exceptionsBag.Add(exception);
            }
        }

        public: static inline Platform::Delegates::MulticastDelegate<void(void*, const std::exception&)> ExceptionIgnored = OnExceptionIgnored;
    };
}
