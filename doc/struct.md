# struct

```evento
// No commas, F#-style
struct Point [little|big] {
  name`type [ = default_value ]
```
- [[E/endianness|endianness]]
- field
	- types also include [[E/bitfield|bitfield]] arbitrary
	- default values: optional
- [[Attributes|attributes]]
	- [[packed]]
	- [[aligned]]
- Comma-free cleaner syntax

```evento
// No commas, F#-style
struct Point [little|big] {
  x`f32 = 0.0
  y`f32 = 0.0
  z`f32 = 0.0
}
```

Instantiation:
```event
let origin = Point { x: 0.0 y: 0.0 z: 0.0 }  // No commas
```

Example: Sensor Configuration
```evento
struct SensorConfig {
  id`u8
  sampling_rate`u16
  calibrated`bool = false
}

let config = SensorConfig {
  id: 0x42
  sampling_rate: 1000
  // calibrated: default from definition
}
```
