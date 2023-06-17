cmake_minimum_required(VERSION 3.15)
project(Platform.Exceptions)
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}/bin)

find_package(GTest REQUIRED)
find_package(Platform.Delegates REQUIRED)

add_library(${PROJECT_NAME}.Library INTERFACE)
target_include_directories(${PROJECT_NAME}.Library INTERFACE ${PROJECT_NAME})
target_link_libraries(${PROJECT_NAME}.Library INTERFACE Platform.Delegates::Platform.Delegates)

if(${LINKS_PLATFORM_TESTS})
    add_executable(${PROJECT_NAME}.Tests ${PROJECT_NAME}.Tests/AllTests.cpp)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE ${PROJECT_NAME}.Library)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest)
    target_link_libraries(${PROJECT_NAME}.Tests PRIVATE GTest::gtest_main)
    set_target_properties(${PROJECT_NAME}.Tests PROPERTIES CXX_STANDARD 20)
endif()