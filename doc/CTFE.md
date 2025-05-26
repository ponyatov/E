# CTFE
## Compile-Time Function Execution

Compile-Time Function Execution (CTFE) is a technique where
- certain functions or expressions in a programming language **are evaluated at compile time**,
- producing results that are embedded directly into the generated code.

This eliminates runtime overhead, making it particularly valuable for resource-constrained environments like embedded systems, any minimizes startup time in case you need some complex data structures can't be specified statically using available language syntax.

For example, you can fetch some configuration from database, that changes between compiler runs, and compile-in configuration constants directly into resulting machine code.

- `const fn`: Marks functions for CTFE, *ensuring they are side-effect-free and deterministic*.
- `run!`: Executes external commands (e.g., cargo build) at compile time for automation.
- [[Rust/Rust|Rust]] has notable limitation: Only *side-effect-free expressions and functions can be evaluated at compile time*.
	- In a real use this is too limited and impractical: you will probably want to get configuration updates from an external service or database, or register randomly generated cryptokeys during compilation.
	- On the other hand, extra calls during compiler execution can reduce its speed to an unacceptable level, especially if you use blocking I/O. So, it is still necessary to adhere to the recommendations for using pure functions.
- So, **we justifiably abandon the following restrictions** in CTFE functions:
	- **No I/O or hardware access**: we sometimes need to do some network discovery, or query local IoT devices for its capabilities, in case we want to add new device into a group, and rebuild optimized firmware without unneeded options
	- 