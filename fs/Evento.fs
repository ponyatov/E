//! Evento language prototype in F#

let APP = "Evento"
let VERSION = "0.0.1"
let TITLE = "embedded programming language prototype"
let AUTHOR = "Dmitry Ponyatov"
let EMAIL = "dponyatov@gmail.com"
let LICENSE = "MIT"
let YEAR = 2025

let ABOUT =
    "\
- for distributed programs
- on embedded systems (microcontrollers)\
"

open System.IO

let README =
    File.WriteAllText(
        "README.md",
        $"# `{APP}` {VERSION}
## {TITLE}

(c) {AUTHOR} <<{EMAIL}>> {YEAR} {LICENSE}

github: https://github.com/ponyatov/{APP}

{ABOUT}
"
    )

let Cargo_toml = File.WriteAllText("Cargo.toml",$"""
[package]
name        =  "{APP}"
version     =  "{VERSION}"
description =  "{TITLE}"
authors     = ["{AUTHOR} <{EMAIL}>"]
license     =  "{LICENSE}"
edition     =  "{YEAR}"

[dependencies]

[[bin]]
name  = "evento"
path  = "src/rs.rs"
test  = false
debug = true

[features]
# hw
pc            = ["i5"]
pillf103      = ["stm32f103c8t6"]
f429disco     = ["stm32f429zit6"]
# cpu
i5            = ["x86_64"]
stm32f103c8t6 = ["cortexM4"]
stm32f429zit6 = ["cortexM4"]
# arch
x86_64        = ["linux"]
cortexM       = ["bare"]
cortexM3      = ["cortexM"]
cortexM4      = ["cortexM"]
# os
linux         = []
bare          = []
""")
