# Annotations

can be used before:
- [[E/Function Definition|Function Definitions]]
- [[E/Code Block|Code Blocks]]
- [[E/Loops|Loops]]

## time-related

- [[E/period]] / [[frequency]]

- `@repeat <period>`
	- isohronous repeat (low-jitter or hardware timer binded)
```E
// block annotated syntactically looks like loop parameter
loop @repeat 50Hz/4 {  // mains power related app
    poll_sensors()
}
```
```E
// annotated loop calls a single no-params function
@repeat 5min loop autosave
```

- `@timeout <period>`
	- fault if block executes longer then period

## [[E/Event]]

- `@on <event>`
	- wait event for block/loop iteration start
	- for functions, statically bind [[E/spawn|spawn <function>]] as event handler
- `@sync <event>`
	- sync every loop iteration with event (run code on event, and sleep for next)
