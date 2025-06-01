# Keywords

## Core

|Keyword|Usage Example|Notes|
|---|---|---|
|`const`|`const BL = 0x20`|Compile-time constant|
|`let`|`let endline = '\n'`|Variable binding (default)|
|`mut`|``mut compile`bool = false``|Mutable variable/parameter|
|`pub`||Public visibility (default: module private)|
|`actor`| `actor Main { on reset {} }` |Define a concurrent entity|
|`on`| `on sleep {}` |Actor action (message selector)|
|`spawn`||Create a new actor instance|
|`fn`||Function/method definition|
|`type`|`type Port = u16;`|Type alias

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

|Keyword|Usage Example|Notes|
|-|-|-|-
|`enum`|`enum Status { Active Low HiZ }`
|`struct`|
|`trait`|
|`impl`|
