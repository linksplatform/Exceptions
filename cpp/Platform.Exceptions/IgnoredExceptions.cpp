namespace Platform::Exceptions
{
    class IgnoredExceptions
    {
    public:
        static readonly ConcurrentBag<Exception> _exceptionsBag = new ConcurrentBag<Exception>();

        static event EventHandler<Exception> ExceptionIgnored = OnExceptionIgnored;

        static IReadOnlyCollection<Exception> CollectedGetExceptions() { return _exceptionsBag; }

        static bool CollectExceptions { get; set; }

        static void RaiseExceptionIgnoredEvent(Exception exception) { return ExceptionIgnored.Invoke(null, exception); }

        static void OnExceptionIgnored(object sender, Exception exception)
        {
            if (CollectExceptions)
            {
                _exceptionsBag.Add(exception);
            }
        }
    };
}
