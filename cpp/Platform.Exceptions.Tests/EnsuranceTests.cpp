namespace Platform::Exceptions::Tests
{
    TEST(EnsuranceTests, ArgumentNotNullEnsuranceTest)
    {
        EXPECT_THROW(Ensure::Always::ArgumentNotNull(nullptr, "object"), std::invalid_argument);
    };
}
