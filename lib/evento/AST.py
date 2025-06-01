import math


class AST:
    def __init__(self, V):
        self.value = V
        self.nest = []
        self.attr = {}
        self.priv = True

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
        return f'{prefix}<{self.tag()}:{self.val()}> {"" if self.priv else "^"}'

    def dump(self, depth=0, prefix=''):
        def pad(depth): return '\n' + '\t' * depth
        ret = pad(depth) + self.head(prefix)
        for i, j in self.attr.items():
            ret += j.dump(depth + 1, prefix=f'{i} = ')
        for i in self.nest:
            ret += i.dump(depth + 1)
        return ret

    def eval(self, ctx={}): raise TypeError(self)

    def pub(self): self.priv = False; return self

class Primitive(AST):
    def eval(self, ctx={}): return self
    def cpp(self): return self.val()
    def hpp(self): return f'{"static" if self.priv else "extern"} {self.ctype()} {self.val()};'
    def carr(self): return ''

class Int(Primitive):
    def ctype(self): return 'int'

class Float(Primitive):
    def abs(self): return math.fabs(self.value)
    def ctype(self): return 'float'

from Str import *

class Id(Primitive): pass

class Op(AST): pass

class Keyword(AST):
    def __init__(self, V=None):
        super().__init__(V if V else '')

from Var import *

from Module import *

class Type(AST):
    def eval(self, ctx):
        return self
    def hpp(self): return self[0].hpp()
    def cpp(self): return self[0].cpp()
    def carr(self): return ''

class TInt(Type):
    def ctype(self): return 'int'

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
    def ctype(self): return 'float'
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
