﻿namespace Platform::Exceptions::Tests
{
    TEST_CLASS(EnsuranceTests)
    {
        public: TEST_METHOD(ArgumentNotNullEnsuranceTest)
        {
            Assert::ExpectException<std::invalid_argument>([&]()-> auto { return Platform::Exceptions::EnsureExtensions::ArgumentNotNull<void*>(Platform::Exceptions::Ensure::Always, {}, "object"); });
        }
    };
}
