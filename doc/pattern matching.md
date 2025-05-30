# [[lang/pattern matching|pattern matching]]

```evento
match value
| pattern1 -> expr1
| pattern2 | pattern3 -> expr2
| _ -> default_expr
```

[[lang/pattern matching|Pattern matching]] is the most powerful language feature in modern programming languages oriented on complex data structure processing.

- **Expressive Control Flow**: Support pattern matching for [[E/enum|enum]]s (e.g., [[E/Result|Result]], [[E/Option|Option]]), [[E/tuple|tuple]]s, [[E/struct|struct]]s, and literals, enabling concise and safe data handling.
- **Access named patterns fragments** by unification with local variables, directly available in `case` branches code -- *the ease of data structure decomposition*
- **F#-Style Syntax**: Use no-parentheses, space-separated syntax for consistency with [[Evento]]’s aesthetic.
- **[[UCS]] Compatibility**: Allow pattern matching to work with UCS (e.g., data.match or match data).
- **Embedded Efficiency**: Compile to efficient C/Rust code for [[no_std]] environments, avoiding runtime overhead.
- **Type Safety**: Type system checks all available variants, and produce error if no default case provided, or some variant was erroneously skipped

