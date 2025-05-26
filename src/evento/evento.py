import sys

import lexer

if __name__ == '__main__':
    print(sys.argv)
    for i in sys.argv[1:]:
        with open(i) as src:
            lexer.lexer.input(src.read())
            while True:
                token = lexer.lexer.token()
                if not token:
                    break
                print(token)
