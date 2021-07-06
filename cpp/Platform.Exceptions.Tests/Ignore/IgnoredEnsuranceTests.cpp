namespace Platform::Exceptions::Tests::Ignore
{
    TEST(IgnoredEnsuranceTests, EnsuranceIgnoredTest)
    {
        EXPECT_NO_THROW(Always::ArgumentNotNull(nullptr, "object"));
    };
}
