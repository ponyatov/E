## @file @brief pythonic OOP style code for book:
## **Programming Language Concepts for Software Developers**
## *Peter Sestoft*
##
## Object Graph-based homoiconic language (directed graph / tree)

import os, sys, re

## test equality
def test_eq(a, b):
    if f'{a}' == f'{b}': pass
    else: raise Exception(f'{a}\n{b}')
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
        ## nested scopes: search attributes in upper level
        self.scope = []

    ## static constructor (wrapper)
    def new(pyobj):
        if isinstance(pyobj, Object): return pyobj
        if type(pyobj) == str: return Var(pyobj)
        if type(pyobj) == int: return Int(pyobj)
        if type(pyobj) == float: return Float(pyobj)
        raise TypeError(type(pyobj), pyobj)

    def tag(self): return self.__class__.__name__.lower()
    def val(self): return f'{self.value}'

    def head(self, depth=0, prefix=''):
        ret = f'{prefix}{self.tag()}:{self.val()}'
        if self.scope:
            ret += ' \\ '
            for s in self.scope: ret += s.head(' ')
        return ret

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
        if type(idx) == str:
            try: return self.slot[idx] # in self scope
            except KeyError:
                for s in self.scope: # in uppers scopes
                    try: return s[idx]
                    except KeyError: pass # ignore not exists
                raise KeyError # if not found in .scopes
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
    def __float__(self): return float(self.value)

A = Int(123) # direct creation
test_eq(A, '\nint:123')
B = Object.new(456) # create using wrapper
test_eq(B, '\nint:456')
# test_raise(Int("azaza")}'=='int: 123')

## floating point numbers
class Float(Number):
    def __init__(self, F): super().__init__(float(F))
    def __float__(self): return self.value

    def __format__(self, format):
        if not format: return self.dump()
        if format == 'f': return f'{self.value:.2f}'
        raise TypeError(type(format), format)

    def __add__(self, that): return Float(self.value + that.__float__())
    def __mul__(self, that): return Float(self.value * that.__float__())

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
glob['pi'] = Float(3.14)
test_eq(glob, '\nenv:glob\n\tpi = float:3.14')
test_eq(pi.eval(glob), '\nfloat:3.14')

## operator
class Op(Active): pass

## unary operator (prefix)
class PfxOp(Op):
    def __init__(self, V, A):
        super().__init__(V); self // Object.new(A)

## binary operator
class BinOp(Op):
    def __init__(self, V, A, B):
        super().__init__(V); self // Object.new(A) // Object.new(B)

class Add(BinOp):
    def __init__(self, A, B): super().__init__('+', A, B)
    def eval(self, env): return self[0].eval(env) + self[1].eval(env)

class Sub(BinOp):
    def __init__(self, A, B): super().__init__('-', A, B)

class Mul(BinOp):
    def __init__(self, A, B): super().__init__('*', A, B)
    def eval(self, env): return self[0].eval(env) * self[1].eval(env)

class Div(BinOp):
    def __init__(self, A, B): super().__init__('/', A, B)

ApB = Add(A, B)
test_eq(str(ApB), '\nadd:+\n\tint:123\n\tint:456')

## let lhs = rhs in body
class Let(Op):
    def __init__(self, lhs, rhs, body):
        lhs = Object.new(lhs); assert isinstance(lhs, Var)
        super().__init__('=')
        self // Object.new(lhs) // Object.new(rhs) // body

    def eval(self, env):
        lhs, rhs, body = self[0], self[1], self[2]
        # new local environment
        local = Env(f'{self.__hash__():x}')
        # reference to parent env
        local.scope.append(env)
        # assign local variable
        local[lhs.val()] = rhs.eval(env)
        # compute body in local env
        print(local)
        return body.eval(local)

## `let e = 2.71 in pi * (e + 1)`
elog = Let('e', 2.71, Mul('pi', Add('e', 1)))
test_eq(elog, '\nlet:=\n\tvar:e\n\tfloat:2.71\n\tmul:*\n\t\tvar:pi\n\t\tadd:+\n\t\t\tvar:e\n\t\t\tint:1')
test_eq(f'{elog.eval(glob):f}', '11.65')
# test_raise(glob['e'], KeyError) # e in local env

print(sys.argv)
