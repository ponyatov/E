# `wait`
## non-blocking wait loop

```evento
wait condition`bool;   /* wait with default thread delay quant    */
wait condition       { /* optional code repeated every wait quant */ }
```

```evento
wait gpio[0] & 0b00110010;  // Pause until some pin active (yields CPU)
```

