#!/usr/bin/env evento
// ^^^^ shebang for using E in script mode
// line comment
/* block comment */

pub const PROJECT = "Evento";
pub const ABOUT   = "programming language prototype";
pub const EMAIL   = "dponyatov@gmail.com";
pub const AUTHOR  = 'Dmitry Ponyatov {EMAIL}';
pub const TGRAM   = '@dponyatov';
pub const VERSION = "0.0.1";

const BL       = 0b00100000`u8;
const CR       = 0x0D`u8;
const LF       = 0x0A`u8;
const TAB      = 0x09`u8;
const PI       = 3.1415926535;
const AVOGADRO = 6.02214076e23`f32;

let dialect = 'FORTH';
mut compile = false;

const Sym = #Bol;

// // let numbers = [-01 +0230 0xDeadBeef 0o750 0b1101];
