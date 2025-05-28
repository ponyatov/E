# array

`[type; size]`

## Declaration & Initialization

```
let boot_sector`[u8; 512] = [0; sizeof boot_sector -2 ] + [0xAA 0X55]
```

```
// Stack-allocated with zero init
let buffer`[u8; 256] = [0; 256];
```
```
// Explicit values
let temps`[f32; 3] = [25.5, 30.0, 22.1];  
```

 ## Struct Embedding
 
```
// Struct field
struct SensorData {
  timestamp` u64,
  readings `[f32; 8],  // Fixed size
}
```

```
struct SensorPacket {
  timestamp ` u64,
  readings  `[u12; 8],  // Fixed-size array of 12-bit values (stored as u16)
  checksum  `u8
}

let data = SensorPacket {
  timestamp: 0xAABBCCDD,
  readings: [0xFFF, 0x800, 0x000, ...],  // 12-bit values
  checksum: 0x42
};
```
- [[E/struct|struct]]
- [[E/bitfield|bitfield]]

```
actor Sensor {
  let history `[f32; 16] = [0.0; 16];  // Circular buffer
  
  fn update(value`f32 = 0.0) {
    history << history[1]              // Efficient shift
    history[15] = value;
  }
}
```

## Hardware Register Access

```evento
let gpio` [u32; 16] @volatile @addr(0x4002_0000) // STM32F4 GPIO regs
```
- [[E/attribute|attribute]]
	- [[E/addr]]
