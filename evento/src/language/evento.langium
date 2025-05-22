grammar Evento

entry Program:
    'program' name=ID ';'
    ( words+=ID | numbers+=INT )*;

hidden terminal WS: /\s+/;
terminal ID: /[_a-zA-Z][\w_]*/;
terminal INT returns number: /[+\-]?[0-9]+/;
// terminal STRING: /"(\\.|[^"\\])*"|'(\\.|[^'\\])*'/;

hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;
hidden terminal FORTH_COMMENT: /\([\s\S]*\)/;
