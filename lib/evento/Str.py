from AST import Primitive

class Str(Primitive):
    def hpp(self): return ';'
    def cpp(self): return f'"{self.val()}"'
    def ctype(self): return 'char'
    def carr(self): return '[]'

class Sym(Primitive):
    def hpp(self): return ';'
    def cpp(self): return f'"{self.val()}"'
    def ctype(self): return 'char*'
    def carr(self): return ''
