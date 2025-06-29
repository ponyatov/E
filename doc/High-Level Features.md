# High-Level Features

[[E/E|E-lang]] is a modern, embedded-focused programming language designed for **industrial automation, IoT, and real-time systems**. It combines the safety and expressiveness of functional programming with low-level control for microcontrollers and embedded Linux.

### **1. Embedded & Real-Time Optimized**

- Targets **microcontrollers** (Cortex-M, ESP8266/ESP32, RISC-V) and **embedded Linux** (Raspberry Pi, PC/104).
- **Hard real-time** support with deterministic memory management (stack/heap control).
- Optional thread-local **garbage collection** for complex data structures.

### **2. Safe & Expressive Syntax**

- **Pattern matching** (inspired by Rust/F#)
	- for clean control flow 
	- for ease of structured data processing (deep trees and graphs traversal)
- **Strong typing + type inference** for reliability.
- **Algebraic data types** (tagged unions, enums) for structured error handling.
- **First-class functions** (lambdas, closures, generators, combinators).

### **3. Concurrency & Memory Safety**

- **Threads, coroutines** (Erlang/Elixir style).
	- green threads
	- supervision trees
	- network clustering
- **Synchronization primitives**: locks, atomics, typed channels (Go-style).
- **No undefined behavior** (unlike C/C++).

### **4. Cross-Platform & Heterogeneous Systems**

- **Canadian Cross-compilation**: Build firmware for ARM, x86, RISC-V, Xtensa from a single codebase.    
- Supports **bare-metal microcontrollers, Linux, and Windows**.
- **Self-hosting compiler** (can compile itself for different targets).

### **5. Developer Experience**

- **REPL-driven development**:
	- Smalltalk style with [[interactive debugger]]:
	    - Modify running programs interactively.
	    - Full-featured **breakloop debugger**.
        
- **Integrated toolchain**:
	- [[compiler as a library]] approach
    - [[LSP]] server, [[E/autoformat|autoformatter]], project manager.
    - [[vscode/VSCode|VSCode]] & [[cmake/CMake|CMake]] support.
