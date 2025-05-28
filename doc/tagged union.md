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

[[E/pattern matching|pattern matching]]:

```
fn handle_data (data: SensorData) -> u8 {
  match data {
    Temperature   t         => t.round() |> u8
    Accelerometer (x, y, z) => (x + y + z).abs() |> u8
    Error(code)             => code
  }
}
```

![[E/State Machine|State Machine]]:


![[E/Option|Option]]
![[E/Result|Result]]
