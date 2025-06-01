from AST import Primitive

class Str(Primitive):
    def hpp(self): return ';'
    def cpp(self): return f'"{self.val()}"'
