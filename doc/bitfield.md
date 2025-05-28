# bitfield

`b1..64`

```evento
struct Name`type [little|big] {
  _: 1      // padding
  name`b2   // bits 15..13
  mode`b3   // bits 2..0
}
```
- special type for [[E/struct|struct]]
- `type` = **unsigned** [[E/Integer|Integer]]
	- type hint used for binding to one of unsigned types as container
- optional [[E/endianness]]
- `name:n` defines n-bit field
	- order from higher bits as it drawn in most datasheets
- default @[[packed]] [[E/attribute|attribute]]

```evento
// Declare a bitfield type
bitfield GPIO_Config`u8 {
  _: 1      // Bit 7: unused
  speed: 3  // Bits 4-6: output speed
  pull: 2   // Bits 2-3: pull-up/down
  mode: 2   // Bits 0-1: 2-bit mode
}
```

```evento
// Instantiate
let config = GPIO_Config { 
  mode: 0b01, 
  pull: 0b10, 
  speed: 0b111 
};
```
