# Loops

[[E/Loops|Loops]] and [[E/Code Block|Code Blocks]] can be syntatically [[E/annotation|annotated]]:
- isohronous repeat time intervals without delays in a code
- able to bind loop iteration to hardware timer, interrupt, network message, or any other async events
- RTOS scheduling priority
- marked as critical section with precision code points where to release a control

## Infinite

- [[E/loop|loop]] - infinite loop

```E
loop [repeat: <duration>] [on: <event>] [prio: <rt_priority>] {
    // Code to repeat indefinitely
    yield // release current thread every loop iteration
    poll_sensors
}
```
- `{}` [[lang/code block|code block]] can be replaced by a single function
- [[E/yield|yield]]
- [[E/break|break]]

when to use:

- [[em/event loop|event loop]]
- hardware & network polling
	- check sensors does not use interrupts,
	- periodical queries, etc

Why Not Just `while true`?

- [[#Infinite]] looping too common case that is good to have a special syntax
- with [[E/annotation|annotations]] look cool

[[E/annotation]]

## Iteration

- [[E/for|for]] - iteration loop

## Preconditional

- [[E/while|while]] - preconditional loop

## Postcondition

- [[E/do|do]]
- [[E/until|until]] - postcondition loop
