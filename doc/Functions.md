# Functions

[[Evento]] tries to intergate most powerful features from some not so known languages:
- [[Fsh|F#]]-style (ML-like) functions without parens (sometimes a huge pile of them)
- Unified Call Syntax ([[UCS]]) to let you write dot-piped call conveyor
	- and async `|>` pipe operator for more complex dataflow computing
- [[Elixir]] function polymorphism with guards

Benefits for [[Evento]]:
- **Conciseness**: Omitting parentheses reduces visual clutter, aligning with Evento’s Python-like usability goal.
- **Readability**: Space-separated arguments and pipelining make dataflow explicit, ideal for event-driven and distributed systems.

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
![[Why Python’s Tabbed Syntax Is Considered Harmful]]?

![[CTFE]]
