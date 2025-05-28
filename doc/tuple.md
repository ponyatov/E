# tuple

```evento
// Comma-separated, parentheses-optional
let coords = x: 1.0, y: 2.0, z: 0.0    // Named fields
let pair = (42, "answer")              // Unnamed, heterogeneous
let unit = (,)                         // Empty tuple
```
- group data elements of heterogeneous types
- comma-separated
	- optional parens
- usage
	- return multiple values from [[E/Function|Function]]
	- visually distinct `extern C` calling

```evento
// Explicit type hints
let point: (x`f32, y`f32) = (1.5, 2.0)
let ids: (u16, u16) = (0x1234, 0x5678)
```

Access Patterns

|Method|Example|Notes|
|---|---|---|
|**Positional**|`pair.0` (→ `42`)|Zero-indexed|
|**Named**|`coords.x` (→ `1.0`)|Requires field names|
|**Destructuring**|`let (x, y) = coords`|Pattern matching|


## vs [[E/struct|struct]]

- unnamed
- [[E/Copy|Copy]] semantics (stack-allocated)
- positional access
- no Memory layout control
