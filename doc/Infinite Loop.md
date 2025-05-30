# `loop`
## Infinite Loop

```evento
loop {
  let data = read sensor;
  if data > threshold { break; }
}
```

- **Compiles to**: `while (1) { ... }` in C.
- **Use Case**: Main control loops, RTOS task runners.
