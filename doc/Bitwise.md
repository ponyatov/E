# Bitwise

```E
// bitwise:
   ~ A // NOT
A  & B // AND
A  | B // OR
A  ^ B // XOR
A << B // left shift (unsigned)
A >> B // right shift (unsigned)
```

```E
let a:byte = 0b1100
let b      = 0b1010

let and_result = a & b  // 0b1000 (8)
let or_result  = a | b  // 0b1110 (14)
let xor_result = a ^ b  // 0b0110 (6)
let not_a      = ~a     // 0b11110011

let shifted_left  = 0b0001 << 3  // 0b1000
let shifted_right = 0b1000 << 3  // 0b0001
```

## Precedence

Bitwise operators have the following precedence (from highest to lowest):

1. `~` (bitwise NOT)
2. `<<`, `>>` (shifts)
3. `&` (bitwise AND)
4. `^` (bitwise XOR)
5. `|` (bitwise OR)

## [[Bit Manipulation]]
