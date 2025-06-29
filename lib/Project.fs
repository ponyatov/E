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

let dirs () = vscode doc lib inc src tmp giti
