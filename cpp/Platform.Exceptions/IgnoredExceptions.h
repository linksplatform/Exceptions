namespace Platform::Exceptions
{
    class IgnoredExceptions
    {
        private: inline static std::mutex _exceptionsBag_mutex;

        private: inline static std::vector<std::exception> _exceptionsBag;

        public: static std::vector<std::exception> GetCollectedExceptions() { std::lock_guard<std::mutex> guard(_exceptionsBag_mutex); return std::vector<std::exception>(_exceptionsBag); }

        public: inline static bool CollectExceptions;

        public: static void RaiseExceptionIgnoredEvent(const std::exception& exception) { ExceptionIgnored({}, exception); }

        private: static void OnExceptionIgnored(void *sender, const std::exception& exception)
        {
            if (CollectExceptions)
            {
                std::lock_guard<std::mutex> guard(_exceptionsBag_mutex);
                _exceptionsBag.push_back(exception);
            }
        }

        public: static inline Platform::Delegates::MulticastDelegate<void(void*, const std::exception&)> ExceptionIgnored = OnExceptionIgnored;
    };
}
