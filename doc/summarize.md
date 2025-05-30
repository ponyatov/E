# Evento
## programming language prototype

> - for distributed programs 
> - for embedded systems ([[hw/microcontroller|microcontroller]]s)
> - mixes Rust, Exlixir and F#

1. Distributed & Event-Driven by Default

	- **Actor model** (like Elixir/Erlang) for concurrency.
	- **Message-passing** between lightweight processes.
	- Built-in **pub/sub** and **RPC** for distributed systems.

2. Memory-Safe & Hard RealTime
	- **Ownership model** (but simpler than Rust) without gc
	- optional Real-Time Garbage Collection (RTGC) for circular data structures

3. Portable
	- source-to-source translator into high-lelvel C code for **bare-metal** targets (ARM , RISC-V, embedded Linux)
	- no FFI: translated code can be compiler with any C/C++ compiler

4. Clean and easy readable syntax
	- F# inspired
		- functions without parens
	- Elixir inspiered
		- pattern matching and functions with guards
		- `|>` pipe operators
	- Rust inspired
		- variable immutability (let & mut)
5. Cross-compile first for microcontrollers
	- ARM Cortex-M (Cortex-M0, Cortex-M1, Cortex-M4)
	- RiscV
	- embedded Linux (multiple hardware platforms, including x86_64 & Raspberry Pi)

6. No runtime: `no_std` environment
	 - Hardware access (GPIO, I2C, etc.) as first-class
	 - async non-blocking I/O

7. Networking
	- heterogeneous cluster over wireless mesh networks
	- direct interaction with Ethernet, WiFi and Bluetooth (raw packets and cross-mesh forwarding)
	- generic IP stack with optional `lwip` integration
