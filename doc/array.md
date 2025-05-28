# array

`[type; size]`

```
let boot_sector`[u8; 512] = [0; sizeof boot_sector -2 ] + [0xAA 0X55]
```

```
// Stack-allocated with zero init
let buffer: [u8; 256] = [0; 256];
```
```
// Struct field
struct SensorData {
  timestamp: u64,
  readings: [f32; 8],  // Fixed size
}
```

```
actor Sensor {
  let history: [f32; 16] = [0.0; 16];  // Circular buffer
  
  fn update(value: f32) {
    history << history[1]              // Efficient shift
    history[15] = value;
  }
}
```
