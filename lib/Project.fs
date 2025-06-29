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
    File.WriteAllText(".vscode/settings.json", """{}""")

let vscode () =
    let vs = ".vscode"
    Directory.CreateDirectory(vs)
    File.WriteAllText($"{vs}/.gitignore", "!.gitignore\n")
    c_cpp_properties
    launch
    extensions
    tasks
    settings

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
