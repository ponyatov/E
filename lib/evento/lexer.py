import ply.lex as lex

tokens = ['INT', 'ID', 'STR', 'EQ', TICK`]

t_ignore = '[ \t\r]'
t_ignore_shebenag = '^\#![^\r\n]*'
t_ignore_line_comment = '//[^\r\n]*'
t_ignore_block_comment = '/\*[^*]*\*/'

def t_newline(t):
    r'[\n]+'
    t.lineno += len(t.value)

t_EQ = '='
t_TICK = '`'

def t_STR(t):
    r'"[^"]*"|\'[^\']*\''
    t.value = t.value[1:-1]; return t

def t_INT_bin(t):
    r'0b[01]+'
    t.type = 'INT'; t.value = int(t.value[2:], 0x02); return t

def t_ID(t):
    r'[_a-zA-Z][_a-zA-Z0-9]*'
    return t

def t_ANY_error(t): raise SyntaxError(t)

lexer = lex.lex()
