# Assignment

## Basic Assignment

|Operator|Description|Example|Equivalent|
|---|---|---|---|
|`=`|Simple assignment|`x = 5`|`x = 5`|

- [[E/let|let]] immutable by default
	- [[E/mut|mut]]
- No implicit type conversions during assignment

## Compound Assignment

|Operator|Description|Example|Equivalent|
|---|---|---|---|
|`+=`|Add and assign|`x += 3`|`x = x + 3`|
|`-=`|Subtract and assign|`x -= 2`|`x = x - 2`|
|`*=`|Multiply and assign|`x *= 4`|`x = x * 4`|
|`/=`|Divide and assign|`x /= 2`|`x = x / 2`|
|`%=`|Modulo and assign|`x %= 3`|`x = x % 3`|
|`&=`|Bitwise AND and assign|`x &= mask`|`x = x & mask`|
|`|=`|Bitwise OR and assign|`x|= flags`|`x = x|flags`|
|`^=`|Bitwise XOR and assign|`x ^= 0xFF`|`x = x ^ 0xFF`|
|`<<=`|Left shift and assign|`x <<= 2`|`x = x << 2`|
|`>>=`|Right shift and assign|`x >>= 1`|`x = x >> 1`|

```E
mut counter = 0
counter += 1       // Increment
counter -= 1       // Decrement
counter *= 2       // Double
counter /= 2       // Halve
```
```E
mut flags = 0b0000
flags |= 0b0100    // Set bit 2
flags &= ~0b0100   // Clear bit 2
flags ^= 0b1000    // Toggle bit 3
value <<= 3        // Multiply by 8
value >>= 2        // Divide by 4
```

## Multiple Assignment

- **destructuring assignment** for tuples and other patterns:

```E
// Tuple destructuring
let (x, y) = (10, 20)  // Destructuring assignment
```

- **Swap Values**

```E
// Swap values without temp variable
mut a = 5
mut b = 10
(a, b) = (b, a)  // a=10, b=5
```
