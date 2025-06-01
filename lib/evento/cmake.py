def src():
    with open('cmake/src.cmake', 'w') as src:
        print('''# scan project for source code files

file(GLOB LD
    RELATIVE ${CMAKE_SOURCE_DIR}
    hw/${HW}/*.ld
)

file(GLOB S
    RELATIVE ${CMAKE_SOURCE_DIR}
    hw/${HW}/*.s
)

file(GLOB C
    RELATIVE ${CMAKE_SOURCE_DIR}
    src/*.c*
)

file(GLOB H
    RELATIVE ${CMAKE_SOURCE_DIR}
    inc/*.h*
)

file(GLOB INC
    RELATIVE ${CMAKE_SOURCE_DIR}
    ${CMAKE_BINARY_DIR}
    inc
)
include_directories(${INC})''', file=src)

def preset():
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

def lists(project):
    with open('CMakeLists.txt', 'w') as cmake:
        print(f'''\
cmake_minimum_required(VERSION 3.22)
get_filename_component(CMAKE_PROJECT_NAME "{project}" NAME_WE)
project(${{CMAKE_PROJECT_NAME}} LANGUAGES C CXX ASM)

include(version)        # binary files naming by version & git branch/hash
include(src)            # scan project for source code files
''', file=cmake)
        print('''\
message("-- |")
message("-- | toolchain: " ${CMAKE_CXX_COMPILER} " @ " ${CMAKE_TOOLCHAIN_FILE})
message("-- |      host: " ${CMAKE_HOST_SYSTEM_NAME}-${CMAKE_HOST_SYSTEM_VERSION})
message("-- |    target: " "hw:" ${HW} " cpu:" ${CPU} " arch:" ${ARCH} " os:" ${OS})
message("-- |   startup: " "${S}")
message("-- |    linker: " "${LD}")
message("-- |    binary: " ${CMAKE_INSTALL_PREFIX}/${BIN_OUTPUT_NAME}${CMAKE_EXECUTABLE_SUFFIX})
message("-- |")

add_executable(${CMAKE_PROJECT_NAME}
    ${C}  ${H}          # C/C++ source
    ${S}  ${LD}         # embedded/lowlevel
)

# target_link_libraries(${CMAKE_PROJECT_NAME} -static)

include(install)        # target install\
''', file=cmake)
