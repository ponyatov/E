# Evento
## programming language prototype

> - for distributed programs 
> - for embedded systems ([[hw/microcontroller|microcontroller]]s)
> - mixes Rust, Elixir and F#

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

## **Evento Language Specification**

### **1. [[E/Language Overview]]**
### **2. [[E/Lexical Structure]]**
### **3. [[E/Data Types]]**
### **4. [[E/Memory Model]]**
### **5. [[E/Concurrency Model]]**
### **6. [[E/Error Handling]]**
### **7. [[E/Hardware Interaction]]**
### **8. [[E/Compilation Model]]**
### **9. [[E/Standard Library]]**
### **10. [[E/Safety]] & Compliance**
