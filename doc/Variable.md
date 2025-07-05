# Variable

- [[E/let|let]] - declares an immutable variable
- [[E/mut|mut]] - declares a mutable variable
- [[E/const|const]] - declares a compile-time constant

## Declaration

### Immutable Variables ([[E/let|let]])

- Default declaration creates immutable bindings
- Cannot be reassigned after declaration

```E
let x = 10      // immutable integer
let name = "E"  // immutable string
x = 20          // Error: cannot reassign immutable variable
```

### Mutable Variables ([[E/mut|mut]])

- Explicitly marked as mutable
- Can be reassigned

```E
mut counter = 0
counter += 1    // Valid: mutable variable can be modified
```

## Constants ([[E/const|const]])

- Compile-time constants
- Must be initialized with a constant expression
- Conventionally named in ALL_CAPS

```E
const MAX_SIZE = 100
const PI = 3.14159
MAX_SIZE = 200  // Error: cannot modify constant
```
