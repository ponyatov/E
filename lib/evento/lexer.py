from AST import *

import ply.lex as lex

tokens = [
    'INT', 'FLOAT', 'ID', 'SYM', 'STR',
    'TICK', 'TYPE',
    'CONST', 'LET', 'MUT', 'EQ',
]

t_ignore = '[ \t\r]'
t_ignore_shebenag = '^\#![^\r\n]*'
t_ignore_line_comment = '//[^\r\n]*'
t_ignore_block_comment = '/\*[^*]*\*/'
t_ignore_semicolon = ';'

def t_newline(t):
    r'[\n]+'
    t.lineno += len(t.value)

def t_EQ(t):
    r'='
    t.value = Op(t.value); return t
def t_TICK(t):
    r'`'
    t.value = Op(t.value); return t

def t_CONST(t):
    r'const'
    t.value = Const(); return t

def t_LET(t):
    r'let'
    t.value = Let(); return t
def t_MUT(t):
    r'mut'
    t.value = Mut(); return t

def t_STR(t):
    r'"[^"]*"|\'[^\']*\''
    t.value = Str(t.value[1:-1]); return t

def t_FLOAT(t):
    r'[+\-]?[0-9]+\.[0-9]+([eE][0-9]+)?'
    t.value = Float(float(t.value)); return t

def t_TYPE_int(t):
    r'[iu](8|16|32|64)'
    t.type = 'TYPE'; t.value = TInt(t.value); return t
def t_TYPE_float(t):
    r'f(16|32|64)'
    t.type = 'TYPE'; t.value = TFloat(t.value); return t

def t_INT_hex(t):
    r'0x[0-9a-fA-F]+'
    t.type = 'INT'; t.value = Int(int(t.value[2:], 0x10)); return t
# def t_INT_oct(t):
#     r'0o[0-7]+'
#     t.type = 'INT'; t.value = int(t.value[2:], 0x08); return t
def t_INT_bin(t):
    r'0b[01]+'
    t.type = 'INT'; t.value = Int(int(t.value[2:], 0x02)); return t
# def t_INT(t):
#     r'[+\-]?[0-9]+'
#     t.type = 'INT'; t.value = int(t.value, 0x0A); return t

def t_SYM(t):
    r'\#[_a-zA-Z][_a-zA-Z0-9]*'
    t.value = Sym(t.value); return t
def t_ID(t):
    r'[_a-zA-Z][_a-zA-Z0-9]*'
    t.value = Id(t.value); return t

def t_ANY_error(t): raise SyntaxError(t)

lexer = lex.lex()
