from AST import AST

class Module(AST):
    def compile(self):
        super().compile()
        self.cmake()
        self.cpreset()

    def cpreset(self):
        with open('CMakePresets.json', 'w') as cp:
            print('''\
{
    "version": 6,
    "buildPresets": [
        {
            "name"            :  "linux",
            "configurePreset" :  "linux",
            "targets"         : ["all","install"]
        }
    ],
    "configurePresets": [
        {
            "name"            : "common",
            "hidden"          :  true,
            "binaryDir"       : "${sourceDir}/tmp/${presetName}",
            "generator"       : "Unix Makefiles",
            "cacheVariables"  : {
                "CMAKE_INSTALL_PREFIX"    : "${sourceDir}/bin",
                "CMAKE_MODULE_PATH"       : "${sourceDir}/cmake",
                "CMAKE_COLOR_DIAGNOSTICS" :  false,
                "CMAKE_BUILD_TYPE"        : "Debug",
                "CMAKE_VERBOSE_MAKEFILE"  :  false
            }
        },
        {
            "name"            : "pc",
            "inherits"        : "common",
            "hidden"          :  true,
            "cacheVariables"  : {"HW":"pc", "CPU":"i5", "ARCH":"x86_64"}
        },
        {
            "name"            : "linux",
            "inherits"        : "pc",
            "toolchainFile"   : "${sourceDir}/cmake/x86_64-linux-gnu.cmake",
            "cacheVariables"  : {"OS":"linux"}
        }
    ]
}''', file=cp)

    def cmake(self):
        with open('CMakeLists.txt', 'w') as cmake:
            try: pname = self['PROJECT'].val()
            except KeyError: pname = self.val()
            print(f'''\
cmake_minimum_required(VERSION 3.22)
get_filename_component(CMAKE_PROJECT_NAME "{pname}" NAME_WE)
project(${{CMAKE_PROJECT_NAME}} LANGUAGES C CXX ASM)
''', file=cmake)

    def cpp(self):
        with open(f'src/{self.val()}.cpp', 'w') as cpp:
            print(f"#include <{self.val()}.hpp>", file=cpp)
            print('''
int main(int argc, char* argv[]) {}
void arg(int argc, char* argv  ) {}
''', file=cpp)

    def hpp(self):
        with open(f'inc/{self.val()}.hpp', 'w') as hpp:
            print('#pragma once', file=hpp)
            print('''
#include <stdio.h>
#include <stdlib.h>
#include <assert.h>''', file=hpp)
            print('''
extern int main(int argc, char* argv[]);
extern void arg(int argc, char* argv  );
''', file=hpp)
