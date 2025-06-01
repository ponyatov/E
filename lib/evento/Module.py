from AST import AST, Int, Str, Float

import cmake

class Module(AST):
    def compile(self):
        super().compile()
        try: cname = self['PROJECT'].val()
        except KeyError: cname = self.val()
        cmake.lists(cname)
        cmake.preset()
        cmake.src()

    def cpp(self):
        with open(f'src/{self.val()}.cpp', 'w') as cpp:
            print(f"#include <{self.val()}.hpp>", file=cpp)
            print(self.main(), file=cpp)
            print(self.arg(), file=cpp)
            #
            print('', file=cpp)
            for k in self.attr:
                v = self[k]
                print(v.cpp(),file=cpp)
                # p = 'static ' if v.priv else ''
                # print(
                #     f'{p}const {v.ctype()} {k+v.carr()} = {v.cpp()};', file=cpp)

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
extern void arg(int argc, char* argv);
''', file=hpp)
            #
            for k in self.attr:
                v = self[k]
                print(v.hpp(),file=hpp)
                # print(
                #         f'{"//" if v.priv else "extern"} const {v.ctype()} {k+v.carr()};', file=hpp)
