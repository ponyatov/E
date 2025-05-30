# `bool`

```evento
terminal BOOL returns boolean: ('true'|'false');
```

- `true'bool`, `false'bool`

## implicit conversion

- *Python-like Implicit conversion* to [[E/Bool|Bool]] must be used in
	- [[E/if|if]]-like and [[E/filter|filter]] constructs, and 
	- [[conditional loop]]s*
- use `-Wimplicit-conversion` compiler check flag for strict projects

|Type|Falsy Values|Truthy Values|
|---|---|---|
|**Bool**|`false`|`true`|
|**Integers**|`0`|Any non-zero|
|**Floats**|`0.0`, `NaN`|Non-zero, non-NaN|
|**Pointers**|`null`|Valid addresses|
|**Arrays**|Empty (`len == 0`)|Non-empty|

```evento
let x = 10;  
if x { ... }  // true (non-zero)
```

## operators

### Logical Operators (Short-circuiting)

|Operator|Example|Compilation|
|---|---|---|
|`and`|`x and y`|`x & y` (C-style)|
|`or`|`x or y`|x \| y|
|`not`|`not x`|`!x`|

Compiler distinguishes logical vs. bitwise based on operand types:

```evento
if (x > 0) and (y < 10)   // Logical (short-circuit)
let mask = 0xFF & gpio[0] // Bitwise
```

### Bitwise Operators (Non-short-circuiting)

|Operator|Example|Hardware Use Case|
|---|---|---|
|`&`|`flags & 0x1`|Masking GPIO registers|
|\||config \| `0x80`|Setting control bits|
|`^`|`mask ^ 0xFF`|Toggle bits|
|`~`|`~status`|Invert all bits|

_(For hardware registers, machine numbers, and flags)_

```evento
let gpio_state = bool (gpio[0] & 0x1)  // Extract pin 0 state and get Bool
```
```evento
// Safe bitmask operation
fn is_flag_set(reg: u32, bit: u8) -> bool {
  (reg & (1 << bit)) != 0  // Explicit comparison
}
```
