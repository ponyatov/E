## @file @brief pythonic OOP style code for book:
## **Programming Language Concepts for Software Developers**
## *Peter Sestoft*
##
## Object Graph-based homoiconic language (directed graph / tree)

import os, sys, re

## test equality
def test_eq(a, b):
    if f'{a}' == f'{b}': pass
    else: raise Exception(f'<{a}> != <{b}>')
test_eq(1 == 1, 'True')

## test exception
def test_raise(a, b):
    try: a()
    except Exception as e: print(e); raise e
# test_raise(lambda: raise SyntaxError("x"), Exception)

## base object class
class Object:
    def __init__(self, V):
        ## scalar: object name, number value
        self.value = V
        ## ordered: vector, AST subtrees
        self.nest = []
        ## associative: attributes
        self.slot = {}

    def tag(self): return self.__class__.__name__.lower()
    def val(self): return f'{self.value}'

    def head(self, depth=0,
             prefix=''): return f'{prefix}{self.tag()}:{self.val()}'

    def dump(self, depth=0, prefix=''):
        def tab(depth): return '\n' + '\t' * depth
        ret = tab(depth) + self.head(depth, prefix)
        for k in sorted(self.slot.keys()):
            ret += self.slot[k].dump(depth + 1, f'{k} = ')
        for i in self.nest:
            ret += i.dump(depth + 1)
        return ret

    def __repr__(self): return self.dump()

    def __floordiv__(self, that):
        self.nest.append(that); return self

    def __getitem__(self, idx):
        if type(idx) == int: return self.nest[idx]
        if type(idx) == str: return self.slot[idx]
        raise TypeError(type(idx), idx)

    def __setitem__(self, idx, that):
        if type(idx) == int: self.nest[idx] = that; return self
        if type(idx) == str: self.slot[idx] = that; return self
        raise TypeError(type(idx), idx)

    def eval(self, env): return self

## scalars & machine types
class Primitive(Object): pass

## abstract number
class Number(Primitive): pass

## integer numbers
class Int(Number):
    def __init__(self, N): super().__init__(int(N))

A = Int(123)
test_eq(A, '\nint:123')
B = Int(456)
test_eq(B, '\nint:456')
# test_raise(Int("azaza")}'=='int: 123')

## floating point numbers
class Float(Number):
    def __init__(self, F): super().__init__(float(F))

class Container(Object): pass
class Vector(Container): pass
class Stack(Container): pass
class Map(Container): pass
class Queue(Container): pass

## executable data
class Active(Container): pass

## environment
class Env(Container): pass

## global env
glob = Env('glob')
test_eq(glob, '\nenv:glob')

class Var(Primitive):
    def eval(self, env): return env[self.val()]

pi = Var('pi')
test_eq(pi, '\nvar:pi')
# test_raise(pi.eval(glob), KeyError)
glob['pi'] = Float(3.1415)
test_eq(glob, '\nenv:glob\n\tpi = float:3.1415')
test_eq(pi.eval(glob), '\nfloat:3.1415')

## operator
class Op(Active): pass

## unary operator (prefix)
class PfxOp(Op):
    def __init__(self, V, A):
        super().__init__(V); self // A

## binary operator
class BinOp(Op):
    def __init__(self, V, A, B):
        super().__init__(V); self // A // B

class Add(BinOp):
    def __init__(self, A, B): super().__init__('+', A, B)
class Sub(BinOp):
    def __init__(self, A, B): super().__init__('-', A, B)
class Mul(BinOp):
    def __init__(self, A, B): super().__init__('*', A, B)
class Div(BinOp):
    def __init__(self, A, B): super().__init__('/', A, B)

ApB = Add(A, B)
test_eq(str(ApB), '\nadd:+\n\tint:123\n\tint:456')

print(sys.argv)
