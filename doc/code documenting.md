# code documenting

- Single-line docstring
```E
/// This is a single-line comment
/// (prefixes the object documented, and can be multiline)
let x = 10;  //< explanation in a same line
```

- Multi-line docstring
	- prefix
	```E
	/**
	This is a multi-line comment block before some code object
	It can span multiple lines.
	*/
	```

	- infix docstring documents code block (or the whole module)
	```E
	let same x =
	/*!
	internal documentation about @same
	uses @... prefix for code object referencing
	*/
		x // returns the same (this comment not goes into docs)
	```
