from AST import AST, Int, Str, Float

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
            print(self.main(), file=cpp)
            print(self.arg(), file=cpp)

    def main(self):
        return r'''
int main(int argc, char* argv[]) {
    arg(0, argv[0]);
    for (int i = 1; i < argc; i++) {  //
        arg(i, argv[i]);
    }
}'''

    def arg(self):
        return r'''
void arg(int argc, char* argv) {  //
    fprintf(stderr, "arg[%i] = <%s>\n", argc, argv);
}'''

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
            #
            for k in self.attr:
                v = self[k]
                t = ''
                arr = ''
                if isinstance(v, Int): t = 'int'
                if isinstance(v, Float): t = 'float'
                if isinstance(v, Str): t = 'char*';# arr = '[]'
                print(f'extern const {t:<7} {k+arr:<11};', file=hpp)
