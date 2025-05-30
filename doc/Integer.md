# `int`
## Integer number

```evento
42          // Decimal
0xFF        // Hex
0o755       // Octal
0b1101_0101 // Binary (with underscores)
1_000_000   // Digit separators
```

Literal numbers can be followed by type hint:
- no special suffixes

```evento
   42`i32
 0xFF`u8
0o755`u16
```

- `i` [[Cpp/signed|signed]] integer
	- `int` **signed integer with CPU-native bit size**
	- `i8` Sensors, small counters
	- `i32` Default `int` for MCUs
	- `iN` arbitrary-bits signed integer (limited range values, ADC)
- `u` [[Cpp/unsigned|unsigned]] integer
	- `uint` **unsigned integer with CPU-native bit size**
		- default [[E/array|array]] index
	- `u8` = byte
		- arrays with short indexing (optimized for data rings & queue buffers)
	- `u32` Timers, large counters, `uint` on MCUs
	- `u64` Timestamps
	- `uN` arbitrary-bits unsigned integer (limited range values, ADC, [[ring]] index)
- 8, 16, 32, 64 bits for integers can be manipulated in CPU registers
	- 1..64 bits for arbitrary-bits numbers besides $2^n,n=3..6$
- hex, oct & bin bases with `0x` `0o` `0b` prefixes
- `_` allowed to split digit groups
	- `@addr(0x4002_0000)` `123_456_789`

```langio
Int returns number: INT | HEX | OCT | BIN;

terminal fragment Intuffix : /\`[ui](8|16|32|64)/;

terminal HEX returns number: /0x[0-9a-fA-F]+/ Intuffix?;
terminal OCT returns number: /0o[0-7]+/       Intuffix?;
terminal BIN returns number: /0b[01]+/        Intuffix?;
terminal INT returns number: /[+\-]?[0-9]+/   Intuffix?;
```
