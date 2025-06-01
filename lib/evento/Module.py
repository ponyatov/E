from AST import AST

class Module(AST):
    def compile(self):
        with open(f'src/{self.val()}.cpp','w') as cpp:
            print(f"#include <{self.val()}.hpp>",file=cpp)
        with open(f'inc/{self.val()}.hpp','w') as hpp:
            print('#pragma once',file=hpp)
