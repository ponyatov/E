# Iteration

- Range-Based

```evento
for i in 0..10 {  // 0 ≤ i < 10
  buffer[i] = 0;
}
```

- Array Iteration

```evento
for byte in buffer {
  crc = crc.update byte;
}
```
