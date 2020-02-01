namespace Platform::Exceptions::Tests::Ignore
{
    TEST_CLASS(IgnoredEnsurance)
    {
        public: TEST_METHOD(EnsuranceIgnoredTest)
        {
            Ensure.Always.ArgumentNotNull<object>(nullptr, "object");
        }
    };
}
