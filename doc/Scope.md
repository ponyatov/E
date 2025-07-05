# Scope

- Variables are block-scoped (similar to Rust/JavaScript)
- Shadowing is allowed (declaring a new variable with same name in inner scope)

```E
let x = 10
{
    let x = 20  // shadows outer x
    log x       // prints 20
}
log x           // prints 10
```

## Module-Level Forward Declarations

### 1. Function Prototypes

```E
// Forward declare functions before implementation
fn calculate x:int, y:int -> int  // prototype
```
```E
// Later in same module:
fn calculate x y  = x * y + 42  // implementation
```

### 2. Type Declarations

```E
// Forward declare types
type Packet        // opaque type declaration
type Result<T, E>  // generic type declaration
```
```E
// Later implementations
type Packet = {
    header: u32,
    payload: [u8]
}

type Result<T, E> = Ok(T) | Err(E)
```
