import os, sys, re

from lexer import *

if __name__ == '__main__':
    print(sys.argv)
    for i in sys.argv[1:]:
        with open(i, 'r') as src:
            lexer.input(src.read())
            while True:
                token = lexer.token()
                if not token: break
                print(token)
