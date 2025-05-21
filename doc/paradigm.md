# [[Evento]] language paradigm

When designing a **programming language for distributed programs on embedded systems (microcontrollers)**, the paradigm 
- should prioritize 
	- efficiency,
	- [[lang/reliability]], and 
	- low-resource constraints
- while supporting 
	- concurrency, 
	- fault tolerance, and 
	- direct hardware interaction. 

Here’s a breakdown of the ideal paradigm and features:

---

## **1. Primary Paradigm: Actor Model + Imperative**
- **Why?**  
  - **Actor Model**: Embeds *message-passing concurrency* natively, ideal for distributed systems (no shared memory, avoids locks).  
    - Example: [[Erlang]]/[[Elixir]] (but optimized for microcontrollers).  
  - **Imperative Core**: Close-to-hardware control (needed for registers, interrupts, and memory-mapped I/O).  
	  - no FFI: the most code and libs C-only, so we must use
	  - seamless interop with native C/C++ by C (Rust?) code generation

- **Implementation**:  
  - Each "[[Actor]]" is a lightweight process/task running independently.  
  - Messages are passed asynchronously (non-blocking).  
  - Built-in scheduler for cooperative multitasking (no [[RTOS/RTOS|RTOS]] needed).  

---

## **2. Secondary Paradigm: Event-Driven + Reactive**
- **Why?**  
  - Microcontrollers often respond to *external events* (sensor inputs, interrupts).  
  - Reactive programming simplifies event chains (e.g., `on_button_press → send_signal`).  

- **Implementation**:  
  - Syntax for event handlers (like Arduino’s `loop()` but language-native).  
  - Data[[flow variable]]s (automatically propagate changes).  

---

## **3. Key Language Features**  

### **A. Memory Safety Without GC**  
- **[[Rust/Rust|Rust]]-like [[Rust/ownership|ownership]] model**
	- no [[garbage collector]], 
	- no runtime overhead.  
- **Static allocation** (avoid heap fragmentation).  

### **B. Deterministic Real-Time Behavior**  
- **No dynamic memory allocation** (or opt-in only).  
- **Fixed-size types** (e.g., `int32`, `uint8`).  

### **C. Distributed Primitives**  
- **Message-passing syntax**:  
```rust
// Example: Send data to another node\
// ttl: time-to-live, timeout for message passing
// hops: numbers of resends in mesh network
send!(data, node_id, ttl=100ms, hops=4);
```
- **Built-in network stack** (LoRa, BLE, CAN bus abstractions). 
	- mesh networking

#### **D. Fault Tolerance**  
- **Supervision trees** (restart failed tasks, like Erlang).  
- **Atomic message delivery** (at-least-once or exactly-once semantics).  

#### **E. Hardware Abstraction**  
- **Register macros** (like embedded Rust’s `svd2rust`):  
  ```rust
  let gpio = GPIO::new(0x4000_0000); // Memory-mapped I/O
  gpio.write(HIGH);
  ```
- **Compile-time pin checking** (prevent invalid configurations).  

---

### **4. Example Language Syntax (Hypothetical)**  
```rust
// Distributed temperature monitor with pipe operators

const SERVER = MeshId(0x42)

actor SensorNode<S:TempSensor,P:Protocol> {
    let sensor      = S(P(PIN0));
    let server_addr = SERVER;

    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius()     // Preprocess
                |> round_to_decimal(1)    // Transform
                |> send!(server_addr);    // Action
            
            sleep!(1s);
        }
    }
}

actor ServerNode {
    on receive(data: f32) {
        data 
            |> format!("Temp: {:.1}C")   // Formatting
            |> print!();                 // Side effect
    }
}
```

---

### **5. Existing Languages to Borrow From**  
- **Rust**
	- [[memory safety]]
	- no [[gc/gc|gc]]
	- embedded-friendly
	- **aggressive type checking**
- **Erlang/Elixir**
	- **[[actor model]]**
	- fault tolerance
- **C**
	- **low-level control**
	- but lacks modern safety
- **Zig**
	- compile-time checks
	- manual memory

---

### **6. Toolchain Requirements**  
- **[[cross-compilation]] in the first place**
	- (e.g., [[arm-none-eabi]] backend).
	- on-host compilation is a degenerate case with `HOST=TARGET`
- **Hardware-in-the-loop testing**.  
- **Small runtime** (if any)
- [[FuSA]]

---

### **Conclusion**  
A **message-passing, memory-safe, event-driven language** with **zero-cost abstractions** would be ideal. Rust + Erlang’s best features, tailored for microcontrollers, would cover most needs.  
