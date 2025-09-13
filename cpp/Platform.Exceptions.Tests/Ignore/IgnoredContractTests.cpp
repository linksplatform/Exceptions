namespace Platform::Exceptions::Tests::Ignore
{
    TEST(IgnoredContractTests, ContractIgnoredTest)
    {
        EXPECT_NO_THROW(Always::ArgumentNotNull(nullptr, "object"));
    };
}
