# Arithmetic

## Unary

|Operator|Description|Example|Result|
|---|---|---|---|
|`+`|Positive (no-op)|`+5`|`5`|
|`-`|Negation|`-5`|`-5`|

## Infix

|Operator|Description|Example|Result|
|---|---|---|---|
|`+`|Addition|`5 + 3`|`8`|
|`-`|Subtraction|`7 - 2`|`5`|
|`*`|Multiplication|`4 * 6`|`24`|
|`/`|Division *|`10 / 3`|`3`|
|`%`|Modulus/Remainder|`10 % 3`|`1`|

* Note:
	- [[E/int|int]]: integer division truncates toward zero (like C, not like Python)
	- [[E/float|float]]: float-point division works as usual on most languages

## Inc-/Decrement

|Operator|Description|Example|Effect|
|---|---|---|---|
|`++`|Post-increment|`x++`|Returns x, then increments|
|`++`|Pre-increment|`++x`|Increments, then returns x|
|`--`|Post-decrement|`x--`|Returns x, then decrements|
|`--`|Pre-decrement|`--x`|Decrements, then returns x|

## Operator Precedence

From highest to lowest precedence:

1. `()` (parentheses)
2. `++`, `--` (postfix), `+`, `-` (unary)
3. `*`, `/`, `%`
4. `+`, `-` (binary)
5. `=`, `+=`, `-=`, `*=`, `/=`, `%=` (assignment)
