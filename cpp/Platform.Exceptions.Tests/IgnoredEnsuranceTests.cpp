namespace Platform::Exceptions::Tests::Ignore
{
    TEST_CLASS(IgnoredEnsurance)
    {
        public: TEST_METHOD(EnsuranceIgnoredTest)
        {
            Platform::Exceptions::EnsureExtensions::ArgumentNotNull<void*>(Ensure::Always, nullptr, "object");
        }
    };
}
