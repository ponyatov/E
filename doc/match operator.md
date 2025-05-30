In [[Evento]], the `=` operator is actually called _the match operator_. Let's see why:

```evento
let x = 1
```
- immutable bind of `x` variable

```evento
let a, b, c = #hello, "world", 42
```
- binds
	- `a`: binds to `#hello` [[E/Symbol|Symbol]]
	- `b`: string
	- `c`: integer


[[E/GPIO]]