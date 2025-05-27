grammar Evento

entry Program:
    SHEBANG?
    (defs+=Def)*;
//     ( words+=ID | numbers+=Num | strs+=STR | stmt+=Stmt | actors+=Actor )*;

Def:
    ConstDef|LetDef|MutDef;

ConstDef:
    'const' id=ID '=' Expr;

LetDef:
    'let' id=ID '=' Expr;

MutDef:
    'mut' id=ID '=' Expr;

Expr:
    (n=Int|f=Float|s=STR|b=BOOL|s=SYM);

// Actor:
//     'actor' name=ID (':' parent=ID)? '{' handlers+=Handler* '}';

// Handler:
//     'on' event=ID '=' (expr+=Expr)+ ;

Int returns number: INT | HEX | OCT | BIN;
Float returns number: FLOAT;

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
terminal SYM: '#' ID;

       terminal       SHEBANG: /#![^\r\n]+/;
hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;

hidden terminal WS: /\s+/;
