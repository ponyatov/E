# period = time delta
## time [[E/measurement]] units

- `<int>...` or `<float>...`
	- `d` days (planning)
	- `h` hour (time management)
	- `min` minutes (reminders)
	- `s` second (logging, messaging, slow control)
	- `ms` millisecond (sensor polling, process control)
	- `us` microsecond (hi-res timers, PWM & motion, DSP)
	- `ns` nanosecond (hardware sync)
- can be sequenced in sum:
	- `3d4h = 3d + 4h`
- [[E/frequency]] (automatically recalculates to period)
