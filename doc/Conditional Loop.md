# Conditional Loop

## pre-condition

```evento
while x < 100 {
  x += process();
}
```

- Body executes only if condition holds initially.

## post-condition

```evento
do {
  x = sensor.read();
} while x < 100;
```
- **at least one iteration** must be done before condition check
- Use Case: Hardware polling
