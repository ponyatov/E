import os, sys, re

from lexer import *
from parser import *

if __name__ == '__main__':
    print(sys.argv)
    for i in sys.argv[1:]:
        print(i)
        with open(i, 'r') as src:
            parser.module = os.path.splitext(os.path.basename(i))[0]
            print(parser.parse(src.read()).dump())
