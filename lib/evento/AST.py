import math


class AST:
    def __init__(self, V):
        self.value = V
        self.nest = []
        self.attr = {}

    def compile(self):
        self.hpp(); self.cpp()

    def __mul__(self, o):
        assert isinstance(o, AST)
        self.value = o.val(); return self

    def __setitem__(self, idx, o):
        assert isinstance(idx, str)
        assert isinstance(o, AST)
        self.attr[idx] = o; return self

    def __getitem__(self, idx):
        if isinstance(idx, str): return self.attr[idx]
        if isinstance(idx, int): return self.nest[idx]
        raise TypeError(type(idx), idx)

    def __floordiv__(self, o):
        assert isinstance(o, AST)
        self.nest.append(o); return self

    def __repr__(self): return self.head()

    def tag(self): return self.__class__.__name__
    def val(self): return f'{self.value}'

    def head(self, prefix=''):
        return f'{prefix}<{self.tag()}:{self.val()}>'

    def dump(self, depth=0, prefix=''):
        def pad(depth): return '\n' + '\t' * depth
        ret = pad(depth) + self.head(prefix)
        for i, j in self.attr.items():
            ret += j.dump(depth + 1, prefix=f'{i} = ')
        for i in self.nest:
            ret += i.dump(depth + 1)
        return ret

    def eval(self, ctx={}): raise TypeError(self)

class Primitive(AST):
    def eval(self, ctx={}): return self
    def compile(self): return self.val()

class Int(Primitive): pass

class Float(Primitive):
    def abs(self): return math.fabs(self.value)

class Str(Primitive):
    def compile(self): return f'"{self.val()}"'

class Sym(Primitive): pass
class Id(Primitive): pass

class Op(AST): pass

class Keyword(AST):
    def __init__(self, V=None):
        super().__init__(V if V else '')

class Const(Keyword):
    def eval(self, ctx):
        ctx[self.val()] = self[0].eval(ctx)
        return ctx

class Let(Keyword): pass
class Mut(Keyword): pass

from Module import *

class Type(AST):
    def eval(self, ctx):
        return self

class TInt(Type):
    def eval(self, ctx):
        t = self.value
        v = self[0]; assert isinstance(v, Int)
        match t[0]:
            case 'u':
                match t[1:]:
                    case '8': assert v.value <= 0xFF
                    case _: raise TypeError(self)
            case 'i':
                match t[1:]:
                    case '8': assert v.value <= 127
                    case _: raise TypeError(self)
            case _:
                raise TypeError(self)
        return v

class TFloat(Type):
    def eval(self, ctx):
        t = self.value
        v = self[0]; assert isinstance(v, Float)
        match t[0]:
            case 'f':
                match t[1:]:
                    case '16': assert v.abs() < 65504.0
                    case '32': assert v.abs() < 3.4028235e38
                    case '64': pass
                    case _: raise TypeError(self)
            case _: raise TypeError(self)
        return v
