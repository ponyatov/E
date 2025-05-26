import sys

import ply.lex as lex

tokens = ['CONST', 'ID', 'STR', 'EQ']
states = (('str1', 'exclusive'), ('str2', 'exclusive'),)

t_ignore = ' \t\r\n'
t_ignore_shebang = '\#![^\r\n]*'
t_ignore_line_comment = '//[^\r\n]*'
t_ignore_block_comment = '/\*[^*/]*\*/'

t_CONST = 'const'

t_ID = '[a-zA-Z_][a-zA-Z_0-9]*'

t_EQ = '='


def t_STR_START(t):
    r'["\']'
    t.lexer.string_start = t.lexpos  # Track starting position
    t.lexer.string_value = ''  # initial empty string
    if t.value == '"':
        t.lexer.begin('str2')
    else:
        t.lexer.begin('str1')


def t_str1_STR_END(t):
    r'\''
    t.lexer.begin('INITIAL')
    t.type = 'STR'
    t.value = t.lexer.string_value  # set token value
    return t


def t_str2_STR_END(t):
    r'"'
    t.lexer.begin('INITIAL')
    t.type = 'STR'
    t.value = t.lexer.string_value  # set token value
    return t


def t_str1_char(t):
    r'.'
    t.lexer.string_value += t.value


def t_str2_char(t):
    r'.'
    t.lexer.string_value += t.value


def t_ANY_error(t): raise SyntaxError(t)


lexer = lex.lex()


if __name__ == '__main__':
    print(sys.argv)
    for i in sys.argv[1:]:
        with open(i) as src:
            lexer.input(src.read())
            while True:
                token = lexer.token()
                if not token:
                    break
                print(token)
