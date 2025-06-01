from lexer import *

import ply.yacc as yacc

def p_error(p): return SyntaxError(p)

def p_module_none(p):
    ' module : '
    p[0] = Module(parser.module)
def p_syntax_const(p):
    ' module : module const '
    p[1][p[2].val()] = p[2][0]
    p[0] = p[1]

def p_const(p):
    r' const : CONST ID EQ expr '
    p[0] = Const(p[2].val()) // p[4]

def p_expr_str(p):
    r' expr : STR '
    p[0] = p[1]

parser = yacc.yacc(debug=False, write_tables=False)
