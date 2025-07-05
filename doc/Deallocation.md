# Deallocation

```E
// Automatic resource deallocation
let file = open "sample.e" in
    // file automatically closed at end
    E.parse(file) // returns AST
```
