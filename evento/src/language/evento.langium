grammar Evento

entry Program: ( names+=ID | numbers+=INT )*;

// Person:
//     'person' name=ID;

// Greeting:
//     'Hello' person=[Person:ID] '!';

hidden terminal WS: /\s+/;
terminal ID: /[_a-zA-Z][\w_]*/;
terminal INT returns number: /[+\-]?[0-9]+/;
// terminal STRING: /"(\\.|[^"\\])*"|'(\\.|[^'\\])*'/;

hidden terminal LINE_COMMENT: /\/\/[^\n\r]*/;
// hidden terminal ML_COMMENT: /\/\*[\s\S]*?\*\//;
