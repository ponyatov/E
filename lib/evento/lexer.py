import ply.lex as lex

tokens = ['INT', 'FLOAT', 'ID', 'STR', 'EQ', 'TICK',
          'CONST', 'LET', 'MUT', 'CLASS', 'ACTOR']

t_ignore = '[ \t\r]'
t_ignore_shebenag = '^\#![^\r\n]*'
t_ignore_line_comment = '//[^\r\n]*'
t_ignore_block_comment = '/\*[^*]*\*/'

def t_newline(t):
    r'[\n]+'
    t.lineno += len(t.value)

t_EQ = '='
t_TICK = '`'

def t_CONST(t):
    r'const'
    return t
def t_LET(t):
    r'let'
    return t
def t_MUT(t):
    r'mut'
    return t
def t_CLASS(t):
    r'class'
    return t
def t_ACTOR(t):
    r'actor'
    return t

def t_STR(t):
    r'"[^"]*"|\'[^\']*\''
    t.value = t.value[1:-1]; return t

def t_FLOAT(t):
    r'[+\-]?[0-9]+\.[0-9]+([eE][0-9]+)?'
    t.value = float(t.value); return t

def t_INT_hex(t):
    r'0x[0-0a-fA-F]+'
    t.type = 'INT'; t.value = int(t.value[2:], 0x10); return t
def t_INT_oct(t):
    r'0o[0-7]+'
    t.type = 'INT'; t.value = int(t.value[2:], 0x08); return t
def t_INT_bin(t):
    r'0b[01]+'
    t.type = 'INT'; t.value = int(t.value[2:], 0x02); return t
def t_INT(t):
    r'[+\-]?[0-9]+'
    t.type = 'INT'; t.value = int(t.value, 0x0A); return t

def t_ID(t):
    r'[_a-zA-Z][_a-zA-Z0-9]*'
    return t

def t_ANY_error(t): raise SyntaxError(t)

lexer = lex.lex()
