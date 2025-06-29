# [[E/E|E]] Design Principles

## Syntax Philosophy: Compact, Readable & Feature-Rich

[[E/E|E]] aims to blend the best features of modern and not so known languages into a minimalist, embedded-friendly syntax friendly both for professional programmers and domain specialists:

- Rich [[E/Pattern Matching|Pattern Matching]] is the most required feature not available in most popular languages:
	- Rust/F#:
		- [[E/Error|Error]]/[[E/Result|Result]] and [[E/Option|Option]]al data handling empowered by [[algebraic types]]
	- Erlang/[[Elixir]]:
		- decompose data structures and raw binary data down to bit fields
		- compose binary packages with syntax patterns for bitfield composition
- [[E/Type System|Type System]] with [[algebraic types]]
- [[First-Class Functions]]
	- Python/JS/[[Fsh|F#]]/Rust:
		- full-sized [[lang/functional programming|functional programming]] support
- [[E/Concurrency|Concurrency]] & Hard-[[RTOS/RTOS|RTOS]] features
	- Erlang/Elixir:
		- [[green threads]]
		- [[supervision tree]]
		- [[thread-local heap allocation]]
	- [[Go]]:
		- typed [[Channels]]
	- [[Nim/Nim|Nim]]:
		- optional [[Real-Time Garbage Collection]]
