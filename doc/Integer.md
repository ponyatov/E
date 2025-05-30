# `int`
## integer number variants

- `i` [[Cpp/signed|signed]] integer
	- `int` signed integer with CPU-native bit size
	- `i8` Sensors, small counters
	- `i32` Default signed integer
- `u` [[Cpp/unsigned|unsigned]] integer
	- [[E/bitfield|bitfield]] container & status flags
		- bitfields must be packed into unsigned CPU register to apply bit commands for accessing and modifing
	- `uint` unsigned integer with CPU-native bit size
		- default [[E/array|array]] index
	- `u8` = byte
		- arrays with short indexing (optimized for data rings & queue buffers)
	- `u32` Timers, large counters
	- `u64` Timestamps
- 8, 16, 32, 64 bits
- hex, oct & bin bases with 0x prefixes
- `_` allowed to split digit groups
	- `@addr(0x4002_0000)` `123_456_789`

```langio
terminal fragment Intuffix : /`[ui](8|16|32|64)/;

terminal HEX returns number: /0x[0-9a-fA-F]+/ Intuffix?;
terminal OCT returns number: /0o[0-7]+/       Intuffix?;
terminal BIN returns number: /0b[01]+/        Intuffix?;
terminal INT returns number: /[+\-]?[0-9]+/   Intuffix?;
```
- with optional `` `type`` [[type hints]]
- Storage Size: 1..8 bytes (limited to double machine word on 32-bit [[em/MCU|MCU]]s)
	- generic machine integers uses $8 \times n$ bit count
	- [[E/bitfield]] uses arbitrary bit count `[ui](1..64)`
- Examples: `42`, ``0xFF`u8``, ``1_000`u24``

## embedded specific

non-byte aligned integers

- `u12` match common 12-bit ADCs
- `u16` 16-bit ADC
- `u24` RTC timers, DSP

## operators

bitwize operators see: [[E/Bool#operators]]

