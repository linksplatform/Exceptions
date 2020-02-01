namespace Platform::Exceptions::Tests
{
    TEST_CLASS(Ensurance)
    {
        public: TEST_METHOD(ArgumentNotNullEnsuranceTest)
        {
            Assert.Throws<ArgumentNullException>(() { return Ensure.Always.ArgumentNotNull<object>(nullptr; }, "object"));
        }
    };
}
