namespace Platform::Exceptions::Tests
{
    TEST(ContractTests, ArgumentNotNullContractTest)
    {
        EXPECT_THROW(Contract::Always::ArgumentNotNull(nullptr, "object"), std::invalid_argument);
    };
}
