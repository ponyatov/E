# Parameters and Return Values

> data Passing mechanisms:
> - by value
> - by reference

In [[E/E|E]] there are no parens required to call functions:
- no `()` unit token required
- [[unified call syntax]] supported for functions calls using `.` dotted chains

```E
// Function call (no parens)
foo x y    // Equivalent to foo(x, y)

foo        // Just a variable
bar        // or function call without arguments
```
```E
// Without delimiters (clear)
add 1 2      // add(1, 2)

// With delimiters (nested operations)
mul (add 1 2) 3   // mul(add(1, 2), 3)
```

Also, [[E/pipe|pipe]] operator can be used:

```E
x |> foo |> bar  // Equivalent to bar(foo(x))
```

## Return

- Implicit Returns:
	- last expression in a [[E/Code Block|Code Block]] is returned.
- Explicit [[E/return|return]]
	- mostly use for early exits in a mid of code

```E
fn find xs:Ordered<T> target<T> -> Option<T> =
    for x in xs do
        if x == target then return Some(x)
    None
```
