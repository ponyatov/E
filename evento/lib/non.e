#!/home/user/E/bin/evento
// empty file

program None
-01 +0230 0xDeadBeef 0o750 0b1101 /* numbers */

const PROJECT = "Evento"
const AUTHOR = "Dmitry Ponyatov {EMAIL}"
const EMAIL = "dponyatov@gmail.com"

const BL = 0b1101
const CR = 0x0D
const LF = 0x0A
const TAB = 0x09
const PI = 3.1415926535
const AVOGADRO = 6.02214076e23

actor Actor {
    on init(){}
    on halt(){}
}

actor Logger:Actor {
    on log(){}
}
