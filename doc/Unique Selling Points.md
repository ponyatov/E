# Unique Selling Points

### **1. Designed for Embedded, Not Adapted**

Unlike [[Python]] (too slow) or [[Rust/Rust|Rust]] (too complex for embedded), [[E/E|E]] is **built from the ground up** for microcontrollers and industrial use.

### **2. REPL for Firmware Development**

- **Interactive firmware debugging** (rare in embedded).
- **Modify running code** without full recompilation.
    
### **3. Cross-Compile First**

- **Single codebase → multiple architectures** (ARM, x86, RISC-V, ESP).
- No need for separate build systems.

### **4. Safety Without Overhead**

- **No hidden allocations** (unlike Go/Python).
- **Manual memory control** (like C) but with safe defaults.
    
### **5. Domain-Specific Advantages**

- **Bitfield manipulation** (for protocol stacks).
- **Binary pattern matching** (for sensor data parsing).
- **Real-time GC** (optional, for dynamic data).
