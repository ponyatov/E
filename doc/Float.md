# Floats

```langio
terminal fragment Flotuffix: /`f{16|32|64}/;

terminal FLOAT returns number: /[+\-]?[0-9]+\.[0-9]+([eE][+\-]?[0-9]+)?/ Flotuffix?;
```

- Examples: `3.14'f32`, `1.5e-10'f64`
