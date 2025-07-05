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
        ret = tab(depth) + self.head()
        for i in self.nest: ret += i.dump(depth + 1)
        return ret

    def __repr__(self): return self.dump()

    def __floordiv__(self, that): self.nest.append(that); return self

## scalars & machine types
class Primitive(Object): pass

## integer numbers
class Int(Primitive):
    def __init__(self, N): super().__init__(int(N))

A = Int(123)
test_eq(A, '\nint:123')
B = Int(456)
test_eq(B, '\nint:456')
# test_raise(Int("azaza")}'=='int: 123')

## floating point numbers
class Float(Primitive):
    def __init__(self, F): super().__init__(float(V))

class Container(Object): pass
class Vector(Container): pass
class Stack(Container): pass
class Map(Container): pass
class Queue(Container): pass

## executable data
class Active(Container): pass

## operator
class Op(Active): pass
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
