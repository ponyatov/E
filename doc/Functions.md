# Functions

[[Evento]] tries to intergate most powerful features from some not so known languages:
- [[Fsh|F#]]-style (ML-like) functions without parens (sometimes a huge pile of them)
- Unified Call Syntax ([[UCS]]) to let you write dot-piped call conveyor
	- and async `|>` pipe operator for more complex dataflow computing
- [[Elixir]] function polymorphism with guards

## Function Definitions

Use [[E/let|let]] for functions
- with lightweight syntax,
- omitting parentheses for arguments when possible:

```evento
let add x y = x + y
```

## Calling Syntax

Functions are called without parentheses, using space-separated arguments:

```evento
let result = add 5 3 // Returns 8
```

![[UCS]]

![[E/pipeline]]

![[CTFE]]
