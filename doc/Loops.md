# Loops

## Infinite

- [[E/loop|loop]] - infinite loop

```E
loop {
    // Code to repeat indefinitely
    yield // release current thread every loop iteration
    do_something
}
```
- [[E/yield|yield]]
- [[E/break|break]]

when to use:

- [[em/event loop|event loop]]
- hardware & network polling
	- check sensors does not use interrupts,
	- periodical queries, etc

Why Not Just `while true`?

- [[#Infinite]] looping too common case that is good to have a special syntax
- loops can be syntatically annotated:
	- isohronous repeat time intervals without delays in a code
	- RTOS scheduling priority
	- as critical section with precision code points where to release a control

## Iteration

- [[E/for|for]] - iteration loop

## Preconditional

- [[E/while|while]] - preconditional loop

## Postcondition

- [[E/do|do]]
- [[E/until|until]] - postcondition loop
