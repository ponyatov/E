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

Num returns number: INT | HEX | OCT | BIN | FLOAT ;


terminal FLOAT returns number: /[+\-]?[0-9]+\.[0-9]+([eE][+\-]?[0-9]+)?/;
terminal HEX returns number: /0x[0-9a-fA-F]+/;
terminal OCT returns number: /0o[0-7]+/;
terminal BIN returns number: /0b[01]+/;
terminal INT returns number: /[+\-]?[0-9]+/;
terminal STR: /"[^"]*"|'[^']*'/;
terminal BOOL returns boolean: ('true'|'false');
terminal ID: /[_a-zA-Z][\w_]*/;

       terminal       SHEBANG: /#![^\r\n]+/;
hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;

hidden terminal WS: /\s+/;
