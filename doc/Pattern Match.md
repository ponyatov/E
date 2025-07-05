# Pattern Match

- [[E/match|match]] - pattern matching expression

## [[algebraic types]]
## [[E/Destructuring]]
## [[E/match|match]]

- The [[Pattern Match]] in [[E/E|E]] is the most powerful feature
- any data stucture can be [[E/Destructuring|destructured]] into separate variables, with later can be used for natural syntax for data transformation
- type-matching allows to use dynamic polymorphism in runtime
- [[E/when|guards]] selects match rules with matched values checking

```E
match doSmth // variable, function call, or expression
| Ok value  => log "Success: {value}"
| Error err =>
	thread::spawn failover_restart
	log "Failed: {err}"
```
- vertical bars makes code more readable
- tabbed syntax removes syntax noise

- [[E/bitfield|bitfield patterns]] allows to easy write any binary parsers in a few lines of code

	```E
	fn binary_parser raw:&[u8] -> Packet =
	    match raw with
	    | <<version:4, type:4, flags:8, payload:16>> =>
	        Packet {version, type, flags, payload}
		| _ =>
			raise Error.InvalidData (raw.dump)
	```
