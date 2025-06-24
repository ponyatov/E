# Core Paradigms

## **1. Actor Model (Erlang/Elixir Inspiration)**

- **Isolated Processes**
	- Each actor maintains private stack, heap, and resources
	- Per-process memory allocation (and optional garbage collection)
- **Message Passing**:
	- local: using shared memory and message-typed pointers
```evento
sensor read |> to_celsius |> send!(logger)
```
- **Let-It-Crash**:
	- Automatic supervisor hierarchies
- **Location Transparency**:
	- Same syntax for local/remote actors

```evento
actor Sensor {
  temp:f32 = 0.0

  on update { temp = i2c[TERMOMETER] |> to_celsius }

  on msg {
    match msg
    | $read         => reply! temp
    | $calibrate, t => temp = t
    | _             => fail! msg
  }
}
```

## **2. Ownership System (Rust Inspiration)**

- **Compile-Time Checks**: No GC, no dangling pointers
- **Simplified Borrowing**:

```evento
mut x = [0u8; 1024];  // Exclusive ownership
let y = &mut x;       // Mutable borrow
```
    
- **Static Lifetimes**
	- for hardware resources
	- for preallocated memory regions

- **Immutable-by-Default**:
```evento
let x = 5;    // Immutable
mut y = 10;   // Mutable
```    

## **3. Pattern Matching**:

```
match packet
| $temp t    if t > 60 => #forced_shutdown |> send! system
| $alert msg           => log!(msg)
| _                    => ignore()
```

## **4. Async Messaging and Functional Pipes**

- paren-less functions (F# Inspiration)
	- Unified Call Syntax allowed
	- functional polymorphism with Elixir-like guards


- **Pipe Operator**:
```evento
 sensor_data
      |> filter #valid
      |> map (convert_units #volts)
      |> #log
```
- Named pub/sub Channels
```evento
channel log  // referenced by #log
```
