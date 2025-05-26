# `if`
## Conditional Code

```evento
if condition {
    do_something
} else {
    do_else
}
```
- No parentheses around condition, aligning with [[Fsh|F#]].
- Curly braces `{}` for blocks, avoiding [[Python]]’s indentation issues.
	- can be omitted for short single expression in place of block
- Optional `else` branch
	- can be omitted only if `do_something` returns `() = unit`
	- as `is` is expressions
	- and both branches must return the same return type
