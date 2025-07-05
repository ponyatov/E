# Code Block

- code block in `{ }` curly braces
	- blocks has lexical [[E/Scope|scoping]]
- memory deallocation is syncronous:
	- memory frees at the end of block or scope
	- destructors runs at the end of variable life-time
	- delayed finalization must be expressed as a separate explicit construct

```E
// Simple block has its own scope
{
    let x = 10
    let y = 20
    x + y  // last expression is return value
}
```
```E
// expression block
let result = {
    let temp = calculate()
    temp * 2 + 1
}
```
```E
// block as function body
fn add a b  {
    let sum = a + b
    sum  // explicit return
}
```
```E
// lambda with implicit return (last expression in a code block)
let multiply a b -> a * b // single expressions does not need {}
```

## [[E/unsafe|unsafe]]
## [[Atomics]]
## [[E/Deallocation]]
## [[Asynchronous functions]]
