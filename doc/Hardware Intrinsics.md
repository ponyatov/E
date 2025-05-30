# Hardware Intrinsics

## float

```evento
@fpu
fn fmadd(a`f32, b`f32, c`f32) -> f32 { // Fused multiply-add
  a * b + c                            // Single instruction on Cortex-M4F
}
```
- [[Attributes|fpu]]
