# `Option<T>`

Represents an optional value that may or may not exist.

- [[E/Some|Some]] (T)
	- Contains a valid value.
- [[E/None|None]]
	- No value exists.

```E
// example: Safe Division
fn safe_divide a b -> Option<float> =
    if b == 0 then None
              else Some (a / b)
```
usage:
```E
let result = safe_divide 10 0

match result with
| Some x => log   "Result: {x}"
| None   => panic "Division by zero!"
```
