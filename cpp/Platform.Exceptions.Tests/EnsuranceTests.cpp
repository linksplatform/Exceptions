namespace Platform::Exceptions::Tests
{
    TEST_CLASS(Ensurance)
    {
        public: TEST_METHOD(ArgumentNotNullEnsuranceTest)
        {
            Assert::ExpectException<std::invalid_argument>([&]()-> auto { return Ensure.Always.ArgumentNotNull<void*>(nullptr, "object"); });
        }
    };
}
