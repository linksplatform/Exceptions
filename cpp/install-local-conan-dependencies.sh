#!/bin/bash

git clone https://github.com/linksplatform/conan-center-index
cd conan-center-index && cd recipes
conan create platform.delegates/all platform.delegates/0.3.7@
