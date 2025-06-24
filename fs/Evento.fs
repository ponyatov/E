//! Evento language prototype in F#

let APP = "Evento"
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
        $"# `{APP}`
## {TITLE}

(c) {AUTHOR} <<{EMAIL}>> {YEAR} {LICENSE}

github: https://github.com/ponyatov/{APP}

{ABOUT}
"
    )
