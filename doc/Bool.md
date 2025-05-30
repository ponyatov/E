# `bool`

```evento
terminal BOOL returns boolean: ('true'|'false');
```

- `true'bool`, `false'bool`

## implicit conversion

- *Python-like conversion can be used in
	- [[E/if|if]]-like and
	- [[E/filter|filter]] constructs, and 
	- [[conditional loop]]s*

| -> | true | false
|-|-|-
| true | v |
| false || v
| int | != 0 | == 0
| float | >= $\pm \epsilon$ | < $\pm \epsilon$ |
| [[E/array]] | size > 0 & some element == true | [ ] \| all elements == false
| [[E/vector]] | size > 0 & some element == true | [ ] \| all elements == false

## logic operators

logic operators works the same for integers and [[E/Bool|Bool]] type so we don't need to make separate groups for logic and bitwize operations

|Operator|Meaning|Example|Notes|
|---|---|---|---|
|`&&`|logical & bitwize AND|`if (x > 0) && (y < 10)`|Short-circuits (evaluates left-first)|
|`\|`|Logical OR|`if (err) \| (timeout)`|Short-circuits|
|`!`|Logical NOT|`if !ready`|Unary NOT operator|

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
