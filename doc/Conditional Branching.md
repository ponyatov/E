# Conditional Branching

- [[E/if|if]] - conditional statement
- [[E/else|else]] - alternative branch

```E
if condition then
    // true branch
else
    // optional false branch
```

- there is no ternary expression: if/else itself if conditional expression

```E
let result = if condition then true_value else false_value
```

## Short-Circuiting

```E
// Logical AND - evaluates second operand only if first is true
condition1 && condition2

// Logical OR - evaluates second operand only if first is false
condition1 || condition2
```
