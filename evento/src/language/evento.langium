grammar Evento

entry Program:
    'program' name=ID ';'
    ( words+=ID | numbers+=Int | consts+=ConstDef )*;

ConstDef:
    'const' id=ID '=' n=Int ';';

Int returns number: INT | HEX | OCT | BIN ;

hidden terminal WS: /\s+/;
terminal HEX returns number: /0x[0-9a-fA-F]+/;
terminal OCT returns number: /0o[0-7]+/;
terminal BIN returns number: /0b[01]+/;
terminal INT returns number: /[+\-]?[0-9]+/;
terminal ID: /[_a-zA-Z][\w_]*/;
// terminal STRING: /"(\\.|[^"\\])*"|'(\\.|[^'\\])*'/;

hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;
hidden terminal FORTH_COMMENT: /\([\s\S]*\)/;
