# [[E/E|E]] Design Principles

## Syntax Philosophy: Compact, Readable & Feature-Rich

[[E/E|E]] aims to blend the best features of modern and not so known languages into a minimalist, embedded-friendly syntax friendly both for professional programmers and domain specialists:

- Rich [[E/Pattern Matching|Pattern Matching]] is the most required feature not available in most popular languages:
	- Rust/F#:
		- [[E/Error|Error]]/[[E/Result|Result]] and [[E/Option|Option]]al data handling empowered by [[algebraic types]]
		- compile-time checking that all cases are covered
	- Erlang/[[Elixir]]:
		- decompose data structures and raw binary data down to [[E/bitfield|bitfield]]s
		- compose binary packages using syntax patterns for bitfield composition
- [[E/Type System|Type System]]
	- Rust/F#:
		- [[algebraic types]]
- [[First-Class Functions]]
	- Python/JS/[[Fsh|F#]]/Rust:
		- full-sized [[lang/functional programming|functional programming]] support
	- F#:
		- paren-less syntax
	- Nim:
		- [[UFCS|Unified function call syntax]]
- variables using `let`/`mut` with default [[immutability]]
	- Rust:
		- `let` immutable by default
		- but `mut` as a separate keyword replaces `let` when needed
- [[E/Concurrency|Concurrency]] & Hard-[[RTOS/RTOS|RTOS]] features
	- Erlang/Elixir:
		- [[green threads]]
		- [[supervision tree]]
		- [[thread-local heap allocation]]
	- [[Go]]:
		- typed [[Channels]]
	- [[Nim/Nim|Nim]]:
		- optional [[Real-Time Garbage Collection]]
- [[Why Pythons Tabbed Syntax Is Considered Harmful]]
	- Python/F#: 
		- [[tabbed syntax]] forces to write structured code
	- Rust/F#:
		- [[E/autoformat|autoformat]]
- class-based [[OOP]]
	- Python:
		- multiple [[oop/inheritance|inheritance]]
		- [[lang/operator overloading|operator overloading]]
