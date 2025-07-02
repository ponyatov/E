# Comparison

|Operator|Description|Example|Notes|
|---|---|---|---|
|`==`|Equality|`x == y`|Value equality check|
|`!=`|Inequality|`x != y`|Negation of `==`|
|`<`|Less than|`x < y`||
|`>`|Greater than|`x > y`||
|`<=`|Less than or equal|`x <= y`||
|`>=`|Greater than or equal|`x >= y`||
|`===`|reference comparison|`&a === &b`|compare objects is the same|

- Works seamlessly with [[E/match|match]] expressions:
```E
match x with
| n when n > 0 => "positive",
| 0            => "zero",
| _            => "negative"
```
- For advanced use (e.g., custom types), implement comparison via [[E/trait|traits]]
