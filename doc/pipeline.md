# Pipeline operator

```nim
A.first.next(X).last(Y,Z)
```

- `A.first` becomes `first A`
- `result1.next(X)` becomes `next result1 X`
- `result2.last(Y,Z)` becomes `last result2 Y Z`

Combining [[UCS]] with parenless function call syntax, we can get more readable code look:

```evento
A first |> next X |> last Y Z
```
```evento
actor ADC {
	let mode = StartStop
	mut delta = 0.0

	on signal(change) {
	    if change > 0.1 | delta > 0.2
	    {
		    read sensor |> scale celsius |> send! SERVER
		} else {
			delta += change
		}
	}
}
```
