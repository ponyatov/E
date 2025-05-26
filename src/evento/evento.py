import sys

import ply.lex as lex

tokens = ['CONST', 'ID', 'STR', 'EQ']

t_ignore = ' \t\r\n'
t_ignore_shebang = '!#[^\r\n]+'
t_ignore_line_comment = '//'


def t_error(t): raise SyntaxError(t)


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
