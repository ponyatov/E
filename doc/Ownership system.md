# Ownership system
## simplified [[Rust/Rust|Rust]]-like

The [[Ownership system]] in [[Evento]] is inspired by [[Rust/Rust|Rust]] but simplified for embedded and distributed systems. It ensures memory safety and deterministic resource management without runtime garbage collection ([[gc/gc|GC]]).

## 1. Core Principles

- **No GC**: Static checks at compile time eliminate runtime overhead.
	- syncronous memory deallocation and object destruction:
		- memory frees at end of scope, which is more predictive in hard realtime
- **No Dangling Pointers**: Compiler enforces lifetime rules.
- **Immutable-by-Default**:
	- `let` variables are immutable
	- `mut` unless declared as `mut`.

## 2. Key Concepts

### A. Ownership Rules

1. **Single Owner**: Each value has exactly one owner (variable/actor).

```evento
let x = [0u8; 256];  // `x` owns the array.
```

2. **Move Semantics**: Assignments transfer ownership.

```evento
let y = x;  // `x` is now invalid; ownership moved to `y`.
```

3. **No Implicit Copies**: Explicit `.copy()` required for duplicates.

### B. Borrowing

- **Immutable Borrows (`&T`)**: Multiple read-only references allowed.

```evento
let sum = calculate(&y);  // `y` borrowed immutably.
```

- **Mutable Borrows (`&mut T`)**: Only one exclusive reference.

```evento
let ref = &mut y;  // Exclusive access to `y`.
ref[0] = 42;       // Mutation allowed.
```

### C. Lifetimes

- **Static Analysis**: Compiler ensures references don’t outlive their data.

```evento
fn get_slice(data: &[u8]) -> &[u8] { ... }  // Lifetime inferred.
```

## 3. Embedded-Specific Adaptations

## 4. Error Handling

