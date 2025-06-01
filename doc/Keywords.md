# Keywords

## Core

|Keyword|Purpose|Inspired By|
|---|---|---|
|`const`|Compile-time constant|Rust/C|
|`let`|Variable binding (default)|Rust/F#|
|`mut`|Mutable variable/parameter|Rust|
|`pub`|Public visibility (default: module private)|Rust|
|`actor`|Define a concurrent entity|Elixir/Erlang|
|`on`|Actor action (message selector)|Elixir/Erlang|
|`spawn`|Create a new actor instance|Rust (threads)|
|`fn`|Function definition|Rust|

## Control Flow

|Keyword|Usage Example|Notes|
|---|---|---|
|`if`/`else`|`if x > 0 { ... } else { ... }`|Classic branching|
|`match`|`match x { 1 => "one", _ => ... }`|Pattern matching (Rust-style)|
|`loop`|`loop { ... }`|[[Infinite Loop]]|
|`while`|`while sensor < 10 { ... }`|[[Conditional Loop]]|
|`do`|`do { extruder.heat } while T < 180`|[[Conditional Loop]]|
|`until`|`do { stepper.up; } until Z < 10`|[[Conditional Loop]]|
|`for`||[[Iteration]]
|`wait`|`wait temp < 65;`|non-blocking [[wait]] loop|
|`return`|Early exit from function|Optional (tail-expr preferred)|

## Traits

Instead of classic inheritance, use **composition + traits** (zero-cost abstractions, better for embedded):
- No runtime polymorphism (faster, predictable for embedded).
- Avoids diamond inheritance problems
- Fits Evento’s Rust/Elixir roots
- Embedded-safe (no vtables unless needed)
- It’s a better fit for both distributed systems (actors scale better) and microcontrollers (avoid dynamic dispatch).

||
|-|-|-|-
|`struct`|
|`trait`|
|`impl`|
