# Design goals

programming language
- for distributed programs 
- for embedded systems ([[hw/microcontroller|microcontroller]]s)

1. Distributed & Event-Driven Development

	- Erlang-style **actor model** with green thread processes.
	- **Message-passing** (using shared memory for local messages).
	- Built-in **pub/sub** and **RPC** for distributed systems.

2. Memory-Safe & Hard RealTime
	- **Sub-microsecond** context switches
	- **Deterministic memory access**
		- **Simplified Rust-like ownership** (no GC by default).
		- **Static-only allocation** by default (optional arena allocators)
		- **No heap fragmentation** (region-based allocation).
	- optional Real-Time Garbage Collection (RTGC) for circular data structures
	- **DMA-safe abstractions** (compiler-verified pointer lifetimes)

3. **Portability via native C Transpilation**
	- **Source-to-source translation to human-readable ANSI C** (no FFI hell).
	- Works with **any C/C++ toolchain** (GCC, Clang, IAR, Keil).
	- targets for **bare-metal** cross-compile (ARM , RISC-V, embedded Linux)
	- transpiler without IR layers (generates C code for target selected by project config and compiler options)
	- **GDB-compatible C output** (match source line numbers)
	- MISRA-C and ISO 26262/SIL4 compliant output

4. Hardware as First-Class Citizens
	- **Cross-Compile to Bare Metal**
		- Tier 1:
			- **ARM Cortex-M0/M4** (STM32, GD32)
			- **RISC-V**, **Xtensa** , (ESP8266, ESP32. ESP-Cx)
		- Tier 2: **Embedded Linux**
			- Raspberry Pi
			- i386 SBCs
			- x86_64 desktops & servers
	 - Packed structs with bitfields
		 - binary and ASCII parser/serializer generators
		 - protocol specfications with executable grammars
	 - Typed hardware access for all popular peripherals and interfaces (MCU & PC)

5. **Zero-Runtime (`no_std`) with hard RTOS features**
	 - preemptive multitasking with priorities
	 - RTOS syncronization (green threads on Linux targets)
	 - non-blocking I/O

6. Clean and easy-readable syntax
	- F# inspired
		- functions without parens
	- Elixir inspired
		- pattern matching and functions with guards
		- `|>` pipe operators
		- Supervision trees
	- Rust inspired
		- variable immutability (let & mut)

7. Networking
	- heterogeneous cluster over wireless mesh networks
	- direct interaction with Ethernet, WiFi and Bluetooth (raw packets and cross-mesh forwarding)
	- generic IP stack with optional `lwip` integration
	- **CRDTs for shared state** (conflict-free replicated data types)
