#!/bin/bash

git clone https://github.com/linksplatform/conan-center-index
cd conan-center-index && git checkout only-development && cd recipes
conan create platform.delegates/all platform.delegates/0.1.3@ -pr=linksplatform
