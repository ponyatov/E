from AST import Keyword

class Var(Keyword):
    def eval(self, ctx):
        ctx[self.val()] = self
        return self

    def hpp(self):
        v = self[0]
        p = '//' if self.priv else 'extern'
        c = 'const' if self.const else ''
        t = v.ctype()
        a = v.carr()
        return f'{p} {c} {t} {self.val()}{a};'

    def cpp(self):
        v = self[0]
        p = 'static' if self.priv else ''
        c = 'const' if self.const else ''
        t = v.ctype()
        a = v.carr()
        return f'{p} {c} {t} {self.val()}{a} = {v.cpp()};'

class Const(Var):
    const = True
class Let(Var):
    const = True
class Mut(Var):
    const = False
