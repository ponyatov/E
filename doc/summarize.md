# Evento
## programming language prototype

> - for distributed programs 
> - for embedded systems ([[hw/microcontroller|microcontroller]]s)
> - mixes Rust, Exlixir and F#

1. Distributed & Event-Driven by Default

	- Erlang-style **actor model** with green thread processes.
	- **Message-passing** (using shared memory for local messages).
	- Built-in **pub/sub** and **RPC** for distributed systems.

2. Memory-Safe & Hard RealTime
	- **Simplified Rust-like ownership** (no GC by default).
	- optional Real-Time Garbage Collection (RTGC) for circular data structures
	- **No heap fragmentation** (region-based allocation).

3. **Portable via native C Transpilation**
	- **Source-to-source translation to human-readable ANSI C** (no FFI hell).
	- Works with **any C/C++ toolchain** (GCC, Clang, IAR, Keil).
	- targets for **bare-metal** cross-compile (ARM , RISC-V, embedded Linux)
	- transpiler without IR layers (generates C code for target selected by project config and compiler options)
	- MISRA-C and ISO 26262/SIL4 compliant output

4. Clean and easy-readable syntax
	- F# inspired
		- functions without parens
	- Elixir inspired
		- pattern matching and functions with guards
		- `|>` pipe operators
		- Supervision trees
	- Rust inspired
		- variable immutability (let & mut)
5. **Cross-Compile to Bare Metal**
	- Tier 1: **ARM Cortex-M0/M4**, **RISC-V** (ESP32, GD32).
	- Tier 2: **Embedded Linux** (RPi, i386 SBCs, x86_64 desktops & servers).

6. **Zero-Runtime (`no_std`) with hard RTOS features**
	 - Typed hardware access for all popular peripherals and interfaces (MCU & PC)
	 - preemptive multitasking with priorities
	 - RTOS syncronization (green threads on Linux targets)
	 - non-blocking I/O

7. Networking
	- heterogeneous cluster over wireless mesh networks
	- direct interaction with Ethernet, WiFi and Bluetooth (raw packets and cross-mesh forwarding)
	- generic IP stack with optional `lwip` integration

## **Evento Language Specification (Minimal Set)**

### **1. Language Overview**

- Design goals (embedded, distributed, real-time)
- Core paradigms (actor model, functional, ownership)
- Target platforms (bare-metal, embedded Linux)

### **2. Lexical Structure**

- Comments (line, block, doc comments)
- Literals (numbers, strings, binaries)
- Identifiers (naming rules)
- Keywords (`actor`, `mut`, `async`, `match`)

### **3. Data Types**

- Primitives (`i32`, `f32`, `bool`, `u8`)
- Compound types (tuples, arrays, slices)
- Special types (`Result<T,E>`, `Option<T>`)
- Hardware types (`GPIO`, `I2C`, `PWM`)

### **4. Memory Model**

- Ownership system (simplified Rust)
- Borrowing rules (immutable/mutable)
- Static allocation (`@section` syntax)
- Optional RTGC constraints

### **5. Concurrency Model**

- Actor declaration syntax
- Message passing patterns
- Built-in supervision trees
- Priority-based scheduling

### **6. Error Handling**

- `Result` type semantics
- Error propagation (`?` operator)
- Panic behavior (configurable handlers)

### **7. Hardware Interaction**

- Peripheral access syntax
- Volatile operations
- Interrupt handlers
- DMA safety annotations

### **8. Compilation Model**

- Transpilation to C rules
- Target-specific behaviors
- `no_std` requirements
- Linker script integration

### **9. Standard Library**

- Core modules (`io`, `net`, `time`)
- Hardware abstraction layer
- Distributed primitives
- Minimal runtime services

### **10. Safety & Compliance**

- MISRA-C mapping
- ISO 26262 traceability
- Undefined behavior guarantees
- Certification annexes
