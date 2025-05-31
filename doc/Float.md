# `float`
## floating point numbers

```evento
3.14        // Default f64
6.022e23    // Scientific notation
1.0`f32     // Explicit single-precision
1.5e-3`f16  // Half-precision (ARM Cortex-M4+)
```

```langio
Float returns number: FLOAT;

terminal fragment Flotuffix: /\`f{16|32|64}/;

terminal FLOAT returns number: /[+\-]?[0-9]+\.[0-9]+([eE][+\-]?[0-9]+)?/ Flotuffix?;
```

## special values

```evento
inf     // Positive infinity
-inf    // Negative infinity
nan     // Quiet NaN
```

## functions

![[Basic Arithmetic]]
![[Trigonometry]]
![[Rounding]]
![[Constraints]]
![[Hardware Intrinsics#float]]
