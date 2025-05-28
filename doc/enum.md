# enum

C-like [[Cpp/enum|enum]] holds names bounded with primitive type

```
// Simple enum (C-like)
enum Status`u8 {
  Ok
  Error
  Loading
}
```
```
// With discriminants assigns values
enum HttpCode`i16 {
  Ok = 200
  NotFound = 404
  ServerError = 500
}
```

also see: [[E/tagged union|tagged union]]
