# `wait`
## non-blocking wait loop

- Yields CPU to scheduler (cooperative multitasking)
- additional checks and behaviour in action block
- for safety: always pair with timeout-like checks
- compilation: maps to RTOS `TaskDelay()` or hardware-specific yielded busy-wait

```evento
wait condition`bool;   /* wait with default thread delay quant    */
wait condition       { /* optional code repeated every wait quant */ }
```

```evento
wait gpio[0] & 0b00110010;  // Pause until some pin active (yields CPU)
```

```evento
wait sensor.ready {  // Checks condition every scheduler quantum
  if !(timeout_counter--) { panic! "Timeout"; }
}
```
