# Bit Manipulation

- C-style using [[Bitwise|bitwize operators]] over integer types
	- suitable for code rewriting, and old-skilled firmware programmers

```E
// Set bit 3 (0-based)
let value = 0
value |= (1 << 3)  // 0b00001000

// Clear bit 2
value &= ~(1 << 2)  // 0b00001000 (no change if bit was already clear)

// Toggle bit 0
value ^= (1 << 0)   // 0b00001001

// Check if bit 3 is set
if value & (1 << 3)) {} // bit is set
```

- Erlang-style
	- bitfield matching

		```E
		// Define a bitfield structure
		type Packet = {
			version:  u4,  // 4 bits
			type:     u2,  // 2 bits
			flags:    u8,  // 8 bits
			payload:  u16  // 16 bits
		}
		
		// Pattern matching on bitfields
		fn decode_packet raw:u32 -> Packet =
			match raw with
			| <<version:4, type:4, flags:8, payload:16>> =>
				{version, type, flags, payload}
		```

	- packet construction into integer type or memory region:
		```E
		// Constructing bitfields with `T:V` groups
		// T: integer number set field bit size
		// V: field value
		let packet = <<4:1, 2:3, 8:0xFF, 16:0xABCD>>
		```
		```E
		// with named fields: bit pattern must be typed
		let packet = Packet <<version:1, type:3, flags:0xFF, payload:0xABCD>>
		```
