# `bool`

```evento
terminal BOOL returns boolean: ('true'|'false');
```

- `true'bool`, `false'bool`

## implicit conversion

- *Python-like Implicit conversion* to [[E/Bool|Bool]] must be used in
	- [[E/if|if]]-like and [[E/filter|filter]] constructs, and 
	- [[conditional loop]]s*

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

_(Same symbols for logical/bitwise, context-dependent)_

|Operator|Logical Context|Bitwise Context|
|---|---|---|
|`&`|Short-circuiting AND|Bitwise AND|
|\||Short-circuiting OR|Bitwise OR|
|`^`|XOR|Bitwise XOR
|`!`|Logical NOT
|`~`||Bitwise NOT|

_(For hardware registers, machine numbers, and flags)_

```evento
let gpio_state = (gpio[0] & 0x1) != 0;  // Extract pin 0 state
```
