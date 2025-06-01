grammar Evento

entry Module:
    (shebang=SHEBANG)?
    (defs+=Def)*
;

Def:
    'pub'? (ConstDef|LetDef|MutDef|FnDef) ';';

ConstDef:
    'const' id=ID '=' Expr;

LetDef:
    'let' id=ID '=' Expr;

MutDef:
    'mut' id=ID '=' Expr;

FnDef:
    'extern'? 'fn' name=ID '(';

Expr:
    (n=Int|f=Float|b=Bool|s=STR|y=SYM);

Int:
    val=(INT | HEX | OCT | BIN) ('`' typ=TInt)?;
Float:
    val=FLOAT ('`' typ=TFloat)?;
Bool:
    val=BOOL;

TInt:
    typ=(I8|I16|I32|I64|U8|U16|U32|U64);

terminal I8 : 'i8';
terminal I16: 'i16';
terminal I32: 'i32';
terminal I64: 'i64';
terminal U8 : 'u8';
terminal U16: 'u16';
terminal U32: 'u32';
terminal U64: 'u64';

TFloat: typ=(F16|F32|F64);

terminal F16: 'f16';
terminal F32: 'f32';
terminal F64: 'f64';

terminal FLOAT returns number: /[+\-]?[0-9]+\.[0-9]+([eE][+\-]?[0-9]+)?/ ;
terminal HEX returns number: /0x[0-9a-fA-F]+/ ;
terminal OCT returns number: /0o[0-7]+/       ;
terminal BIN returns number: /0b[01]+/        ;
terminal INT returns number: /[+\-]?[0-9]+/   ;
terminal STR: /"[^"]*?"|'[^']*?'/;
terminal BOOL returns boolean: ('true'|'false');
terminal ID: /[_a-zA-Z][_a-zA-Z0-9]*/;
terminal SYM: '#' ID;

terminal SHEBANG: /#![^\r\n]+/;
hidden terminal LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;

hidden terminal WS: /\s+/;
