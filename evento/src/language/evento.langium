grammar Evento

entry Program:
    SHEBANG?
    (defs+=Def)*;
//     ( words+=ID | numbers+=Num | strs+=STR | stmt+=Stmt | actors+=Actor )*;

Def:
    ConstDef;

ConstDef:
    'const' id=ID '=' (n=Num|s=STR|b=BOOL);

// Actor:
//     'actor' name=ID (':' parent=ID)? '{' members+=Member* '}';

// Member:
//     ConstDef
//     | Handler;

// Handler:
//     'on' event=ID '()' '{' statements+=ID* '}';

Num returns number:
    INT | HEX | OCT | BIN
    | FLOAT ;


terminal fragment Intuffix : /\`[ui](8|16|32|64)/;
terminal fragment Flotuffix: /\`f{16|32|64}/;

terminal FLOAT returns number: /[+\-]?[0-9]+\.[0-9]+([eE][+\-]?[0-9]+)?/ Flotuffix?;
terminal HEX returns number: /0x[0-9a-fA-F]+/ Intuffix?;
terminal OCT returns number: /0o[0-7]+/       Intuffix?;
terminal BIN returns number: /0b[01]+/        Intuffix?;
terminal INT returns number: /[+\-]?[0-9]+/   Intuffix?;
terminal STR: /"[^"]*"|'[^']*'/;
terminal BOOL returns boolean: ('true'|'false');
terminal ID: /[_a-zA-Z][_a-zA-Z0-9]*/;

       terminal       SHEBANG: /#![^\r\n]+/;
hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;

hidden terminal WS: /\s+/;
