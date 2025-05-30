# `bool`

```evento
terminal BOOL returns boolean: ('true'|'false');
```

- `true'bool`, `false'bool`

## logic operators

### Boolean `bool bool -> bool`

|Operator|Meaning|Example|Notes|
|---|---|---|---|
|`&&`|Logical AND|`if (x > 0) && (y < 10)`|Short-circuits (evaluates left-first)|
|`\|`|Logical OR|`if (err) \| (timeout)`|Short-circuits|
|`!`|Logical NOT|`if !ready`|Unary operator|

- **No implicit conversions**: Operands must be `bool` (unlike C).
- **Strict typing**: `1 && true` → Compile error (mix `i32` and `bool`).

### Bitwise

_(For hardware registers, machine numbers, and flags)_

|Operator|Meaning|Example|Notes|
|---|---|---|---|
|`&`|Bitwise AND|`flags & 0x1`|No short-circuit|
|`\|`|Bitwise OR|`config \| 0x80`||
|`^`|Bitwise XOR|`mask ^ 0xFF`||
|`~`|Bitwise NOT|`~status`|Unary operator|

```evento
let gpio_state = (gpio[0] & 0x1) != 0;  // Extract pin 0 state
```
