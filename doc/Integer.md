# `int`
## integer number variants

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
