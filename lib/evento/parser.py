from lexer import *

import ply.yacc as yacc

def p_module_none(p):
    ' module : '
    p[0] = Module(parser.module)
def p_syntax_pub_def(p):
    ' module : module PUB def '
    p[0] = p[1]; p[3].eval(p[1]).pub()
def p_syntax_def(p):
    ' module : module def '
    p[0] = p[1]; p[2].eval(p[1])

def p_def_const(p):
    r' def : const '
    p[0] = p[1]
def p_def_let(p):
    r' def : let '
    p[0] = p[1]
def p_def_mut(p):
    r' def : mut '
    p[0] = p[1]

def p_const(p):
    r' const : CONST ID EQ expr '
    p[0] = p[1] * p[2] // p[4]
def p_let(p):
    r' let : LET ID EQ expr '
    p[0] = p[1] * p[2] // p[4]
def p_mut(p):
    r' mut : MUT ID EQ expr '
    p[0] = p[1] * p[2] // p[4]

def p_expr_str(p):
    r' expr : STR '
    p[0] = p[1]
def p_expr_sym(p):
    r' expr : SYM '
    p[0] = p[1]
def p_expr_int(p):
    r' expr : INT '
    p[0] = p[1]
def p_expr_float(p):
    r' expr : FLOAT '
    p[0] = p[1]
def p_expr_bool(p):
    r' expr : BOOL '
    p[0] = p[1]

def p_expr_type(p):
    r' expr : expr TICK TYPE '
    p[0] = p[3]//p[1]

def p_error(p): return SyntaxError(p)

parser = yacc.yacc(debug=False, write_tables=False)
