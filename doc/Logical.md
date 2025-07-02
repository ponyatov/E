# Logical

```E
       // in precedence order: highest to lower:
!x     // logical not
x && y // logical and
x || y // or
```

- **Short-Circuit Evaluation**
	- `&&` stops evaluating if the left operand is `false`.
	- `||` stops evaluating if the left operand is `true`.
	- Critical for performance and safety in embedded systems.
- **Implicit Boolean Context**
	- Operands are implicitly converted to `bool`
		- `n:int => false if n == 0 else true`
		- `f:float => true if abs(f) > epsilon else false`
		- `s:string => false if s == "" else true`
		- `x:container => !x.isEmpty`
