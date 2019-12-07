namespace Platform::Exceptions
{
    class IgnoredExceptions
    {
    public:
        static readonly ConcurrentBag<std::exception> _exceptionsBag = new ConcurrentBag<std::exception>();

        static event EventHandler<std::exception> ExceptionIgnored = OnExceptionIgnored;

        static IReadOnlyCollection<std::exception> CollectedGetExceptions() { return _exceptionsBag; }

        static bool CollectExceptions { get; set; }

        static void RaiseExceptionIgnoredEvent(const std::exception& exception) { ExceptionIgnored.Invoke(null, exception); }

        static void OnExceptionIgnored(object sender, const std::exception& exception)
        {
            if (CollectExceptions)
            {
                _exceptionsBag.Add(exception);
            }
        }
    };
}
