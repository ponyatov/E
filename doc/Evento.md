# Evento

https://chat.deepseek.com/a/chat/s/a184a060-a1e8-43bc-ab61-c7e404c47e58

> [[lang/programming language|programming language]] prototype 
> - for distributed programs 
> - on embedded systems ([[hw/microcontroller|microcontroller]]s)

- **[[Actor]] Model**:
	- Embeds *pure async message-passing concurrency* natively,
	- ideal for distributed systems (no shared memory, avoids locks).  
	- **Implementation**:
		- Each "[[Actor]]" is a lightweight process/task running independently.  
		- Messages are passed asynchronously (non-blocking).  
		- Built-in scheduler for cooperative multitasking (no RTOS needed).
		- Thread-local (per-Actor) optional GC avoid locks on memory cleanup
- **Event-Driven**
	  - Microcontrollers often respond to *external events* (sensor inputs, interrupts).  
	  - Reactive programming simplifies event chains (e.g., `on_button_press → send_signal`).  
	- **Implementation**:  
		- Syntax for event handlers (like Arduino’s `loop()` but language-native).  
		- Data[[flow variable]]s (automatically propagate changes).  
		- Threads waiting on variable **pause** until the variable gets a next value
		- [[flow variable]] looks like a named channel
- **Imperative Core**:
	- Close-to-hardware control (needed for registers, interrupts, and memory-mapped I/O).  

![[E/concept]]
![[E/paradigm|paradigm]]
![[Lexical Structure]]
![[E/Syntax]]
![[E/Type System]]
![[E/Semantics]]
![[E/Error Handling]]
![[E/Standard Library]]
![[E/Interoperability]]
![[Tooling Directives]]
![[Formal Verification]]
![[Examples and Edge Cases]]

### **Prioritization for Evento**

1. **Must Have**: Lex, syntax, type system, actor semantics, error handling.
2. **Nice to Have**: Formal verification, advanced FFI.
3. **Embedded-Critical**: Memory model, hardware APIs.
