# `if`
## Conditional Code

```bnf
<if_expr> ::= "if" <expr> "then" <expr> ("else" <expr>)?
```

```evento
if condition then
  expression1
else
  expression2
```
- No parentheses around condition, aligning with [[Fsh|F#]].
	- more readabiity, no syntax noise
	- `then` keyword for visual split predicate from action
- Optional `else` branch
	- can be omitted only if `do_something` returns `() = unit`
	- as `is` is expressions
- both branches are expressions and must return the same return type

Chains:
```evento
let temp_level = 
  if temp > 40.0 then "Hot"
  else if temp > 25.0 then "Warm"
  else "Cold"
```

Actor sample:
```evento
actor Thermostat {
  on update(temp`f32) {
    let action = if temp > 30.0 then
      cooler |> send! ON
    else
      send!(cooler, OFF)
  }
}
```

In-expression use:
```evento
let x = if a > b then a else b
```
is an analog of C code:
```evento
int x = (a > b) ? a : b;
```

Example: Sensor Calibration
```evento
fn calibrate(raw`u12) -> f32 =
  if raw == 0 then
    error!("Invalid reading")
  else
    (raw`f32 * 3.3) / 4095.0
```
