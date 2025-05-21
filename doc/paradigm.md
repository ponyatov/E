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
    - Example: Erlang/Elixir (but optimized for microcontrollers).  
  - **Imperative Core**: Close-to-hardware control (needed for registers, interrupts, and memory-mapped I/O).  
	  - no FFI: seamless interop with native C/C++ code as the most code and libs C-only

- **Implementation**:  
  - Each "actor" is a lightweight process/task running independently.  
  - Messages are passed asynchronously (non-blocking).  
  - Built-in scheduler for cooperative multitasking (no RTOS needed).  

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
// Distributed temperature monitor on microcontrollers
actor SensorNode {
    let sensor: TempSensor = TempSensor(PIN0);
    let server_addr: NodeId = 0x42;

    on init() {
        loop {
            let temp = sensor.read();
            send!(server_addr, temp);
            sleep!(1s);
        }
    }
}

actor ServerNode {
    on receive(data: f32) {
        print!("Temp: {}", data);
    }
}
```

---

### **5. Existing Languages to Borrow From**  
- **Rust** (memory safety, no GC, embedded-friendly).  
- **Erlang/Elixir** (actor model, fault tolerance).  
- **C** (low-level control, but lacks modern safety).  
- **Zig** (compile-time checks, manual memory).  

---

### **6. Toolchain Requirements**  
- **Cross-compilation** (e.g., `arm-none-eabi-gcc` backend).  
- **Hardware-in-the-loop testing**.  
- **Small runtime** (if any).  

---

### **Conclusion**  
A **message-passing, memory-safe, event-driven language** with **zero-cost abstractions** would be ideal. Rust + Erlang’s best features, tailored for microcontrollers, would cover most needs.  

Would you like help prototyping such a language? 😊
