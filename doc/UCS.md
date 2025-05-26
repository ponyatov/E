# UCS
## Unified Call Syntax

[[UCS]] allows functions and methods to be called uniformly, blurring the distinction between free functions and object methods. For example:
- In a language with UCS, 
	- `obj.method(arg)` can be written as 
	- `method obj arg`, treating methods like free functions.
- Conversely, free functions can be called like methods: 
	- `func(x, y)` becomes `x.func(y)`
	- `fn(A,B,C)` -> `A.fn(B,C)`
- For functions with single argument:
	- `fn(X) -> X.fn` without parens (more readable)


Allows dot-pipelines:

```evento
let result = 5 .add 3 // Equivalent to add(5, 3)
```

[[UCS]] mostly used for functional-style dotted pipes:

```nim
A.first.next(X).last(Y,Z)
```

- `A`: An object or value (e.g., an variable, sensor, or data structure).
- `first`: A method or function applied to `A`, producing a result.
- `next(X)`: A method or function applied to the result of first, taking argument X.
- `last(Y,Z)`: A method or function applied to the result of next(X), taking arguments Y and Z.

```evento
actor ADC {
	on data: sensor.read.scale(celsius).send!(SERVER)
}
```
