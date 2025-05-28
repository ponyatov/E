# bitfield

```evento
// Declare a bitfield type
bitfield GPIO_Config`u8 {
  _: 1,     // Bit 7: unused
  speed: 3, // Bits 4-6: output speed
  pull: 2,  // Bits 2-3: pull-up/down
  mode: 2,  // Bits 0-1: 2-bit mode
}
```
- special keyword
- type hint used for binding to one of [[E/Integer|Integer]] unsigned types as container
- `:n` defines n-bit field
- order from higher bits as it drawn in most datasheets
- default @[[packed]] [[E/attribute|attribute]]

```evento
// Instantiate
let config = GPIO_Config { 
  mode: 0b01, 
  pull: 0b10, 
  speed: 0b111 
};
```

