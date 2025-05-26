# Comments
## Consistency with C/[[Cpp/C++|C++]] and [[Rust/Rust|Rust]] Style

```rust
// Single-line comment (C-style familiar)
/* Multi-line comment for in-code
   and multiline blocks */
```

```langium
hidden terminal  LINE_COMMENT: /\/\/[^\n\r]*/;
hidden terminal BLOCK_COMMENT: /\/\*[\s\S]*?\*\//;
```

- `hidden`: The hidden keyword means this token is ignored in the [[syntax/AST|AST]], used only for lexical analysis (i.e., it’s not part of the parsed program structure).

```evento
// This is a single-line comment
const x = 42; // Another comment
```

```evento
/* This is a
   multi-line comment */
const y = "hello";
```
