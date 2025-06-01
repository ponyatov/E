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

 const char PROJECT[] = "Evento";
 const char ABOUT[] = "programming language prototype";
 const char EMAIL[] = "dponyatov@gmail.com";
 const char AUTHOR[] = "Dmitry Ponyatov {EMAIL}";
 const char TGRAM[] = "@dponyatov";
 const char VERSION[] = "0.0.1";
static const int BL = 32;
static const int CR = 13;
static const int LF = 10;
static const int TAB = 9;
static const float PI = 3.1415926535;
static const float AVOGADRO = 6.02214076e+23;
static const char dialect[] = "FORTH";
static const char* Sym = "#Bol";
