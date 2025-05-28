# tagged union

```
enum SensorData {
  Temperature   f32
  Accelerometer x`f32, y`f32, z`f32
  Error         code`u8
  Unsupported
}
```

- mixes [[Cpp/enum]] & [[Cpp/union]] structures
	- has hidden [[E/enum|enum]]-like type selector field to specify what data now holded in
- binds type name with tuple-like data groups
- data shares the same [[E/Sized|Sized]] memory region

![[E/Option|Option]]
![[E/Result|Result]]
