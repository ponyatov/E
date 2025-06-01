#include <evento.hpp>

int main(int argc, char* argv[]) {
    arg(0, argv[0]);
    for (int i = 1; i < argc; i++) {  //
        arg(i, argv[i]);
    }
}

void arg(int argc, char* argv) {  //
    fprintf(stderr, "arg[%i] = <%s>\n", argc, argv);
}

const char    PROJECT[]   = "Evento";
const char    ABOUT[]     = "programming language prototype";
const char    EMAIL[]     = "dponyatov@gmail.com";
const char    AUTHOR[]    = "Dmitry Ponyatov {EMAIL}";
const char    TGRAM[]     = "@dponyatov";
const char    VERSION[]   = "0.0.1";
const int     BL          = 32;
const int     CR          = 13;
const int     LF          = 10;
const int     TAB         = 9;
const float   PI          = 3.1415926535;
const float   AVOGADRO    = 6.02214076e+23;
const char*   Sym         = "#Bol";
