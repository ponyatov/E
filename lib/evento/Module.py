from AST import AST

import cmake

class Module(AST):
    def compile(self):
        super().compile()
        cmake.lists(self['PROJECT'].val())
        cmake.preset()
        cmake.src()

    def cpp(self):
        with open(f'src/{self.val()}.cpp', 'w') as cpp:
            print(f"#include <{self.val()}.hpp>", file=cpp)
            print('''
int main(int argc, char* argv[]) {}
void arg(int argc, char* argv  ) {}
''', file=cpp)

    def hpp(self):
        with open(f'inc/{self.val()}.hpp', 'w') as hpp:
            print('#pragma once', file=hpp)
            print('''
#include <stdio.h>
#include <stdlib.h>
#include <assert.h>''', file=hpp)
            print('''
extern int main(int argc, char* argv[]);
extern void arg(int argc, char* argv  );
''', file=hpp)
