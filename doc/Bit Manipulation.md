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
				Packet {version, type, flags, payload}
		```

	- packet construction into integer type or memory region:
		```E
		// Constructing bitfields with `T:V` groups
		// T: integer type with arbitrary bits number
		// V: field value
		let packet = <<u4:1, u2:3, u8:0xFF, u16:0xABCD>>
		```
		```E
		// with named fields: bit pattern must be typed
		let packet = Packet <<version:1, type:3, flags:0xFF, payload:0xABCD>>
		```

## Use Cases in Embedded Systems

1. **Hardware Register Manipulation**
	```E
	// set specific bits in a hardware register
	const STATUS_REG = 0x40021000 as *mut u32
	unsafe { *STATUS_REG |= (1 << 5) } // Set bit 5
	```
2. **Protocol Implementation**
	```E
	// Decode a network packet header
	fn decode_header raw: u32 -> (u3, u5, u24) =
	    match raw with
	    | <<u3:version, u5:flags, u24:length>> =>
	        (version, flags, length)
	```
3. **Memory Optimization**
	```E
	// Pack multiple boolean flags into a single byte (using bit ops)
	let flags: u8 = 0
	flags |= (has_error << 0)
	flags |= (is_ready << 1)
	flags |= (needs_reply << 2)
	```
	```E
	// with bit patterns
	// (bools automatically treated as u1 single bits)
	let flags: u8 = <<bool:needs_reply bool:is_ready u1:has_error>>
	```
