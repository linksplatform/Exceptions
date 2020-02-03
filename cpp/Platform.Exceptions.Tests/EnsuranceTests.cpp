namespace Platform::Exceptions::Tests
{
    TEST_CLASS(Ensurance)
    {
        public: TEST_METHOD(ArgumentNotNullEnsuranceTest)
        {
            Assert.Throws<ArgumentNullException>([&]()-> auto { return Ensure.Always.ArgumentNotNull<object>(nullptr, "object"); });
        }
    };
}
