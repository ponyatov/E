let APP = "E"
let VERSION = "0.0.1"
let TITLE = "embedded programming language prototype"
let AUTHOR = "Dmitry Ponyatov"
let EMAIL = "dponyatov@gmail.com"
let YEAR = 2025
let LICENSE = "MIT"
let GITHUB = "https://github.com/ponyatov"

let ABOUT =
    "
- smart vehicles, industrial automation & IIoT
- targets microcontrollers & embedded Linux
- heterogenous distributed systems
- wireless sensor networks
"

open System.IO

let README () =
    File.WriteAllText(
        "README.md",
        $"\
# ![logo](vscode/logo.png) `{APP}` {VERSION}
## {TITLE}

(c) {AUTHOR} <{EMAIL}> {YEAR} {LICENSE}

github: {GITHUB}/{APP}
{ABOUT}"
    )

let LICENSE () =
    File.WriteAllText("LICENSE",$"MIT License

Copyright (c) {AUTHOR} <{EMAIL}> {YEAR} {LICENSE}

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the \"Software\"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
")

let tmp () =
    for d in [ "bin"; "tmp"; "ref" ] do
        Directory.CreateDirectory(d)
        File.WriteAllText($"{d}/.gitignore", "*\n!.gitignore\n")

let c_cpp_properties () =
    File.WriteAllText(
        ".vscode/c_cpp_properties.json",
"""{
    "version": 4,
    "env":{
        "appInclude": [
            "${workspaceFolder}/inc/**",
            "${workspaceFolder}/tmp/**",
            "${workspaceFolder}/src/**"
        ],
        "crossInclude": [
            "${workspaceFolder}/hw/inc/**",
            "${workspaceFolder}/cpu/inc/**",
            "${workspaceFolder}/arch/inc/**",
            "${workspaceFolder}/os/inc/**"
        ]
    },
    "configurations": [
        {
            "name"                 : "cmake",
            "configurationProvider": "ms-vscode.cmake-tools",
            "mergeConfigurations"  :  true,
            "includePath": [
                "${appInclude}", "${crossInclude}"
            ],
            "defines": [
                "PC", "I5", "X86_64", "LINUX"
            ]
        }
    ]
}
"""
    )

let launch () =
    File.WriteAllText(".vscode/launch.json",
"""{
    "version": "0.2.0",
    "configurations": [
        {
            "name"          : "cmake:linux",
            "type"          : "cppdbg",
            "request"       : "launch",
            "program"       : "${command:cmake.launchTargetPath}",
            "preLaunchTask" : "CMake: build",
            "cwd"           : "${workspaceFolder}",
            "MIMode"        : "gdb",
            "stopAtEntry"   : true,
            "setupCommands" : [
                {"text": "-enable-pretty-printing", "ignoreFailures": true}
            ],
            "args"          : [
                "${workspaceFolder}/lib/${workspaceFolderBasename}.ini"
            ]
        }
    ]
}
""")

let extensions () =
    File.WriteAllText(".vscode/extensions.json",
"""{
    "recommendations": [
        "stkb.rewrap",
        "ms-vscode.makefile-tools",
        "IBM.output-colorizer",
        // formatters
        "xaver.clang-format",
        "foxundermoon.shell-format",
        "esbenp.prettier-vscode",
        // Linux
        "ms-vscode-remote.remote-ssh",
        "coolbear.systemd-unit-file",
        // misc
        "usernamehw.errorlens",
        "hbenl.vscode-test-explorer",
        // C++
        "ms-vscode.cpptools",
        "jeff-hykin.better-cpp-syntax",
        "ms-vscode.cmake-tools",
        // parser
        "daohong-emilio.yash",
        "rreverser.ragel",
        // embedded
        "basdp.language-gas-x86",
        "dan-c-underwood.arm",
        "zixuanwang.linkerscript",
        "ms-vscode.vscode-serial-monitor",
        // Python
        "ms-python.python",
        "ms-python.autopep8",
        // Rust
        "rust-lang.rust-analyzer",
        "tamasfe.even-better-toml",
        "vadimcn.vscode-lldb",
        // F#
        "ionide.ionide-fsharp",
        "redhat.vscode-xml",
        "mnxn.fsharp-fsl-fsy",
    ]
}
""")

let tasks () =
    File.WriteAllText(".vscode/tasks.json",
"""{
    "version": "2.0.0",
    "tasks": [
        {
            "label"          : "project: install",
            "type"           : "shell",
            "command"        : "make install",
            "presentation"   : {"focus": true},
            "problemMatcher" : []
        },
        {
            "label"          : "project: update",
            "type"           : "shell",
            "command"        : "make update",
            "presentation"   : {"focus": true},
            "problemMatcher" : []
        },
        {
            "label"          : "AI: context",
            "type"           : "shell",
            "command"        : "make ai",
            "problemMatcher" : [],
            "presentation"   : {"showReuseMessage": true, "focus": true, "reveal": "silent", "close": false},
            "group"          : {"kind": "build", "isDefault": true}
        },
    ]
}
""")

let settings () =
    File.WriteAllText(".vscode/settings.json",
"""{
    // files
    "files.exclude": {
        "doc/html": true, "node_modules": true,
    },
    "files.watcherExclude": {
        "ref/**": true, "target/**": true, "obj/**": true,
    },
    "files.associations": {
        "*.mk": "makefile",
        "*.ld*": "linkerscript", "*.s": "arm", "memory.x": "linkerscript",
        "*.ocd": "properties", "*.gdb": "properties",
        "*.ioc": "properties", "*.config": "properties",
        "*.kernel": "properties", "*.service": "systemd-unit-file",
    },

    // editor
    "files.eol": "\n",
    "files.insertFinalNewline": true,
    "files.trimFinalNewlines": true,
    "editor.tabSize": 4,
    "editor.insertSpaces": true,
    "editor.detectIndentation": false,
    "editor.rulers": [80],
    "editor.lineNumbers": "on",
    "workbench.tree.indent": 24,
    "editor.fontSize": 14,
    "explorer.autoReveal": false,
    "terminal.integrated.copyOnSelection": true,
    "editor.formatOnSave":  false,
    "git.enabled": false,

    // terminal
    "SerialTerminal.serial port.configurations": ["115200n1"],

    // JavaScript
    "prettier.configPath"         : ".prettierrc",
    "prettier.requireConfig"      :  true,
    "json.format.enable"          :  true,

    // clang-format
    "clang-format.executable"     : "clang-format",
    "clang-format.fallbackStyle"  : "Google",
    "clang-format.style"          : "file",

    // C++
    "[c]"  : { "editor.defaultFormatter" : "xaver.clang-format" },
    "[cpp]": { "editor.defaultFormatter" : "xaver.clang-format" },
    // "C_Cpp.intelliSenseEngine": "Tag Parser",
    "C_Cpp.default.configurationProvider": "ms-vscode.cmake-tools",

    // CMake
    "cmake.sourceDirectory" : "${workspaceFolder}",
    "cmake.buildDirectory"  : "${workspaceFolder}/tmp/${workspaceFolderBasename}",
    "cmake.generator"       : "Unix Makefiles",
    "cmake.parallelJobs"    :  2,
    "cmake.useCMakePresets" : "always",
    "cmake.ignoreCMakeListsMissing" : false,
    "cmake.buildBeforeRun"  :  true,
    "cmake.saveBeforeBuild" :  true,
    "cmake.debugConfig"     : {
        "cwd" :   "${workspaceFolder}",
        "args": [ "lib/${workspaceFolderBasename}.ini" ] },
    "cmake.allowCommentsInPresetsFile" : true,

    // Python
    "python.defaultInterpreterPath":  "python3",
    "autopep8.path"                : ["autopep8"],
    "autopep8.args"                : ["--ignore","E26,E302,E305,E401,E402,E701,E702"],
    "[python]": {
        "editor.defaultFormatter"  : "ms-python.autopep8",
    },
    "python.autoComplete.extraPaths": ["src/${workspaceFolderBasename}"],

    // Rust
    "rust-analyzer.checkOnSave"     : false,
    "rust-analyzer.check.allTargets": false,
    "rust-analyzer.cargo.target"    : "x86_64-unknown-linux-gnu",
    // "rust-analyzer.cargo.target"    : "aarch64-unknown-linux-gnu",
    // "rust-analyzer.cargo.target"    : "wasm32-unknown-unknown",
    // "rust-analyzer.cargo.target"    : "thumbv7m-none-eabihf",
    // "rust-analyzer.cargo.target"    : "thumbv7em-none-eabihf",
    // "rust-analyzer.cargo.target"    : "i686-pc-windows-gnu",
    "[rust]": {
        "editor.defaultFormatter": "rust-lang.rust-analyzer",
    },

    // MinGW/MSYS2
    "terminal.integrated.defaultProfile.windows": "UCRT64",
    "terminal.integrated.profiles.windows": {
      "UCRT64": {
        "path": "C:\\msys64\\usr\\bin\\bash.exe",
        "args": ["--login","-i"],
        "env": {
          "MSYSTEM": "UCRT64",
          "CHERE_INVOKING": "1",
        }}},
}
""")

let vscode () =
    let vs = ".vscode"
    Directory.CreateDirectory(vs)
    File.WriteAllText($"{vs}/.gitignore", "!.gitignore\n")
    c_cpp_properties
    launch
    extensions
    tasks
    settings

let doc () = 
    Directory.CreateDirectory("doc")
    File.WriteAllText($"doc/.gitignore", "html/\n!.gitignore\n")


let giti() = 
    File.WriteAllText(".gitignore",
"*~
*.swp
*.log
/target/
/obj/
__pycache__/
node_modules/
!.gitignore
")

let cargo () =
    let app = APP.ToLower()
    File.WriteAllText("Cargo.toml", $"[package]
name        =  \"{app}\"
version     =  \"{VERSION}\"
description =  \"{TITLE}\"
authors     = [\"{AUTHOR} <{EMAIL}>\"]
license     =  \"{LICENSE}\"
edition     =  \"2024\"

[dependencies]
")

let src () =
    Directory.CreateDirectory("lib")
    File.WriteAllText($"lib/.gitignore", "")
    Directory.CreateDirectory("inc")
    File.WriteAllText($"inc/.gitignore", "")
    Directory.CreateDirectory("src")
    File.WriteAllText($"src/.gitignore", "")

let rust () =
    cargo
    File.WriteAllText($"src/main.rs", "fn main() {}\n")
    File.WriteAllText($"src/lib.rs", "")

let cpp () =
    File.WriteAllText($"inc/hpp.hpp", "#pragma once\n")
    File.WriteAllText($"src/cpp.cpp", "#include \"hpp.hpp\"\nint main() {}\n")

let CMakeLists () =
    File.WriteAllText("CMakeLists.txt","""cmake_minimum_required(VERSION 3.22)
get_filename_component(CMAKE_PROJECT_NAME ${CMAKE_SOURCE_DIR} NAME_WE)
project(${CMAKE_PROJECT_NAME} LANGUAGES C CXX ASM)

include(version)        # binary files naming by version & git branch/hash
include(src)            # scan project for source code files
include(syntax)         # parser generators (flex,yacc/bison,ragel,lemon,..)

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
    ${CP} ${HP} ${OP}   # parsers
)

# target_link_libraries(${CMAKE_PROJECT_NAME} -static)

include(install)        # target install
include(cross)          # cross compiler binaries: elf/dfu
include(clean)          # project clean-up (remove generated & temp files)
""")

let CMakePresets () =
    File.WriteAllText("CMakePresets.json","""{
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
}
""")

let clean () =
    File.WriteAllText($"cmake/clean.cmake",
"""# project clean-up (remove generated & temp files)

file(GLOB BINS
    ${CMAKE_INSTALL_PREFIX}/${CMAKE_PROJECT_NAME}_${HW}_${BRANCH}*
        ${CMAKE_BINARY_DIR}/${CMAKE_PROJECT_NAME}_${HW}_${BRANCH}*)

set_property (
    TARGET ${CMAKE_PROJECT_NAME}
    APPEND PROPERTY ADDITIONAL_CLEAN_FILES ${BINS} ${ELF} ${DFU})
""")

let version () =
    File.WriteAllText($"cmake/version.cmake",
"""# binary files naming by version & git branch/hash

execute_process(
    OUTPUT_VARIABLE REL
    COMMAND git rev-parse --short=4 HEAD
    WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}
    OUTPUT_STRIP_TRAILING_WHITESPACE
)

execute_process(
    OUTPUT_VARIABLE BRANCH
    COMMAND git rev-parse --abbrev-ref HEAD
    WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}
    OUTPUT_STRIP_TRAILING_WHITESPACE
)

execute_process(
    OUTPUT_VARIABLE NOW
    COMMAND date +%y%m%d # _%H%M
    WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}
    OUTPUT_STRIP_TRAILING_WHITESPACE
)

set(BIN_OUTPUT_NAME "${CMAKE_PROJECT_NAME}_${HW}_${BRANCH}_${NOW}")
""")

let cmsrc () =
    File.WriteAllText($"cmake/src.cmake",
"""# scan project for source code files

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
    # cross
      hw/src/*.c*   hw/${HW}/src/*.c*
     cpu/src/*.c*  cpu/${CPU}/src/*.c*
    arch/src/*.c* arch/${ARCH}/src/*.c*
      os/src/*.c*   os/${OS}/src/*.c*
)

file(GLOB H
    RELATIVE ${CMAKE_SOURCE_DIR}
    inc/*.h*
    # cross
      hw/inc/*.h*   hw/${HW}/inc/*.h*
     cpu/inc/*.h*  cpu/${CPU}/inc/*.h*
    arch/inc/*.h* arch/${ARCH}/inc/*.h*
      os/inc/*.h*   os/${OS}/inc/*.h*
)

file(GLOB INC
    RELATIVE ${CMAKE_SOURCE_DIR}
    ${CMAKE_BINARY_DIR}
    inc
    # cross
      hw/inc   hw/${HW}/inc
     cpu/inc  cpu/${CPU}/inc
    arch/inc arch/${ARCH}/inc
      os/inc   os/${OS}/inc
)
include_directories(${INC})
""")

let cross () =
    File.WriteAllText($"cmake/cross.cmake",
"""# cross compiler binaries: elf/dfu

set(ELF ${CMAKE_INSTALL_PREFIX}/${BIN_OUTPUT_NAME}.elf)
set(DFU ${CMAKE_INSTALL_PREFIX}/${BIN_OUTPUT_NAME}.dfu)

add_custom_command(
    OUTPUT  ${DFU}
    DEPENDS ${ELF}
    COMMAND ../elf2dfuse/bin/elf2dfuse ${ELF} ${DFU}
    WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}
)
add_custom_target(dfu DEPENDS ${DFU})
""")

let syntax () =
    File.WriteAllText($"cmake/syntax.cmake",
"""# parser generators (flex,yacc/bison,ragel,lemon,..)

# find_package(FLEX     REQUIRED)
# find_package(BISON    REQUIRED)
# find_package(Readline REQUIRED)
# find_package(RAGEL    REQUIRED)
# find_package(LEMON    REQUIRED)

file(GLOB L
    RELATIVE ${CMAKE_SOURCE_DIR}
    src/*.lex
    lib/src/*.lex lib/*/src/*.lex
)

file(GLOB Y
    RELATIVE ${CMAKE_SOURCE_DIR}
    src/*.yacc
    lib/src/*.yacc lib/*/src/*.yacc
)

file(GLOB R
    RELATIVE ${CMAKE_SOURCE_DIR}
    src/*.ragel
    lib/src/*.ragel lib/*/src/*.ragel
)

file(GLOB M
    RELATIVE ${CMAKE_SOURCE_DIR}
    src/*.lemon
    lib/src/*.lemon lib/*/src/*.lemon
)

foreach(LEX_FILE ${L})
    string(REGEX REPLACE ".+\/(.+)\.lex$" "${CMAKE_BINARY_DIR}/\\1.lex.cpp"
        LEXER_CPP           ${LEX_FILE})
        list(APPEND CP      ${LEXER_CPP})
    string(REGEX REPLACE ".+\/(.+)\.lex$" "${CMAKE_BINARY_DIR}/\\1.lex.hpp"
        LEXER_HPP           ${LEX_FILE})
        list(APPEND HP      ${LEXER_HPP})
    add_custom_command(
        OUTPUT              ${LEXER_CPP} ${LEXER_HPP}
        DEPENDS             ${LEX_FILE}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             ${FLEX_EXECUTABLE}
        ARGS                --header-file=${LEXER_HPP} -o ${LEXER_CPP} ${LEX_FILE}
    )
endforeach()

foreach(YACC_FILE ${Y})
    string(REGEX REPLACE ".+\/(.+)\.yacc$" "${CMAKE_BINARY_DIR}/\\1.yacc.cpp"
        PARSER_CPP          ${YACC_FILE})
    string(REGEX REPLACE ".+\/(.+)\.yacc$" "${CMAKE_BINARY_DIR}/\\1.yacc.hpp"
        PARSER_HPP          ${YACC_FILE})
    list(APPEND CP          ${PARSER_CPP})
    list(APPEND HP          ${PARSER_HPP})
    add_custom_command(
        OUTPUT              ${PARSER_CPP} ${PARSER_HPP}
        DEPENDS             ${YACC_FILE}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             ${BISON_EXECUTABLE}
        ARGS                -o ${PARSER_CPP} ${YACC_FILE}
    )
endforeach()

foreach(RAGEL_FILE ${R})
    string(REGEX REPLACE ".+\/(.+)\.ragel$" "${CMAKE_BINARY_DIR}/\\1.ragel.cpp"
        RAGEL_CPP           ${RAGEL_FILE})
    list(APPEND CP          ${RAGEL_CPP})
    add_custom_command(
        OUTPUT              ${RAGEL_CPP}
        DEPENDS             ${RAGEL_FILE}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             ${RAGEL_EXECUTABLE}
        ARGS                -C -G2 -o ${RAGEL_CPP} ${RAGEL_FILE}
    )
endforeach()

foreach(LEMON_FILE ${M})
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.lemon.cpp"
        LEMON_CPP           ${LEMON_FILE})
    list(APPEND CP          ${LEMON_CPP})
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.lemon.hpp"
        LEMON_HPP           ${LEMON_FILE})
    list(APPEND HP          ${LEMON_HPP})
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.lemon.out"
        LEMON_OUT           ${LEMON_FILE})
    list(APPEND OP          ${LEMON_OUT})
    #
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.c"
        LEMON_C             ${LEMON_FILE})
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.h"
        LEMON_H             ${LEMON_FILE})
    string(REGEX REPLACE ".+\/(.+)\.lemon$" "${CMAKE_BINARY_DIR}/\\1.out"
        LEMON_O             ${LEMON_FILE})
    add_custom_command(
        OUTPUT              ${LEMON_C} ${LEMON_H}
        DEPENDS             ${LEMON_FILE}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             ${LEMON_EXECUTABLE}
        ARGS                -l -d${CMAKE_BINARY_DIR} ${LEMON_FILE}
    )
    add_custom_command(
        OUTPUT              ${LEMON_CPP}
        DEPENDS             ${LEMON_C}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             mv
        ARGS                ${LEMON_C} ${LEMON_CPP}
    )
    add_custom_command(
        OUTPUT              ${LEMON_HPP}
        DEPENDS             ${LEMON_H}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             mv
        ARGS                ${LEMON_H} ${LEMON_HPP}
    )
    add_custom_command(
        OUTPUT              ${LEMON_OUT}
        DEPENDS             ${LEMON_O}
        WORKING_DIRECTORY   ${CMAKE_SOURCE_DIR}
        COMMAND             mv
        ARGS                ${LEMON_O} ${LEMON_OUT}
    )
endforeach()
""")

let install () =
    File.WriteAllText($"cmake/install.cmake",
"""# target install

set_target_properties(${CMAKE_PROJECT_NAME}
    PROPERTIES OUTPUT_NAME ${BIN_OUTPUT_NAME}${CMAKE_EXECUTABLE_SUFFIX})
install(TARGETS ${CMAKE_PROJECT_NAME}
    DESTINATION ${CMAKE_INSTALL_PREFIX})
file(CREATE_LINK ${BIN_OUTPUT_NAME}${CMAKE_EXECUTABLE_SUFFIX}
    ${CMAKE_INSTALL_PREFIX}/${CMAKE_PROJECT_NAME} SYMBOLIC)
""")

let x86 = 
    File.WriteAllText($"cmake/x86_64-linux-gnu.cmake",
"""set(CMAKE_SYSTEM_NAME       Linux)
set(CMAKE_SYSTEM_PROCESSOR  x86_64)
set(TOOLCHAIN_PREFIX        ${ARCH}-${OS}-gnu)
set(CMAKE_EXECUTABLE_SUFFIX "")

include(any_toolchain)

add_compile_definitions()
add_compile_options()
add_link_options()
""")

let any_toolchain() =
    File.WriteAllText($"cmake/any_toolchain.cmake",
"""set(CMAKE_C_STANDARD   17)
set(CMAKE_CXX_STANDARD 17)

set(CMAKE_C_COMPILER_FORCED   TRUE)
set(CMAKE_CXX_COMPILER_FORCED TRUE)
set(CMAKE_C_COMPILER_ID       GNU)
set(CMAKE_CXX_COMPILER_ID     GNU)

set(CMAKE_C_COMPILER   ${TOOLCHAIN_PREFIX}-gcc)
set(CMAKE_ASM_COMPILER ${CMAKE_C_COMPILER})
set(CMAKE_CXX_COMPILER ${TOOLCHAIN_PREFIX}-g++)
set(CMAKE_LINKER       ${CMAKE_C_COMPILER})
set(CMAKE_OBJCOPY      ${TOOLCHAIN_PREFIX}-objcopy)
set(CMAKE_SIZE         ${TOOLCHAIN_PREFIX}-size)
set(CMAKE_RC_COMPILER  ${TOOLCHAIN_PREFIX}-windres)

include(  os/${OS}/${OS}.cmake    )
include(arch/${ARCH}/${ARCH}.cmake)
include( cpu/${CPU}/${CPU}.cmake  )
include(  hw/${HW}/${HW}.cmake    )

string(TOUPPER ${HW}   HW_  )
string(TOUPPER ${CPU}  CPU_ )
string(TOUPPER ${ARCH} ARCH_)
string(TOUPPER ${OS}   OS_  )

add_compile_options(
    -Wall -Wextra               # -Wpedantic
    -Wno-implicit-fallthrough   # ragel
    -Wno-unused-function        # flex
    -Wno-write-strings          # yacc
    -Wno-unused-parameter       # stm32
    $<$<CONFIG:Debug>:-DDEBUG>
)

add_compile_definitions(
    ${HW_} ${CPU_} ${ARCH_} ${OS_}
)

add_link_options(
    -Wl,--print-memory-usage
)

if(CMAKE_BUILD_TYPE MATCHES Debug)
    add_compile_options(-O0 -g3)
endif()
if(CMAKE_BUILD_TYPE MATCHES Release)
    add_compile_options(-Os -g0)
endif()

set(CMAKE_EXECUTABLE_SUFFIX_ASM ${CMAKE_EXECUTABLE_SUFFIX})
set(CMAKE_EXECUTABLE_SUFFIX_C   ${CMAKE_EXECUTABLE_SUFFIX})
set(CMAKE_EXECUTABLE_SUFFIX_CXX ${CMAKE_EXECUTABLE_SUFFIX})
""")
        
let toolchain () =
    any_toolchain
    x86

let cmake() =
    Directory.CreateDirectory("cmake")
    File.WriteAllText($"cmake/.gitignore", "")
    CMakeLists
    CMakePresets
    clean
    version
    cmsrc
    cross
    syntax
    install
    toolchain

let pc () =
    Directory.CreateDirectory("hw/pc")
    File.WriteAllText("hw/pc/pc.mk","CPU = i5\n")
    File.WriteAllText("hw/pc/pc.cmake","")
    Directory.CreateDirectory("hw/pc/inc")
    Directory.CreateDirectory("hw/pc/src")
    File.WriteAllText("hw/pc/inc/pc.hpp","/// @defgroup pc pc\n/// #ingroup x86 x86\n")
    File.WriteAllText("hw/pc/src/pc.cpp","#include \"pc.hpp\"\n")

let pillf103 () =
    Directory.CreateDirectory("hw/pillf103")
    File.WriteAllText("hw/pillf103/pillf103.mk","CPU = stm32f103c8t6\n")
    File.WriteAllText("hw/pillf103/pillf103.cmake","")
    Directory.CreateDirectory("hw/pillf103/inc")
    Directory.CreateDirectory("hw/pillf103/src")
    File.WriteAllText("hw/pillf103/inc/pillf103.hpp","/// @defgroup pillf103 pillf103\n/// #ingroup cortex cortex\n")
    File.WriteAllText("hw/pillf103/src/pillf103.cpp","#include \"hw/pillf103.hpp\"\n")

let f429disco () =
    Directory.CreateDirectory("hw/f429disco")
    File.WriteAllText("hw/f429disco/f429disco.mk","CPU = stm32f429zit6\n")
    File.WriteAllText("hw/f429disco/f429disco.cmake","")
    Directory.CreateDirectory("hw/f429disco/inc")
    Directory.CreateDirectory("hw/f429disco/src")
    File.WriteAllText("hw/f429disco/inc/f429disco.hpp","/// @defgroup f429disco f429disco\n/// #ingroup cortex cortex\n")
    File.WriteAllText("hw/f429disco/src/f429disco.cpp","#include \"hw/f429disco.hpp\"\n")

let iskra () =
    Directory.CreateDirectory("hw/iskra")
    File.WriteAllText("hw/iskra/iskra.mk","CPU = stm32f405rgt6\n")
    File.WriteAllText("hw/iskra/iskra.cmake","")
    Directory.CreateDirectory("hw/iskra/inc")
    Directory.CreateDirectory("hw/iskra/src")
    File.WriteAllText("hw/iskra/inc/iskra.hpp","/// @defgroup iskra iskra\n/// #ingroup cortex cortex\n")
    File.WriteAllText("hw/iskra/src/iskra.cpp","#include \"hw/iskra.hpp\"\n")

let esp8266 () =
    Directory.CreateDirectory("hw/esp8266")
    File.WriteAllText("hw/esp8266/esp8266.mk","CPU = lx106\n")
    File.WriteAllText("hw/esp8266/esp8266.cmake","")
    Directory.CreateDirectory("hw/esp8266/inc")
    Directory.CreateDirectory("hw/esp8266/src")
    File.WriteAllText("hw/esp8266/inc/esp8266.hpp","/// @defgroup esp8266 esp8266\n/// #ingroup esp esp\n")
    File.WriteAllText("hw/esp8266/src/esp8266.cpp","#include \"hw/esp8266.hpp\"\n")

let esp32 () =
    Directory.CreateDirectory("hw/esp32")
    File.WriteAllText("hw/esp32/esp32.mk","CPU = lx106\n")
    File.WriteAllText("hw/esp32/esp32.cmake","")
    Directory.CreateDirectory("hw/esp32/inc")
    Directory.CreateDirectory("hw/esp32/src")
    File.WriteAllText("hw/esp32/inc/esp32.hpp","/// @defgroup esp32 esp32\n/// #ingroup esp esp\n")
    File.WriteAllText("hw/esp32/src/esp32.cpp","#include \"hw/esp32.hpp\"\n")

let hw () =
    Directory.CreateDirectory("hw")
    Directory.CreateDirectory("hw/inc")
    Directory.CreateDirectory("hw/src")
    File.WriteAllText("hw/inc/hw.hpp","""/// @defgroup hw hw
/// @defgroup x86 x86 @ingroup hw
/// @defgroup rpi rpi @ingroup hw"
/// @defgroup esp rpi @ingroup hw"
/// @defgroup cortex cortex @ingroup hw""")
    File.WriteAllText("hw/src/hw.cpp","")
    pc pillf103 f429disco iskra esp8266 esp32
    
let i5 () =
    Directory.CreateDirectory("cpu/i5")
    Directory.CreateDirectory("cpu/i5/inc")
    Directory.CreateDirectory("cpu/i5/src")
    File.WriteAllText("cpu/i5/i5.mk","ARCH = x86_64\n")
    File.WriteAllText("cpu/i5/i5.cmake","")

let cpu () =
    Directory.CreateDirectory("cpu")
    Directory.CreateDirectory("cpu/inc")
    Directory.CreateDirectory("cpu/src")
    File.WriteAllText("cpu/inc/cpu.hpp","""/// @defgroup cpu cpu
/// @defgroup x32 x32 @ingroup cpu
/// @defgroup x64 x64 @ingroup cpu
/// @defgroup stm32 stm32 @ingroup cpu
""")
    File.WriteAllText("cpu/src/cpu.cpp","")
    i5

let x86_64 () =
    Directory.CreateDirectory("arch/x86_64")
    File.WriteAllText("arch/x86_64/x86_64.mk","OS ?= linux\n")
    File.WriteAllText("arch/x86_64/x86_64.cmake","")
    Directory.CreateDirectory("arch/x86_64/inc")
    Directory.CreateDirectory("arch/x86_64/src")
    File.WriteAllText("arch/x86_64/inc/x86_64.hpp","/// @defgroup x86_64 x86_64\n/// @ingroup arch\n")
    File.WriteAllText("arch/x86_64/src/x86_64.cpp","")

let i386 () =

let aarch64 () =

let cortexM () =

let cortexM3 () =

let cortexM4 () =

let xtensa () =


let arch () =
    Directory.CreateDirectory("arch")
    Directory.CreateDirectory("arch/inc")
    Directory.CreateDirectory("arch/src")
    File.WriteAllText("arch/inc/arch.hpp","/// @defgroup arch arch\n")
    File.WriteAllText("arch/src/arch.cpp","")
    x86_64 i386 aarch64 cortexM cortexM3 cortexM4 xtensa

let linux () = 
    Directory.CreateDirectory("os/linux")
    File.WriteAllText("os/linux/linux.mk","")
    File.WriteAllText("os/linux/linux.cmake","")
    Directory.CreateDirectory("os/linux/inc")
    Directory.CreateDirectory("os/linux/src")
    File.WriteAllText("os/linux/inc/linux.hpp","/// @defgroup linux linux\n/// @ingroup os os\n")
    File.WriteAllText("os/linux/src/linux.cpp","#include \"linux.hpp\"\n")

let none () = 

let freertos () = 

let win32 () = 
    
let os () =
    Directory.CreateDirectory("os")
    Directory.CreateDirectory("os/inc")
    Directory.CreateDirectory("os/src")
    File.WriteAllText("os/inc/os.hpp","""/// @defgroup os os\n""")
    File.WriteAllText("os/src/os.cpp","")
    linux none freertos win32

let cross () = 
    hw
    cpu
    arch
    os

let dirs () = vscode doc src tmp giti rust cpp cmake cross

let apt() =
    File.WriteAllText("apt.Debian",
    """git make curl
code meld doxygen clang-format
g++ cmake gdb gdb-multiarch
python3 python3-autopep8 python3-venv python3-ply
""")

let vsext () =
    Directory.CreateDirectory("vscode")
    File.WriteAllText("vscode/package.json",
    """{
    "name": "e",
    "displayName": "Evento",
    "description": "embedded programming language prototype",
    "version": "0.0.1",
    "author": "Dmitry Ponyatov <dponyatov@gmail.com>",
    "license": "MIT",
    "scripts": {
        "test": "echo \"Error: no test specified\" && exit 1"
    },
    "dependencies": {
    },
    "devDependencies": {
        "@types/node": "^18.0.0",
        "typescript": "~5.8.3"
    },
    "engines": {
        "vscode": "^1.67.0",
        "node": ">=18.0.0"
    }
}
""")
