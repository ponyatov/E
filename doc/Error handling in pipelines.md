# Error handling in [[lang/pipeline|pipelines]]

## **1. Explicit Error Propagation (Rust-Style)**

```rust
actor SensorNode {
    on init() {
        loop {
		sensor.read()
		|> scale_to_celsius()                    // Fallible op
		|> Result.map!(round_to_decimal(1))  
		|> Result.and_then!(send!(server_addr))  // Early return on error
		|> error!("Sensor failed");              // Handle leftovers
		
		sleep!(1s);
        }
    }
}
```

- **Operators**:
    - `Result.map!`: Transform success values.
    - `Result.and_then!`: Chain fallible operations.
    - `log_error!`: Swallow/log errors without crashing.

## **2. Short-Circuiting with `?`**

```rust
actor SensorNode {
    on init() {
        loop {
            try {
                sensor.read()
                    |> scale_to_celsius()?    // ? Aborts pipeline
                    |> round_to_decimal(1)?   //   on error
                    |> send!(server_addr)?;   
            } catch err {
				error!("Error: {}", err);
            };
            sleep!(1s);
        }
    }
}
```

- **Cleaner** but requires language support for `?` and `try/catch`.

## **3. Elixir-Style Pattern Matching**

```rust
actor SensorNode {
    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius() // -> Result
                |> match {
                    Ok(temp) ->
	                    temp
                        |> round_to_decimal(1) 
                        |> send!(server_addr),
                    Err(err) ->
	                    log!("Sensor error: {}", err)
                };
            sleep!(1s);
        }
    }
}
```
- [[Rust/Result|Result]] tagged union type:
	- `Ok(data)` wrapped data
	- `Err(e)`

## **4. Timeouts for Distributed Contexts**

```rust
actor SensorNode {
    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius()
                |> with_timeout!(500ms)  // Fail if stale
                |> try_send!(server_addr, retries=2)
                |> if_err!("Retries exhausted");
            
            sleep!(1s);
        }
    }
}
```

- `with_timeout!`: Prevent hangs.
- `try_send!`: Retry transient failures.

## **5. Embedded-Optimized (No Allocations)**

```rust
static buf: Buffer[16];                // pre-allocated buffer

actor SensorNode {
    on init() {
        loop {
            sensor.read()
                |> scale_to_celsius()
                |> Buffer.write!(buf)  // store intermediate state
                |> if_ok!(round_to_decimal(1, buf))
                |> if_ok!(send!(server_addr, buf));
            
            sleep!(1s);
        }
    }
}
```
- **Avoids heap** by reusing a static buffer.

## **Recommendations**

1. **For embedded**:
	- Use **explicit matching** (3)
	- or **alloc-free buffers** (5).
2. **For distributed**: Add **timeouts/retries** (4).
3. **For ergonomics**: Implement `?` (2) if possible.
