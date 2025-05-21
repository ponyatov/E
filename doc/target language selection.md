# target language selection

Choosing between **C**, **C++**, or **Rust** as the **target language for a programming language translator** (e.g., a compiler or transpiler) depends on your priorities:

|**Criteria**|**[[C]]**|**[[C++]]**|**[[Rust]]**|
|---|---|---|---|
|**Performance**|🔥 Fast, no overhead|🔥 Fast, but some bloat|🔥 Fast, zero-cost abstractions|
|**Safety**|❌ Manual memory management|⚠️ Better than C, but still unsafe|✅ Memory-safe by default|
|**Tooling**|✅ Mature, ubiquitous|✅ Rich ([[LLVM]], [[STL]])|✅ Modern ([[cargo]], crates.io)|
|**Complexity**|✅ Simple, predictable|❌ Complex (templates, [[OOP]])|⚠️ Steeper learning curve|
|**Embedded Use**|✅ Dominates MCUs|⚠️ Possible (no RTTI/exceptions)|✅ Growing support ([[no_std]])|
|**Concurrency**|❌ Threads are painful|⚠️ Better with `std::thread`|✅ Fearless concurrency|
|**Output Size**|✅ Tiny binaries|⚠️ Larger (STL overhead)|⚠️ Larger (runtime checks)|

## **When to Choose Each:**

### **1. [[Cpp/C|C]] – Best for:**

- **[[bare-metal]] systems** ([[hw/microcontroller|microcontroller]]s, kernels).
    
- **Minimalist translators** (e.g., transpiling to ANSI C for max portability).
    
- **Legacy toolchains** (needs to work everywhere).
    

### **2. [[Cpp/C++|C++]] – Best for:**

- **High-level abstractions** (e.g., transpiling [[oop/OOP|OOP]] languages).
    
- **[[LLVM/LLVM|LLVM]]-based compilers** (rich optimization APIs).
    
- **Existing C++ tooling** (e.g., Clang libTooling).
    

### **3. [[Rust/Rust|Rust]] – Best for:**

- **Long-term maintenance** (no memory bugs).
    
- **Concurrent/parallel backends** (e.g., for distributed Evento).
    
- **Modern tooling** (Cargo > Make/CMake).

### **Recommendation:**

- **If targeting microcontrollers** → **[[Cpp/C|C]]** (widest support, no surprises with compatibility).
    
- **If safety/concurrency matters** → **[[Rust/Rust|Rust]]** (e.g., for a resilient distributed runtime or [[Safety-Critical System]]s).
    
- **If leveraging [[LLVM/LLVM|LLVM]]** → **[[Cpp/C++|C++]]** (best for optimizations).
