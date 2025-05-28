# State Machine

```
enum State {
  Init    gpio_pin`u8
  Reading sensor_id`u8, timeout`u32
  Fault   error_code`u16
}

trait Machine<T> {
	fn run state'T
}

impl Machine for State {
	fn run state'T =
		match state
		| Init    pin            => self.run sensors[pin] 1000
		| Reading sensor timeout => self.run sensor timeout-1
		| Fault   error          => fail error
}

Machine.run State::Reading(0x42, 1000);
```
